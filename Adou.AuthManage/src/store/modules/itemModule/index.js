import getters from './getters'
import mutations from './mutations'
import actions from './actions'

const skinModule = {
    state: {
        testItemTypeList: [],
        testItemPackageList: [],
        selectTestItem: [],
        orderInfo: {},
        total: 0
    },
    getters: getters,
    mutations: mutations,
    actions: actions
};

export default skinModule;