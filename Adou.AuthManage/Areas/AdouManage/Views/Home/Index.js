import HomeTemplate from "./Index.cshtml";
import "./Index.scss";

export default {
    name: "HomeComponent",
    template: HomeTemplate,
    data() {
        return {
            message: "homes"
        }
    }
}