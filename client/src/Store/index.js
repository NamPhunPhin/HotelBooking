import { createStore } from "vuex";
import AuthModule from "./AuthModule/index";
import HomeModule from "./HomeModule/index";

const store = createStore({
  state: {
    number: 1,
  },
  modules: {
    Auth: AuthModule,
    Home: HomeModule,
  },
});

export default store;
