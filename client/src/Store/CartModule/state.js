import { GetLocalStorage } from "../../service/AccountService";
const cartStorage = GetLocalStorage("Cart");
const state = cartStorage
  ? {
      Cart: cartStorage,
    }
  : {
      Cart: [],
    };
export default state;
