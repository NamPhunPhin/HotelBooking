<template>
  <div class="RoomList-Container">
    <div class="Left-Site">
      <img
        :src="
          roomData.thumbnail
            ? IMAGE_PATH + roomData.thumbnail
            : '/images/room4.jpg'
        "
        alt=""
      />
      <h6>1 giường king hoặc 2 giường đơn</h6>
      <ul>
        <li>
          <i class="fa-solid fa-house"></i> Diện tích phòng:
          {{ roomData.room_area }} m²
        </li>
        <li v-for="(item, index) in AmenitiesShow" :key="index">
          <span v-html="item.icon"></span>
          {{ " " + item.name }}
        </li>
        <li
          class="text-danger More-Amenities"
          @mouseover="PopUpHandleMouseOver(roomData.room_type_id)"
          @mouseout="PopUpHandleMouseOut(roomData.room_type_id)"
        >
          <span><i class="fa-solid fa-flag"></i> Các tiện ích khác</span>
          <div
            class="PopUpAmenities"
            :id="`Amenity_PopUp_${roomData.room_type_id}`"
          >
            <div
              class="Amenities-Item"
              v-for="(item, index) in AmenitiesAll"
              :key="index"
            >
              <span v-html="item.icon"></span> {{ " " + item.name }}
            </div>
          </div>
        </li>
      </ul>
    </div>
    <div class="Right-Site">
      <div class="Nav-Type">
        <div>Tóm Tăt</div>
        <div>Sức Chứa</div>
        <div>Giá Phòng</div>
      </div>

      <div class="Room-List">
        <div
          class="Room-Item"
          v-for="(item, index) in roomData.rooms"
          :key="index"
        >
          <div>
            {{ item.description }}
          </div>
          <div class="text-center">
            <span v-for="(number, index) in item.number_people" :key="index">
              <i class="fa-solid fa-user"></i>&nbsp;</span
            >
          </div>
          <div class="Buy-Area">
            <div>
              <div
                v-if="!item.discount"
                v-show="item.quatity <= 10"
                class="Quatity_Room Quatity_Room-Align"
              >
                <span v-if="item.quatity == 1"
                  >Hiện tại, chỉ còn lại {{ item.quatity }} phòng cuối cùng
                  !</span
                >

                <span v-else-if="item.quatity == 0"
                  >Hiện tại, đã hết phòng trống !</span
                >

                <span v-else
                  >Hiện tại, chỉ còn lại {{ item.quatity }} phòng trống !</span
                >
              </div>
              <div v-show="item.discount">
                <span>{{ item.discount }}%</span>
              </div>
              <div>
                <strike v-show="item.discount">{{
                  FormatCurrency(item.price)
                }}</strike>
                <div class="Price-Room">
                  {{
                    item.discount
                      ? FormatCurrency(item.price_discount)
                      : FormatCurrency(item.price)
                  }}
                </div>
              </div>
            </div>
            <div>
              <div
                v-if="item.discount"
                v-show="item.quatity <= 10"
                class="Quatity_Room"
              >
                <span v-if="item.quatity == 1"
                  >Hiện tại, chỉ còn lại {{ item.quatity }} phòng cuối cùng
                  !</span
                >

                <span v-else-if="item.quatity == 0"
                  >Hiện tại, đã hết phòng trống !</span
                >

                <span v-else
                  >Hiện tại, chỉ còn lại {{ item.quatity }} phòng trống !</span
                >
              </div>
              <router-link to="/payment"
                ><button class="buy-now" @click="BuyNowHandleClick(item)">
                  Đặt Ngay
                </button></router-link
              >
              <button @click="AddToCartHandleClick(item)">
                Thêm Vào Đẩy Hàng
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <vue-basic-alert :duration="300" :closeIn="3000" ref="alert" />
</template>

<script>
import { FormatCurrency } from "@/service/FormatService";
import { mapGetters, mapMutations } from "vuex";
import VueBasicAlert from "vue-basic-alert";

export default {
  name: "RoomListComponent",
  components: {
    VueBasicAlert,
  },
  props: ["roomData", "hotelData"],
  data() {
    return {
      IMAGE_PATH: process.env.VUE_APP_IMAGE_PATH,
    };
  },

  methods: {
    ...mapMutations("Cart", ["ADD_ROOM_TO_CART"]),

    AlertShow(type, hearder, message) {
      this.$refs.alert.showAlert(
        type, // There are 4 types of alert: success, info, warning, error

        message, // Message of the alert
        hearder // Header of the alert
      );
    },

    AddToCartHandleClick(room) {
      let RoomData = {
        Room_Type: this.roomData,
        Hotel: this.hotelData,
        Room: room,
        Info: {
          checkin: this.getSearching.CheckIn,
          checkout: this.getSearching.CheckOut,
          room_number: this.getSearching.Rooms,
          adult: this.getSearching.AdultPeople,
          children: this.getSearching.ChildrenPeople,
        },
      };

      this.ADD_ROOM_TO_CART(RoomData);

      this.AlertShow(
        "success",
        "Thành Công",
        "Đã thêm vào giỏ hàng thành công."
      );
    },

    BuyNowHandleClick(room) {
      let RoomData = {
        Room_Type: this.roomData,
        Hotel: this.hotelData,
        Room: room,
        Info: {
          checkin: this.getSearching.CheckIn,
          checkout: this.getSearching.CheckOut,
          room_number: this.getSearching.Rooms,
          adult: this.getSearching.AdultPeople,
          children: this.getSearching.ChildrenPeople,
        },
      };

      this.ADD_ROOM_TO_CART(RoomData);
    },

    FormatCurrency(number) {
      return FormatCurrency(number);
    },

    PopUpHandleMouseOver(id) {
      const popUp = document.getElementById(`Amenity_PopUp_${id}`);
      popUp.style.display = "grid";
    },

    PopUpHandleMouseOut(id) {
      const popUp = document.getElementById(`Amenity_PopUp_${id}`);
      popUp.style.display = "none";
    },
  },

  computed: {
    ...mapGetters("Search", ["getSearching"]),
    ...mapGetters("Cart", ["getCart"]),

    AmenitiesShow() {
      return this.roomData.amenities.filter(
        (amenities) => amenities.show == true
      );
    },

    AmenitiesAll() {
      return this.roomData.amenities.filter(
        (amenities) => amenities.show != true
      );
    },
  },
};
</script>

