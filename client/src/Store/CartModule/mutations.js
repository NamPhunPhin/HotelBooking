import { GET_NUMBER_DATE } from "@/service/FormatService";
import { SetLocalStorage } from "@/service/AccountService";
export default {
  ADD_ROOM_TO_CART(state, data) {
    if (data) {
      let priceMain;
      let numberPeople = data.Room.number_people * data.Info.room_number;
      let peopleExtra;
      let totalPrice;
      if (data.Room.discount != 0) {
        priceMain = data.Room.price_discount;
      } else {
        priceMain = data.Room.price;
      }

      console.log(
        data.Info.adult,
        numberPeople,
        data.Room.number_people,
        data.Info.room_number
      );

      if (data.Info.adult > numberPeople) {
        peopleExtra = data.Info.adult - numberPeople;
        let priceExtra = ((priceMain * 10) / 100) * peopleExtra; //10 là phần trăm cho người dư
        totalPrice =
          (priceMain * data.Info.room_number + priceExtra) *
          GET_NUMBER_DATE(data.Info.checkin, data.Info.checkout);
      } else {
        totalPrice =
          priceMain *
          data.Info.room_number *
          GET_NUMBER_DATE(data.Info.checkin, data.Info.checkout);
      }

      let RoomItem = {
        ...data,
        total: totalPrice,
      };

      SetLocalStorage("Cart", [RoomItem, ...state.Cart]);
      state.Cart = [RoomItem, ...state.Cart];
    }
  },

  DELETE_ONE_ROOM(state, index) {
    state.Cart.splice(index, 1);
    SetLocalStorage("Cart", [...state.Cart]);
  },
};
