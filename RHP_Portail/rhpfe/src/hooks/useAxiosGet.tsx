import axios from "axios";
import { Connexion, myJwt } from "../modules/module_general";

const useAxiosGet = () => {
  const myAxios = async ({
    apiStr,
    bdy,
    hdr,
    options,
    onUploadProgress,
    responseType = "json",
  }: {
    apiStr: string;
    bdy?: any;
    hdr?: any;
    options?: any;
    onUploadProgress?: any;
    responseType?:
      | "blob"
      | "json"
      | "text"
      | "arraybuffer"
      | "document"
      | "stream";
  }) => {
    let headers = {
      ...hdr,
      authorization: `Bearer ${myJwt}`,
    };
    try {
      return axios.get(`${Connexion}${apiStr}`, {
        params: { ...bdy },
        headers: {
          ...headers,
          ...options,
        },
        responseType,
      });
    } catch (err: any) {
      if (axios.isAxiosError(err) && err.response?.status === 500) {
      }
    }
    return { data: "", status: -1 };
  };
  return myAxios;
};

export default useAxiosGet;
