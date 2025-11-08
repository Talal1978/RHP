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
  date: "/^(0[1-9]|[12][0-9]|3[01])\\/(0[1-9]|1[012])\\/(19|20)\\d\\d$/",
};
export const dateWithoutTimezone = (date: Date) => {
  const tzoffset = date.getTimezoneOffset() * 60000; //offset in milliseconds
  const withoutTimezone = new Date(date.valueOf() - tzoffset)
    .toISOString()
    .slice(0, -1);
  return withoutTimezone;
};
