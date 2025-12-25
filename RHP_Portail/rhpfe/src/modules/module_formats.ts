import { format, isValid, parse } from "date-fns";
export const rgDate = /\d{2}\/\d{2}\/\d{4}/;
export const rgDateTime = /\d{2}\/\d{2}\/\d{4}\s\d\d?\:\d\d?/;
const rsDateTimeZone = /\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{3}Z/;
const rsDateTime = /\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{3}/;
export const estEmail = (email: any) => {
  new RegExp(formatsUsuels["email"], "gi").test(email);
};
export const estNumeric = (num: string | number): boolean =>
  !isNaN(parseFloat(num.toString()));
export function estDate(date: any): date is Date {
  return (
    (date instanceof Date && !isNaN(date.getTime())) ||
    rsDateTimeZone.test(date) ||
    rsDateTime.test(date) ||
    rgDate.test(date) ||
    rgDateTime.test(date)
  );
}
export const cDate = (strDate: string): Date => {
  if (rgDateTime.test(strDate)) {
    return parse(strDate, "dd/MM/yyyy HH:mm", new Date());
  } else if (rgDate.test(strDate)) {
    return parse(strDate, "dd/MM/yyyy", new Date());
  } else {
    return new Date(strDate);
  }
};
export const formatDateFR = (obj: any, ShowTime: boolean = false) => {
  if (isValid(obj)) {
    return format(obj, "dd/MM/yyyy" + (ShowTime ? " HH:mm" : ""));
  } else if (/\d{4}\-\d{2}\-\d{2}T\d\d?\:\d\d?/g.test(obj)) {
    let y = obj.substring(0, 4);
    let M = ("00" + obj.substring(5, 7)).slice(-2);
    let d = ("00" + obj.substring(8, 10)).slice(-2);
    let h = ("00" + obj.substring(11, 13)).slice(-2);
    let m = ("00" + obj.substring(14, 16)).slice(-2);
    return ShowTime ? `${d}/${M}/${y} ${h}:${m}` : `${d}/${M}/${y}`;
  } else {
    return obj;
  }
};
export const toSqlDateFormat = (dat: any, ShowTime?: boolean) => {
  let mydat = estDate(dat)
    ? format(dat, "MM-dd-yyyy" + (ShowTime ? " HH:mm" : ""))
    : cDate(dat);
  return mydat;
};
export const formatsUsuels: { [kay: string]: string } = {
  cin: "[a-zA-Z]{1,3}s*\\d{1,7}",
  integer: "^\\d+$",
  number: "^[+-]?\\d+(\\.\\d+)?$",
  email: "^[a-zA-Z0-9_.-]+@[a-zA-Z0-9.-_]+.[a-zA-Z]{2,}$",
  date: "^\\d{4}-\\d{2}-\\d{2}$",
};
export const dateWithoutTimezone = (date: Date) => {
  const tzoffset = date.getTimezoneOffset() * 60000; //offset in milliseconds
  const withoutTimezone = new Date(date.valueOf() - tzoffset)
    .toISOString()
    .slice(0, -1);
  return withoutTimezone;
};

