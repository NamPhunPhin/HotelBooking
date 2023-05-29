export default {
  getUser(state) {
    return state.user;
  },

  getAuthStatus(state) {
    return state.status;
  },

  getAuthResponse(state) {
    return state.response;
  },
};
