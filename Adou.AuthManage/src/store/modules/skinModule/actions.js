import Vue from 'vue'
import Enum from './mutation-enum.js'

export default {
    SetHeaderBg: ({ commit}, params) => {
        commit(Enum.SET_HEADER_BG, params);
    }
}