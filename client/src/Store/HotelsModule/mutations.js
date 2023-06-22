export default {
  HOTELS_REQUEST_START(state) {
    state.status = {
      isLoading: true,
      isSuccessed: false,
      isError: false,
    };
  },

  HOTELS_REQUEST_SUCCESS(state, data) {
    state.hotels = data.sort((a, b) => b.hotel_id - a.hotel_id);
    state.status = {
      isLoading: false,
      isSuccessed: true,
      isError: false,
    };
  },

  HOTELS_SEARCH(state, data) {
    state.hotelSearching = data;
  },

  MIN_PRICE(state, data) {
    state.filter.min_price = data;
  },
  MAX_PRICE(state, data) {
    state.filter.max_price = data;
  },

  DEFAULT_PRICE(state) {
    state.filter = {
      min_price: 500000,
      max_price: 10000000,
      distance_citycenter: null,
    };
  },

  DEFAULT_FILTER_SEARCH(state) {
    state.hotelSearching = "";
    state.filter = {
      min_price: 500000,
      max_price: 10000000,
      distance_citycenter: null,
      city_id: null,
    };
  },

  FILTER_DISTANCE(state, data) {
    state.filter.distance_citycenter = data;
  },

  UNFILTER_DISTANCE(state) {
    state.filter.distance_citycenter = null;
  },

  FILTER_CITY(state, data) {
    state.filter.city_id = data;
  },

  UNFILTER_CITY(state) {
    state.filter.city_id = null;
  },

  ARRANGER(state, data) {
    state.filter.arrange = data;
  },
};
