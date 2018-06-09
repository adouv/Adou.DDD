import "./tip.scss";
import tipComponent from "./tip.html";

export default
    {
        name: "tipComponent",
        template: tipComponent,
        data() {
            return {
                message: "这里是提示内容",
                show: false
            }
        },
        methods: {
            /**
             * 关闭tip
             */
            btnClose() {
                this.show = false;
            }
        }
    }