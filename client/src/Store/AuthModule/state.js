import { GetLocalStorage } from "../../service/AccountService";
const userStorage = GetLocalStorage("user");
const state = userStorage
  ? {
      status: {
        isloading: false,
        isLogined: true,
        isError: false,
      },
      user: userStorage,
      response: { result: true, message: "" },
      errorMessage: "",
    }
  : {
      status: {
        isloading: false,
        isLogined: false,
        isError: false,
      },
      user: {
        address: null,
        avatar: null,
        coin: 0,
        contact_number: null,
        createdAt: null,
        email: null,
        first_name: null,
        last_name: null,
        merchant_id: null,
        role_type_id: null,
        user_id: null,
      },
      response: { result: true, message: "" },
      errorMessage: "",
    };
export default state;
