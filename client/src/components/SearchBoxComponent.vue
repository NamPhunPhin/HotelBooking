<template>
  <div class="Search-Box-Container">
    <div class="Title"><i class="fa-solid fa-hotel"></i> Khách Sạn</div>
    <div class="Search-Switch">
      <div
        :class="isOverNight && 'SwitchSearch-Active'"
        @click="
          () => {
            if (!isOverNight) {
              isOverNight = !isOverNight;
            }
          }
        "
      >
        Chổ ở qua đêm
      </div>
      <div
        :class="!isOverNight && 'SwitchSearch-Active'"
        @click="
          () => {
            if (isOverNight) {
              isOverNight = !isOverNight;
            }
          }
        "
      >
        Chổ ở trong ngày
      </div>
    </div>

    <form action="">
      <div class="row">
        <div v-if="!isOverNight" class="mb-4">
          <span class="text-danger">Chỗ Ở Trong Ngày</span> là phòng cho thuê
          không đắt, 4-12 tiếng mà không phải qua đêm. Quý khách sẽ nhận phòng
          và trả phòng vào cùng một ngày.
        </div>
        <div class="Location-Search col-lg-12">
          <i class="fa-solid fa-magnifying-glass"></i>
          <input
            type="text"
            @focus="PopUpSuggestHandleFocus()"
            placeholder="Nhập địa diểm du lịch hoặc tên khách sạn"
          />

          <div class="Suggest-Searching" v-if="isPopUpSuggest">
            <ul>
              <li>
                <i class="fa-solid fa-location-dot"></i>
                <div class="Suggest-Text">
                  <div>Da Lat, Viet Nam</div>
                  <div>Thành Phố</div>
                </div>
              </li>
            </ul>
          </div>
        </div>
        <div class="Input-Form">
          <div
            class="Check-In-Out"
            :style="!isOverNight && 'padding-left: 30px'"
          >
            <div
              :class="isOverNight ? 'In' : 'In w-100'"
              @click="CheckInOpenHandleClick()"
            >
              <i class="fa-solid fa-calendar-days"></i>
              <!-- <div>Ngày nhận phòng</div> -->
              <div :class="!isOverNight && 'w-100'">
                <div>
                  {{
                    DateCheckInFormat ? DateCheckInFormat : "Ngày nhận phòng"
                  }}
                </div>
                <div class="sub-text" v-if="DayCheckInFormat">
                  {{ DayCheckInFormat }}
                  <span v-if="!isOverNight"
                    >| Trả phòng trong ngày (tối đa 8 tiếng)</span
                  >
                </div>
              </div>
              <input type="date" ref="CheckIn" v-model="DataSearch.CheckIn" />
            </div>
            <i v-if="isOverNight" class="fa-solid fa-minus"></i>
            <div
              v-if="isOverNight"
              class="Out"
              @click="CheckOutOpenHandleClick()"
            >
              <i class="fa-solid fa-calendar-days"></i>
              <!-- <div>Ngày trả phòng</div> -->
              <div>
                <div>
                  {{
                    DateCheckOutFormat ? DateCheckOutFormat : "Ngày trả phòng"
                  }}
                </div>
                <div class="sub-text" v-if="DayCheckOutFormat">
                  {{ DayCheckOutFormat }}
                </div>
              </div>
              <input type="date" ref="CheckOut" v-model="DataSearch.CheckOut" />
            </div>
          </div>
          <div class="Quatity" @click="PopUpQuatityHandleClick()">
            <i class="fa-solid fa-people-group"></i>
            <div>
              <div>
                {{ DataSearch.AdultPeople }} người lớn
                <span v-if="DataSearch.ChildrenPeople > 0"
                  >, {{ DataSearch.ChildrenPeople }} trẻ em</span
                >
              </div>
              <div class="sub-text">{{ DataSearch.Rooms }} phòng</div>
            </div>
            <i class="fa-solid fa-caret-down"></i>
            <div class="Quantity-Control" v-if="isPopUpQuatity">
              <ul>
                <li>
                  <div>Phòng</div>
                  <div class="Control-Up-Down">
                    <span
                      @click="() => DataSearch.Rooms > 0 && DataSearch.Rooms--"
                      ><i
                        :class="
                          DataSearch.Rooms > 0
                            ? 'fa-solid fa-circle-minus text-danger'
                            : 'fa-solid fa-circle-minus text-muted'
                        "
                      ></i
                    ></span>
                    <span>{{ DataSearch.Rooms }}</span>
                    <span @click="() => DataSearch.Rooms++"
                      ><i class="fa-solid fa-circle-plus text-danger"></i
                    ></span>
                  </div>
                </li>
                <li>
                  <div>Người lớn</div>
                  <div class="Control-Up-Down">
                    <span
                      @click="
                        () =>
                          DataSearch.AdultPeople > 0 && DataSearch.AdultPeople--
                      "
                      ><i
                        :class="
                          DataSearch.AdultPeople > 0
                            ? 'fa-solid fa-circle-minus text-danger'
                            : 'fa-solid fa-circle-minus text-muted'
                        "
                      ></i
                    ></span>
                    <span>{{ DataSearch.AdultPeople }}</span>
                    <span @click="() => DataSearch.AdultPeople++"
                      ><i class="fa-solid fa-circle-plus text-danger"></i
                    ></span>
                  </div>
                </li>
                <li>
                  <div>Trẻ em</div>
                  <div class="Control-Up-Down">
                    <span
                      @click="
                        () =>
                          DataSearch.ChildrenPeople > 0 &&
                          DataSearch.ChildrenPeople--
                      "
                      ><i
                        :class="
                          DataSearch.ChildrenPeople > 0
                            ? 'fa-solid fa-circle-minus text-danger'
                            : 'fa-solid fa-circle-minus text-muted'
                        "
                      ></i
                    ></span>
                    <span>{{ DataSearch.ChildrenPeople }}</span>
                    <span @click="() => DataSearch.ChildrenPeople++"
                      ><i class="fa-solid fa-circle-plus text-danger"></i
                    ></span>
                  </div>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
      <button class="Button-Main Search-Button" @click="SearchHandleClick">
        Tìm
      </button>
    </form>
    <div
      v-if="isFocusLayout"
      class="Focus-Layout"
      @click="FocusLayoutHandleClick()"
    ></div>
  </div>
