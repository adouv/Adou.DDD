import Enum from './mutation-enum.js'
/** 
 * mutations
 * 提交状态修改。也就是set、get中的set，这是vuex中唯一修改state的方式，但不支持异步操作。
 * 第一个参数默认是state。外部调用方式：store.commit('SET_AGE', 18)。和vue中的methods类似。
 */
export default {
    [Enum.TEST_ITEM_TYPE_LIST]: (state, list) => {
        state.testItemTypeList = [];
        state.testItemTypeList = list;
    },
    [Enum.TEST_ITEM_PACKAGE_LIST]: (state, list) => {
        state.testItemPackageList = [];
        state.testItemPackageList = list;
    },
    [Enum.SET_TEST_ITEM_TYPE_ITEM]: (state, item) => {
        item.check = !item.check;
        item.itemList.filter(e => (e.check = item.check));

        if (state.testItemPackageList.length !== 0) {
            state.testItemPackageList.forEach(e => {
                if (e.itemList.length !== 0) {
                    e.itemList.forEach(ele => {
                        let include = item.itemList.find(f => f.value === ele.value);
                        if (include !== undefined) {
                            ele.check = item.check;
                        }
                    });
                }
                let a = e.itemList.filter(e => e.check).length;
                let b = e.itemList.length;
                e.check = a === b;
            });
        }

        state.total = 0;
        state.selectTestItem = [];
        if (state.testItemTypeList.length !== 0) {
            state.testItemTypeList.forEach(e => {
                e.itemList.forEach(ele => {
                    if (ele.check) {
                        state.total += parseFloat(ele.price);
                        state.selectTestItem.push(ele);
                    }
                });
            });
        }
        console.log(state.total);
    },
    [Enum.SET_TEST_ITEM]: (state, params) => {
        let itemType = params.itemType;
        let item = params.item;
        let type = params.type;

        item.check = !item.check;
        let a = itemType.itemList.filter(e => e.check).length;
        let b = itemType.itemList.length;
        itemType.check = a === b;

        if (type === undefined) {
            if (state.testItemPackageList.length !== 0) {
                state.testItemPackageList.forEach(e => {
                    if (e.itemList.length !== 0) {
                        e.itemList.forEach(ele => {
                            if (ele.value === item.value) {
                                ele.check = item.check;
                            }
                        });
                    }
                    let a = e.itemList.filter(e => e.check).length;
                    let b = e.itemList.length;
                    e.check = a === b;
                });
            }
        }

        if (type === 1) {
            state.testItemTypeList.forEach(e => {
                e.itemList.forEach(ele => {
                    if (ele.value === item.value) {
                        ele.check = item.check;
                    }
                });
                let a = e.itemList.filter(e => e.check).length;
                let b = e.itemList.length;
                e.check = a === b;
            });
        }

        state.total = 0;
        state.selectTestItem = [];
        if (state.testItemTypeList.length !== 0) {
            state.testItemTypeList.forEach(e => {
                e.itemList.forEach(ele => {
                    if (ele.check) {
                        state.total += parseFloat(ele.price);
                        state.selectTestItem.push(ele);
                    }
                });
            });
        }
        console.log(state.total);
    },
    [Enum.SET_TEST_ITEM_PACKAGE_ITEM]: (state, item) => {
        item.check = !item.check;
        item.itemList.filter(e => (e.check = item.check));

        if (state.testItemTypeList.length !== 0) {
            state.testItemTypeList.forEach(e => {
                if (e.itemList.length !== 0) {
                    e.itemList.forEach(ele => {
                        let check = item.itemList.find(i => i.value === ele.value);
                        if (check !== undefined) {
                            ele.check = check.check;
                        }
                    });
                }
                let a = e.itemList.filter(e => e.check).length;
                let b = e.itemList.length;
                e.check = a === b;
            });
        }

        state.total = 0;
        state.selectTestItem = [];
        if (state.testItemTypeList.length !== 0) {
            state.testItemTypeList.forEach(e => {
                e.itemList.forEach(ele => {
                    if (ele.check) {
                        state.total += parseFloat(ele.price);
                        state.selectTestItem.push(ele);
                    }
                });
            });
        }
        console.log(state.total);
    },
    /**
     * 存储订单信息
     * @param {*} { commit }
     * @param {*} params
     */
    [Enum.SET_ORDER_INFO]: (state, params) => {
        state.orderInfo = {};
        state.orderInfo = params;
    },
    /**
     * 存储已选检测项目编号
     * @param {*} { commit }
     * @param {*} ids
     */
    [Enum.SET_ITEM_IDS]: (state, ids) => {
        state.orderInfo.ItemIds = [];
        state.orderInfo.ItemIds.push(...ids);
    },
    /**
     * 重置
     * @param {*} { commit }
     */
    [Enum.RESET]: (state) => {
        state.testItemTypeList = [];
        state.testItemPackageList = [];
        state.selectTestItem = [];
        state.orderInfo = {};
        state.total = 0;
    }
}