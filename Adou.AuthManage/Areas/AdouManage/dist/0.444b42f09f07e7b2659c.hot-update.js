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
            return this.isCollapse ? '230px' : '230px';
        },
        menuWidth: function menuWidth() {
            return this.isCollapse ? '88px' : '248px';
        }
    }
});

/***/ })

})
//# sourceMappingURL=0.444b42f09f07e7b2659c.hot-update.js.map