</template>

<script>
export default {
  name: "SearchBoxComponent",
  data() {
    return {
      isPopUpSuggest: false,
      isFocusLayout: false,
      isPopUpQuatity: false,
      isOverNight: true,
      DataSearch: {
        SearchText: "",
        CheckIn: "",
        cityId: 2,
        countryId: 1,
        CheckOut: "",
        Rooms: 1,
        AdultPeople: 2,
        ChildrenPeople: 0,
      },
    };
  },
  methods: {
    CheckInOpenHandleClick() {
      this.$refs.CheckIn.showPicker();
      this.isFocusLayout = true;
      this.isPopUpQuatity = false;
      this.isPopUpSuggest = false;
    },

    CheckOutOpenHandleClick() {
      this.$refs.CheckOut.showPicker();
      this.isFocusLayout = true;
      this.isPopUpQuatity = false;
      this.isPopUpSuggest = false;
    },

    DateFormat(DateInput) {
      var date = new Date(DateInput);
      if (DateInput != "") {
        return `${date.getDate()} tháng ${
          date.getMonth() + 1
        } ${date.getFullYear()}`;
      } else {
        return null;
      }
    },

    DayFormat(DayInput) {
      var DayResult = null;
      if (DayInput != "") {
        var date = new Date(DayInput);
        switch (date.getDay()) {
          case 0:
            DayResult = "Chủ Nhật";
            break;
          case 1:
            DayResult = "Thứ Hai";
            break;
          case 2:
            DayResult = "Thứ Ba";
            break;
          case 3:
            DayResult = "Thứ Tư";
            break;
          case 4:
            DayResult = "Thứ Năm";
            break;
          case 5:
            DayResult = "Thứ Sáu";
            break;
          case 6:
            DayResult = "Thứ Bảy";
            break;
        }
      } else {
        DayResult = null;
      }

      return DayResult;
    },

    PopUpSuggestHandleFocus() {
      this.isPopUpSuggest = true;
      this.isFocusLayout = true;
      this.isPopUpQuatity = false;
    },

    FocusLayoutHandleClick() {
      this.isPopUpSuggest = false;
      this.isFocusLayout = false;
      this.isPopUpQuatity = false;
    },

    PopUpQuatityHandleClick() {
      this.isPopUpQuatity = true;
      this.isFocusLayout = true;
      this.isPopUpSuggest = false;
    },
    // Khi bấm Tìm.
    SearchHandleClick(e) {
      e.preventDefault();
      this.$router.push(
        `/hotels/${this.DataSearch.CheckIn}/${this.DataSearch.CheckOut}/${this.DataSearch.countryId}/${this.DataSearch.cityId}/${this.DataSearch.AdultPeople}/${this.DataSearch.ChildrenPeople}/${this.DataSearch.Rooms}`
      ); //Điều hướng
    },
  },

  computed: {
    DateCheckInFormat() {
      var checkIn = this.DataSearch.CheckIn;
      return this.DateFormat(checkIn);
    },

    DateCheckOutFormat() {
      var checkOut = this.DataSearch.CheckOut;
      return this.DateFormat(checkOut);
    },

    DayCheckInFormat() {
      var checkIn = this.DataSearch.CheckIn;
      return this.DayFormat(checkIn);
    },

    DayCheckOutFormat() {
      var checkOut = this.DataSearch.CheckOut;
      return this.DayFormat(checkOut);
    },
  },
};
</script>

