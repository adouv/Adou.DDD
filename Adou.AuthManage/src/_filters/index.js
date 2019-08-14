import { dateTimeFormats } from "./dateTime.filter";
import { dateFormats } from "./date.filter";
import { emptyFormats } from "./empty.filter";
export const FilterInstall = Vue => {
    dateTimeFormats(Vue);
    dateFormats(Vue);
    emptyFormats(Vue);
};