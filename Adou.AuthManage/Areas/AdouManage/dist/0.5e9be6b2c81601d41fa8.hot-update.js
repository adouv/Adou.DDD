webpackHotUpdate(0,{

/***/ 44:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__Index_scss__ = __webpack_require__(45);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__Index_scss___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0__Index_scss__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__Index_cshtml__ = __webpack_require__(46);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__Index_cshtml___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1__Index_cshtml__);



/* harmony default export */ __webpack_exports__["a"] = ({
    name: "HomeComponent",
    template: __WEBPACK_IMPORTED_MODULE_1__Index_cshtml___default.a,
    data: function data() {
        return {
            isCollapse: false
        };
    },

    methods: {
        handleOpen: function handleOpen(key, keyPath) {
            console.log(key, keyPath);
        },
        handleClose: function handleClose(key, keyPath) {
            console.log(key, keyPath);
        },
        toggleCollapse: function toggleCollapse() {
            this.isCollapse = !this.isCollapse;
        }
    },
    computed: {
        asideWidth: function asideWidth() {
            return this.isCollapse ? '70px' : '230px';
        },
        menuWidth: function menuWidth() {
            return this.isCollapse ? '88px' : '248px';
        }
    }
});

/***/ }),

/***/ 45:
/***/ (function(module, exports) {

throw new Error("Module build failed: ModuleBuildError: Module build failed: \r\n        }*/\r\n       ^\r\n      Invalid CSS after \"        }\": expected \"}\", was \"*/\"\r\n      in D:\\adou\\adouproject\\api\\Adou.Api\\Adou.AuthManage\\Areas\\AdouManage\\Views\\Home\\Index.scss (line 56, column 9)\n    at runLoaders (D:\\adou\\adouproject\\api\\Adou.Api\\Adou.AuthManage\\node_modules\\webpack\\lib\\NormalModule.js:195:19)\n    at D:\\adou\\adouproject\\api\\Adou.Api\\Adou.AuthManage\\node_modules\\loader-runner\\lib\\LoaderRunner.js:364:11\n    at D:\\adou\\adouproject\\api\\Adou.Api\\Adou.AuthManage\\node_modules\\loader-runner\\lib\\LoaderRunner.js:230:18\n    at context.callback (D:\\adou\\adouproject\\api\\Adou.Api\\Adou.AuthManage\\node_modules\\loader-runner\\lib\\LoaderRunner.js:111:13)\n    at Object.asyncSassJobQueue.push [as callback] (D:\\adou\\adouproject\\api\\Adou.Api\\Adou.AuthManage\\node_modules\\sass-loader\\lib\\loader.js:67:13)\n    at Object.done [as callback] (D:\\adou\\adouproject\\api\\Adou.Api\\Adou.AuthManage\\node_modules\\neo-async\\async.js:7974:18)\n    at options.error (D:\\adou\\adouproject\\api\\Adou.Api\\Adou.AuthManage\\node_modules\\node-sass\\lib\\index.js:294:32)");

/***/ })

})
//# sourceMappingURL=0.5e9be6b2c81601d41fa8.hot-update.js.map