<style>
.Input-Form {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 0 !important;
  gap: 20px;
}

.Search-Box-Container {
  font-weight: 500;
  position: relative;
  min-width: 580px;
  background-color: aqua;
  padding: 32px 48px 64px;
  width: 70%;
  box-shadow: rgba(0, 0, 0, 0.2) 0px 2px 8px 3px;
  border-radius: 16px;
  background-color: rgb(248, 247, 249);
  right: 15%;
  left: 15%;
}

.Search-Box-Container > .Title {
  width: 30%;
  position: absolute;
  top: -25px;
  left: 35%;
  right: 35%;
  box-shadow: rgba(0, 0, 0, 0.2) 0px 2px 8px 3px;
  border-radius: 16px;
  background-color: rgb(248, 247, 249);
  /* padding: 10px; */
  line-height: 50px;
  text-align: center;
  color: var(--main-Color);
  z-index: 999;
}

.Focus-Layout {
  background-color: #000;
  bottom: 0;
  left: 0;
  opacity: 0.65;
  position: fixed;
  right: 0;
  top: 0;
  z-index: 995;
}

.Search-Switch > div {
  background: rgb(255, 255, 255);
  border-radius: 999px;
  padding: 0 16px;
  cursor: pointer;
  line-height: 36px;
  border: var(--border-Input);
  margin: 20px 0;
  z-index: 999;
}

.Search-Switch > div:hover {
  background: rgb(255, 255, 255);
  border: 1px solid var(--main-Color);
  color: var(--main-Color);
  transition: background-color 0s ease 0s, outline-color 0.2s ease-in-out 0s,
    border-color 0.2s ease-in-out 0s;
  fill: var(--main-Color);
}

.SwitchSearch-Active {
  background: rgb(255, 255, 255);
  border: 1px solid var(--main-Color) !important;
  color: var(--main-Color);
  transition: background-color 0s ease 0s, outline-color 0.2s ease-in-out 0s,
    border-color 0.2s ease-in-out 0s;
  fill: var(--main-Color);
}

.Search-Switch {
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 1rem;
}

.Location-Search {
  position: relative;
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
  border: var(--border-Input);
  height: 66px;
  border-radius: 5px;
  background: white;
  gap: 0.5rem;
  margin-bottom: 20px;
  z-index: 1000;
}

.Location-Search > i {
  font-size: 25px;
  margin-left: 20px;
}

.Location-Search > input {
  width: 100%;
  background: none;
  border: none;
  font-size: 20px;
  margin-right: 20px;
}

.Location-Search > input:focus {
  outline: none;
}

