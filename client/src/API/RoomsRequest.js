import BaseUrl from "./BaseUrl";

export const GetRoomByHotelId = (id) => {
  return BaseUrl.get(`/api/Rooms/getRoomsByHotelId/${id}`);
};
