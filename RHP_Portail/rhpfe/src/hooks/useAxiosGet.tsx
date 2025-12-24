import axios from "axios";
import { useCallback } from "react";
import { Connexion, myJwt, setJwt } from "../modules/module_general";

const useAxiosGet = () => {
  const myAxios = useCallback(async ({
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
      return await axios.get(`${Connexion}${apiStr}`, {
        params: { ...bdy },
        headers: {
          ...headers,
          ...options,
        },
        responseType,
      });
    } catch (err: any) {
      if (axios.isAxiosError(err) && err.response?.status === 403) {
        // Attempt refresh
        try {
          const refreshResponse = await axios.post(`${Connexion}refresh`, {}, { withCredentials: true });
          if (refreshResponse.data && refreshResponse.data.accessToken) {
            const { accessToken } = refreshResponse.data;
            setJwt(accessToken);

            // Retry original request
            headers.authorization = `Bearer ${accessToken}`;
            return await axios.get(`${Connexion}${apiStr}`, {
              params: { ...bdy },
              headers: {
                ...headers,
                ...options,
              },
              responseType,
            });
          }
        } catch (refreshErr) {
          console.error("Token refresh failed", refreshErr);
          window.location.href = "/";
        }
      }

      // Connection cut / Network Error detection
      if (!err.response || err.code === "ERR_NETWORK") {
        window.location.href = "/";
      }

      if (axios.isAxiosError(err) && err.response?.status === 500) {
      }
    }
    return { data: "", status: -1 };
  }, []);
  return myAxios;
};

export default useAxiosGet;
