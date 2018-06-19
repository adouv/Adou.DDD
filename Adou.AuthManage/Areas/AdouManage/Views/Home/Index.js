import "./Index.scss";
import HomeTemplate from "./Index.cshtml";

export default {
    name: "HomeComponent",
    template: HomeTemplate,
    data() {
        return {
            isCollapse: false
        };
    },
    methods: {
        handleOpen(key, keyPath) {
            console.log(key, keyPath);
        },
        handleClose(key, keyPath) {
            console.log(key, keyPath);
        },
        toggleCollapse() {
            this.isCollapse = !this.isCollapse;
        }
    },
    computed: {
        asideWidth() {
            return this.isCollapse ? '70px' : '230px';
        },
        menuWidth() {
            return this.isCollapse ? '88px' : '248px';
        }
    }
}