import { GetLocalStorage } from "../../service/AccountService";
const userStorage = GetLocalStorage("user");
const state = userStorage
  ? {
      status: {
        isloading: false,
        isLogined: true,
        isError: false,
        isAdmin: false,
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
        isAdmin: false,
      },
      user: null,
      response: { result: true, message: "" },
      errorMessage: "",
    };
export default state;
