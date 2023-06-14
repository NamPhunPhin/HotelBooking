import BaseUrl from "./BaseUrl";

export const GetQuatityHotelsInTheCityById = (id) => {
  return BaseUrl.get(`/api/Countries/GetQuatityHotelsInTheCityById/${id}`);
};

export const GetQuatityHotelsInTheCountryOutSite = (id) => {
  return BaseUrl.get(`/api/Countries/CountryOutSide/${id}`);
};
