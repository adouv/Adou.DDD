import "./Index.scss";
import HomeTemplate from "./Index.cshtml";

export default {
    name: "HomeComponent",
    template: HomeTemplate,
    data() {
        return {
            message: "home"
        }
    },
    methods: {
        btnOpen() {
            this.$tip("hello tip!");
        }
    }
}