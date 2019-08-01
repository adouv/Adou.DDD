import { MessageBox } from 'element-ui'

const confirm = function (title, message, options = {}) {

    let confirm = options.confirm;
    let cancel = options.cancel;

    options.customClass = "adou-message-box-confirm";

    MessageBox.confirm(message, title, options)
        .then(() => {
            if (typeof (confirm) != 'function') {
                return;
            }
            confirm();
        })
        .catch(() => {
            if (typeof (cancel) != 'function') {
                return;
            }
            cancel();
        });

}


export default confirm;