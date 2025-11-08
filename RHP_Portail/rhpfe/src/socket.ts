import { io } from "socket.io-client";
const URL: string =
  process.env.NODE_ENV === "production" ? "" : "http://localhost:3500";

export let socket: any;
export async function setSocket(_Jwt: string, _adr: string = URL) {
  socket = io(_adr, {
    autoConnect: true,
    withCredentials: true,
    extraHeaders: { jwt: _Jwt },
    transports: ["polling"],
  });
  await socket.connect();
}
