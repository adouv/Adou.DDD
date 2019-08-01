import Enum from './mutation-enum.js'

export default {
    testItemTypeListAction({ commit }, list) {
        commit(Enum.TEST_ITEM_TYPE_LIST, list);
    },
    testItemPackageListAction({ commit }, list) {
        commit(Enum.TEST_ITEM_PACKAGE_LIST, list);
    },
    setTestItemTypeItemAction({ commit }, item) {
        commit(Enum.SET_TEST_ITEM_TYPE_ITEM, item);
    },
    setTestItemAction({ commit }, params) {
        commit(Enum.SET_TEST_ITEM, params);
    },
    setTestItemPackageItemAction({ commit }, item) {
        commit(Enum.SET_TEST_ITEM_PACKAGE_ITEM, item);
    },
    /**
     * 存储订单信息
     * @param {*} { commit }
     * @param {*} params
     */
    orderInfoAction({ commit }, params) {
        commit(Enum.SET_ORDER_INFO, params);
    },
    /**
     * 存储已选检测项目编号
     * @param {*} { commit }
     * @param {*} ids
     */
    itemIDsAction({ commit }, ids) {
        commit(Enum.SET_ITEM_IDS, ids);
    },
    /**
     * 重置
     * @param {*} { commit }
     */
    resetAction({ commit }) {
        commit(Enum.RESET);
    }
}