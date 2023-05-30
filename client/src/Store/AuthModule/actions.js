import { SignUp, LogIn } from "../../API/AuthRequests";
import { SetLocalStorage } from "../../service/AccountService";
export default {
  async SignUpAction({ commit }, data) {
    commit("AUTH_REQUEST");
    try {
      const SignUpResponse = await SignUp(data);
      await SetLocalStorage("user", SignUpResponse.data.data);
      await commit("AUTH_SUCCESS", SignUpResponse.data);
    } catch (error) {
      await commit("AUTH_FAIL", error);
    }
  },

  async LogInAction({ commit }, data) {
    commit("AUTH_REQUEST");
    try {
      const LogInResponse = await LogIn(data);
      await SetLocalStorage("user", LogInResponse.data.data);
      await commit("AUTH_SUCCESS", LogInResponse.data);
    } catch (error) {
      await commit("AUTH_FAIL", error);
    }
  },
};
