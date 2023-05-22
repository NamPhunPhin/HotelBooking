<template>
  <div class="SearchNavbar-Container">
    <div class="SearchNavbar-Box">
      <div class="SearchNavbar-Location">
        <i class="fa-solid fa-magnifying-glass"></i>
        <input
          type="text"
          placeholder="Nhập địa diểm du lịch hoặc tên khách sạn"
          v-model="DataSearch.SearchText"
          @focus="PopUpSuggestHandleFocus()"
        />

        <div class="Suggest-Searching-Nav" v-if="isPopUpSuggest">
          <ul>
            <li>
              <i class="fa-solid fa-location-dot"></i>
              <div class="Suggest-Text">
                <div>Da Lat, Viet Nam</div>
                <div class="Sub-Text mt-1">Thành Phố</div>
              </div>
            </li>
          </ul>
        </div>
      </div>

      <div class="Check-In-Out-Nav">
        <div class="Check-In" @click="CheckInOpenHandleClick()">
          <i class="fa-solid fa-calendar-days"></i>

          <div>
            <div>
              {{ DateCheckInFormat ? DateCheckInFormat : "Ngày trả phòng" }}
            </div>
            <div class="Sub-Text">{{ DayCheckInFormat }}</div>
          </div>
          <input type="date" ref="CheckIn" v-model="DataSearch.CheckIn" />
        </div>

        <i class="fa-solid fa-minus"></i>

        <div class="Check-Out" @click="CheckOutOpenHandleClick()">
          <i class="fa-solid fa-calendar-days"></i>
          <!-- <div>Ngày trả phòng</div> -->
          <div>
            <div>
              {{ DateCheckOutFormat ? DateCheckOutFormat : "Ngày trả phòng" }}
            </div>
            <div class="Sub-Text">{{ DayCheckOutFormat }}</div>
          </div>
          <input type="date" ref="CheckOut" v-model="DataSearch.CheckOut" />
        </div>
      </div>

      <div class="Quatity-Nav" @click="PopUpQuatityHandleClick()">
        <i class="fa-solid fa-people-group"></i>
        <div class="w-100">
          <div>
            {{ DataSearch.AdultPeople }} người lớn
            <span v-if="DataSearch.ChildrenPeople > 0"
              >, {{ DataSearch.ChildrenPeople }} trẻ em</span
            >
          </div>
          <div class="Sub-Text">{{ DataSearch.Rooms }} phòng</div>
        </div>
        <i class="fa-solid fa-caret-down"></i>

        <div class="Quantity-Control" v-if="isPopUpQuatity">
          <ul>
            <li>
              <div>Phòng</div>
              <div class="Control-Up-Down">
                <span @click="() => DataSearch.Rooms > 0 && DataSearch.Rooms--"
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
                    () => DataSearch.AdultPeople > 0 && DataSearch.AdultPeople--
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

      <button class="btn btn-light" @click="SearchHandleClick()">Tìm</button>
    </div>
  </div>

  <div
    v-if="isFocusLayout"
    @click="FocusLayoutHandleClick()"
    class="Focus-Layout-Nav"
  ></div>
</template>

<script>
export default {
  name: "SearchNavbarComponent",
  data() {
    return {
      isPopUpSuggest: false,
      isFocusLayout: false,
      isPopUpQuatity: false,
      isOverNight: true,
      DataSearch: {
        SearchText: "",
        CheckIn: "",
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
    SearchHandleClick() {
      console.log(this.DataSearch);
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
.SearchNavbar-Container {
  background: var(--main-Color);
  padding: 10px 0;
  font-weight: 500;
  font-family: var(--font-Mallory);
  position: relative;
  z-index: 999 !important;
}

.SearchNavbar-Box {
  display: flex;
  justify-content: center;
  align-content: center;
  gap: 0.5rem;
}

.SearchNavbar-Box > button {
  width: 10%;
  font-weight: 500;
  font-size: 20px;
}

.SearchNavbar-Location {
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 0.5rem;
  background: white;
  padding: 5px 10px;
  border-radius: 5px;
  width: 25%;
  cursor: pointer;
  position: relative;
}

.SearchNavbar-Location > i {
  font-size: 20px;
}

.SearchNavbar-Location > input {
  border: none;
  background: none;
  width: 100%;
  font-weight: 500;
  font-family: var(--font-Mallory);
}

.SearchNavbar-Location > input:focus {
  outline: none;
}

.Check-In-Out-Nav {
  display: flex;
  justify-content: space-around;
  align-items: center;
  width: 25%;
  background: white;
  padding: 5px 10px;
  border-radius: 5px;
}

.Check-In {
  display: flex;
  justify-content: center;
  align-items: center;
  position: relative;
  gap: 0.5rem;
  cursor: pointer;
}

.Check-In > i {
  font-size: 20px;
}

.Check-In > input {
  position: absolute;
  height: 100%;
  width: 100%;
  visibility: hidden;
}

.Check-Out {
  display: flex;
  justify-content: center;
  align-items: center;
  position: relative;
  gap: 0.5rem;
  cursor: pointer;
}

.Check-Out > input {
  position: absolute;
  height: 100%;
  width: 100%;
  visibility: hidden;
}

.Quatity-Nav {
  width: 20%;
  display: flex;
  cursor: pointer;
  justify-content: space-between;
  align-items: center;
  background: white;
  padding: 5px 10px;
  gap: 0.5rem;
  border-radius: 5px;
  position: relative;
}

.Sub-Text {
  color: #999 !important;
  font-size: 13px;
}

.Focus-Layout-Nav {
  background-color: #000;
  bottom: 0;
  left: 0;
  opacity: 0.2;
  position: fixed;
  right: 0;
  top: 0;
  z-index: 900;
}

.Suggest-Searching-Nav {
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

.Suggest-Searching-Nav > ul {
  list-style: none;
  display: flex;
  flex-direction: column;
  width: 100%;
  padding: 0px !important;
  margin: 0 !important;
}

.Suggest-Searching-Nav > ul > li {
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

.Suggest-Searching-Nav > ul > li:hover {
  background: var(--main-Color);
  color: white;
}

.Suggest-Searching-Nav > ul > li > i {
  font-size: 20px;
}

.Suggest-Searching-Nav > ul > li > i {
  font-size: 20px;
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

.Quantity-Control {
  position: absolute;
  background: white;
  top: 120%;
  padding: 0 20px;
  width: 100% !important;
  border-radius: 8px;
  box-sizing: border-box;
  line-height: 18.8343px;
  overflow-x: hidden;
  overflow-y: hidden;
  z-index: 1000;
  font-size: 18px;
  right: 0;
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
</style>
