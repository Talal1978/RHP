
// Mocking the function directly to avoid import issues

const parseRtfToText = (rtf: string) => {
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
                        // Decode char
                        if (stack.length === 0 || !stack[stack.length - 1].skip) {
                            const charCode = parseInt(hex, 16);
                            // Mocking TextDecoder for basic latin1
                            // const decodedChar = new TextDecoder("windows-1252").decode(new Uint8Array([charCode]));
                            const decodedChar = String.fromCharCode(charCode); // Assuming CP1252 matches Unicode for < 256 mostly
                            result += decodedChar;
                        }
                        i += 3;
                        continue;
                    }
                }
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

                if (ignorableDestinations.has(cmd)) {
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
                        const cleanCode = uCode < 0 ? uCode + 65536 : uCode;
                        result += String.fromCharCode(cleanCode);
                    }
                    if (i < rtf.length) {
                        const nextC = rtf[i];
                        if (nextC === '\\') {
                            if (i + 1 < rtf.length) {
                                const nextNext = rtf[i + 1];
                                if (nextNext === '\'') {
                                    i += 3;
                                } else if (/[a-z]/i.test(nextNext)) {
                                    i += 2;
                                    while (i < rtf.length && /[a-z]/i.test(rtf[i])) i++;
                                    while (i < rtf.length && /[-0-9]/.test(rtf[i])) i++;
                                    if (i < rtf.length && rtf[i] === ' ') i++;
                                } else {
                                    i += 2;
                                }
                            } else {
                                i++;
                            }
                        } else {
                            i++;
                        }
                    }
                }
            }
        } else if (char === '{') {
            let isDest = false;
            let k = i + 1;
            while (k < rtf.length && (rtf[k] === '\r' || rtf[k] === '\n')) k++;
            if (k < rtf.length && rtf[k] === '\\') {
                if (k + 1 < rtf.length && rtf[k + 1] === '*') isDest = true;
            }
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

const testCases = [
    { input: "D\\'e9partement", label: "Hex Accented" },
    { input: "D\\u233?partement", label: "Unicode with ?" },
    { input: "D\\u233 9partement", label: "Unicode with space+9" },
    { input: "D\\u233\\'39partement", label: "Unicode with \\'39" },
    { input: "D\\u233 9 partement", label: "Unicode with space+9+space" },
    { input: "\\u233", label: "Unicode End" },
    { input: "D\\u8230.partement", label: "Ellipsis test" }
];

testCases.forEach(t => {
    console.log(`[${t.label}] Input: ${t.input} => Output: ${parseRtfToText(t.input)}`);
});
