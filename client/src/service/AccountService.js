export const SetLocalStorage = (name, data) => {
  localStorage.setItem(name, JSON.stringify(data));
};

export const GetLocalStorage = (name) => {
  return JSON.parse(localStorage.getItem(name));
};

export const UpdateUserLocalStorage = (data) => {
  let userUpdateData = GetLocalStorage("user");
  userUpdateData.address = data.address ? data.address : userUpdateData.address;
  userUpdateData.avatar = data.avatar ? data.avatar : userUpdateData.avatar;
  userUpdateData.coin = data.coin ? data.coin : userUpdateData.coin;
  userUpdateData.contact_number = data.contact_number
    ? data.contact_number
    : userUpdateData.contact_number;
  userUpdateData.first_name = data.first_name
    ? data.first_name
    : userUpdateData.first_name;
  userUpdateData.last_name = data.last_name
    ? data.last_name
    : userUpdateData.last_name;
  userUpdateData.merchant_id = data.merchant_id
    ? data.merchant_id
    : userUpdateData.merchant_id;
  userUpdateData.role_type_id = data.role_type_id
    ? data.role_type_id
    : userUpdateData.role_type_id;

  SetLocalStorage("user", userUpdateData);
};

export const ClearLocalStorage = () => {
  localStorage.clear();
};