<style>
.RoomList-Container {
  display: grid;
  grid-template-columns: 20% 78%;
  gap: 2%;
}

.Left-Site > img {
  width: 100%;
}

.Left-Site > h6 {
  font-weight: 700;
  font-family: unset;
  margin: 10px 0;
}

.Left-Site > ul {
  list-style: none;
  padding: 0;
  margin: 0;
  display: flex;
  font-size: 13px;
  flex-direction: column;
  gap: 0.5rem;
  color: rgb(117, 111, 111);
  font-weight: 600;
}

.Right-Site {
  display: flex;
  flex-direction: column;
  gap: 5px;
}

.Nav-Type {
  display: flex;
  justify-content: space-between;
  align-items: center;
  gap: 5px;
}

.Nav-Type > div:nth-of-type(2) {
  width: 20%;
  background: white;
}

.Nav-Type > div {
  width: 40%;
  background: white;
  padding: 10px;
  border-radius: 10px;
  text-align: center;
  font-weight: bold;
}

.Room-List {
  height: 100%;
  display: flex;
  flex-direction: column;
  width: 100%;
  border-radius: 10px;
}

.Room-Item {
  height: 100%;
  margin: 5px 0;
  background: white;
  padding: 10px;
  display: grid;
  grid-template-columns: 39% 20% 39%;
  gap: 1%;
  border-radius: 10px;
}

.Room-Item:hover {
  box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
}

.Room-Item > div {
  background: rgb(245, 247, 250);
  border-radius: 10px;
  padding: 10px;
  width: 100%;
  border-radius: 10px;
}

.Buy-Area {
  display: flex;
  justify-content: center;
  align-items: end;
  gap: 0.5rem;
}

.Buy-Area > div {
  width: 50%;
}

.Buy-Area > div:nth-of-type(1) {
  text-align: end;
}

.Buy-Area > div:nth-of-type(1) > div:nth-of-type(1) > span {
  background: lightskyblue;
  padding: 5px 10px;
  border-radius: 5px;
  font-weight: bold;
  color: white;
}

.Buy-Area > div:nth-of-type(1) > div:nth-of-type(2) > strike {
  font-size: 14px;
}

.Buy-Area > div:nth-of-type(1) > div:nth-of-type(2) {
  font-size: 20px;
  margin-top: 10px;
}

.Buy-Area > div:nth-of-type(2) > button:nth-of-type(1) {
  border: none;
  width: 100%;
  font-weight: bold;
  background: var(--main-Color);
  padding: 10px;
  color: white;
  margin-top: 10px;
  border-radius: 5px;
}

.Buy-Area > div:nth-of-type(2) > button:nth-of-type(2) {
  border: none;
  width: 100%;
  font-weight: bold;
  background: lightseagreen;
  padding: 10px;
  color: white;
  margin-top: 10px;
  border-radius: 5px;
}

.buy-now {
  border: none;
  width: 100%;
  font-weight: bold;
  background: var(--main-Color);
  padding: 10px;
  color: white;
  margin-top: 10px;
  border-radius: 5px;
}

.More-Amenities {
  position: relative;
  cursor: pointer;
}

.PopUpAmenities {
  box-shadow: rgba(100, 100, 111, 0.2) 0px 7px 29px 0px;
  display: grid;
  width: 500px;
  grid-template-columns: 50% 50%;
  background: white;
  padding: 20px;
  position: absolute;
  border-radius: 10px;
  bottom: 0;
  left: 100%;
  gap: 1rem;
  display: none;
  z-index: 9999;
  height: 450px;
  overflow-y: auto;
  overflow-x: hidden;
}

.PopUpAmenities::-webkit-scrollbar {
  display: none;
}

.Amenities-Item {
  font-size: 14px;
  font-weight: 500;
}

.Price-Room {
  font-size: 25px;
  font-weight: bold;
  color: var(--main-Color);
}

.Quatity_Room {
  font-weight: 700;
  font-size: 13px;
  text-align: center;
  color: darkblue;
}

.Quatity_Room-Align {
  text-align: end !important;
  padding: 20px 10px;
}

.Quatity_Room > span {
  background: transparent !important;
  color: darkblue !important;
  text-align: right !important;
}
</style>
