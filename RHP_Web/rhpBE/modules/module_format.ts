import { format, parse } from "date-fns";
export const rgDate = /\d{2}\/\d{2}\/\d{4}/;
export const rgDateTime = /\d{2}\/\d{2}\/\d{4}\s\d\d?\:\d\d?/;
const rsDateTimeZone = /\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{3}Z/;
const rsDateTime = /\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.\d{3}/;
export const estEmail = (email: any) => {
  /[a-zA-Z0-9_.-]+@[a-zA-Z0-9.-_]+\.[a-zA-Z]{2,}/.test(email);
};
export function estDate(date: any): date is Date {
  return (
    (date instanceof Date && !isNaN(date.getTime())) ||
    rsDateTimeZone.test(date) ||
    rsDateTime.test(date) ||
    rgDate.test(date) ||
    rgDateTime.test(date)
  );
}
export function checkDateFormat(date: any): boolean {
  const parsedDate = new Date(date);
  return parsedDate instanceof Date && !isNaN(parsedDate.getTime());
}
export const cDate = (strDate: string): Date => {
  if (
    rgDateTime.test(strDate) ||
    rsDateTimeZone.test(strDate) ||
    rsDateTime.test(strDate)
  ) {
    return parse(strDate, "dd/MM/yyyy HH:mm", new Date());
  } else if (rgDate.test(strDate)) {
    return parse(strDate, "dd/MM/yyyy", new Date());
  } else {
    return new Date(strDate);
  }
};
export const formatDateFR = (obj: any, ShowTime = false) => {
  if (estDate(obj)) {
    return format(obj, "dd/MM/yyyy" + (ShowTime ? " HH:mm" : ""));
  } else return obj;
};
export const toSqlDateFormat = (dat: any, ShowTime = false) => {
  let mydat = estDate(dat)
    ? format(dat, "MM-dd-yyyy" + (ShowTime ? " HH:mm" : ""))
    : cDate(dat);
  return mydat;
};
