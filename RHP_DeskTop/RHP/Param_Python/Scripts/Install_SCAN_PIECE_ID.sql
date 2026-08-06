-- ============================================================================
-- Installation du traitement specifique SCAN_PIECE_ID
-- Scan / lecture de piece d'identite (CIN, Passeport, Carte de sejour)
-- -> Creation / mise a jour de l'agent (RH_Agent) avec extraction OCR / LLM
--
-- Pre-requis :
--   1. Param_General.chemin_python doit pointer sur le python embarque
--      (rsc\python\python.exe) ou tout python 3.x avec pyodbc.
--   2. Packages python : pillow, numpy, requests, opencv-python<5 (camera,
--      detection visage) et pytesseract (fallback OCR) + binaire Tesseract.
--      Le script tente une installation automatique des packages manquants.
--   3. Pour l'extraction par IA : configurer Ai_Agent avec un modele
--      MULTIMODAL (vision). Sinon le fallback OCR/MRZ est utilise.
--
-- Execution : menu RHP (PYT) ou bouton "Traitements specifiques" de l'ecran
-- RH_Agent (le matricule courant y est pre-rempli).
-- ============================================================================

-- 1. Script Python ------------------------------------------------------------
DELETE FROM Param_Python WHERE Cod_Python='SCAN_PIECE_ID'
INSERT INTO Param_Python (Cod_Python, Nom_Python, Text_Code, Actif, Typ_Python, withConn, Created_By, Dat_Crea)
VALUES ('SCAN_PIECE_ID', 'Scan piece d''identite (OCR/IA)', '# -*- coding: utf-8 -*-
# =============================================================================
# SCAN_PIECE_ID - Lecture d''une piece d''identite (CIN, Passeport, Carte sejour)
#                 et creation / mise a jour de l''agent (RH_Agent)
#
# Traitement specifique RHP (Param_Python, withConn = 1) :
#   - ''conn'' (pyodbc) est injecte automatiquement par l''environnement RHP.
#   - IDSOC     : id societe (argument, valeur par defaut GV_IDSOC)
#   - MATRICULE : matricule agent (optionnel, pre-rempli depuis l''ecran RH_Agent)
#
# Extraction des donnees (par ordre de fiabilite) :
#   1. LLM multimodele parametrage dans Ai_Agent (si le modele accepte les images)
#   2. Zone MRZ (Passeport TD3 / CIN electronique TD1) via Tesseract OCR
#   3. OCR generique Tesseract (heuristiques)
# =============================================================================
# Controle qualite (pylint lance par RHP a la sauvegarde) - desactivations
# justifiees pour ce script stocke en base et execute dans un environnement
# injecte (conn, IDSOC, MATRICULE) avec dependances optionnelles (cv2...) :
#   E1101 : cv2/PIL = extensions C, membres invisibles pour pylint (faux +)
#   E0401 : cv2/pytesseract importes paresseusement (installes a la volee)
#   W0718 : exceptions larges volontaires (robustesse traitement utilisateur)
#   W1510 : subprocess.run sans check (resultat non critique)
#   W0621 : redefinition voulue des imports paresseux (PIL/tkinter)
#   W0613 : argument evt impose par les bindings clavier tkinter
#   W0212 : acces interne volontaire a CameraPanel._cancel (annulation thread)
# pylint: disable=W0212
#   C0302/C0415/C0321/C0206 : conventions (script monofichier stocke en base)
#   R0914/R0915/R0912/R0913/R0917/R0902/R1702 : complexite acceptee (assistant IHM)
# pylint: disable=E1101,E0401,W0718,W1510,W0621,W0613,C0302,C0415,C0321,C0206
# pylint: disable=R0914,R0915,R0912,R0913,R0917,R0902,R1702
import io
import os
import re
import sys
import json
import base64
import threading
import subprocess
from datetime import datetime

import pyodbc  # fourni par l''environnement RHP
import tkinter as tk  # stdlib du python embarque RHP
# pillow est present dans le python embarque RHP (installe avec la plateforme)
from PIL import Image, ImageTk  # pylint: disable=E0401

# --- Variables injectees par l''environnement RHP ------------------------------
# conn      : connexion pyodbc (wrapper RHP, withConn=1)
# IDSOC     : id societe (argument, valeur par defaut GV_IDSOC)
# MATRICULE : matricule agent (optionnel, pre-rempli depuis l''ecran RH_Agent)
conn = globals().get("conn")
IDSOC = globals().get("IDSOC", "")
MATRICULE = globals().get("MATRICULE", "")

# --- Constantes paramétrables -------------------------------------------------
DD_TYP_PIECE = "TYP_PIECE_ID"      # Cod_Donnee : type de la piece
DD_EXPI_PIECE = "DATE_EXPI_PIECE"  # Cod_Donnee : date d''expiration de la piece
DD_NUM_PASS = "NUM_PASSEPORT"      # Cod_Donnee : n passeport
CREATED_BY = "SCAN_PIECE_ID"
MAX_IMG_DIM = 2000                 # redimensionnement avant envoi au LLM
JPEG_QUALITY = 85

TYPES_PIECE = [("CIN", "CIN"), ("PASSEPORT", "Passeport"), ("CARTE_SEJOUR", "Carte de sejour")]
TYPES_LIB = dict(TYPES_PIECE)
# types pour lesquels une 2e face est proposee (verso / page d''adresse du passeport)
TYPES_RECTO_VERSO = ("CIN", "CARTE_SEJOUR", "PASSEPORT")


def log(msg):
    """Trace dans la fenetre de resultat RHP."""
    print(str(msg), flush=True)


def parse_date_fr(txt):
    """''JJ/MM/AAAA'' (ou AAAA-MM-JJ) -> datetime ou None."""
    if not txt:
        return None
    txt = str(txt).strip()
    for fmt in ("%d/%m/%Y", "%Y-%m-%d", "%d-%m-%Y", "%d.%m.%Y"):
        try:
            return datetime.strptime(txt, fmt)
        except ValueError:
            pass
    m = re.search(r"(\d{2})\D(\d{2})\D(\d{4})", txt)
    if m:
        try:
            return datetime(int(m.group(3)), int(m.group(2)), int(m.group(1)))
        except ValueError:
            return None
    return None


def extract_json(txt):
    """Extrait le premier bloc JSON {...} d''une reponse LLM."""
    if not txt:
        return {}
    m = re.search(r"\{.*\}", txt, re.DOTALL)
    if not m:
        return {}
    try:
        return json.loads(m.group(0))
    except Exception:
        return {}


def norm_key(k):
    return re.sub(r"[^a-z]", "", str(k).lower())


def normalize_data(raw):
    """Normalise les cles du JSON extrait vers les cles internes : correspondance
       exacte d''abord, puis correspondance floue (fragments) pour les variantes
       inventees par le LLM (adresse_latine, numero_cin, date_exp...)."""
    mapping = {
        "nomlatin": "nom", "nom": "nom", "name": "nom", "surname": "nom", "lastname": "nom",
        "prenomlatin": "prenom", "prenom": "prenom", "firstname": "prenom", "givennames": "prenom",
        "datenaissance": "date_naissance", "birthdate": "date_naissance", "datedenaissance": "date_naissance",
        "lieunaissance": "lieu_naissance", "lieudenaissance": "lieu_naissance", "placeofbirth": "lieu_naissance",
        "numeropiece": "numero_piece", "numero": "numero_piece", "documentnumber": "numero_piece",
        "numerocin": "numero_piece", "cin": "numero_piece", "npiece": "numero_piece",
        "typepiece": "type_piece", "typedepiece": "type_piece", "documenttype": "type_piece",
        "adresse": "adresse", "address": "adresse", "adresselatine": "adresse",
        "adresselatin": "adresse", "adressetransliteree": "adresse",
        "adressecomplete": "adresse", "adresseetranslitteration": "adresse",
        "dateexpiration": "date_expiration", "expirydate": "date_expiration", "dateexpiry": "date_expiration",
        "sexe": "sexe", "sex": "sexe", "genre": "sexe",
        "nationalite": "nationalite", "nationality": "nationalite",
    }
    data = {}
    for k, v in (raw or {}).items():
        nk = mapping.get(norm_key(k))
        if nk and v is not None and str(v).strip() != "":
            data[nk] = str(v).strip()
    # repli : correspondance floue sur les cles non reconnues (ordre = priorite)
    fragments = [("expir", "date_expiration"), ("lieu", "lieu_naissance"),
                 ("place", "lieu_naissance"), ("naissance", "date_naissance"),
                 ("birth", "date_naissance"), ("prenom", "prenom"),
                 ("first", "prenom"), ("adress", "adresse"),
                 ("type", "type_piece"), ("numero", "numero_piece"),
                 ("number", "numero_piece"), ("piece", "numero_piece"),
                 ("cin", "numero_piece"), ("nom", "nom"),
                 ("sex", "sexe"), ("genre", "sexe"), ("national", "nationalite")]
    for k, v in (raw or {}).items():
        kk = norm_key(k)
        if mapping.get(kk) is not None or kk == "photobox":
            continue  # deja traite (ou zone photo geree a part)
        if v is None or str(v).strip() == "":
            continue
        for frag, dest in fragments:
            if frag in kk and dest not in data:
                data[dest] = str(v).strip()
                break
    return data


# =============================================================================
#  Gestion des dependances optionnelles (cv2 / tesseract)
# =============================================================================
_CV2 = [None]       # cache module cv2
_TESS = [None]      # cache module pytesseract


def import_cv2():
    """Import paresseux d''OpenCV, avec proposition d''installation automatique."""
    if _CV2[0] is not None:
        return _CV2[0]
    try:
        import cv2  # pylint: disable=E0401
        _CV2[0] = cv2
        return cv2
    except ImportError:
        pass
    log("OpenCV (cv2) absent : tentative d''installation automatique (pip install opencv-python<5)...")
    try:
        # opencv 5.x a supprime CascadeClassifier (detection de visage) : rester en 4.x
        subprocess.run([sys.executable, "-m", "pip", "install", "opencv-python<5"],
                       capture_output=True, timeout=600)
        import cv2  # pylint: disable=E0401
        _CV2[0] = cv2
        log("OpenCV installe avec succes.")
        return cv2
    except Exception as ex:
        log("Echec installation OpenCV : " + str(ex))
        log("Mode camera et detection automatique indisponibles. Le telechargement de fichier reste possible.")
        _CV2[0] = False
        return False


def import_tesseract():
    """Import paresseux de pytesseract + verification du binaire tesseract."""
    if _TESS[0] is not None:
        return _TESS[0]
    try:
        import pytesseract  # pylint: disable=E0401
    except ImportError:
        log("pytesseract absent : tentative d''installation automatique...")
        try:
            subprocess.run([sys.executable, "-m", "pip", "install", "pytesseract"],
                           capture_output=True, timeout=300)
            import pytesseract  # pylint: disable=E0401
        except Exception as ex:
            log("Echec installation pytesseract : " + str(ex))
            _TESS[0] = False
            return False
    # Localiser le binaire tesseract
    candidates = [r"C:\Program Files\Tesseract-OCR\tesseract.exe",
                  r"C:\Program Files (x86)\Tesseract-OCR\tesseract.exe"]
    ok = False
    for path in candidates:
        if os.path.exists(path):
            pytesseract.pytesseract.tesseract_cmd = path
            ok = True
            break
    if not ok:
        try:
            subprocess.run(["tesseract", "--version"], capture_output=True, timeout=10)
            ok = True
        except Exception:
            ok = False
    if not ok:
        log("Tesseract OCR non installe (binaire introuvable) : le fallback OCR sera indisponible.")
        log("  -> Installer Tesseract : https://github.com/UB-Mannheim/tesseract/wiki")
        _TESS[0] = False
        return False
    _TESS[0] = pytesseract
    return pytesseract


# =============================================================================
#  Helpers image
# =============================================================================
def pil_to_png_bytes(pil_img):
    buf = io.BytesIO()
    pil_img.convert("RGB").save(buf, format="PNG")
    return buf.getvalue()


def adapt_photo_frame(pil_img, fw=333, fh=252):
    """Adapte le portrait au cadre photo de la fiche agent (333 x 252 px,
       affichage CenterImage) : redimensionnement PROPORTIONNEL dans le cadre
       puis centrage sur fond clair (aucune deformation, aucun recadrage)."""
    if pil_img is None:
        return None
    img = pil_img.convert("RGB")
    ratio = min(fw / img.width, fh / img.height)
    nw = max(1, int(img.width * ratio))
    nh = max(1, int(img.height * ratio))
    img = img.resize((nw, nh), Image.LANCZOS)
    cadre = Image.new("RGB", (fw, fh), (245, 245, 245))  # WhiteSmoke comme la fiche
    cadre.paste(img, ((fw - nw) // 2, (fh - nh) // 2))
    return cadre


def pil_to_b64_jpeg(pil_img, max_dim=MAX_IMG_DIM):
    img = pil_img.convert("RGB")
    w, h = img.size
    if max(w, h) < 1400:
        # agrandir les petites captures (webcam) : le LLM lit mieux les petits textes
        ratio = 1400 / max(w, h)
        img = img.resize((int(w * ratio), int(h * ratio)), Image.LANCZOS)
    elif max(w, h) > max_dim:
        ratio = max_dim / max(w, h)
        img = img.resize((int(w * ratio), int(h * ratio)), Image.LANCZOS)
    buf = io.BytesIO()
    img.save(buf, format="JPEG", quality=JPEG_QUALITY)
    return base64.b64encode(buf.getvalue()).decode("ascii")


# =============================================================================
#  Detection / cadrage de la piece + extraction du portrait (OpenCV)
# =============================================================================
def order_points(pts):
    import numpy as np  # pylint: disable=E0401
    rect = np.zeros((4, 2), dtype="float32")
    s = pts.sum(axis=1)
    rect[0] = pts[np.argmin(s)]
    rect[2] = pts[np.argmax(s)]
    d = np.diff(pts, axis=1)
    rect[1] = pts[np.argmin(d)]
    rect[3] = pts[np.argmax(d)]
    return rect


def find_card_quad(cv2, img):
    """Retourne les 4 points du contour de la carte (image BGR) ou None."""
    import numpy as np  # pylint: disable=E0401
    h, w = img.shape[:2]
    ratio = 900.0 / max(h, w)
    small = cv2.resize(img, (int(w * ratio), int(h * ratio))) if ratio < 1 else img.copy()
    gray = cv2.cvtColor(small, cv2.COLOR_BGR2GRAY)
    gray = cv2.GaussianBlur(gray, (5, 5), 0)
    edged = cv2.Canny(gray, 50, 150)
    edged = cv2.dilate(edged, None, iterations=2)
    contours, _ = cv2.findContours(edged, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
    best = None
    best_area = 0
    for c in contours:
        peri = cv2.arcLength(c, True)
        approx = cv2.approxPolyDP(c, 0.02 * peri, True)
        area = cv2.contourArea(approx)
        if len(approx) == 4 and area > best_area and area > 0.15 * small.shape[0] * small.shape[1]:
            best = approx
            best_area = area
    if best is None:
        return None
    pts = best.reshape(4, 2).astype("float32") / (ratio if ratio < 1 else 1.0)
    return pts


def detect_and_crop_card(pil_img):
    """Detecte le contour de la piece et applique une correction de perspective.
       Retourne l''image cadree (PIL) ou l''image d''origine si non detectee."""
    cv2 = import_cv2()
    if not cv2:
        return pil_img
    import numpy as np  # pylint: disable=E0401
    try:
        img = cv2.cvtColor(np.array(pil_img.convert("RGB")), cv2.COLOR_RGB2BGR)
        pts = find_card_quad(cv2, img)
        if pts is None:
            return pil_img
        rect = order_points(pts)
        (tl, tr, br, bl) = rect
        width = int(max(np.linalg.norm(br - bl), np.linalg.norm(tr - tl)))
        height = int(max(np.linalg.norm(tr - br), np.linalg.norm(tl - bl)))
        if width < 100 or height < 100:
            return pil_img
        dst = np.array([[0, 0], [width - 1, 0], [width - 1, height - 1], [0, height - 1]], dtype="float32")
        m = cv2.getPerspectiveTransform(rect, dst)
        warped = cv2.warpPerspective(img, m, (width, height))
        return Image.fromarray(cv2.cvtColor(warped, cv2.COLOR_BGR2RGB))
    except Exception as ex:
        log("Detection automatique impossible : " + str(ex))
        return pil_img


def detect_faces(cv2, img):
    """Visages plausibles (taille/ratio) sur une image BGR : plusieurs cascades
       (haar + lbp) et variantes de contraste (CLAHE) pour les captures webcam."""
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    variantes = [gray]
    try:
        clahe = cv2.createCLAHE(clipLimit=2.0, tileGridSize=(8, 8))
        variantes.append(clahe.apply(gray))
    except Exception:
        pass
    W = gray.shape[1]
    trouve = []
    for cas in ("haarcascade_frontalface_default.xml",
                "haarcascade_frontalface_alt2.xml",
                "lbpcascade_frontalface_improved.xml",
                "lbpcascade_frontalface.xml"):
        cascade = cv2.CascadeClassifier(cv2.data.haarcascades + cas)
        if cascade.empty():
            continue
        for g in variantes:
            faces = cascade.detectMultiScale(g, scaleFactor=1.08,
                                             minNeighbors=4, minSize=(25, 25))
            for (x, y, w, h) in faces:
                rw = w / W
                aspect = h / max(w, 1)
                # filtrer les faux positifs : taille et ratio plausibles
                if 0.03 <= rw <= 0.50 and 0.6 <= aspect <= 1.7:  # pylint: disable=R1716
                    trouve.append((x, y, w, h))
        if trouve:
            break
    return trouve


def extract_face_photo(pil_img, photo_box=None):
    """Portrait du titulaire : 1) zone photo lue par l''IA (photo_box en % du recto),
       2) detection de visage (pleine image puis zone photo standard d''une carte
       ID-1), 3) la zone elle-meme en dernier recours."""
    cv2 = import_cv2()
    if not cv2:
        return None
    import numpy as np  # pylint: disable=E0401
    try:
        img = cv2.cvtColor(np.array(pil_img.convert("RGB")), cv2.COLOR_RGB2BGR)
        H, W = img.shape[:2]
        # 1) zone identifiee par l''IA
        if photo_box:
            try:
                bx0 = max(0, int(W * float(photo_box[0]) / 100))
                by0 = max(0, int(H * float(photo_box[1]) / 100))
                bx1 = min(W, int(W * float(photo_box[2]) / 100))
                by1 = min(H, int(H * float(photo_box[3]) / 100))
                if bx1 - bx0 > W * 0.04 and by1 - by0 > H * 0.04:
                    crop = img[by0:by1, bx0:bx1]
                    if crop.size:
                        log("Photo extraite via la zone identifiee par l''IA.")
                        return Image.fromarray(cv2.cvtColor(crop, cv2.COLOR_BGR2RGB))
            except (TypeError, ValueError, IndexError):
                pass
        # 2) detection de visage
        faces = detect_faces(cv2, img)
        zone = None
        if not faces:
            ratio = W / max(H, 1)
            if 1.3 <= ratio <= 1.9:
                zx0, zx1 = int(W * 0.03), int(W * 0.31)
                zy0, zy1 = int(H * 0.15), int(H * 0.90)
                zone = img[zy0:zy1, zx0:zx1]
                faces = detect_faces(cv2, zone)
                if faces:
                    log("Visage detecte dans la zone photo standard.")
        if faces:
            (x, y, w, h) = max(faces, key=lambda f: f[2] * f[3])
            src = zone if zone is not None else img
            # cadrage portrait serre : marges laterales + au-dessus de la tete
            mx = int(w * 0.40)
            my_haut = int(h * 0.55)
            my_bas = int(h * 0.50)
            x0, y0 = max(0, x - mx), max(0, y - my_haut)
            x1, y1 = min(src.shape[1], x + w + mx), min(src.shape[0], y + h + my_bas)
            crop = src[y0:y1, x0:x1]
            if crop.size:
                return Image.fromarray(cv2.cvtColor(crop, cv2.COLOR_BGR2RGB))
        if zone is not None and zone.size:
            log("Visage non detecte : zone photo standard utilisee telle quelle.")
            return Image.fromarray(cv2.cvtColor(zone, cv2.COLOR_BGR2RGB))
        return None
    except Exception as ex:
        log("Extraction du portrait impossible : " + str(ex))
        return None


# =============================================================================
#  Lecture MRZ (TD1 : CIN electronique / TD3 : Passeport)
# =============================================================================
def mrz_check_digit(field):
    weights = [7, 3, 1]
    total = 0
    for i, ch in enumerate(field):
        if ch.isdigit():
            v = int(ch)
        elif ch == "<":
            v = 0
        else:
            v = ord(ch) - 55  # A=10 ... Z=35
        total += v * weights[i % 3]
    return str(total % 10)


def mrz_date(yymmdd, kind):
    """Convertit une date MRZ (YYMMDD). Naissance : annee candidate la plus
       recente passee. Expiration : annee candidate la plus proche d''aujourd''hui."""
    try:
        yy, mm, dd = int(yymmdd[:2]), int(yymmdd[2:4]), int(yymmdd[4:6])
        now = datetime.now()
        cands = [datetime(c * 100 + yy, mm, dd) for c in (19, 20, 21)]
        if kind == "birth":
            past = [d for d in cands if d <= now]
            return max(past) if past else None
        return min(cands, key=lambda d: abs((d - now).days))
    except Exception:
        return None


def fmt_date(dt):
    return dt.strftime("%d/%m/%Y") if dt else ""


def parse_mrz_lines(lines):
    """Parse des lignes MRZ candidates -> dict de donnees (ou {})."""
    lines = [re.sub(r"[^A-Z0-9<]", "", l.upper()) for l in lines]
    lines = [l for l in lines if len(l) >= 28]
    data = {}
    # --- TD3 : 2 lignes de 44 (Passeport)
    for i in range(len(lines) - 1):
        l1 = (lines[i] + "<" * 44)[:44]
        l2 = (lines[i + 1] + "<" * 44)[:44]
        if not l1.startswith("P<") or len(lines[i + 1]) < 40:
            continue
        doc_num = l2[0:9].replace("<", "")
        try:
            if mrz_check_digit(l2[0:9]) != l2[9]:
                continue
            if mrz_check_digit(l2[13:19]) != l2[19]:
                continue
        except Exception:
            continue
        names = l1[5:44].split("<<")
        data["type_piece"] = "PASSEPORT"
        data["numero_piece"] = doc_num
        data["nom"] = names[0].replace("<", " ").strip()
        data["prenom"] = names[1].replace("<", " ").strip() if len(names) > 1 else ""
        data["nationalite"] = l2[10:13].replace("<", "")
        data["sexe"] = {"M": "H", "F": "F"}.get(l2[20], "")
        data["date_naissance"] = fmt_date(mrz_date(l2[13:19], "birth"))
        data["date_expiration"] = fmt_date(mrz_date(l2[21:27], "expiry"))
        return data
    # --- TD1 : 3 lignes de 30 (CIN electronique, verso)
    for i in range(len(lines) - 2):
        l1 = (lines[i] + "<" * 30)[:30]
        l2 = (lines[i + 1] + "<" * 30)[:30]
        l3 = (lines[i + 2] + "<" * 30)[:30]
        if len(lines[i]) < 28 or len(lines[i + 1]) < 28 or len(lines[i + 2]) < 28:
            continue
        if not re.match(r"^[A-Z]{1,2}<", l1) and not re.match(r"^[A-Z0-9]{2}", l1):
            continue
        try:
            if mrz_check_digit(l1[5:14]) != l1[14]:
                continue
            if mrz_check_digit(l2[0:6]) != l2[6]:
                continue
            if mrz_check_digit(l2[8:14]) != l2[14]:
                continue
        except Exception:
            continue
        doc_num = l1[5:14].replace("<", "")
        names = l3.split("<<")
        data["type_piece"] = "CIN"
        data["numero_piece"] = doc_num
        data["nom"] = names[0].replace("<", " ").strip()
        data["prenom"] = names[1].replace("<", " ").strip() if len(names) > 1 else ""
        data["nationalite"] = l2[15:18].replace("<", "")
        data["sexe"] = {"M": "H", "F": "F"}.get(l2[7], "")
        data["date_naissance"] = fmt_date(mrz_date(l2[0:6], "birth"))
        data["date_expiration"] = fmt_date(mrz_date(l2[8:14], "expiry"))
        return data
    return data


# =============================================================================
#  Extraction OCR (fallback) : MRZ puis heuristiques texte
# =============================================================================
DIGIT_FIX = {"O": "0", "Q": "0", "I": "1", "L": "1", "S": "5",
             "B": "8", "A": "4", "G": "6", "Z": "2", "T": "7"}


def clean_doc_number(token):
    """Nettoie un n de piece lu par OCR (confusions lettres/chiffres dans la
       partie numerique, ex. BKA23456 -> BK423456)."""
    token = re.sub(r"[^A-Z0-9]", "", str(token).upper())
    for n in (2, 1):
        if len(token) > n and token[:n].isalpha():
            fixed = "".join(DIGIT_FIX.get(ch, ch) for ch in token[n:])
            if fixed.isdigit() and 4 <= len(fixed) <= 7:
                return token[:n] + fixed
    return token


def norm_date_str(txt):
    return txt.replace("-", "/").replace(".", "/")


def ocr_extract(images):
    """Extraction par Tesseract : MRZ d''abord, puis heuristiques simples."""
    tess = import_tesseract()
    if not tess:
        return {}
    cv2 = import_cv2()
    import numpy as np  # pylint: disable=E0401
    data = {}
    full_text = ""
    for pil_img in images:
        if pil_img is None:
            continue
        # --- 1) tentative MRZ : bas de l''image, seuillage, whitelist MRZ
        try:
            arr = np.array(pil_img.convert("L"))
            h = arr.shape[0]
            zone = arr[int(h * 0.55):, :]
            zone = cv2.resize(zone, None, fx=2, fy=2) if cv2 else zone
            if cv2:
                _, zone = cv2.threshold(zone, 0, 255, cv2.THRESH_BINARY + cv2.THRESH_OTSU)
            cfg = "--psm 6 -c tessedit_char_whitelist=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789<"
            txt = tess.image_to_string(zone, lang="eng", config=cfg)
            lines = [l.strip() for l in txt.splitlines() if len(l.strip()) >= 28]
            if len(lines) >= 2:
                mrz = parse_mrz_lines(lines)
                if mrz:
                    log("Zone MRZ detectee et validee : " + mrz.get("numero_piece", ""))
                    data.update(mrz)
        except Exception as ex:
            log("OCR MRZ : " + str(ex))
        # --- 2) OCR texte complet (fra + ara si dispo)
        try:
            langs = "fra"
            try:
                avail = tess.get_languages()
                if "ara" in avail:
                    langs = "fra+ara"
            except Exception:
                pass
            full_text += "\n" + tess.image_to_string(pil_img, lang=langs)
        except Exception as ex:
            log("OCR texte : " + str(ex))
    # --- heuristiques sur le texte
    up = full_text.upper()
    pat_date = r"(\d{2}[./-]\d{2}[./-](?:19|20)\d{2})"
    dates = list(re.finditer(pat_date, up))
    if "date_naissance" not in data:
        m = re.search(r"\b(?:NE|NEE|NAISSANCE|BIRTH)\b[A-Z'' ]{0,15}" + pat_date, up)
        if m:
            data["date_naissance"] = norm_date_str(m.group(1))
        elif dates:
            data["date_naissance"] = norm_date_str(dates[0].group(1))
    if "date_expiration" not in data:
        m = re.search(r"\b(?:EXPIR|VALID|VALABLE|EXP|JUSQU)\b[A-Z'' ]{0,15}" + pat_date, up)
        if m:
            data["date_expiration"] = norm_date_str(m.group(1))
    if "numero_piece" not in data:
        m = re.search(r"\b(?:CIN|C\.I\.N|CARTE|SEJOUR|PASS)\b\s*[:\-]?\s*([A-Z0-9]{5,10})\b", up)
        if m:
            data["numero_piece"] = clean_doc_number(m.group(1))
        else:
            m = re.search(r"\b([A-Z]{1,2}\d{5,7})\b", up)  # pattern CIN marocaine
            if m:
                data["numero_piece"] = m.group(1)
    if "lieu_naissance" not in data and dates:
        m = re.search(pat_date + r"\s+A\s+([A-Z][A-Z'' \-]{2,30})", up)
        if m:
            data["lieu_naissance"] = m.group(1).strip().title()
    if "nom" not in data:
        m = re.search(r"\bNOM\b\s*[:\-]?\s*([A-Z][A-Z'' \-]{2,40})", up)
        if m:
            data["nom"] = m.group(1).strip()
    if "prenom" not in data:
        m = re.search(r"\bPRENOM\b\s*[:\-]?\s*([A-Z][A-Z'' \-]{2,40})", up)
        if m:
            data["prenom"] = m.group(1).strip()
    if "adresse" not in data:
        m = re.search(r"\bADRESSE\b\s*[:\-]?\s*([A-Z0-9][A-Z0-9'' ,\-]{4,90})", up)
        if m:
            data["adresse"] = m.group(1).strip()
    return data


# =============================================================================
#  Extraction par LLM multimodele (parametrage Ai_Agent)
# =============================================================================
def get_llm_config():
    """Lit la configuration LLM (table Ai_Agent) pour la societe courante."""
    cur = conn.cursor()
    sql = ("SELECT TOP 1 Provider, Modele, aiUrl, ApiKey FROM Ai_Agent "
           "WHERE ISNULL(NULLIF(id_Societe,-1), ?) = ? ORDER BY id_Societe")
    cur.execute(sql, (int(IDSOC), int(IDSOC)))
    row = cur.fetchone()
    if not row:
        return None
    provider = (row[0] or "").strip().upper()
    modele = (row[1] or "").split("|")[0].strip()
    url = (row[2] or "").replace("{MODEL}", modele)
    apikey = (row[3] or "").strip()
    if not url:
        return None
    return {"provider": provider, "modele": modele, "url": url, "apikey": apikey}


REGLES_TYPE = {
    "CIN": (
        "- numero_piece : imprime SOUS la photo d''identite (recto) ; format : 1 ou 2 lettres "
        "suivies de 5 a 6 chiffres (ex. BK123456) ; verifie chaque caractere (confusions "
        "0/O, 1/I, 5/S, 8/B).\n"
        "- date_expiration : en bas du recto, precedee de la mention ''valable jusqu''au''.\n"
        "- adresse : figure au VERSO de la carte. Si le verso n''est pas fourni, laisse vide.\n"),
    "CARTE_SEJOUR": (
        "- numero_piece : numero de la carte de sejour imprime sur le recto.\n"
        "- date_expiration : date de fin de validite imprimee sur la piece.\n"
        "- adresse : figure au VERSO de la carte. Si le verso n''est pas fourni, laisse vide.\n"),
    "PASSEPORT": (
        "- numero_piece : numero du passeport en haut a droite de la page d''identite et dans "
        "la zone MRZ en bas (1 ou 2 lettres + 6 a 7 chiffres).\n"
        "- date_expiration : ''Date d''expiration'' imprimee sur la page d''identite.\n"
        "- nationalite : imprimee sur la page d''identite (ex. MAROCAINE).\n"
        "- adresse : ABSENTE de la page d''identite ; elle figure sur une page SEPAREE "
        "(page domicile). Si cette page n''est pas fournie, LAISSE VIDE.\n"),
}

LLM_PROMPT_BASE = (
    "Tu lis une piece d''identite de type : {type_attendu} (recto{verso}). "
    "Extrais les informations et reponds UNIQUEMENT avec un objet JSON (sans commentaire, "
    "sans markdown) avec exactement ces cles :\n"
    ''{{"nom_latin": "", "prenom_latin": "", "date_naissance": "JJ/MM/AAAA", ''
    ''"lieu_naissance": "", "numero_piece": "", "type_piece": "CIN|PASSEPORT|CARTE_SEJOUR", ''
    ''"adresse": "", "date_expiration": "JJ/MM/AAAA", "sexe": "H|F", "nationalite": "", ''
    ''"photo_box": [0, 0, 0, 0]}}\n''
    "Regles strictes :\n"
    "- REGLE D''OR : ne recopie QUE ce qui est clairement LISIBLE sur l''image. N''invente, "
    "ne deduis, ne completes JAMAIS une valeur (par exemple ne deduis pas l''adresse a "
    "partir de la ville). Toute valeur non lisible = chaine vide.\n"
    "- nom et prenom en caracteres latins tels qu''imprimes (pas de traduction).\n"
    "- lieu_naissance : ville imprimee a cote de la date de naissance.\n"
    "- adresse : recopie-la fidelement en caracteres latins telle qu''imprimee ; si elle "
    "est en arabe, translittre-la phonetiquement.\n"
    "- photo_box : coordonnees [x0, y0, x1, y1] de la PHOTO D''IDENTITE imprimee sur le "
    "recto, en pourcentage (0-100) de la largeur/hauteur de l''image recto, sans inclure "
    "le reste de la carte.\n"
)


def build_prompt(type_attendu, verso_txt):
    """Prompt d''extraction differencie selon le type de piece (CIN/sejour vs passeport)."""
    regles = REGLES_TYPE.get(type_attendu, "")
    return (LLM_PROMPT_BASE.replace("{verso}", verso_txt)
                           .replace("{type_attendu}", type_attendu or "a identifier")
            + regles)


def llm_call_openai(cfg, b64_images, prompt):
    import requests  # pylint: disable=E0401
    content = [{"type": "text", "text": prompt}]
    for b64 in b64_images:
        content.append({"type": "image_url",
                        "image_url": {"url": "data:image/jpeg;base64," + b64}})
    payload = {"model": cfg["modele"],
               "messages": [{"role": "user", "content": content}],
               "temperature": 0}
    headers = {"Content-Type": "application/json"}
    if cfg["provider"] == "AZUREOPENAI":
        headers["api-key"] = cfg["apikey"]
    elif cfg["apikey"]:
        headers["Authorization"] = "Bearer " + cfg["apikey"]
    r = requests.post(cfg["url"], json=payload, headers=headers, timeout=90)
    r.raise_for_status()
    j = r.json()
    return j["choices"][0]["message"]["content"]


def llm_call_gemini(cfg, b64_images, prompt):
    import requests  # pylint: disable=E0401
    parts = [{"text": prompt}]
    for b64 in b64_images:
        parts.append({"inline_data": {"mime_type": "image/jpeg", "data": b64}})
    url = cfg["url"]
    if "key=" not in url and cfg["apikey"]:
        url += ("&" if "?" in url else "?") + "key=" + cfg["apikey"]
    r = requests.post(url, json={"contents": [{"parts": parts}]},
                      headers={"Content-Type": "application/json"}, timeout=90)
    r.raise_for_status()
    j = r.json()
    return j["candidates"][0]["content"]["parts"][0]["text"]


def llm_call_anthropic(cfg, b64_images, prompt):
    import requests  # pylint: disable=E0401
    content = []
    for b64 in b64_images:
        content.append({"type": "image",
                        "source": {"type": "base64", "media_type": "image/jpeg", "data": b64}})
    content.append({"type": "text", "text": prompt})
    payload = {"model": cfg["modele"], "max_tokens": 1024,
               "messages": [{"role": "user", "content": content}]}
    headers = {"Content-Type": "application/json", "x-api-key": cfg["apikey"],
               "anthropic-version": "2023-06-01"}
    r = requests.post(cfg["url"], json=payload, headers=headers, timeout=90)
    r.raise_for_status()
    j = r.json()
    return j["content"][0]["text"]


def llm_call_ollama(cfg, b64_images, prompt):
    import requests  # pylint: disable=E0401
    payload = {"model": cfg["modele"], "stream": False,
               "messages": [{"role": "user",
                             "content": prompt,
                             "images": b64_images}]}
    r = requests.post(cfg["url"], json=payload, timeout=120)
    r.raise_for_status()
    j = r.json()
    return j.get("message", {}).get("content", "")


def llm_extract(img_recto, img_verso, type_attendu=""):
    """Envoie les images au LLM parametrage. Retourne {} si indisponible/echec."""
    cfg = get_llm_config()
    if not cfg:
        log("Aucun LLM parametrage (Ai_Agent) : bascule sur OCR local.")
        return {}
    log("Extraction par LLM : " + cfg["provider"] + " / " + cfg["modele"])
    b64_images = [pil_to_b64_jpeg(img) for img in (img_recto, img_verso) if img is not None]
    verso_txt = " et verso" if len(b64_images) > 1 else ""
    prompt = build_prompt(type_attendu, verso_txt)
    try:
        if cfg["provider"] == "GEMINI":
            txt = llm_call_gemini(cfg, b64_images, prompt)
        elif cfg["provider"] == "ANTHROPIC":
            txt = llm_call_anthropic(cfg, b64_images, prompt)
        elif cfg["provider"] == "OLLAMA":
            txt = llm_call_ollama(cfg, b64_images, prompt)
        else:  # OPENAI, KIMI, MISTRAL, GROQ, OPENROUTER, AZUREOPENAI, ...
            txt = llm_call_openai(cfg, b64_images, prompt)
        log("Reponse LLM brute : " + str(txt)[:600])
        raw = extract_json(txt)
        data = normalize_data(raw)
        # zone de la photo d''identite (pourcentages du recto) : doit etre
        # portrait (h >= l) et raisonnablement petite, sinon on l''ignore
        box = raw.get("photo_box") if isinstance(raw, dict) else None
        if isinstance(box, (list, tuple)) and len(box) == 4:
            try:
                vals = [float(v) for v in box]
                bw = vals[2] - vals[0]
                bh = vals[3] - vals[1]
                if bw > 2 and bh > 2 and bh >= bw * 0.9 and bw <= 60:  # pylint: disable=R1716
                    data["photo_box"] = vals
            except (TypeError, ValueError):
                pass
        # seconde passe focalisee sur l''adresse (verso CIN / page domicile passeport)
        if not data.get("adresse") and img_verso is not None and len(b64_images) > 1:
            try:
                type_norm = "PASSEPORT" if "PASS" in (type_attendu or "").upper() else "CIN"
                adr = llm_extract_adresse(cfg, b64_images[1], type_norm)
                if adr:
                    data["adresse"] = adr
                    log("Adresse extraite (passe 2e image) : " + adr)
            except Exception as ex:
                log("Passe adresse : " + str(ex)[:200])
        if not data:
            log("Reponse LLM inexploitable : bascule sur OCR local.")
        return data
    except Exception as ex:
        log("Echec LLM (" + str(ex)[:300] + ") : bascule sur OCR local.")
        log("  -> Verifiez que le modele parametrage (Ai_Agent) est multimodal (accepte les images).")
        return {}


def llm_extract_adresse(cfg, b64_verso, type_piece=""):
    """Seconde passe focalisee : lire l''adresse sur la 2e image (verso CIN / page
       domicile du passeport), sans jamais inventer."""
    if type_piece == "PASSEPORT":
        contexte = ("Cette image est censee etre la PAGE DOMICILE d''un passeport marocain. "
                    "Si un domicile y est clairement imprime, recopie-le fidelement. "
                    "Si l''image ne montre pas de domicile (autre page, page d''identite...), "
                    "reponds une chaine vide.")
    else:
        contexte = ("Cette image est le VERSO d''une CIN ou carte de sejour marocaine. "
                    "Si une adresse y est clairement imprimee (en caracteres latins ou en "
                    "arabe), recopie-la fidelement en caracteres latins ; si elle est en "
                    "arabe, translittre-la phonetiquement (ex. ''حي الوفاء زنقة 5 المحمدية'' "
                    "-> ''HAY AL WAFAA ZANKA 5 MOHAMMEDIA''). Si aucune adresse n''y est "
                    "clairement lisible, reponds une chaine vide.")
    prompt_adr = (contexte + " REGLE D''OR : n''invente et ne deduis JAMAIS une adresse "
                  "(notamment a partir du nom de la ville). Reponds UNIQUEMENT avec un "
                  ''objet JSON : {"adresse": "..."}.'')
    if cfg["provider"] == "GEMINI":
        txt = llm_call_gemini(cfg, [b64_verso], prompt_adr)
    elif cfg["provider"] == "ANTHROPIC":
        txt = llm_call_anthropic(cfg, [b64_verso], prompt_adr)
    elif cfg["provider"] == "OLLAMA":
        txt = llm_call_ollama(cfg, [b64_verso], prompt_adr)
    else:
        txt = llm_call_openai(cfg, [b64_verso], prompt_adr)
    log("Reponse LLM (passe adresse) : " + str(txt)[:300])
    return normalize_data(extract_json(txt)).get("adresse", "")


# =============================================================================
#  Base de donnees : RH_Agent + Donnees diverses
# =============================================================================
def norm_txt(s):
    """Majuscules sans accents (pour les correspondances ville/pays)."""
    import unicodedata
    return "".join(c for c in unicodedata.normalize("NFKD", str(s or "").upper())
                   if not unicodedata.combining(c))


def find_cod_ville(texte, cod_pays):
    """Retourne le Cod_Ville (Param_Ville) correspondant au texte, ou ''''.
       Priorite : egalite exacte > prefixe > ville contenue dans le texte >
       texte contenu dans la ville (evite ''RABAT'' -> ''TEMARA -RABAT'')."""
    t = norm_txt(texte)
    if not t or not cod_pays:
        return ""
    cur = conn.cursor()
    cur.execute("SELECT Cod_Ville, Ville FROM Param_Ville WHERE Cod_Pays=?", (cod_pays,))
    best, best_score = "", -1
    for cod, ville in cur.fetchall():
        v = norm_txt(ville)
        if not v:
            continue
        score = -1
        if t == v:
            score = 1000
        elif v.startswith(t) or t.startswith(v):
            score = 500 + len(v)
        elif v in t:
            score = 400 + len(v)
        elif t in v:
            score = 100 + len(v)
        if score > best_score:
            best, best_score = cod, score
    return best


def find_cod_pays(txt):
    """Retourne le Cod_Pays (Param_Pays) correspondant a un libelle/code pays."""
    t = norm_txt(txt)
    if not t:
        return ""
    cur = conn.cursor()
    cur.execute("SELECT Cod_Pays, Pays, Cod_ISO FROM Param_Pays")
    for cod, pays, iso in cur.fetchall():
        p, i, c = norm_txt(pays), norm_txt(iso), norm_txt(cod)
        if t in (p, i, c) or (p and (t.startswith(p) or p.startswith(t))):
            return cod
    return ""





def find_agent(numero_piece, type_piece):
    """Recherche l''agent : matricule saisi, puis n piece. Retourne le matricule ou None."""
    cur = conn.cursor()
    mat = (MATRICULE or "").strip()
    if mat:
        cur.execute("SELECT Matricule FROM RH_Agent WHERE id_Societe=? AND Matricule=?", (int(IDSOC), mat))
        row = cur.fetchone()
        if row:
            return row[0]
    num = (numero_piece or "").strip()
    if num:
        if type_piece == "CARTE_SEJOUR":
            cur.execute("SELECT Matricule FROM RH_Agent WHERE id_Societe=? AND NumCE=?",
                        (int(IDSOC), num))
        elif type_piece == "PASSEPORT":
            cur.execute("SELECT Matricule FROM RH_Agent WHERE id_Societe=? AND NumPPR=?",
                        (int(IDSOC), num))
        else:
            cur.execute("SELECT Matricule FROM RH_Agent WHERE id_Societe=? AND CIN_Agent=?",
                        (int(IDSOC), num))
        row = cur.fetchone()
        if row:
            return row[0]
    return None


def next_matricule():
    """Genere systematiquement le prochain matricule via le compteur standard
       (Sys_Compteur), meme si Compteur_Auto est inactif pour la societe."""
    cur = conn.cursor()
    cur.execute("exec Sys_Compteur ''Agent'', ?", (int(IDSOC),))
    cur.execute("SELECT Last_Code FROM Param_Compteur WHERE Fichier=''Agent'' AND id_Societe=?",
                (int(IDSOC),))
    row = cur.fetchone()
    return row[0] if row and row[0] else None


def ensure_donnee_param(cod, text, typ):
    """Cree le Cod_Donnee dans le parametrage s''il n''existe pas pour la societe."""
    cur = conn.cursor()
    cur.execute("SELECT COUNT(*) FROM RH_Agent_Donnees_Diverses_Parametrage "
                "WHERE id_Societe=? AND Cod_Donnee=?", (int(IDSOC), cod))
    if cur.fetchone()[0] == 0:
        cur.execute("SELECT COUNT(*) FROM RH_Agent_Donnees_Diverses_Parametrage WHERE id_Societe=?",
                    (int(IDSOC),))
        rang = str(cur.fetchone()[0] + 1)
        cur.execute("INSERT INTO RH_Agent_Donnees_Diverses_Parametrage "
                    "(id_Societe, Cod_Donnee, Text_Donnee, Typ_Donnee, Rang) VALUES (?,?,?,?,?)",
                    (int(IDSOC), cod, text, typ, rang))


def upsert_donnee(matricule, cod, text, valeur):
    if valeur is None or str(valeur).strip() == "":
        return
    cur = conn.cursor()
    cur.execute("SELECT COUNT(*) FROM RH_Agent_Donnees_Diverses "
                "WHERE id_Societe=? AND Matricule=? AND Cod_Donnee=?",
                (int(IDSOC), matricule, cod))
    if cur.fetchone()[0] > 0:
        cur.execute("UPDATE RH_Agent_Donnees_Diverses SET Valeur_Donnee=? "
                    "WHERE id_Societe=? AND Matricule=? AND Cod_Donnee=?",
                    (str(valeur), int(IDSOC), matricule, cod))
    else:
        cur.execute("INSERT INTO RH_Agent_Donnees_Diverses "
                    "(id_Societe, Matricule, Cod_Donnee, Text_Donnee, Valeur_Donnee) VALUES (?,?,?,?,?)",
                    (int(IDSOC), matricule, cod, text, str(valeur)))


def save_agent(data, matricule, photo_png):
    """Cree ou met a jour RH_Agent. Retourne (matricule, ''CREATION''|''MISE_A_JOUR'')."""
    cur = conn.cursor()
    now = datetime.now()
    type_piece = (data.get("type_piece") or "CIN").upper()
    if "PASS" in type_piece:
        type_piece = "PASSEPORT"
    elif "SEJOUR" in type_piece or "RESID" in type_piece:
        type_piece = "CARTE_SEJOUR"
    else:
        type_piece = "CIN"
    num_col = {"CIN": "CIN_Agent", "CARTE_SEJOUR": "NumCE", "PASSEPORT": "NumPPR"}.get(type_piece)
    dat_nai = parse_date_fr(data.get("date_naissance"))
    existing = None
    if matricule:
        cur.execute("SELECT Matricule FROM RH_Agent WHERE id_Societe=? AND Matricule=?",
                    (int(IDSOC), matricule))
        existing = cur.fetchone()
    nom = (data.get("nom") or "").strip()
    prenom = (data.get("prenom") or "").strip()
    adresse = (data.get("adresse") or "").strip()
    numero = (data.get("numero_piece") or "").strip()
    sexe = (data.get("sexe") or "").strip().upper()[:1]
    civilite = {"H": "Mr", "F": "Mme"}.get(sexe)

    # --- Correspondances Param_Pays / Param_Ville (a l''enregistrement uniquement ;
    #     le recapitulatif affiche les valeurs fideles a la piece)
    cur.execute("SELECT Valeur FROM Param_General WHERE Cod_Param=''Cod_Pays''")
    row = cur.fetchone()
    pays_defaut = (row[0] if row else "") or ""
    nat_txt = (data.get("nationalite") or "").strip()
    if type_piece in ("CIN", "CARTE_SEJOUR"):
        cod_pays = pays_defaut
        nationalite = find_cod_pays(nat_txt) or pays_defaut
    else:
        cod_pays = find_cod_pays(nat_txt) or pays_defaut
        nationalite = cod_pays
    lieu_txt = (data.get("lieu_naissance") or "").strip()
    lieu_code = find_cod_ville(lieu_txt, cod_pays)
    lieu = lieu_code or lieu_txt[:50]  # code si correspondance, sinon texte fidele
    cod_ville = find_cod_ville(adresse, cod_pays) or lieu_code
    if lieu_code:
        log("Lieu de naissance -> code ville : " + lieu_code)
    if cod_ville:
        log("Ville -> code : " + cod_ville)

    if existing:  # ---------------- MISE A JOUR (champs non vides uniquement)
        sets, params = [], []
        if nom:
            sets.append("Nom_Agent=?"); params.append(nom)
        if prenom:
            sets.append("Prenom_Agent=?"); params.append(prenom)
        if dat_nai:
            sets.append("Dat_Naissance=?"); params.append(dat_nai)
        if lieu:
            sets.append("Lieu_Naissance=?"); params.append(lieu)
        if numero and num_col:
            sets.append(num_col + "=?"); params.append(numero)
        if adresse:
            sets.append("Adresse=?"); params.append(adresse)
        if nationalite:
            sets.append("Nationalite=?"); params.append(nationalite)
        if cod_pays:
            sets.append("Cod_Pays=?"); params.append(cod_pays)
        if cod_ville:
            sets.append("Cod_Ville=?"); params.append(cod_ville)
        if sexe:
            sets.append("Sexe=?"); params.append(sexe)
        if civilite:
            sets.append("Civilite=?"); params.append(civilite)
        if photo_png:
            sets.append("Photo=?"); params.append(pyodbc.Binary(photo_png))
        sets.append("Modified_By=?"); params.append(CREATED_BY)
        sets.append("Dat_Modif=?"); params.append(now)
        params.extend([int(IDSOC), matricule])
        cur.execute("UPDATE RH_Agent SET " + ", ".join(sets) +
                    " WHERE id_Societe=? AND Matricule=?", params)
        action = "MISE_A_JOUR"
    else:  # ---------------- CREATION
        if not matricule:
            matricule = next_matricule()
        if not matricule:
            raise ValueError("Matricule non renseigne et compteur automatique inactif : "
                             "saisissez un matricule dans l''ecran de recapitulatif.")
        cur.execute(
            "INSERT INTO RH_Agent (id_Societe, Matricule, Nom_Agent, Prenom_Agent, Sexe, Civilite, "
            "Dat_Naissance, Lieu_Naissance, CIN_Agent, NumCE, NumPPR, Adresse, Nationalite, Cod_Pays, "
            "Cod_Ville, Photo, Droit_Paie, Created_By, Dat_Crea) "
            "VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)",
            (int(IDSOC), matricule, nom, prenom, sexe or None, civilite,
             dat_nai, lieu or None,
             numero if type_piece == "CIN" else None,
             numero if type_piece == "CARTE_SEJOUR" else None,
             numero if type_piece == "PASSEPORT" else None,
             adresse or None, nationalite or None, cod_pays or None, cod_ville or None,
             pyodbc.Binary(photo_png) if photo_png else None,
             False, CREATED_BY, now))
        action = "CREATION"
    # ---------------- Donnees diverses : type piece / expiration
    ensure_donnee_param(DD_TYP_PIECE, "Type piece identite", "Alpha")
    ensure_donnee_param(DD_EXPI_PIECE, "Date expiration piece", "Dat")
    upsert_donnee(matricule, DD_TYP_PIECE, "Type piece identite", TYPES_LIB.get(type_piece, type_piece))
    upsert_donnee(matricule, DD_EXPI_PIECE, "Date expiration piece", data.get("date_expiration"))
    conn.commit()
    return matricule, action


# =============================================================================
#  Interface graphique (tkinter - design homogene, camera integree)
# =============================================================================
# Palette = theme RHP (Module_Declaration_Var.vb)
CLR_BG = "#EFF6F8"      # fond fenetre (colorBase04 allege)
CLR_CARD = "#ffffff"    # cartes
CLR_ACC = "#3899B9"     # colorBase01 : accent principal
CLR_ACC_D = "#2C7A94"   # colorBase01 fonce (survol)
CLR_ACC_L = "#D0E7EF"   # colorBase04 : accent clair (selection)
CLR_TXT = "#212529"     # texte
CLR_MUT = "#6c757d"     # texte attenue
CLR_OK = "#5EB975"      # colorBase02 : succes
CLR_OK_D = "#4CA465"    # colorBase02 fonce (survol)
CLR_ORG = "#F05A0A"     # colorBase03 : accent secondaire
CLR_BRD = "#C9DCE4"     # bordures (colorBase04 fonce)
FONT = "Segoe UI"


def flat_button(parent, text, command, bg, fg, hover, width=14):
    """Bouton plat homogene (meme style partout dans l''assistant)."""
    btn = tk.Button(parent, text=text, command=command, font=(FONT, 10),
                    bg=bg, fg=fg, activebackground=hover, activeforeground=fg,
                    relief="flat", bd=0, padx=16, pady=9, width=width,
                    cursor="hand2", highlightthickness=0)
    btn.bind("<Enter>", lambda e: btn.config(bg=hover))
    btn.bind("<Leave>", lambda e: btn.config(bg=bg))
    return btn


def primary_btn(parent, text, command, width=14):
    return flat_button(parent, text, command, CLR_ACC, "#ffffff", CLR_ACC_D, width)


def ok_btn(parent, text, command, width=14):
    return flat_button(parent, text, command, CLR_OK, "#ffffff", CLR_OK_D, width)


def outline_btn(parent, text, command, width=14):
    btn = tk.Button(parent, text=text, command=command, font=(FONT, 10),
                    bg=CLR_CARD, fg=CLR_TXT, activebackground="#e9ecef",
                    activeforeground=CLR_TXT, relief="flat", bd=0, padx=16,
                    pady=9, width=width, cursor="hand2",
                    highlightthickness=1, highlightbackground=CLR_BRD)
    btn.bind("<Enter>", lambda e: btn.config(bg="#e9ecef"))
    btn.bind("<Leave>", lambda e: btn.config(bg=CLR_CARD))
    return btn


class OptionGroup(tk.Frame):
    """Groupe de boutons homogenes a selection unique (switch button)."""

    def __init__(self, parent, options, default=None, width=18):
        super().__init__(parent, bg=CLR_CARD)
        self.var = default
        self._buttons = {}
        for value, label in options:
            btn = tk.Button(self, text=label, font=(FONT, 10), relief="flat",
                            bd=0, padx=14, pady=10, width=width, cursor="hand2",
                            highlightthickness=1, highlightbackground=CLR_BRD,
                            command=lambda v=value: self.select(v))
            btn.pack(side="left", padx=6, pady=4)
            self._buttons[value] = btn
        if default is not None:
            self.select(default)

    def select(self, value):
        self.var = value
        for v, btn in self._buttons.items():
            if v == value:
                btn.config(bg=CLR_ACC, fg="#ffffff",
                           activebackground=CLR_ACC_D, activeforeground="#ffffff",
                           highlightbackground=CLR_ACC)
            else:
                btn.config(bg=CLR_CARD, fg=CLR_TXT,
                           activebackground="#e9ecef", activeforeground=CLR_TXT,
                           highlightbackground=CLR_BRD)

    def get(self):
        return self.var


def guide_rect(w, h):
    """Rectangle de cadrage au ratio carte ID-1 (85,6 x 53,98 mm)."""
    cw = int(w * 0.78)
    ch = int(cw / 1.586)
    if ch > h * 0.85:
        ch = int(h * 0.85)
        cw = int(ch * 1.586)
    x0, y0 = (w - cw) // 2, (h - ch) // 2
    return x0, y0, x0 + cw, y0 + ch


class CameraPanel:
    """Apercu camera integre a la fenetre, avec cadre de cadrage."""

    def __init__(self, parent, dw=660, dh=400):
        self.cv2 = None
        self.cap = None
        self.raw = None
        self.dw, self.dh = dw, dh
        self._job = None
        self._tkimg = None
        self._cancel = False
        self._black_count = 0
        self._black_warned = False
        self.auto_capture = True       # capture auto quand l''image est stable
        self.on_auto = None            # callback declenche par l''auto-capture
        self._prev_small = None
        self._stable_count = 0
        self.err = ""
        self.frame = tk.Frame(parent, bg="#101418",
                              highlightthickness=1, highlightbackground=CLR_BRD)
        self.label = tk.Label(self.frame, bg="#101418", bd=0)
        self.label.pack(fill="both", expand=True)

    def open(self):
        """Essaie plusieurs backends/index. Retourne True des qu''une lecture
           valide arrive (certaines cameras mettent 1-2 s a demarrer ; la
           resolution n''est imposee qu''apres la 1re image pour eviter les
           echecs de negociation driver). Peut tourner dans un thread."""
        cv2 = import_cv2()
        if not cv2:
            self.err = "OpenCV (cv2) n''est pas disponible."
            return False
        self.cv2 = cv2
        try:  # reduire le bruit des warnings videoio sur stderr
            cv2.utils.logging.setLogLevel(cv2.utils.logging.LOG_LEVEL_ERROR)
        except Exception:
            try:
                cv2.setLogLevel(2)
            except Exception:
                pass
        import time as _time
        essais = []
        ouvert = False
        for backend in (cv2.CAP_DSHOW, cv2.CAP_MSMF):
            for idx in (0, 1):
                if self._cancel:
                    return False
                cap = None
                try:
                    cap = cv2.VideoCapture(idx, backend)
                    try:
                        cap.set(cv2.CAP_PROP_OPEN_TIMEOUT_MSEC, 2500)
                        cap.set(cv2.CAP_PROP_READ_TIMEOUT_MSEC, 1200)
                    except Exception:
                        pass
                    if not cap.isOpened():
                        continue
                    ouvert = True
                    ok, fr = False, None
                    debut = _time.time()
                    while _time.time() - debut < 4.0 and not self._cancel:
                        ok, fr = cap.read()
                        if ok and fr is not None:
                            break
                        _time.sleep(0.15)
                    if ok and fr is not None:
                        if self._cancel:
                            cap.release()
                            return False
                        try:  # reglages best-effort APRES la 1re image
                            cap.set(cv2.CAP_PROP_FRAME_WIDTH, 1280)
                            cap.set(cv2.CAP_PROP_FRAME_HEIGHT, 720)
                            cap.set(cv2.CAP_PROP_BUFFERSIZE, 1)
                        except Exception:
                            pass
                        self.cap = cap
                        log("Camera ouverte : index " + str(idx) + ", backend " + str(backend))
                        return True
                    essais.append("camera " + str(idx) + " : ouverte mais aucune image recue")
                    cap.release()
                except Exception as ex:
                    essais.append("camera " + str(idx) + " : " + str(ex))
                    if cap is not None:
                        try:
                            cap.release()
                        except Exception:
                            pass
        if ouvert:
            self.err = ("Camera detectee mais aucune image recue : elle est probablement "
                        "utilisee par une autre application (" + "; ".join(essais[:2]) + ")")
        else:
            self.err = "Aucune camera detectee sur ce poste."
        log(self.err)
        return False

    def start(self):
        self._tick()

    def _tick(self):
        if self.cap is None:
            return
        cv2 = self.cv2
        try:
            ok, fr = self.cap.read()
            if ok and fr is not None:
                self.raw = fr
                # detection d''un flux noir persistant (cache physique, antivirus,
                # mode confidentialite constructeur...)
                if fr.mean() < 3:
                    self._black_count += 1
                else:
                    self._black_count = 0
                h, w = fr.shape[:2]
                x0, y0, x1, y1 = guide_rect(w, h)
                # auto-capture : carte detectee dans le cadre + image nette et stable
                if self.auto_capture and self.on_auto is not None:
                    try:
                        petit = cv2.resize(cv2.cvtColor(fr, cv2.COLOR_BGR2GRAY), (160, 120))
                        zone_grise = cv2.cvtColor(fr[y0:y1, x0:x1], cv2.COLOR_BGR2GRAY)
                        nettete = cv2.Laplacian(zone_grise, cv2.CV_64F).var()
                        stable = (self._prev_small is not None and
                                  cv2.absdiff(petit, self._prev_small).mean() < 2.5)
                        self._prev_small = petit
                        carte = find_card_quad(cv2, fr) is not None
                        texture = zone_grise.std() > 25  # contenu non uniforme dans le cadre
                        if stable and (carte or texture) and nettete > 50:
                            self._stable_count += 1
                        else:
                            self._stable_count = 0
                        if self._stable_count >= 20:  # ~0,6 s stable
                            self._stable_count = 0
                            cb, self.on_auto = self.on_auto, None
                            if cb is not None:
                                self.frame.after(0, cb)
                                self._job = self.frame.after(30, self._tick)
                                return
                    except Exception:
                        pass
                disp = cv2.resize(fr, (self.dw, self.dh))
                sx, sy = self.dw / w, self.dh / h
                dx0, dy0, dx1, dy1 = (int(x0 * sx), int(y0 * sy),
                                      int(x1 * sx), int(y1 * sy))
                overlay = disp.copy()
                cv2.rectangle(overlay, (0, 0), (self.dw, self.dh), (10, 14, 20), -1)
                overlay[dy0:dy1, dx0:dx1] = disp[dy0:dy1, dx0:dx1]
                disp = cv2.addWeighted(overlay, 0.55, disp, 0.45, 0)
                couleur_cadre = (117, 185, 94) if self._stable_count < 5 else (200, 240, 200)
                cv2.rectangle(disp, (dx0, dy0), (dx1, dy1), couleur_cadre, 2)
                if self._stable_count >= 5:
                    cv2.putText(disp, "Image stable : capture automatique...",
                                (dx0, max(25, dy0 - 12)), cv2.FONT_HERSHEY_SIMPLEX,
                                0.6, (200, 240, 200), 2)
                if self._black_count > 90:  # ~3 s de noir continu
                    lignes = ["FLUX NOIR : l''image n''arrive pas.",
                              "Verifiez le cache physique de la camera (ThinkShutter),",
                              "le mode confidentialite (Lenovo Vantage) ou la",
                              "protection webcam de l''antivirus (ex. Kaspersky)."]
                    yy = 40
                    for lg in lignes:
                        cv2.putText(disp, lg, (16, yy), cv2.FONT_HERSHEY_SIMPLEX, 0.55,
                                    (80, 80, 240), 2)
                        yy += 26
                    if not self._black_warned:
                        self._black_warned = True
                        log("Flux camera noir persistant : verifier cache physique, "
                            "mode confidentialite ou protection webcam de l''antivirus.")
                cv2.putText(disp, "Placez la piece dans le cadre - ESPACE pour capturer",
                            (12, self.dh - 12), cv2.FONT_HERSHEY_SIMPLEX, 0.5,
                            (255, 255, 255), 1)
                img = Image.fromarray(cv2.cvtColor(disp, cv2.COLOR_BGR2RGB))
                self._tkimg = ImageTk.PhotoImage(img)
                self.label.config(image=self._tkimg)
        except Exception:
            pass
        self._job = self.frame.after(30, self._tick)

    def capture(self):
        """Retourne l''image PIL cadree (zone guide + detection de contour)."""
        if self.raw is None or self.cv2 is None:
            return None
        h, w = self.raw.shape[:2]
        x0, y0, x1, y1 = guide_rect(w, h)
        crop = self.raw[y0:y1, x0:x1].copy()
        pil = Image.fromarray(self.cv2.cvtColor(crop, self.cv2.COLOR_BGR2RGB))
        return detect_and_crop_card(pil)

    def stop(self):
        self._cancel = True
        if self._job is not None:
            try:
                self.frame.after_cancel(self._job)
            except Exception:
                pass
            self._job = None
        if self.cap is not None:
            try:
                self.cap.release()
            except Exception:
                pass
            self.cap = None


class CropDialog(tk.Toplevel):
    """Recadrage manuel : l''utilisateur dessine un rectangle a la souris puis valide.
       result contient l''image PIL recadree (ou None si annule)."""

    def __init__(self, parent, pil_img, titre):
        super().__init__(parent)
        self.title(titre)
        self.configure(bg=CLR_BG)
        self.transient(parent)
        self.result = None
        self.img = pil_img.convert("RGB")
        self.max_w, self.max_h = 780, 460
        tk.Label(self, text="Dessinez un rectangle sur la zone a garder, puis validez.",
                 font=(FONT, 9), bg=CLR_BG, fg=CLR_MUT).pack(anchor="w", padx=12, pady=(10, 0))
        self.canvas = tk.Canvas(self, highlightthickness=1,
                                highlightbackground=CLR_BRD, cursor="cross")
        self.canvas.pack(padx=12, pady=10)
        self.rect = None
        self.start = None
        self.end = None
        self._tkimg = None
        self.canvas.bind("<ButtonPress-1>", self._down)
        self.canvas.bind("<B1-Motion>", self._move)
        self.canvas.bind("<ButtonRelease-1>", self._up)
        self._render()
        btns = tk.Frame(self, bg=CLR_BG)
        btns.pack(pady=(0, 12))
        outline_btn(btns, "Rot. 90", self._rotate, width=10).pack(side="left", padx=6)
        outline_btn(btns, "Reinitialiser", self._reset, width=13).pack(side="left", padx=6)
        outline_btn(btns, "Annuler", self.destroy, width=12).pack(side="left", padx=6)
        ok_btn(btns, "Valider le cadrage", self._ok, width=18).pack(side="left", padx=6)
        self.update_idletasks()
        try:  # centrer sur la fenetre parente
            x = parent.winfo_rootx() + max(0, (parent.winfo_width() - self.winfo_width()) // 2)
            y = parent.winfo_rooty() + max(0, (parent.winfo_height() - self.winfo_height()) // 2)
            self.geometry("+" + str(x) + "+" + str(y))
        except Exception:
            pass
        self.grab_set()

    def _render(self):
        """(Re)affiche l''image dans le canvas (apres rotation)."""
        self.scale = min(self.max_w / self.img.width, self.max_h / self.img.height, 1.0)
        if self.scale < 1:
            self.disp = self.img.resize((int(self.img.width * self.scale),
                                         int(self.img.height * self.scale)), Image.LANCZOS)
        else:
            self.disp = self.img
        self.canvas.config(width=self.disp.width, height=self.disp.height)
        self.canvas.delete("all")
        self._tkimg = ImageTk.PhotoImage(self.disp)
        self.canvas.create_image(0, 0, anchor="nw", image=self._tkimg)
        self.rect = None
        self.start = None
        self.end = None

    def _rotate(self):
        self.img = self.img.rotate(-90, expand=True)
        self._render()

    def _down(self, evt):
        self.start = (evt.x, evt.y)
        self.end = None
        if self.rect is not None:
            self.canvas.delete(self.rect)
            self.rect = None

    def _move(self, evt):
        if self.start is None:
            return
        if self.rect is not None:
            self.canvas.delete(self.rect)
        self.rect = self.canvas.create_rectangle(self.start[0], self.start[1],
                                                 evt.x, evt.y, outline=CLR_ACC, width=2)
        self.end = (evt.x, evt.y)

    def _up(self, evt):
        self.end = (evt.x, evt.y)

    def _reset(self):
        self.start = None
        self.end = None
        if self.rect is not None:
            self.canvas.delete(self.rect)
            self.rect = None

    def _ok(self):
        if self.start is not None and self.end is not None:
            x0, x1 = sorted((self.start[0], self.end[0]))
            y0, y1 = sorted((self.start[1], self.end[1]))
            if x1 - x0 > 20 and y1 - y0 > 20:
                self.result = self.img.crop((int(x0 / self.scale), int(y0 / self.scale),
                                             int(x1 / self.scale), int(y1 / self.scale)))
        self.destroy()


def run_ui():
    """Assistant : source/type -> recto -> verso -> extraction -> recap -> save."""
    from tkinter import filedialog, messagebox, ttk

    # rendre l''application consciente du DPI Windows : dimensions exactes et
    # police nette meme avec un mise a l''echelle > 100%
    try:
        from ctypes import windll
        windll.shcore.SetProcessDpiAwareness(1)
    except Exception:
        pass

    state = {"source": "camera", "type": "CIN", "etape": 1,
             "recto": None, "verso": None, "data": {}, "photo": None}
    cam = {"panel": None}
    preview_refs = {"img": None}

    root = tk.Tk()
    root.title("RHP - Lecture de piece d''identite")
    root.configure(bg=CLR_BG)
    try:
        # adapter le rendu au DPI reel de l''ecran (evite le contenu tronque
        # ou flou avec une mise a l''echelle Windows > 100%)
        dpi = root.winfo_fpixels("1i")
        root.tk.call("tk", "scaling", dpi / 72.0)
    except Exception:
        pass
    root.geometry("920x700")
    root.update_idletasks()
    try:
        # centrer sur l''ecran PRIMAIRE (taille physique via API Windows,
        # independant du multi-ecrans et du DPI)
        sw = windll.user32.GetSystemMetrics(0)
        sh = windll.user32.GetSystemMetrics(1)
        x = max(0, (sw - root.winfo_width()) // 2)
        y = max(0, (sh - root.winfo_height()) // 2)
        root.geometry("+" + str(x) + "+" + str(y))
    except Exception:
        pass

    # ---------------- bandeau titre ----------------
    header = tk.Frame(root, bg=CLR_ACC, height=56)
    header.pack(fill="x")
    header.pack_propagate(False)
    tk.Label(header, text="Lecture de piece d''identite", font=(FONT, 13, "bold"),
             bg=CLR_ACC, fg="#ffffff").pack(side="left", padx=20)
    step_lbl = tk.Label(header, text="", font=(FONT, 10),
                        bg=CLR_ACC, fg="#dbe7ff")
    step_lbl.pack(side="right", padx=20)

    # ordre de pack critique : les elements "bottom" d''abord, le corps (expand)
    # en dernier pour qu''il n''accapare pas toute la hauteur
    status = tk.Label(root, text="", font=(FONT, 9), bg=CLR_BG, fg=CLR_MUT, anchor="w")
    status.pack(fill="x", side="bottom", padx=24)

    footer = tk.Frame(root, bg=CLR_BG, height=64)
    footer.pack(fill="x", side="bottom")
    footer.pack_propagate(False)

    body = tk.Frame(root, bg=CLR_BG)
    body.pack(fill="both", expand=True, padx=24, pady=16)

    def set_status(msg):
        status.config(text=msg or "")
        if msg:
            log(msg)

    def stop_camera():
        if cam["panel"] is not None:
            cam["panel"].stop()
            cam["panel"] = None

    def on_close():
        stop_camera()
        root.destroy()

    root.protocol("WM_DELETE_WINDOW", on_close)

    def clear():
        stop_camera()
        root.unbind("<space>")
        for wdg in body.winfo_children():
            wdg.destroy()
        for wdg in footer.winfo_children():
            wdg.destroy()

    def card(parent, titre):
        cadre = tk.Frame(parent, bg=CLR_CARD, highlightthickness=1,
                         highlightbackground=CLR_BRD)
        tk.Label(cadre, text=titre, font=(FONT, 10, "bold"), bg=CLR_CARD,
                 fg=CLR_MUT).pack(anchor="w", padx=14, pady=(10, 2))
        return cadre

    def show_preview(parent, pil_img, max_w=680, max_h=360):
        img = pil_img.copy()
        img.thumbnail((max_w, max_h), Image.LANCZOS)
        tkimg = ImageTk.PhotoImage(img)
        lbl = tk.Label(parent, image=tkimg, bg=CLR_CARD,
                       highlightthickness=1, highlightbackground=CLR_BRD)
        lbl.image = tkimg
        preview_refs["img"] = tkimg
        return lbl

    def next_after(cote):
        """Enchainement apres validation d''un cote."""
        if cote == "recto" and state["type"] in TYPES_RECTO_VERSO:
            show_step(3)
        elif cote == "recto":
            show_step(4)
        else:
            show_step(4)

    # ---------------------------------------------------------- etape 1
    def step1():
        clear()
        step_lbl.config(text="Etape 1")
        tk.Label(body, text="Source et type de la piece", font=(FONT, 14, "bold"),
                 bg=CLR_BG, fg=CLR_TXT).pack(anchor="w", pady=(0, 14))

        c1 = card(body, "SOURCE")
        c1.pack(fill="x", pady=6)
        grp_src = OptionGroup(c1, [("camera", "Camera"), ("fichier", "Telecharger une piece")],
                              default=state["source"], width=22)
        grp_src.pack(padx=10, pady=(0, 10))

        c2 = card(body, "TYPE DE LA PIECE D''IDENTITE")
        c2.pack(fill="x", pady=6)
        grp_typ = OptionGroup(c2, TYPES_PIECE, default=state["type"], width=16)
        grp_typ.pack(padx=10, pady=(0, 10))

        def go():
            state["source"] = grp_src.get()
            state["type"] = grp_typ.get()
            show_step(2)

        primary_btn(footer, "Continuer", go, width=18).pack(side="right", padx=24, pady=12)

    # ---------------------------------------------------------- etapes 2 et 3
    def step_capture(cote):
        clear()
        if cote == "verso" and state["type"] == "PASSEPORT":
            titre_cote = "Page d''adresse - Passeport"
        else:
            titre_cote = ("Recto" if cote == "recto" else "Verso") + " - " + TYPES_LIB[state["type"]]
        step_lbl.config(text="Etape " + ("2" if cote == "recto" else "3"))
        tk.Label(body, text=titre_cote, font=(FONT, 14, "bold"),
                 bg=CLR_BG, fg=CLR_TXT).pack(anchor="w", pady=(0, 10))
        holder = tk.Frame(body, bg=CLR_BG)
        holder.pack(fill="both", expand=True)

        def back():
            show_step(1 if cote == "recto" else 3)

        def confirm(pil_img):
            for wdg in holder.winfo_children():
                wdg.destroy()
            for wdg in footer.winfo_children():
                wdg.destroy()
            root.unbind("<space>")
            stop_camera()
            show_preview(holder, pil_img).pack(pady=6)
            set_status("Verifiez le cadrage de l''image puis validez.")

            def valider():
                state[cote] = pil_img
                set_status("")
                next_after(cote)

            def recadrer():
                dlg = CropDialog(root, pil_img, "Recadrer l''image - " + cote)
                root.wait_window(dlg)
                if dlg.result is not None:
                    confirm(dlg.result)

            def rotation(angle):
                confirm(pil_img.rotate(angle, expand=True))

            outline_btn(footer, "Reprendre", lambda: step_capture(cote),
                        width=13).pack(side="left", padx=20, pady=12)
            outline_btn(footer, "Recadrer", recadrer,
                        width=12).pack(side="left", padx=4, pady=12)
            outline_btn(footer, "Rot. -90", lambda: rotation(-90),
                        width=10).pack(side="left", padx=4, pady=12)
            outline_btn(footer, "Rot. +90", lambda: rotation(90),
                        width=10).pack(side="left", padx=4, pady=12)
            primary_btn(footer, "Utiliser cette image", valider,
                        width=18).pack(side="right", padx=20, pady=12)

        def from_file():
            path = filedialog.askopenfilename(
                title="Choisir l''image du " + cote, parent=root,
                filetypes=[("Images", "*.jpg *.jpeg *.png *.bmp *.tif *.tiff"),
                           ("Tous", "*.*")])
            if not path:
                return
            try:
                img = Image.open(path)
                img.load()
                confirm(detect_and_crop_card(img.convert("RGB")))
            except Exception as ex:
                set_status("Image illisible : " + str(ex))

        if state["source"] == "camera":
            panel = CameraPanel(holder)
            panel.frame.pack(pady=6)
            cam["panel"] = panel
            wait_lbl = tk.Label(holder, text="Connexion a la camera...",
                                font=(FONT, 10), bg=CLR_BG, fg=CLR_MUT)
            wait_lbl.pack(pady=4)
            outline_btn(footer, "Retour", back, width=14).pack(side="left", padx=24, pady=12)
            set_status("Connexion a la camera (peut prendre quelques secondes)...")
            root.config(cursor="watch")
            done = {"ok": None}

            def open_work():
                done["ok"] = panel.open()

            def poll_open():
                if done["ok"] is None:
                    if not panel._cancel:
                        root.after(150, poll_open)
                    return
                root.config(cursor="")
                if done["ok"]:
                    wait_lbl.destroy()
                    panel.start()

                    def do_capture(evt=None):
                        img = panel.capture()
                        if img is None:
                            set_status("Capture impossible : pas d''image camera.")
                            return
                        confirm(img)

                    panel.on_auto = do_capture
                    auto_var = tk.BooleanVar(value=True)
                    tk.Checkbutton(holder, text="Capture automatique quand la piece est "
                                                "stable dans le cadre",
                                   variable=auto_var, font=(FONT, 9), bg=CLR_BG,
                                   fg=CLR_TXT, activebackground=CLR_BG,
                                   selectcolor=CLR_CARD,
                                   command=lambda: setattr(panel, "auto_capture",
                                                           auto_var.get())).pack(anchor="w", pady=(0, 4))
                    primary_btn(footer, "Capturer", do_capture,
                                width=18).pack(side="right", padx=24, pady=12)
                    root.bind("<space>", do_capture)
                    set_status("Camera active : cadrez la piece puis ESPACE ou ''Capturer'' "
                               "(capture auto activee).")
                else:
                    stop_camera()
                    for wdg in holder.winfo_children():
                        wdg.destroy()
                    tk.Label(holder, text="Camera indisponible", font=(FONT, 12, "bold"),
                             bg=CLR_BG, fg=CLR_TXT).pack(pady=(30, 6))
                    tk.Label(holder, text=panel.err, font=(FONT, 9), bg=CLR_BG,
                             fg=CLR_MUT, wraplength=640, justify="center").pack(pady=4)
                    tk.Label(holder, text="Verifiez le branchement, fermez les applications utilisant "
                                          "la camera (Teams, Zoom, navigateur...), verifiez les autorisations "
                                          "Windows (Parametres > Confidentialite > Camera), "
                                          "ou choisissez un fichier image.",
                             font=(FONT, 10), bg=CLR_BG, fg=CLR_MUT, wraplength=640,
                             justify="center").pack(pady=4)

                    def use_file():
                        state["source"] = "fichier"
                        step_capture(cote)

                    primary_btn(footer, "Choisir un fichier", use_file,
                                width=18).pack(side="right", padx=24, pady=12)
                    set_status("Camera indisponible.")

            threading.Thread(target=open_work, daemon=True).start()
            root.after(150, poll_open)
        else:
            box = tk.Frame(holder, bg=CLR_BG)
            box.pack(expand=True, pady=40)
            primary_btn(box, "Parcourir...", from_file, width=20).pack()
            tk.Label(box, text="Formats acceptes : JPG, PNG, BMP, TIFF",
                     font=(FONT, 9), bg=CLR_BG, fg=CLR_MUT).pack(pady=8)
            outline_btn(footer, "Retour", back, width=14).pack(side="left", padx=24, pady=12)

    def step3():
        clear()
        step_lbl.config(text="Etape 3")
        if state["type"] == "PASSEPORT":
            lib_face = "la page d''adresse du passeport"
        else:
            lib_face = "le verso de la piece"
        tk.Label(body, text=("Page d''adresse - Passeport" if state["type"] == "PASSEPORT"
                             else "Verso de la piece (" + TYPES_LIB[state["type"]] + ")"),
                 font=(FONT, 14, "bold"), bg=CLR_BG, fg=CLR_TXT).pack(anchor="w", pady=(0, 10))
        tk.Label(body, text="Le recto a ete capture. Chargez maintenant " + lib_face +
                            " (adresse) ou passez cette etape.",
                 font=(FONT, 10), bg=CLR_BG, fg=CLR_MUT, wraplength=820,
                 justify="left").pack(anchor="w", pady=(0, 10))
        c = card(body, "SOURCE")
        c.pack(fill="x", pady=6)
        grp = OptionGroup(c, [("camera", "Camera"), ("fichier", "Telecharger")],
                          default=state["source"], width=22)
        grp.pack(padx=10, pady=(0, 10))

        def go():
            state["source"] = grp.get()
            show_step(3.5)

        outline_btn(footer, "Retour", lambda: show_step(2), width=14).pack(side="left", padx=24, pady=12)
        outline_btn(footer, "Passer (pas de verso)", lambda: show_step(4),
                    width=20).pack(side="left", padx=6, pady=12)
        primary_btn(footer, "Continuer", go, width=18).pack(side="right", padx=24, pady=12)

    # ---------------------------------------------------------- etape 4
    def step4():
        clear()
        step_lbl.config(text="Etape 4")
        tk.Label(body, text="Extraction des donnees", font=(FONT, 14, "bold"),
                 bg=CLR_BG, fg=CLR_TXT).pack(anchor="w", pady=(0, 14))
        lbl = tk.Label(body, text="Analyse des images en cours, veuillez patienter...",
                       font=(FONT, 10), bg=CLR_BG, fg=CLR_MUT)
        lbl.pack(anchor="w", pady=8)
        style = ttk.Style()
        style.configure("Acc.Horizontal.TProgressbar", background=CLR_ACC,
                        troughcolor=CLR_BRD, bordercolor=CLR_BRD)
        bar = ttk.Progressbar(body, mode="indeterminate", length=500,
                              style="Acc.Horizontal.TProgressbar")
        bar.pack(anchor="w", pady=10)
        bar.start(12)
        done = {"ok": False}

        def work():
            try:
                data = llm_extract(state["recto"], state["verso"],
                                   TYPES_LIB.get(state["type"], ""))
                if not data:
                    data = ocr_extract([state["recto"], state["verso"]])
                    state["engine"] = "OCR" if data else "AUCUN"
                else:
                    extra = ocr_extract([state["recto"], state["verso"]])
                    for k, v in extra.items():
                        if k not in data or not data[k]:
                            data[k] = v
                    state["engine"] = "LLM"
                # le type choisi par l''utilisateur prime sur la lecture du LLM
                if state["type"]:
                    data["type_piece"] = state["type"]
                # garde-fou anti-hallucination : une "adresse" qui se resume a la
                # ville (deduite, non lue) est ignoree
                adr = (data.get("adresse") or "").strip()
                ville_txt = (data.get("lieu_naissance") or "").strip()
                if adr and ville_txt:
                    reste = norm_txt(adr).replace(norm_txt(ville_txt), "").strip(" -,")
                    if len(reste) < 8:
                        log("Adresse ignoree (semble deduite de la ville, non lue) : " + adr)
                        data["adresse"] = ""
                # validation/normalisation du n de piece (CIN : 1-2 lettres + 4-7 chiffres)
                if data.get("type_piece") == "CIN" and data.get("numero_piece"):
                    avant = data["numero_piece"]
                    data["numero_piece"] = clean_doc_number(avant)
                    if not re.match(r"^[A-Z]{1,2}\d{4,7}$", data["numero_piece"]):
                        log("N de piece lu de facon incertaine : " + avant +
                            " (verifiez-le dans le recapitulatif)")
                state["data"] = data
                state["photo"] = adapt_photo_frame(
                    extract_face_photo(state["recto"], data.get("photo_box")))
            except Exception as ex:
                log("Erreur extraction : " + str(ex))
                state["data"] = {}
                state["engine"] = "AUCUN"
                state["photo"] = None
            finally:
                done["ok"] = True

        def poll():
            # le thread ne touche jamais tkinter : on scrute son drapeau
            if done["ok"]:
                bar.stop()
                show_step(5)
            else:
                root.after(200, poll)

        threading.Thread(target=work, daemon=True).start()
        root.after(200, poll)

    # ---------------------------------------------------------- etape 5
    def step5():
        clear()
        step_lbl.config(text="Etape 5")
        tk.Label(body, text="Verification et enregistrement", font=(FONT, 14, "bold"),
                 bg=CLR_BG, fg=CLR_TXT).pack(anchor="w", pady=(0, 6))
        if state.get("engine") == "LLM":
            tk.Label(body, text="Donnees extraites par IA (modele multimodal). Verifiez avant d''enregistrer. "
                                "Les correspondances ville/pays (Param_Ville/Param_Pays) sont resolues a "
                                "l''enregistrement.",
                     font=(FONT, 9), bg=CLR_BG, fg=CLR_MUT, wraplength=820,
                     justify="left").pack(anchor="w", pady=(0, 4))
        else:
            tk.Label(body, text="Extraction partielle (OCR local" +
                                (", aucune donnee trouvee" if state.get("engine") == "AUCUN" else "") +
                                "). Pour une extraction complete par IA, configurez un modele "
                                "multimodal (vision) dans Ai_Agent (Assistant IA).",
                     font=(FONT, 9), bg=CLR_BG, fg=CLR_ORG, wraplength=820,
                     justify="left").pack(anchor="w", pady=(0, 4))
        if state["type"] in TYPES_RECTO_VERSO and state["verso"] is None:
            tk.Label(body, text="Note : le verso n''a pas ete capture - l''adresse ne peut pas "
                                "etre extraite (elle figure au verso de la piece).",
                     font=(FONT, 9), bg=CLR_BG, fg=CLR_ORG, wraplength=820,
                     justify="left").pack(anchor="w", pady=(0, 4))
        corps = tk.Frame(body, bg=CLR_BG)
        corps.pack(fill="both", expand=True)
        form = tk.Frame(corps, bg=CLR_BG)
        form.pack(side="left", fill="both", expand=True)
        data = state["data"]
        entries = {}
        champs = [("nom", "Nom (latin)", 1), ("prenom", "Prenom (latin)", 1),
                  ("date_naissance", "Date de naissance (JJ/MM/AAAA)", 1),
                  ("lieu_naissance", "Lieu de naissance", 1),
                  ("numero_piece", "N de la piece", 1),
                  ("type_piece", "Type (CIN/PASSEPORT/CARTE_SEJOUR)", 1),
                  ("adresse", "Adresse", 2),
                  ("date_expiration", "Date d''expiration (JJ/MM/AAAA)", 1),
                  ("sexe", "Sexe (H/F)", 1),
                  ("nationalite", "Nationalite", 1),
                  ("matricule", "Matricule (vide = nouveau/compteur)", 1)]
        vals = dict(data)
        vals["matricule"] = (MATRICULE or
                             find_agent(data.get("numero_piece"), data.get("type_piece")) or "")
        row = 0
        col = 0
        for cle, lib, span in champs:
            cell = tk.Frame(form, bg=CLR_BG)
            cell.grid(row=row, column=col, columnspan=span, sticky="w", padx=(0, 18), pady=3)
            tk.Label(cell, text=lib, font=(FONT, 8), bg=CLR_BG, fg=CLR_MUT).pack(anchor="w")
            ent = tk.Entry(cell, font=(FONT, 10), bg=CLR_CARD, fg=CLR_TXT, relief="flat",
                           highlightthickness=1, highlightbackground=CLR_BRD,
                           highlightcolor=CLR_ACC, width=34 if span == 1 else 72)
            ent.pack(anchor="w", ipady=3)
            ent.insert(0, vals.get(cle, "") or "")
            entries[cle] = ent
            col += span
            if col >= 2:
                col = 0
                row += 1
        # apercu photo
        pnl = tk.Frame(corps, bg=CLR_CARD, highlightthickness=1, highlightbackground=CLR_BRD)
        pnl.pack(side="right", padx=10, fill="y")
        tk.Label(pnl, text="PHOTO", font=(FONT, 8, "bold"), bg=CLR_CARD,
                 fg=CLR_MUT).pack(pady=(8, 2))
        lbl_img = tk.Label(pnl, bg=CLR_CARD)
        lbl_img.pack(padx=8, pady=4)

        def refresh_photo():
            if state["photo"] is not None:
                img = state["photo"].copy()
                img.thumbnail((150, 190), Image.LANCZOS)
                tkimg = ImageTk.PhotoImage(img)
                lbl_img.config(image=tkimg, text="")
                lbl_img.image = tkimg
                preview_refs["img"] = tkimg
            else:
                lbl_img.config(image="", text="(non detectee)",
                               font=(FONT, 9), fg=CLR_MUT)
                lbl_img.image = None

        refresh_photo()
        save_photo_var = tk.BooleanVar(value=state["photo"] is not None)
        tk.Checkbutton(pnl, text="Enregistrer la photo", variable=save_photo_var,
                       font=(FONT, 9), bg=CLR_CARD, fg=CLR_TXT,
                       activebackground=CLR_CARD, selectcolor=CLR_CARD).pack(pady=2)

        def recadrer_photo():
            src = state["recto"]
            if src is None:
                return
            dlg = CropDialog(root, src, "Recadrer la photo (zone du portrait)")
            root.wait_window(dlg)
            if dlg.result is not None:
                state["photo"] = dlg.result
                save_photo_var.set(True)
                refresh_photo()

        outline_btn(pnl, "Recadrer", recadrer_photo, width=12).pack(pady=(2, 8))

        def do_save():
            try:
                for cle in ("date_naissance", "date_expiration"):
                    val = entries[cle].get().strip()
                    if val and not parse_date_fr(val):
                        raise ValueError("Date invalide : " + val + " (format JJ/MM/AAAA)")
                data2 = {cle: entries[cle].get().strip() for cle in entries if cle != "matricule"}
                photo_png = None
                if state["photo"] is not None and save_photo_var.get():
                    # adapte au cadre de la fiche (proportions conservees)
                    photo_png = pil_to_png_bytes(adapt_photo_frame(state["photo"]))
                mat, action = save_agent(data2, entries["matricule"].get().strip(), photo_png)
                log("Agent " + mat + " : " + action + " effectuee.")
                # marqueur lu par RHP pour rafraichir automatiquement la fiche agent
                log("AGENT_ENREGISTRE:" + mat)
                messagebox.showinfo("RHP", "Agent " + mat + " " +
                                    ("cree" if action == "CREATION" else "mis a jour") +
                                    " avec succes.", parent=root)
                root.destroy()
            except Exception as ex:
                log("ERREUR enregistrement : " + str(ex))
                set_status("Erreur : " + str(ex))
                messagebox.showerror("Erreur", str(ex), parent=root)

        outline_btn(footer, "Annuler", on_close, width=14).pack(side="left", padx=24, pady=12)
        ok_btn(footer, "Enregistrer", do_save, width=18).pack(side="right", padx=24, pady=12)

    # ---------------------------------------------------------- routeur
    def show_step(n):
        state["etape"] = n
        if n == 1:
            step1()
        elif n == 2:
            step_capture("recto")
        elif n == 3:
            step3()
        elif n == 3.5:
            step_capture("verso")
        elif n == 4:
            step4()
        elif n == 5:
            step5()

    show_step(1)
    root.mainloop()


# =============================================================================
#  Mode test (SCAN_TEST=1) : valide les fonctions sans interface graphique
# =============================================================================
def self_test():
    log("=== SELF TEST SCAN_PIECE_ID ===")
    # dates
    assert parse_date_fr("12/05/1990") == datetime(1990, 5, 12)
    assert parse_date_fr("1990-05-12") == datetime(1990, 5, 12)
    assert parse_date_fr("abc") is None
    # MRZ TD3 (specimen ONU)
    l1 = "P<UTOERIKSSON<<ANNA<MARIA<<<<<<<<<<<<<<<<<<<"
    l2 = "L898902C36UTO7408122F1204159ZE184226B<<<<<10"
    d = parse_mrz_lines([l1, l2])
    assert d.get("numero_piece") == "L898902C3", d
    assert d.get("nom") == "ERIKSSON", d
    assert d.get("prenom") == "ANNA MARIA", d
    assert d.get("date_naissance") == "12/08/1974", d
    assert d.get("date_expiration") == "15/04/2012", d
    assert d.get("sexe") == "F", d
    # MRZ TD1 (specimen)
    t1 = "I<UTOD231458907<<<<<<<<<<<<<<<"
    t2 = "7408122F1204159UTO<<<<<<<<<<<6"
    t3 = "ERIKSSON<<ANNA<MARIA<<<<<<<<<<"
    d = parse_mrz_lines([t1, t2, t3])
    assert d.get("numero_piece") == "D23145890", d
    assert d.get("nom") == "ERIKSSON", d
    assert d.get("type_piece") == "CIN", d
    # JSON / normalisation
    d = normalize_data(extract_json(''blah {"Nom_Latin": "ALAOUI", "Prenom_Latin": "Sara", ''
                                  ''"Date_Naissance": "01/02/1990"} fin''))
    assert d.get("nom") == "ALAOUI" and d.get("prenom") == "Sara", d
    # connexion + config LLM
    try:
        cfg = get_llm_config()
        log("Config LLM : " + (str(cfg["provider"] + "/" + cfg["modele"]) if cfg else "absente"))
    except Exception as ex:
        log("Config LLM non lue : " + str(ex))
    # compteur
    try:
        cur = conn.cursor()
        cur.execute("SELECT COUNT(*) FROM RH_Agent WHERE id_Societe=?", (int(IDSOC),))
        log("Agents societe " + str(IDSOC) + " : " + str(cur.fetchone()[0]))
    except Exception as ex:
        log("Lecture RH_Agent : " + str(ex))
    log("=== SELF TEST OK ===")


# =============================================================================
if os.environ.get("SCAN_TEST") == "1":
    self_test()
else:
    run_ui()
', 1, 'U', 1, 'INSTALL', GETDATE())
GO

-- 2. Arguments ----------------------------------------------------------------
DELETE FROM Param_Python_Arguments WHERE Cod_Python='SCAN_PIECE_ID'
INSERT INTO Param_Python_Arguments (Cod_Python, Argument, Lib_Argument, Typ_Critere, Default_Value, Rang)
VALUES ('SCAN_PIECE_ID', 'IDSOC', 'Id societe', 'int', 'GV_IDSOC', '1')
INSERT INTO Param_Python_Arguments (Cod_Python, Argument, Lib_Argument, Typ_Critere, Default_Value, Rang)
VALUES ('SCAN_PIECE_ID', 'MATRICULE', 'Matricule agent (vide = nouveau)', 'varchar', '', '2')
GO

-- 3. Entree menu --------------------------------------------------------------
DELETE FROM Controle_Menu WHERE Name_Ecran='SCAN_PIECE_ID' AND Typ_Ecran='PYT'
INSERT INTO Controle_Menu (Name_Ecran, Text_Ecran, Typ_Ecran, Image1)
VALUES ('SCAN_PIECE_ID', 'Scan piece d''identite (OCR/IA)', 'PYT', 'ud_Pyhton')
GO

-- 4. Traitement specifique rattache a l'ecran RH_Agent ------------------------
-- (la vue Sys_Def_Ecran_Traitements_Specifiques est alimentee automatiquement
--  par Param_Python : aucun insert a faire dans la vue)
DELETE FROM Controle_Def_Ecran_Traitements_Specifiques WHERE Cod_Traitement='SCAN_PIECE_ID'
INSERT INTO Controle_Def_Ecran_Traitements_Specifiques (Name_Ecran, Cod_Traitement, Typ_Traitement, Relation, Rang)
VALUES ('RH_Agent', 'SCAN_PIECE_ID', 'PYT', 'MATRICULE:=Matricule_Text', '90')
GO

-- 5. Droits (par defaut : profil Admin uniquement) ----------------------------
-- Decommenter pour rendre le traitement visible par tous les profils actifs :
-- INSERT INTO Controle_Droit (Name_Ecran, Cod_Profile, Visible, Actif)
-- SELECT 'SCAN_PIECE_ID', p.Cod_Profile, 1, 1
-- FROM Controle_Profile p
-- WHERE ISNULL(p.Actif,1)=1
--   AND NOT EXISTS (SELECT 1 FROM Controle_Droit d
--                   WHERE d.Name_Ecran='SCAN_PIECE_ID' AND d.Cod_Profile=p.Cod_Profile)
-- GO