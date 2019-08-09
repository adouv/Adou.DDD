import { dateTimeFormats } from "./dateTime.filter";
import { dateFormats } from "./date.filter";
export const FilterInstall = Vue => {
    dateTimeFormats(Vue);
    dateFormats(Vue);
};