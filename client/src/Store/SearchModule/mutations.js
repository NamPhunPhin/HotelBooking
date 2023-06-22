export default {
  UpdateSearch(state, data) {
    state.SearchText = data.SearchText;
    state.CheckIn = data.CheckIn;
    state.cityId = data.cityId;
    state.countryId = data.countryId;
    state.CheckOut = data.CheckOut;
    state.Rooms = data.Rooms;
    state.AdultPeople = data.AdultPeople;
    state.ChildrenPeople = data.ChildrenPeople;
  },
};
