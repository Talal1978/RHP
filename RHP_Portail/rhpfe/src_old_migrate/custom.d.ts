declare module "*.jpg";
declare module "*.jpeg";
declare module "*.png";
declare module "rtf-parser" {
  export class RTFParser {
    on(event: "text" | "error", callback: (data: string | Error) => void): void;
    write(rtfText: string): void;
    end(): void;
  }
}
