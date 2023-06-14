import BaseUrl from "./BaseUrl";

export const UpdateProfile = (id, data) => {
  return BaseUrl.put(`/api/Users/UpdateProfile/${id}`, data);
};

export const ChangePassword = (id, data) => {
  return BaseUrl.put(`/api/Users/ChangePassword/${id}`, data);
};
