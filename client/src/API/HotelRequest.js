import BaseUrl from "./BaseUrl";

export const GetHotelsByCityId = (id) => {
  return BaseUrl.get(`/api/Hotels/GetHotelsByCityId/${id}`);
};
