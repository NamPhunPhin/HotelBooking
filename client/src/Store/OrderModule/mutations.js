import {
  SetLocalStorage
} from "@/service/AccountService";
export default {
  
  ORDER_ADD_SUCCESS(state, data) {
    state.Order = data;
  },

  ORDER_ADD_FAIL(state, error) {
    state.Order = null;
    state.errorMessage = error;
  },

  ORDER_DETAILS_FAIL(state, error) {
    state.Order = null;
    state.errorMessage = error;
  },

  GET_ORDERS_BY_USER_ID_ERROR(state, error) {
    state.Order = null;
    state.errorMessage = error;
  },

  DELETE_ONE_ORDER(state, index) {
    state.Order.splice(index, 1);
    SetLocalStorage("Orders", [...state.Order]);
  },
};
