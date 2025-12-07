import axios, { AxiosResponse } from "axios";
import { Connexion, myJwt, setJwt } from "../modules/module_general";
import { ObjetGenerique } from "../types";

const useAxiosPost = () => {
  const myAxios = async (
    apiStr: string,
    bdy: ObjetGenerique,
    hdr?: ObjetGenerique,
    options?: ObjetGenerique,
    onUploadProgress?: ObjetGenerique
  ): Promise<
    | AxiosResponse<any>
    | { data: null; error: any; status: number; headers: any }
  > => {
    let headers = {
      ...hdr,
      Autres: "",
      authorization: `Bearer ${myJwt}`,
    };
    try {
      const response = await axios.post(`${Connexion}${apiStr}`, bdy, {
        headers,
        ...options,
      });
      return response;
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
            return await axios.post(`${Connexion}${apiStr}`, bdy, {
              headers,
              ...options,
            });
          }
        } catch (refreshErr) {
          console.error("Token refresh failed", refreshErr);
        }
      }
      console.error(apiStr, err);
      return { data: null, error: err, status: -1, headers: null };
    }
  };
  return myAxios;
};

export default useAxiosPost;
