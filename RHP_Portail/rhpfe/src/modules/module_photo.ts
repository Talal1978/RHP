import { Buffer } from "buffer";
import { fromByteArray } from "base64-js";
import noImage from "../../css/img/noImage.jpg";
import Resizer from "react-image-file-resizer";
export const photoUrlToBinary = async (imageUrl: string) => {
  const response = await fetch(imageUrl);
  const arrayBuffer = await response.arrayBuffer();
  const imageData = new Uint8Array(arrayBuffer);
  return imageData;
};
export const photoFromBinary = (imageBinaryData: any) => {
  return imageBinaryData && imageBinaryData?.data
    ? `data:image/png;base64,${fromByteArray(imageBinaryData.data)}`
    : noImage;
};

const resizeFile = (file: any) => {
  return new Promise((resolve) => {
    Resizer.imageFileResizer(
      file,
      200,
      200,
      "PNG",
      50,
      0,
      (uri: any) => {
        resolve(uri);
      },
      "base64"
    );
  });
};
function base64ToBlob(base64Str: string) {
  const byteCharacters = atob(base64Str);
  const byteNumbers = new Array(byteCharacters.length);
  for (let i = 0; i < byteCharacters.length; i++) {
    byteNumbers[i] = byteCharacters.charCodeAt(i);
  }
  const byteArray = new Uint8Array(byteNumbers);
  const myblob = new Blob([byteArray], { type: "image/png" });
  return myblob;
}
