
import getters from './getters'
import mutations from './mutations'
import actions from './actions'

const skinModule = {
    state: {
        headerBgColor:'#409EFF',
        headerTextColor:'#FFF'
    },
    getters: getters,
    mutations: mutations,
    actions: actions
};

export default skinModule;