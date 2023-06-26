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

        <div
          class="Suggest-Searching-Nav"
          v-if="isPopUpSuggest == true && DataSearch.SearchText != ''"
        >
          <ul>
            <li v-if="SuggestSearching == null" class="Search-Not-Found">
              <div class="Suggest-Text">
                Rất tiếc, chúng tôi không tìm thấy kết quả nào cho "{{
                  DataSearch.SearchText
                }}".
              </div>
            </li>
            <li
              v-for="(item, index) in SuggestSearching"
              :key="index"
              @click="SuggestHandleClick(item)"
            >
              <i class="fa-solid fa-location-dot"></i>
              <div class="Suggest-Text">
                <div>{{ item.location_name }}</div>
                <div class="Sub-Text mt-1">{{ item.location_type }}</div>
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
          <input
            type="date"
            ref="CheckIn"
            @change="DateHanldeChange()"
            v-model="DataSearch.CheckIn"
          />
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

          <input
            type="date"
            ref="CheckOut"
            @change="DateHanldeChange()"
            v-model="DataSearch.CheckOut"
          />
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

      <button
        class="btn btn-light"
        @click="SearchHandleClick"
        :disabled="DataSearch.SearchText == '' || SuggestSearching == null"
      >
        {{ isDetailPage ? (isUpdateTime ? "Cập Nhật" : `Tìm`) : "Tìm" }}
      </button>
    </div>
  </div>

  <div
    v-if="isFocusLayout"
    @click="FocusLayoutHandleClick()"
    class="Focus-Layout-Nav"
  ></div>
  <vue-basic-alert :duration="300" :closeIn="3000" ref="alert" />
</template>

<script>
import { GetAllCountries } from "../API/CountriesRequest";
import { GetAllCities } from "../API/CitiesRequest";
import { mapGetters, mapMutations } from "vuex";
import VueBasicAlert from "vue-basic-alert";
import { useRoute } from "vue-router";

