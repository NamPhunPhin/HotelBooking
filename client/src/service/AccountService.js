export const SetLocalStorage = (name, data) => {
  localStorage.setItem(name, JSON.stringify(data));
};

export const GetLocalStorage = (name) => {
  return JSON.parse(localStorage.getItem(name));
};
