import { GetLocalStorage } from "../../service/AccountService";
const ordersStorage = GetLocalStorage("Order");
const state = ordersStorage
  ? {
      Order: ordersStorage,
      errorMessage: "",
    }
  : {
      Order: null,
      errorMessage: "",
    };
export default state;
