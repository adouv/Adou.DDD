import Vue from 'vue'
import Main from './tip.vue'

let TipConstructor = Vue.extend(Main);

let instance;
let instances = [];
let seed = 1;

const Tip = function (message, options = {}) {
    if (Vue.prototype.$isServer) return;
    options = options || {};
    options.message = message;
    options.type = options.type === undefined ? 'success' : options.type;

    let userOnClose = options.onClose;
    let id = 'message_' + seed++;

    options.onClose = function () {
        Tip.close(id, userOnClose);
    }

    instance = new TipConstructor({
        data: options
    });

    instance.id = id;

    instance.vm = instance.$mount();
    document.body.appendChild(instance.vm.$el);
    instance.vm.visible = true;
    instance.dom = instance.vm.$el;
    instances.push(instance);
    return instance.vm;
}

let typeArray = ['success', 'warning', 'info', 'error'];
typeArray.forEach(type => {
    Tip[type] = options => {
        if (typeof options === 'string') {
            options = {
                message: options
            };
        }
        options.type = type;
        return Tip(options);
    };
});

Tip.close = function (id, userOnClose) {
    for (let i = 0, len = instances.length; i < len; i++) {
        if (typeof userOnClose === 'function') {
            userOnClose(instances[i]);
        }
        instances.splice(i, 1);
        break;
    }
}

Tip.closeAll = function () {
    for (let i = instances.length - 1; i >= 0; i++) {
        instances[i].close();
    }
}

export default Tip;


