export async function loadJSON(path: string): Promise<any> {
  const response = await fetch(path);
  if (!response.ok) {
    throw new Error("Network response was not ok.");
  }
  return response.json();
}
export const telecharger = async (
  data: any,
  typeData: "Blob" | "string64",
  fileName: string
) => {
  const url = window.URL.createObjectURL(
    typeData === "Blob" ? data : new Blob([data])
  );
  const link = document.createElement("a");
  link.href = url;
  link.setAttribute("download", fileName);
  document.body.appendChild(link);
  link.click();
  link.parentNode?.removeChild(link);
  return url;
};

export const convertBlobToBase64 = (blob: Blob) =>
  new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.onerror = reject;
    reader.onload = () => {
      resolve(reader.result);
    };
    reader.readAsDataURL(blob);
  });

export const convertBase64ToBlob = (dataBase64: string) =>
  new Blob([dataBase64]);
