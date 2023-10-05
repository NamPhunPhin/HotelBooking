export default {
  AUTH_REQUEST(state) {
    state.status = {
      isloading: true,
      isLogined: false,
      isError: false,
      isAdmin: false,
    };
    state.user = null;
  },

  AUTH_SUCCESS(state, data) {
    if (data.data.role_type_id == 8) {
      state.status = {
        isloading: false,
        isLogined: true,
        isError: false,
        isAdmin: true,
      };
    } else {
      state.status = {
        isloading: false,
        isLogined: true,
        isError: false,
        isAdmin: false,
      };
    }
    state.response = { result: data.result, message: data.message };
    state.user = data.data;
  },

  AUTH_FAIL(state, error) {
    state.status = {
      isloading: false,
      isLogined: false,
      isError: true,
      isAdmin: false,
    };
    state.user = null;
    state.errorMessage = error;
  },

  AUTH_LOGOUT(state) {
    state.status = {
      isloading: false,
      isLogined: false,
      isError: false,
      isAdmin: false,
    };
    state.user = null;
    state.response = { result: true, message: "" };
    state.errorMessage = "";
  },

  UPDATE_USER(state, data) {
    state.user = data;
  },
};
