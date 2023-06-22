import {
  GetHotelsByCityId,
  GetHotelsByCountryId,
} from "../../API/HotelRequest";
export default {
  async HotelsCountryRequest({ commit }, county_id) {
    let response;
    await commit("HOTELS_REQUEST_START");
    response = await GetHotelsByCountryId(county_id);
    await commit("HOTELS_REQUEST_SUCCESS", response.data);
  },

  async HotelsCityRequest({ commit }, city_id) {
    let response;
    await commit("HOTELS_REQUEST_START");
    response = await GetHotelsByCityId(city_id);
    await commit("HOTELS_REQUEST_SUCCESS", response.data);
  },
};
