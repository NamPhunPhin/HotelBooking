import {
  GetQuatityHotelsInTheCityById,
  GetQuatityHotelsInTheCountryOutSite,
} from "../../API/CountriesRequest";
import { GetHotelsByCityId } from "../../API/HotelRequest";
export default {
  async CitiesAndQuatityHotelsAction({ commit }, id) {
    await commit("CITY_AND_QUATITY_HOTELS_START");
    const response = await GetQuatityHotelsInTheCityById(id);
    if (response.data.result == true) {
      await commit("CITY_AND_QUATITY_HOTELS_SUCCESS", response.data.data);
    } else {
      await commit("CITY_AND_QUATITY_HOTELS_ERROR");
    }
  },

  async GetHotelsByCityId({ commit }, id) {
    await commit("GET_HOTELS_BY_CITY_ID_START");
    const response = await GetHotelsByCityId(id);
    if (response.data.result != false) {
      await commit("GET_HOTELS_BY_CITY_ID_SUCCESS", response.data);
    } else {
      await commit("GET_HOTELS_BY_CITY_ID_ERROR");
    }
  },

  async CountriesOutSideAndHotelsAction({ commit }, id) {
    await commit("COUNTRIES_OUTSIDE_AND_HOTELS_START");
    const response = await GetQuatityHotelsInTheCountryOutSite(id);
    if (response.data) {
      await commit("COUNTRIES_OUTSIDE_AND_HOTELS_SUCCESS", response.data);
    } else {
      await commit("COUNTRIES_OUTSIDE_AND_HOTELS_ERROR");
    }
  },
};
