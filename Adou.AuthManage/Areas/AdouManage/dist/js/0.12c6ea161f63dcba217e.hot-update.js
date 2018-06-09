webpackHotUpdate(0,{

/***/ 20:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});

var _tip = __webpack_require__(21);

var _tip2 = _interopRequireDefault(_tip);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

exports.default = {
    install: function install(Vue) {
        var PluginOptions = arguments.length > 1 && arguments[1] !== undefined ? arguments[1] : {};

        var TipConstructor = Vue.extend(_tip2.default);
        var tip = null;

        function $tip(message) {
            var duration = arguments.length > 1 && arguments[1] !== undefined ? arguments[1] : 3500;

            tip = new TipConstructor();
            tip.$mount();
            document.querySelector(PluginOptions.container || 'body').appendChild(tip.$el);
            tip.message = message;
            tip.show = true;
            setTimeout(function () {
                tip.show = false;
            }, duration);
        }

        Vue.tip = Vue.prototype.$tip = $tip;
    }
};

/***/ })

})
//# sourceMappingURL=0.12c6ea161f63dcba217e.hot-update.js.map