.Suggest-Searching {
  position: absolute;
  background: white;
  padding: 10px 0;
  top: 120%;
  width: 100%;
  border-radius: 8px;
  box-sizing: border-box;
  line-height: 18.8343px;
  overflow-x: hidden;
  overflow-y: hidden;
  z-index: 999;
}

.Suggest-Searching > ul {
  list-style: none;
  display: flex;
  flex-direction: column;
  width: 100%;
  padding: 0px !important;
  margin: 0 !important;
}

.Suggest-Searching > ul > li {
  list-style: none;
  display: flex;
  flex-direction: row;
  align-items: center;
  width: 100%;
  gap: 1rem;
  padding: 10px !important;
  margin: 0 !important;
  cursor: pointer;
}

.Suggest-Searching > ul > li:hover {
  background: var(--main-Color);
  color: white;
}

.Suggest-Searching > ul > li > i {
  font-size: 20px;
}

.Suggest-Searching > ul > li > i {
  font-size: 20px;
}

.Suggest-Text > div:nth-of-type(2) {
  font-weight: normal !important;
  font-size: 13px;
}

.Check-In-Out {
  display: flex;
  align-items: center;
  gap: 2rem;
  background: white;
  border: var(--border-Input);
  min-height: 66px;
  border-radius: 5px;
  background: white;
  width: 50%;
  z-index: 999;
}

.Check-In-Out > .In {
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 1rem;
  width: 50%;
  cursor: pointer;
}

.Check-In-Out > .Out {
  display: flex;
  justify-content: center;
  align-items: center;
  width: 50%;
  gap: 1rem;
  cursor: pointer;
}

.Check-In-Out > .Out > input {
  position: absolute;
  visibility: hidden;
  height: 66px;
  width: 200px;
}

.Check-In-Out > .In > input {
  position: absolute;
  visibility: hidden;
  height: 66px;
  width: 200px;
}

.Check-In-Out > .In > i {
  font-size: 20px;
}

.Check-In-Out > .Out > i {
  font-size: 20px;
}

.Quatity {
  background: white;
  display: flex;
  flex-direction: row;
  align-items: center;
  gap: 1rem;
  border: var(--border-Input);
  min-height: 66px;
  border-radius: 5px;
  width: 50%;
  padding: 0 30px;
  cursor: pointer;
  z-index: 999;
  position: relative;
}

.Quatity > div {
  width: 100%;
}

.Quantity-Control {
  position: absolute;
  background: white;
  top: 120%;
  right: 30%;
  padding: 0 20px;
  width: 70% !important;
  border-radius: 8px;
  box-sizing: border-box;
  line-height: 18.8343px;
  overflow-x: hidden;
  overflow-y: hidden;
  z-index: 1000;
  font-size: 18px;
}

.Quantity-Control > ul {
  margin: 0 !important;
  padding: 0 !important;
  display: flex;
  list-style: none;
  flex-direction: column;
  justify-content: center;
}

.Quantity-Control > ul > li {
  display: flex;
  list-style: none;
  flex-direction: row;
  justify-content: space-between;
  width: 100%;
  line-height: 50px;
  align-items: center;
}

.Control-Up-Down {
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 0.5rem;
  font-size: 20px;
}

.Control-Up-Down > span {
  width: 30px;
  text-align: center;
}

.Search-Button {
  position: absolute;
  border: none;
  width: 50%;
  font-size: 30px;
  color: white;
  padding: 10px;
  bottom: -35px;
  right: 25%;
  left: 25%;
  font-weight: 500;
  box-shadow: rgba(0, 0, 0, 0.2) 0px 2px 8px 3px;
  z-index: 998;
}

.sub-text {
  color: var(--gray-Color);
  font-size: 13px !important;
}

@media only screen and (max-width: 850px) {
  .Input-Form {
    flex-direction: column;
  }

  .Check-In-Out {
    width: 100%;
  }

  .Quatity {
    width: 100%;
  }

  .Search-Box-Container {
    position: unset;
    width: unset;
  }

  .Search-Button {
    position: unset;
    border: none;
    width: 100%;
    z-index: 998;
    margin-top: 20px;
  }

  .Search-Box-Container > .Title {
    display: none;
  }
}
</style>
