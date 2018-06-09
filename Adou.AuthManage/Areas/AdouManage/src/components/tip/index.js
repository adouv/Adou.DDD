import tipComponent from "./tip.js";

export default
    {
        install(Vue, PluginOptions = {}) {
            const TipConstructor = Vue.extend(tipComponent);
            let tip = null;

            function $tip(message, duration = 3500) {
                tip = new TipConstructor();
                tip.$mount();
                document.querySelector(PluginOptions.container || 'body').appendChild(tip.$el);
                tip.message = message;
                tip.show = true;
                setTimeout(() => {
                    tip.show = false;
                }, duration);
            }

            Vue.tip = Vue.prototype.$tip = $tip;
        }
    }