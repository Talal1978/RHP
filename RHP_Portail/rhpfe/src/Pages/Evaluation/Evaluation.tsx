import { useCallback, useContext, useEffect, useRef } from 'react'
import { Typography, Paper, Grid, Box } from '@mui/material';
import Survey_Rendering from '../Survey/Survey_Rendering'
import { colorBase } from '../../modules/module_general';
import { useLocation, useNavigate } from 'react-router-dom';
import { cntX } from '../../Menu/MenuMain';
import { DrawOutlined, PrintOutlined, SaveAsOutlined } from '@mui/icons-material';
import { ChildHandle } from '../Survey/Types';
import useAlert from '../../hooks/useAlert';
import { TReport } from '../../Report/ReportViewer';

type TState = {
  cod_survey: string;
  cod_evaluation: string;
  lib_evaluation: string;
  cod_reply: number;
  evalue: string;
  nom_evalue: string;
  evaluateur: string;
  nom_evaluateur: string;
  typ_survey: "E";
}

const Evaluation = () => {
  const myRef = useRef<ChildHandle>(null);
  const location = useLocation();
  const navigate = useNavigate();
  const alert = useAlert();
  const { settbnMenu, setSignatureProps, setShowSignature } = useContext(cntX);

  const state = location.state as TState;

  useEffect(() => {
    if (!state) {
      navigate('/myspace/Evaluation_Liste/Consultation des évaluations');
    }
  }, [state, navigate]);



  const { cod_survey, cod_evaluation, lib_evaluation, cod_reply, evalue, nom_evalue, evaluateur, nom_evaluateur, typ_survey } = state || {} as any;

  const Enregistrer = useCallback(async () => {
    if (myRef.current) {
      const rsl = await myRef.current.save();
      console.log(rsl);
      if (rsl.result) {
        alert({
          titre: "Enregistrement",
          msg: "Enregistré avec succès",
          typMsg: "success",
          timeOut: 3000,
        });
      } else {
        alert({
          titre: "Enregistrement",
          msg:  rsl.data && rsl.data.length > 0 ? rsl.data[0] : "Enregistrement echoué",
          typMsg: "error",
          timeOut: 3000,
        });
      }
    }
  }, [alert]);

  const Imprimer = useCallback(() => {
    window.print();
  }, []);

  const SoumettreEnSignature = useCallback(() => {
    setSignatureProps({ typ_document: "EV", valeur_index: cod_evaluation });
    setShowSignature(true);
  }, [setSignatureProps, setShowSignature, cod_evaluation]);

  useEffect(() => {
    settbnMenu([
      {
        name: "Enregistrer",
        disabled: false,
        libelle: "Enregistrer",
        action: Enregistrer,
        icon: <SaveAsOutlined />,
      },
      {
        name: "Imprimer",
        disabled: false,
        libelle: "Imprimer",
        action: Imprimer,
        icon: <PrintOutlined />,
      },
      {
        name: "Signer",
        disabled: false,
        libelle: "Signer",
        action: SoumettreEnSignature,
        icon: <DrawOutlined />,
      }
    ]);

    return () => {
      settbnMenu([]);
    };
  }, [settbnMenu, Enregistrer, Imprimer, SoumettreEnSignature]);

  if (!state) return null;

  return (
    <div className="evaluation-container">
      <style>
        {`
          @media print {
            body * {
              visibility: hidden;
            }
            .evaluation-container, .evaluation-container * {
              visibility: visible;
            }
            .evaluation-container {
              position: absolute;
              left: 0;
              top: 0;
              width: 100%;
              margin: 0;
              padding: 0 !important;
              background-color: white;
            }
            /* Hide buttons or other UI elements if they have specific classes, mostly strictly hiding parents */
            .MuiDrawer-root, .MuiAppBar-root, header, nav, .menu-container {
               display: none !important;
            }
          }
        `}
      </style>
      <Typography variant="h4" sx={{ textAlign: 'center', mb: 2, fontWeight: 'bold', color: colorBase.colorBase01 }}>
        Évaluation
      </Typography>

      <Box sx={{
        p: 3,
        width: '100%',
        bgcolor: "var(--bg-input)",
        color: "var(--fore-color-base-01)",
        border: "1px solid #e0e0e0",
        marginBottom: '10px'
      }}>
        <Grid container spacing={2}>
          <Grid item xs={12} sm={6}>
            <Box>
              <Typography variant="subtitle2" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>
                Evaluation
              </Typography>
              <Typography variant="body1">
                {cod_evaluation} {lib_evaluation}
              </Typography>
            </Box>
          </Grid>
          <Grid item xs={12} sm={6}>
            <Box>
              <Typography variant="subtitle2" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>
                Évaluateur
              </Typography>
              <Typography variant="body1">
                {evaluateur} {nom_evaluateur}
              </Typography>
            </Box>
          </Grid>
          <Grid item xs={12} sm={6}>
            <Box>
              <Typography variant="subtitle2" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>
                Evalué
              </Typography>
              <Typography variant="body1">
                {evalue} {nom_evalue}
              </Typography>
            </Box>
          </Grid>
          <Grid item xs={12} sm={6}>
            <Box>
              <Typography variant="subtitle2" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>
                Formulaire
              </Typography>
              <Typography variant="body1">
                {cod_survey}
              </Typography>
            </Box>
          </Grid>
          <Grid item xs={12}>
            <Box>
              <Typography variant="subtitle2" sx={{ color: colorBase.colorBase01, fontWeight: 'bold' }}>
                Réponses
              </Typography>
              <Typography variant="body1">
                {cod_reply}
              </Typography>
            </Box>
          </Grid>
        </Grid>
      </Box>
      <Survey_Rendering refChild={myRef} ref_evaluation={cod_evaluation} cod_survey={cod_survey} cod_reply={cod_reply} evalue={evalue} evaluateur={evaluateur} typ_survey={typ_survey} />
    </div>
  )
}

export default Evaluation