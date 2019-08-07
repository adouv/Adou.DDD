import AdConfirmComponent from "./index.vue";
/** 
 * 
 */
export const adConfirmInstall = (Vue, PluginOptions = {}) => {
    Object.defineProperty(Vue.prototype, 'confirm$', {
        get() {
            let div = document.createElement('div');
            document.body.appendChild(div);
            return (options) => {
                const Constructor = Vue.extend(AdConfirmComponent);
                const Instance = new Constructor({
                    data() {
                        return {
                            show: true,
                            confirmOptions: options
                        }
                    }
                }).$mount(div);
            }
        }
    });

    Vue.confirm = Vue.prototype.confirm$;
};