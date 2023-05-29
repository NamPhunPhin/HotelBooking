import { createStore } from "vuex";
import AuthModule from "./AuthModule/index";

const store = createStore({
  state: {
    number: 1,
  },
  modules: {
    Auth: AuthModule,
  },
});

export default store;
