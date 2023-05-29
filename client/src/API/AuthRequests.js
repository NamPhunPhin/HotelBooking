import BaseUrl from "./BaseUrl";

export const SignUp = (data) => {
  return BaseUrl.post("/api/Auth/SignUp", data);
};

export const LogIn = (data) => {
  return BaseUrl.post("/api/Auth/LogIn", data);
};
