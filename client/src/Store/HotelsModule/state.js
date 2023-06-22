const state = {
  hotelSearching: "",
  hotels: null,
  status: {
    isLoading: false,
    isSuccessed: false,
    isError: false,
  },

  filter: {
    min_price: 500000,
    max_price: 10000000,
    distance_citycenter: null,
    city_id: null,
    arrange: null,
  },
};
export default state;
