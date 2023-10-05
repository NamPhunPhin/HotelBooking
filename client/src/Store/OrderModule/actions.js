import { AddOrder, AddOrderDetails } from "@/API/OrderRequests";
import { SetLocalStorage } from "../../service/AccountService";

export default {
  async AddOrderAction({ commit }, data) {
    try {
      var response = await AddOrder(data);
      SetLocalStorage("Order", response.data.data);
      await commit("ORDER_ADD_SUCCESS", response.data.data);
    } catch (error) {
      await commit("ORDER_ADD_FAIL", error);
    }
  },

  async AddOrderDetailsAction({ commit }, data) {
    try {
      await AddOrderDetails(data);
    } catch (error) {
      await commit("ORDER_DETAILS_FAIL", error);
    }
  },
};
