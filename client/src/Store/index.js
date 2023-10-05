import { createStore } from "vuex";
import AuthModule from "./AuthModule/index";
import HomeModule from "./HomeModule/index";
import SearchModule from "./SearchModule/index";
import HotelsModule from "./HotelsModule/index";
import CartModule from "./CartModule/index";
import OrdersModule from "./OrderModule";

const store = createStore({
  modules: {
    Auth: AuthModule,
    Home: HomeModule,
    Search: SearchModule,
    Hotels: HotelsModule,
    Cart: CartModule,
    Orders: OrdersModule,
  },
});

export default store;
