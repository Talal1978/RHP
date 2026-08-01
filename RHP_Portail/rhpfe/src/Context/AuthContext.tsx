import React, { createContext, useContext, useState, useCallback, useMemo } from "react";
import { TAgent } from "../types";

export interface AuthState {
  jwt: string;
  agent: TAgent;
  isAuthenticated: boolean;
}

const initialAgent: TAgent = {
  codProfile: "",
  Login: "",
  Typ_Role: "",
  Cod_Poste: "",
  Cod_Entite: "",
  Matricule: "",
  Nom: "",
  Mail: "",
  id_Societe: "",
  TeamLeader: false,
  RacineHierarchique: "",
};

const AuthContext = createContext<{
  auth: AuthState;
  setAuth: (auth: AuthState) => void;
  setJwt: (jwt: string) => void;
  setAgent: (agent: TAgent) => void;
  logout: () => void;
}>({
  auth: { jwt: "", agent: initialAgent, isAuthenticated: false },
  setAuth: () => {},
  setJwt: () => {},
  setAgent: () => {},
  logout: () => {},
});

export const AuthProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  const [auth, setAuthState] = useState<AuthState>(() => {
    const storedToken = localStorage.getItem("auth_token");
    const storedAgent = localStorage.getItem("auth_agent");
    if (storedToken && storedAgent) {
      try {
        const parsedAgent = JSON.parse(storedAgent);
        if (parsedAgent && typeof parsedAgent === "object") {
          return { jwt: storedToken, agent: parsedAgent, isAuthenticated: true };
        }
      } catch {
        localStorage.removeItem("auth_token");
        localStorage.removeItem("auth_agent");
      }
    }
    return { jwt: "", agent: initialAgent, isAuthenticated: false };
  });

  const setJwt = useCallback((jwt: string) => {
    setAuthState((prev) => ({ ...prev, jwt, isAuthenticated: !!jwt }));
  }, []);

  const setAgent = useCallback((agent: TAgent) => {
    setAuthState((prev) => ({ ...prev, agent }));
  }, []);

  const setAuth = useCallback((next: AuthState) => {
    setAuthState(next);
  }, []);

  const logout = useCallback(() => {
    localStorage.removeItem("auth_token");
    localStorage.removeItem("auth_agent");
    localStorage.removeItem("remembered_login");
    setAuthState({ jwt: "", agent: initialAgent, isAuthenticated: false });
    window.location.href = "/";
  }, []);

  const value = useMemo(() => ({ auth, setAuth, setJwt, setAgent, logout }), [auth, setAuth, setJwt, setAgent, logout]);

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};

export const useAuth = () => useContext(AuthContext);
