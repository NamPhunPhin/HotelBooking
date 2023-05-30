import state from "./state";
import getters from "./getters";
import mutations from "./mutations";
import actions from "./actions";
const namespaced = true;

const AuthModule = {
  namespaced,
  state,
  getters,
  mutations,
  actions,
};

export default AuthModule;
