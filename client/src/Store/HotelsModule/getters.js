export default {
  getHotelsData(state) {
    let hotels = state.hotels;
    if (state.hotelSearching != "") {
      hotels = hotels.filter((hotel) =>
        hotel.name.toLowerCase().includes(state.hotelSearching.toLowerCase())
      );
    }

    if (
      state.filter.min_price != 500000 ||
      state.filter.max_price != 10000000
    ) {
      hotels = hotels.filter(
        (hotel) =>
          (hotel.min_price >= state.filter.min_price &&
            hotel.min_price <= state.filter.max_price) ||
          (hotel.min_price_discount >= state.filter.min_price &&
            hotel.min_price_discount <= state.filter.max_price)
      );
    }

    if (state.filter.distance_citycenter != null) {
      if (
        state.filter.distance_citycenter.min == 0 &&
        state.filter.distance_citycenter.max == 0
      ) {
        hotels = hotels.filter((hotel) => hotel.distance_citycenter == 0);
      }

      if (
        state.filter.distance_citycenter.min == 2 &&
        state.filter.distance_citycenter.max == 0
      ) {
        hotels = hotels.filter(
          (hotel) =>
            hotel.distance_citycenter < state.filter.distance_citycenter.min &&
            hotel.distance_citycenter != 0
        );
      }

      if (
        state.filter.distance_citycenter.min == 2 &&
        state.filter.distance_citycenter.max == 5
      ) {
        hotels = hotels.filter(
          (hotel) =>
            hotel.distance_citycenter >= state.filter.distance_citycenter.min &&
            hotel.distance_citycenter <= state.filter.distance_citycenter.max
        );
      }

      if (
        state.filter.distance_citycenter.min == 5 &&
        state.filter.distance_citycenter.max == 10
      ) {
        hotels = hotels.filter(
          (hotel) =>
            hotel.distance_citycenter >= state.filter.distance_citycenter.min &&
            hotel.distance_citycenter <= state.filter.distance_citycenter.max
        );
      }

      if (
        state.filter.distance_citycenter.min == 0 &&
        state.filter.distance_citycenter.max == 10
      ) {
        hotels = hotels.filter(
          (hotel) =>
            hotel.distance_citycenter >= state.filter.distance_citycenter.max
        );
      }
    }

    if (state.filter.city_id != null) {
      console.log(state.filter.city_id);
      hotels = hotels.filter((hotel) => hotel.city_id == state.filter.city_id);
    }

    if (state.filter.arrange != null) {
      switch (state.filter.arrange) {
        case 0:
          hotels = hotels.sort((a, b) => b.hotel_id - a.hotel_id);
          break;
        case 1:
          hotels = hotels
            .sort((a, b) => a.min_price - b.min_price)
            .filter((hotel) => hotel.min_discount == 0);
          break;

        case 2:
          hotels = hotels
            .sort((a, b) => b.min_price - a.min_price)
            .filter((hotel) => hotel.min_discount == 0);
          break;

        case 4:
          hotels = hotels.filter((hotel) => hotel.min_discount != 0);
          break;

        default:
          hotels = hotels.sort((a, b) => b.CreatedAt - a.CreatedAt);
          break;
      }
    }

    return hotels;
  },
  getHotelsStatus(state) {
    return state.status;
  },

  getHotelsSearching(state) {
    return state.hotelSearching;
  },

  getMaxPrice(state) {
    return state.filter.max_price;
  },

  getMinPrice(state) {
    return state.filter.min_price;
  },

  getDistanceCityCenter(state) {
    return state.filter.distance_citycenter;
  },

  getCityFilter(state) {
    return state.filter.city_id;
  },
};
