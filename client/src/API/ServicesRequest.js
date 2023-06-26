import BaseUrl from "./BaseUrl";

export const GetServiceByHotelId = (id) => {
  return BaseUrl.get(`/api/Services/GetServiceByHotelId/${id}`);
};

export const GetServiceDetailsByHotelId = (id) => {
  return BaseUrl.get(`/api/ServiceDetails/GetServiceDetailsByHotelId/${id}`);
};