export default {
  name: "SearchNavbarComponent",
  components: {
    VueBasicAlert,
  },
  props: ["isDetailPage"],
  data() {
    return {
      SearchTextDefault: "",
      LocationData: "",
      isPopUpSuggest: false,
      isFocusLayout: false,
      isPopUpQuatity: false,
      isOverNight: true,
      isUpdateSearch: true,
      DataSearch: {
        SearchText: "",
        CheckIn: "",
        cityId: "",
        countryId: "",
        CheckOut: "",
        Rooms: 1,
        AdultPeople: 2,
        ChildrenPeople: 0,
      },
    };
  },

  async created() {},

  async mounted() {
    this.DataSearch = this.getSearching;

    const router = useRoute();
    if (router.query.country != null || router.query.city != null) {
      if (router.query.country != undefined) {
        this.DataSearch.countryId = router.query.country;
        this.DataSearch.cityId = "";
      }
      if (router.query.city != undefined) {
        this.DataSearch.cityId = router.query.city;
        this.DataSearch.countryId = "";
      }
      this.DataSearch.CheckIn = router.query.checkin;
      this.DataSearch.CheckOut = router.query.checkout;
      this.DataSearch.Rooms = router.query.rooms;
      this.DataSearch.AdultPeople = router.query.adults;
      this.DataSearch.ChildrenPeople = router.query.children;
      this.UpdateSearch(this.DataSearch);
    }

    const countriesRes = await GetAllCountries();
    const countriesData = countriesRes.data.countriesData;

    await countriesData.forEach((element) => {
      const countryItem = {
        location_name: element.name,
        country_id: element.country_id,
        city_id: null,
        location_type: "Quốc Gia",
      };

      this.LocationData = [...this.LocationData, countryItem];
    });

    const citiesRes = await GetAllCities();
    const citiesData = citiesRes.data.citiesData;

    citiesData.forEach((city) => {
      const cityItem = {
        country_id: city.country_id,
        city_id: city.city_id,
        location_type: "Thành Phố",
      };
      countriesData.forEach((country) => {
        if (country.country_id === city.country_id) {
          cityItem.location_name = `${city.name}, ${country.name}`;
        }
      });
      this.LocationData = [...this.LocationData, cityItem];
    });

    if (this.LocationData != "") {
      this.LocationData.forEach((item) => {
        if (
          item.city_id == null &&
          item.country_id == this.DataSearch.countryId
        ) {
          this.SearchTextDefault = item.location_name;
          this.SuggestHandleClick(item);
        }

        if (item.city_id != null && item.city_id == this.DataSearch.cityId) {
          this.SuggestHandleClick(item);
          this.SearchTextDefault = item.location_name;
        }
      });
    }

    console.log(this.DataSearch.SearchText);
    console.log(this.SearchTextDefault);
  },

  methods: {
    ...mapMutations("Search", ["UpdateSearch"]),
    ...mapMutations("Hotels", ["DEFAULT_FILTER_SEARCH"]),

    AlertShow(type, hearder, message) {
      this.$refs.alert.showAlert(
        type, // There are 4 types of alert: success, info, warning, error

        message, // Message of the alert
        hearder // Header of the alert
      );
    },

    SearchHandleClick(e) {
      e.preventDefault();
      this.isPopUpSuggest = false;
      this.isFocusLayout = false;
      this.isPopUpQuatity = false;
      if (this.SuggestSearching != null && this.DataSearch.SearchText != "") {
        if (this.SuggestSearching[0].city_id != null) {
          this.DataSearch.cityId = this.SuggestSearching[0].city_id;
          this.DataSearch.countryId = "";
        } else {
          this.DataSearch.countryId = this.SuggestSearching[0].country_id;
          this.DataSearch.cityId = "";
        }
        this.DataSearch.SearchText = this.SuggestSearching[0].location_name;
        this.UpdateSearch(this.DataSearch);
      }

      if (
        (this.DataSearch.countryId != "" || this.DataSearch.cityId != "") &&
        this.DataSearch.CheckIn != "" &&
        this.DataSearch.CheckOut != ""
      ) {
        if (this.isDetailPage && this.isUpdateTime) {
          this.$router.push(
            `/hotels/detail/${this.$route.params.id}?${
              this.DataSearch.countryId != ""
                ? `country=${this.DataSearch.countryId}`
                : ""
            }${
              this.DataSearch.cityId != ""
                ? `city=${this.DataSearch.cityId}`
                : ""
            }&checkin=${this.DataSearch.CheckIn}&checkout=${
              this.DataSearch.CheckOut
            }&adults=${this.DataSearch.AdultPeople}&children=${
              this.DataSearch.ChildrenPeople
            }&rooms=${this.DataSearch.Rooms}`
          );
        } else {
          this.$router.push(
            `/hotels?${
              this.DataSearch.countryId != ""
                ? `country=${this.DataSearch.countryId}`
                : ""
            }${
              this.DataSearch.cityId != ""
                ? `city=${this.DataSearch.cityId}`
                : ""
            }&checkin=${this.DataSearch.CheckIn}&checkout=${
              this.DataSearch.CheckOut
            }&adults=${this.DataSearch.AdultPeople}&children=${
              this.DataSearch.ChildrenPeople
            }&rooms=${this.DataSearch.Rooms}`
          );
        }

        this.$emit("Search-Hotels", {
          country: this.DataSearch.countryId,
          city: this.DataSearch.cityId,
        });

        this.DEFAULT_FILTER_SEARCH();
        document.body.scrollTop = 0;
        document.documentElement.scrollTop = 0;
      } else {
        this.isFocusLayout = false;
        this.AlertShow(
          "warning",
          "Thông báo",
          "Vui lòng nhập đầy đủ thông tin để tìm"
        );
      }

      //Điều hướng
    },

    SuggestHandleClick(item) {
      this.DataSearch.SearchText = item.location_name;
      this.isPopUpSuggest = false;
      if (item.city_id != null) {
        this.DataSearch.cityId = item.city_id;
      } else {
        this.DataSearch.countryId = item.country_id;
      }
    },

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

    DateHanldeChange() {
      let checkInDate = new Date(this.DataSearch.CheckIn);
      let checkOutDate = new Date(this.DataSearch.CheckOut);

      if (checkInDate.getTime() > checkOutDate.getTime()) {
        const nextDate = new Date(checkInDate);
        nextDate.setDate(nextDate.getDate() + 1);
        this.DataSearch.CheckOut = nextDate.toISOString().slice(0, 10);
        // this.AlertShow(
        //   "error",
        //   "Thông báo",
        //   "Ngày trả phòng không được lớn hơn ngày trả phòng"
        // );
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
  },

  computed: {
    ...mapGetters("Search", ["getSearching"]),

    isUpdateTime() {
      let oldSearch = this.SearchTextDefault;
      let newSearch = this.DataSearch.SearchText;

      if (oldSearch == newSearch) {
        return true;
      } else {
        return false;
      }
    },

    SuggestSearching() {
      if (this.DataSearch.SearchText != "" && this.LocationData != "") {
        let dataSearching = this.LocationData.filter((item) =>
          item.location_name
            .toLowerCase()
            .includes(this.DataSearch.SearchText.toLowerCase())
        );
        if (dataSearching.length > 0) {
          return dataSearching;
        } else {
          return null;
        }
      } else {
        return this.LocationData;
      }
    },

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