export const parseRtfToText = (rtf: string) => {
  let result = "";
  let stack: { skip: boolean }[] = [];
  let i = 0;

  // Common groups to ignore even if not marked with \*
  const ignorableDestinations = new Set([
    "fonttbl", "colortbl", "stylesheet", "info", "operator",
    "generator", "printim", "private", "revtbl"
  ]);

  while (i < rtf.length) {
    const char = rtf[i];

    if (char === '\\') {
      i++;
      if (i >= rtf.length) break;
      const next = rtf[i];

      if (next === "'") {
        // Hex encoding \'xx
        if (i + 2 < rtf.length) {
          const hex = rtf.substring(i + 1, i + 3);
          if (/^[0-9A-Fa-f]{2}$/.test(hex)) {
            // If we are not skipping content, decode char
            if (stack.length === 0 || !stack[stack.length - 1].skip) {
              // RTF typically uses Windows-1252 (cp1252) for \'\xx
              // We can try to decode it.
              const charCode = parseInt(hex, 16);
              // Simple mapping for common western european
              // Using a decoder would be best but for now basic windows-1252 check
              const decodedChar = new TextDecoder("windows-1252").decode(new Uint8Array([charCode]));
              result += decodedChar;
            }
            i += 3;
            continue;
          }
        }
        // Fallback if not valid hex
        i++;
      } else if (next === '{' || next === '}' || next === '\\') {
        if (stack.length === 0 || !stack[stack.length - 1].skip) {
          result += next;
        }
        i++;
      } else if (next === '\n' || next === '\r') {
        i++;
      } else {
        // Command
        let cmd = "";
        while (i < rtf.length && /[a-z]/i.test(rtf[i])) {
          cmd += rtf[i];
          i++;
        }

        // Check if this command starts a group we should ignore
        // Usually the command is the *first* thing in the group, e.g. {\fonttbl...}
        // So we might need to check the stack's top if it was just pushed.

        let param = "";
        let hasParam = false;
        if (i < rtf.length && /[-0-9]/.test(rtf[i])) {
          hasParam = true;
          while (i < rtf.length && /[-0-9]/.test(rtf[i])) {
            param += rtf[i];
            i++;
          }
        }
        if (i < rtf.length && rtf[i] === ' ') {
          i++;
        }

        // Check if we are in a new group that needs to optionally skip based on this command
        if (stack.length > 0) {
          // If we just entered a group (char was '{'), we haven't decided skip yet unless it was \*
          // But if we see \fonttbl right after {, we should skip.
          // This logic is tricky in one pass without lookahead or state.
          // Simpler: if we encounter an ignorable command, and we are inside a group, 
          // mark the current group as skip.
          // But we might be mid-group.
          // Actually, header groups usually start with the command immediately after {.

          // Note: The previous loop logic separated { from the command. 
          // We rely on the fact that if we just pushed to stack, this command might define the group type.
        }

        if (ignorableDestinations.has(cmd)) {
          // Mark current group as skip
          if (stack.length > 0) stack[stack.length - 1].skip = true;
        }

        if (cmd === "par" || cmd === "line") {
          if (stack.length === 0 || !stack[stack.length - 1].skip) result += "\n";
        }
        if (cmd === "tab") {
          if (stack.length === 0 || !stack[stack.length - 1].skip) result += "\t";
        }

        // Unicode
        if (cmd === "u" && hasParam) {
          if (stack.length === 0 || !stack[stack.length - 1].skip) {
            const uCode = parseInt(param, 10);
            // Handle negative values (16-bit signed)
            const cleanCode = uCode < 0 ? uCode + 65536 : uCode;
            result += String.fromCharCode(cleanCode);
          }
          // Skip replacement chars for \uN
          // usually followed by ? or a character to skip
          // Logic: RTF 'uc' control defaults to 1 char skip.
          // We'll assume 1 char skip for now.
          if (i < rtf.length) {
            // Skip one char (replacement char)
            // Note: replacement char might be unescaped char or escaped char like \'3f
            // Simple skip for now:
            // If next is \, it might comprise a sequence like \'3f or similar. 
            // But typically it's just '?'
            // Let's implement robust skip: if next is \, skip until after the control/hex, else skip 1 char.
            // BUT, simpler valid approach for standard RTF generators (like RichEdit): just skip next char if it is '?'
            // Or just skip 1 char.
            // Actually, if it's \u1234\'3f, the replacement is \'3f (one rtf atom).
            // If it's \u1234?, the replacement is ?.

            // Let's try skipping exactly one char (byte or hex or cmd)
            /*
               Logic:
               if char is \, consume next cmd or hex or char.
               else consume 1 char.
            */
            const nextC = rtf[i];
            if (nextC === '\\') {
              // check if hex or special
              if (i + 1 < rtf.length) {
                const nextNext = rtf[i + 1];
                if (nextNext === '\'') {
                  // \'xx -> skip 3 chars total
                  i += 3;
                } else if (/[a-z]/i.test(nextNext)) {
                  // command -> skip until space or non-alphanum
                  // This is rare for replacement char but possible
                  // Just advance past command
                  i += 2;
                  while (i < rtf.length && /[a-z]/i.test(rtf[i])) i++;
                  while (i < rtf.length && /[-0-9]/.test(rtf[i])) i++;
                  if (i < rtf.length && rtf[i] === ' ') i++;
                } else {
                  // escaped char like \{
                  i += 2;
                }
              } else {
                i++; // trailing \ ?
              }
            } else {
              // literal char
              i++;
            }
          }
        }
      }
    } else if (char === '{') {
      let isDest = false;
      // Check if next is \*
      let k = i + 1;
      while (k < rtf.length && (rtf[k] === '\r' || rtf[k] === '\n')) k++; // skip whitespace if any?
      if (k < rtf.length && rtf[k] === '\\') {
        if (k + 1 < rtf.length && rtf[k + 1] === '*') isDest = true;
      }

      // Inherit skip from parent
      if (stack.length > 0 && stack[stack.length - 1].skip) isDest = true;

      stack.push({ skip: isDest });
      i++;
    } else if (char === '}') {
      if (stack.length > 0) stack.pop();
      i++;
    } else {
      if (stack.length === 0 || !stack[stack.length - 1].skip) {
        if (char !== '\n' && char !== '\r') result += char;
      }
      i++;
    }
  }
  return result.trim();
};
