import BaseUrl from "./BaseUrl";

export const GetAllCities = () => {
  return BaseUrl.get(`/api/Cities/Get`);
};
