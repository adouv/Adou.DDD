webpackHotUpdate(0,{

/***/ 10:
false,

/***/ 11:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});

var _Index = __webpack_require__(!(function webpackMissingModule() { var e = new Error("Cannot find module \"Index.cshtml\""); e.code = 'MODULE_NOT_FOUND'; throw e; }()));

var _Index2 = _interopRequireDefault(_Index);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

exports.default = {
    name: "HomeComponent",
    template: _Index2.default,
    data: function data() {
        return {
            message: "homes"
        };
    }
};

/***/ }),

/***/ 7:
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});

var _vue = __webpack_require__(1);

var _vue2 = _interopRequireDefault(_vue);

var _vueRouter = __webpack_require__(8);

var _vueRouter2 = _interopRequireDefault(_vueRouter);

var _Index = __webpack_require__(11);

var _Index2 = _interopRequireDefault(_Index);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

var Bar = { template: '<div>bar</div>' };

_vue2.default.use(_vueRouter2.default);

var routers = [{ path: '/home', component: _Index2.default }, { path: '/bar', component: Bar }];

var router = new _vueRouter2.default({
    routes: routers
});

exports.default = router;

/***/ })

})
//# sourceMappingURL=0.e72b51f99a56facd8f0f.hot-update.js.map