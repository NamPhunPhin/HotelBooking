export default {
  CITY_AND_QUATITY_HOTELS_START(state) {
    state.CitiesAndQuatityHotels.status = {
      isLoading: true,
      isSuccess: false,
      isError: false,
    };
  },

  CITY_AND_QUATITY_HOTELS_SUCCESS(state, data) {
    state.CitiesAndQuatityHotels.data = [...data];
    state.CitiesAndQuatityHotels.status = {
      isLoading: false,
      isSuccess: true,
      isError: false,
    };
  },

  CITY_AND_QUATITY_HOTELS_ERROR(state) {
    state.CitiesAndQuatityHotels.status = {
      isLoading: false,
      isSuccess: false,
      isError: true,
    };
  },

  GET_HOTELS_BY_CITY_ID_START(state) {
    state.Hotels.status = {
      isLoading: true,
      isSuccess: false,
      isError: false,
    };
  },

  GET_HOTELS_BY_CITY_ID_SUCCESS(state, data) {
    state.Hotels.data = [...data];
    state.Hotels.status = {
      isLoading: false,
      isSuccess: true,
      isError: false,
    };
  },

  GET_HOTELS_BY_CITY_ID_ERROR(state) {
    state.Hotels.status = {
      isLoading: false,
      isSuccess: false,
      isError: true,
    };
  },

  COUNTRIES_OUTSIDE_AND_HOTELS_START(state) {
    state.CountriesAndQuatityHotels.status = {
      isLoading: true,
      isSuccess: false,
      isError: false,
    };
  },

  COUNTRIES_OUTSIDE_AND_HOTELS_SUCCESS(state, data) {
    state.CountriesAndQuatityHotels.data = [...data];
    state.CountriesAndQuatityHotels.status = {
      isLoading: false,
      isSuccess: true,
      isError: false,
    };
  },

  COUNTRIES_OUTSIDE_AND_HOTELS_ERROR(state) {
    state.CountriesAndQuatityHotels.status = {
      isLoading: false,
      isSuccess: false,
      isError: true,
    };
  },
};
