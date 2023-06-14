import state from "./state";
import getters from "./getters";
import mutations from "./mutations";
import actions from "./actions";
const namespaced = true;

const HomeModule = {
  namespaced,
  state,
  getters,
  mutations,
  actions,
};

export default HomeModule;
