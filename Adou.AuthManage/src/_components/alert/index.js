import { MessageBox } from 'element-ui'

const alert = function (title, message, options = {}) {

    options.customClass = "adou-message-box-alert";

    MessageBox.alert(message, title, options);
}


export default alert;