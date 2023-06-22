const today = new Date();
const tomorrow = new Date(today);
tomorrow.setDate(today.getDate() + 1);

const state = {
  SearchText: "",
  CheckIn: today.toISOString().slice(0, 10),
  CheckOut: tomorrow.toISOString().slice(0, 10),
  cityId: "",
  countryId: "",
  Rooms: 1,
  AdultPeople: 2,
  ChildrenPeople: 0,
};
export default state;
