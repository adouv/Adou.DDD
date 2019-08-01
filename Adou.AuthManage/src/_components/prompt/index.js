import { MessageBox } from 'element-ui'

const prompt = function (title, message, options = {}) {

    let confirm = options.confirm;
    let cancel = options.cancel;

    options.customClass = "adou-message-box-prompt",

        MessageBox.prompt(message, title, options)
            .then(({ value }) => {
                if (typeof (confirm) != 'function') {
                    return;
                }
                confirm(value);
            })
            .catch(() => {
                if (typeof (cancel) != 'function') {
                    return;
                }
                cancel();
            });
}

export default prompt;