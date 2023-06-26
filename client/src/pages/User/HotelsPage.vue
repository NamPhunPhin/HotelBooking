<template>
  <div class="Hotels-Container">
    <div :class="view.topOfPage && 'Search-Nav'">
      <SearchNavbarComponent @Search-Hotels="SearchHotelsHandleClick" />
    </div>
    <div class="container mt-3 Hotels-Wrapper">
      <div class="Left-Side">
        <div class="Search-Field">
          <i class="fa-solid fa-magnifying-glass"></i>

          <input
            type="text"
            placeholder="Nhập tên khách sạn"
            v-model="SearchingNameHotel"
          />
        </div>

        <!-- <div class="Your-Filter">
          <div class="Filter">
            <div>
              <span>Bộ lọc của quý khách</span>
              <span class="delete-filter">Xoá</span>
            </div>
            <ul>
              <li v-for="(item, index) in YourFilterData" :key="index">
                <input type="checkbox" name="" id="noidung" />
                <label for="noidung"></label>
              </li>
            </ul>
          </div>
        </div> -->

        <!-- <hr /> -->

        {{ PriceLowestFormat }}

        <div class="Filter-Price">
          <div class="Filter" style="font-size: 16px">
            <div>
              <span>Bộ lọc theo giá</span>
              <span
                class="delete-filter"
                @click="DEFAULT_PRICE"
                v-if="getMaxPrice != 10000000 || getMinPrice != 500000"
                >Đặt lại</span
              >
            </div>
          </div>

          <div>
            <label for="customRange1" class="form-label">Tối thiểu</label>
            <input
              type="range"
              class="form-range"
              :max="Max_Price"
              min="500000"
              id="customRange1"
              v-model="Min_Price"
            />
            <label for="customRange2" class="form-label">Tối đa</label>
            <input
              type="range"
              :min="Min_Price"
              max="10000000"
              class="form-range"
              id="customRange2"
              v-model="Max_Price"
            />

            <div class="Price-Around">
              <div>
                <input
                  type="text"
                  disabled
                  :value="FormatCurrency(getMinPrice)"
                />
              </div>
              <span>to</span>
              <div>
                <input
                  type="text"
                  disabled
                  :value="FormatCurrency(getMaxPrice)"
                />
              </div>
            </div>
          </div>
        </div>

        <hr />

        <div class="Filter">
          <div>
            <span>Khoảng cách đến trung tâm</span>
            <span
              class="delete-filter"
              @click="
                () => {
                  UNFILTER_DISTANCE();
                  isChecked = '';
                }
              "
              v-if="getDistanceCityCenter"
              >Đặt lại</span
            >
          </div>
          <ul>
            <li>
              <input
                @click="FilterKilometerCityCenterHandleClick(5)"
                :checked="isChecked != '' && isChecked == 5"
                type="checkbox"
                name=""
                :class="isChecked == 5 && 'Checked-Color'"
                id="citycenter1"
              />
              <label
                for="citycenter1"
                :class="isChecked == 5 && 'text-danger Checked-Color'"
                >Bên trong trung tâm thành phố (291)</label
              >
            </li>
            <li>
              <input
                @click="FilterKilometerCityCenterHandleClick(1)"
                :checked="isChecked != '' && isChecked == 1"
                type="checkbox"
                :class="isChecked == 1 && 'Checked-Color'"
                name=""
                id="citycenter2"
              />
              <label
                for="citycenter2"
                :class="isChecked == 1 && 'text-danger Checked-Color'"
                >cách trung tâm &lt; 2 km (189)</label
              >
            </li>
            <li>
              <input
                @click="FilterKilometerCityCenterHandleClick(2)"
                :checked="isChecked != '' && isChecked == 2"
                :class="isChecked == 2 && 'Checked-Color'"
                type="checkbox"
                class="Checked-Color"
                name=""
                id="citycenter3"
              />
              <label
                for="citycenter3"
                :class="isChecked == 2 && 'text-danger Checked-Color'"
                >cách trung tâm 2-5 km (303)</label
              >
            </li>
            <li>
              <input
                @click="FilterKilometerCityCenterHandleClick(3)"
                :checked="isChecked != '' && isChecked == 3"
                :class="isChecked == 3 && 'Checked-Color'"
                type="checkbox"
                class="Checked-Color"
                name=""
                id="citycenter4"
              />

              <label
                for="citycenter4"
                :disabled="isChecked == 3"
                :class="isChecked == 3 && 'text-danger Checked-Color'"
                >cách trung tâm 5-10 km (163)</label
              >
            </li>
            <li>
              <input
                @click="FilterKilometerCityCenterHandleClick(4)"
                :checked="isChecked != '' && isChecked == 4"
                :class="isChecked == 4 && 'Checked-Color'"
                type="checkbox"
                class="Checked-Color"
                name=""
                id="citycenter5"
              />
              <label
                for="citycenter5"
                :class="isChecked == 4 && 'text-danger Checked-Color'"
                >cách trung tâm > 10 km (603)</label
              >
            </li>
          </ul>
        </div>

        <hr v-if="DataSearch.countryId != ''" />

        <div class="Filter" v-if="DataSearch.countryId != ''">
          <div>
            <span>Khu vực</span>
            <span
              class="delete-filter"
              @click="
                () => {
                  UNFILTER_CITY();
                  isCheckedCityFilter = '';
                }
              "
              v-if="getCityFilter"
              >Đặt lại</span
            >
          </div>
          <ul>
            <li v-for="(item, index) in CityFilterData" :key="index">
              <input
                type="checkbox"
                name=""
                :checked="isCheckedCityFilter == item.city_id"
                :class="isCheckedCityFilter == item.city_id && 'Checked-Color'"
                @click="CityFilterHandleClick(item.city_id)"
                :id="`city_${item.city_id}`"
              />
              <label
                :for="`city_${item.city_id}`"
                :class="
                  isCheckedCityFilter == item.city_id &&
                  'text-danger Checked-Color'
                "
                >{{ item.name }} ({{ item.quatity_hotels }})</label
              >
            </li>
          </ul>
        </div>

        <hr />

        <div class="Filter">
          <span>Loại giường</span>
          <ul>
            <li>
              <input type="checkbox" name="" id="noidung2" />
              <label for="noidung2">Đôi (572)</label>
            </li>
          </ul>
        </div>

        <hr />

        <div class="Filter">
          <span>Đánh giá của khách</span>
          <ul>
            <li>
              <input type="checkbox" name="" id="rating-your4" />
              <label for="rating-your4"><b>9+</b> Trên cả tuyệt vời (85)</label>
            </li>
            <li>
              <input type="checkbox" name="" id="rating-your3" />
              <label for="rating-your3"><b>8+</b> Xuất sắc (205)</label>
            </li>
            <li>
              <input type="checkbox" name="" id="rating-your2" />
              <label for="rating-your2"><b>7+</b> Rất tốt (372)</label>
            </li>
            <li>
              <input type="checkbox" name="" id="rating-your1" />
              <label for="rating-your1"><b>6+</b> Hài lòng (522)</label>
            </li>
          </ul>
        </div>

        <hr />

        <div class="Filter">
          <span>Đánh giá của khách</span>
          <ul>
            <li>
              <input type="checkbox" name="" id="rating-star4" />
              <label for="rating-star4">
                <i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star text-warning"></i> (500)
              </label>
            </li>
            <li>
              <input type="checkbox" name="" id="rating-star3" />
              <label for="rating-star3">
                <i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star"></i> (500)
              </label>
            </li>
            <li>
              <input type="checkbox" name="" id="rating-star2" />
              <label for="rating-star2"
                ><i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star"></i>
                <i class="fa-solid fa-star"></i> (500)</label
              >
            </li>
            <li>
              <input type="checkbox" name="" id="rating-star1" />
              <label for="rating-star1">
                <i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star"></i>
                <i class="fa-solid fa-star"></i>
                <i class="fa-solid fa-star"></i> (500)
              </label>
            </li>
            <li>
              <input type="checkbox" name="" id="rating-star0" />
              <label for="rating-star0">
                <i class="fa-solid fa-star text-warning"></i>
                <i class="fa-solid fa-star"></i>
                <i class="fa-solid fa-star"></i>
                <i class="fa-solid fa-star"></i>
                <i class="fa-solid fa-star"></i> (500)
              </label>
            </li>
            <li>
              <input type="checkbox" name="" id="rating-star00" />
              <label for="rating-star00"> Chưa xếp hạng (93) </label>
            </li>
          </ul>
        </div>
      </div>
      <div class="Right-Side">
        <div class="Arrange-Hotels">
          <div
            @click="ArrangeHandleClick(0)"
            :class="isArrange == 0 && `Arrange-Active`"
          >
            Phổ Biến
          </div>
          <div
            @click="ArrangeHandleClick(1)"
            :class="isArrange == 1 && `Arrange-Active`"
          >
            Giá Thấp Nhất
          </div>
          <div
            @click="ArrangeHandleClick(2)"
            :class="isArrange == 2 && `Arrange-Active`"
          >
            Giá Cao Nhất
          </div>
          <div
            @click="ArrangeHandleClick(3)"
            :class="isArrange == 3 && `Arrange-Active`"
          >
            Đánh Giá
          </div>
          <div
            @click="ArrangeHandleClick(4)"
            :class="isArrange == 4 && `Arrange-Active`"
          >
            Đang Giảm Giá
          </div>
        </div>
        <div class="Found-Text" v-if="getSearching.SearchText">
          {{ getSearching.SearchText }}: tìm thấy
          {{ getHotelsData ? getHotelsData.length : "0" }} khách sạn
        </div>

        <div
          class="Focus-Layout-Loading"
          v-if="getHotelsStatus.isLoading == true"
        >
          <div class="Message-Searching">
            <img src="/images/agoji-parachute.gif" alt="" />
            <h5>ĐẢM BẢO TRẢI NGHIỆM TỐT NHẤT</h5>
            <div>
              Chúng tôi sẽ tìm kiếm những khách sạn an toàn, tiết kiệm và phù
              hợp với bạn.
            </div>
          </div>
        </div>

        <div class="Hotel-List">
          <HotelItemComponent
            v-for="(item, index) in getHotelsData"
            :key="index"
            @click="DetailHotelHandleClick(item.hotel_id)"
            :item-hotel="item"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { useRoute } from "vue-router";
import HotelItemComponent from "../../components/HotelItemComponent.vue";
import { GetQuatityHotelsInTheCityById } from "../../API/CountriesRequest";
import SearchNavbarComponent from "../../components/SearchNavbarComponent.vue";
import { mapGetters, mapMutations, mapActions, mapState } from "vuex";

export default {
  name: "HotelsPage",

  created() {
    this.DataSearch = this.getSearching;
  },

  mounted() {
    document.body.scrollTop = 0; // For Safari
    document.documentElement.scrollTop = 0;
    const router = useRoute();
    if (router.query.country != undefined) {
      this.HotelsCountryRequest(router.query.country);
      this.DataSearch.countryId = router.query.country;
      this.CitiesDataFilterRequest(router.query.country);
      this.DataSearch.cityId = "";
    }
    if (router.query.city != undefined) {
      this.HotelsCityRequest(router.query.city);
      this.DataSearch.cityId = router.query.city;
    } else {
      this.DataSearch.cityId = "";
    }
    this.DataSearch.CheckIn = router.query.checkin;
    this.DataSearch.CheckOut = router.query.checkout;
    this.DataSearch.Rooms = router.query.rooms;
    this.DataSearch.AdultPeople = router.query.adults;
    this.DataSearch.ChildrenPeople = router.query.children;
    this.UpdateSearch(this.DataSearch);
    this.DEFAULT_FILTER_SEARCH();
  },
  data() {
    return {
      IMAGE_PATH: process.env.VUE_APP_IMAGE_PATH,
      dataRessponse: "",
      isChecked: "",
      isCheckedCityFilter: "",
      isArrange: 0,
      FilterData: {
        PriceLowest: 500000,
        PriceHighest: 10000000,
        number_selected: null,
      },
      view: {
        topOfPage: false,
      },
      CityFilterData: "",
      DataSearch: {
        cityId: "",
        countryId: "",
        CheckOut: "",
        CheckIn: "",
        Rooms: 1,
        AdultPeople: 2,
        ChildrenPeople: 0,
      },
    };
  },
  methods: {
    ...mapActions("Hotels", ["HotelsCountryRequest", "HotelsCityRequest"]),
    ...mapMutations("Search", ["UpdateSearch"]),
    ...mapMutations("Hotels", [
      "HOTELS_SEARCH",
      "MIN_PRICE",
      "MAX_PRICE",
      "DEFAULT_FILTER_SEARCH",
      "FILTER_DISTANCE",
      "UNFILTER_DISTANCE",
      "DEFAULT_PRICE",
      "YOUR_FILTER_ADD",
      "FILTER_CITY",
      "UNFILTER_CITY",
      "ARRANGER",
    ]),

    ArrangeHandleClick(number) {
      this.isArrange = number;
      this.ARRANGER(number);
    },

    CityFilterHandleClick(number) {
      this.isCheckedCityFilter = number;
      this.FILTER_CITY(number);
    },

    async CitiesDataFilterRequest(country) {
      const citiesData = await GetQuatityHotelsInTheCityById(country);
      this.CityFilterData = citiesData.data.data;
    },

    FilterKilometerCityCenterHandleClick(number) {
      let distance_citycenter;
      this.isChecked = number;
      if (number == 5) {
        distance_citycenter = {
          min: 0,
          max: 0,
          number: number,
        };
      } else if (number == 1) {
        distance_citycenter = {
          min: 2,
          max: 0,
          number: number,
        };
      } else if (number == 2) {
        distance_citycenter = {
          min: 2,
          max: 5,
          number: number,
        };
      } else if (number == 3) {
        distance_citycenter = {
          min: 5,
          max: 10,
          number: number,
        };
      } else {
        distance_citycenter = {
          min: 0,
          max: 10,
          number: number,
        };
      }

      this.FILTER_DISTANCE(distance_citycenter);
    },

    SearchHotelsHandleClick(data) {
      this.isArrange = 0;
      if (data.country != "") {
        this.HotelsCountryRequest(data.country);
        this.CitiesDataFilterRequest(data.country);
      }
      if (data.city != "") {
        this.HotelsCityRequest(data.city);
      }
    },

    NavSearchHandleScroll() {
      document.documentElement.scrollTop > 100
        ? (this.view.topOfPage = true)
        : (this.view.topOfPage = false);
    },

    FormatCurrency(number) {
      return new Intl.NumberFormat("vi-VN", {
        style: "currency",
        currency: "VND",
      }).format(number);
    },
    DetailHotelHandleClick(roomID) {
      window.open(
        `/hotels/detail/${roomID}?${
          this.DataSearch.countryId != ""
            ? `country=${this.DataSearch.countryId}`
            : ""
        }${
          this.DataSearch.cityId != "" ? `city=${this.DataSearch.cityId}` : ""
        }&checkin=${this.DataSearch.CheckIn}&checkout=${
          this.DataSearch.CheckOut
        }&adults=${this.DataSearch.AdultPeople}&children=${
          this.DataSearch.ChildrenPeople
        }&rooms=${this.DataSearch.Rooms}`,
        "_blank"
      );
    },
  },
  computed: {
    ...mapState("Hotels", ["hotelSearching"]),
    ...mapGetters("Search", ["getSearching"]),
    ...mapGetters("Hotels", [
      "getHotelsData",
      "getHotelsStatus",
      "getHotelsSearching",
      "getMaxPrice",
      "getMinPrice",
      "getDistanceCityCenter",
      "getYourFilter",
      "getCityFilter",
    ]),

    SearchingNameHotel: {
      get() {
        return this.getHotelsSearching;
      },
      set(value) {
        this.HOTELS_SEARCH(value);
      },
    },

    Min_Price: {
      get() {
        return this.getMinPrice;
      },
      set(value) {
        this.MIN_PRICE(value);
      },
    },
    Max_Price: {
      get() {
        return this.getMaxPrice;
      },
      set(value) {
        this.MAX_PRICE(value);
      },
    },
  },

  beforeMount() {
    window.addEventListener("scroll", this.NavSearchHandleScroll);
  },

  components: {
    SearchNavbarComponent,
    HotelItemComponent,
  },
};
</script>

<style>
.Hotels-Wrapper {
  display: flex;
  gap: 1rem;
}

.Left-Side {
  width: 30%;
}

.Left-Side > .Search-Field {
  width: 100%;
  background: rgb(245, 247, 250);
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 10px;
  gap: 0.5rem;
  border-radius: 20px;
  margin-bottom: 20px;
}

.Left-Side > .Search-Field > i {
  font-size: 20px;
  color: #7d90a8;
}

.Left-Side > .Search-Field > input {
  border: none;
  background: none;
  width: 100%;
}

.Left-Side > .Search-Field > input:focus {
  outline: none;
}

.Right-Side {
  width: 70%;
}

.Filter > span {
  font-weight: bold;
  color: #5a5b79;
}

.Filter > ul {
  margin: 5px 0;
  list-style: none;
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
  padding: 0;
}

.Filter > ul > li {
  display: flex;
  align-items: center;
  width: 100%;
  gap: 0.5rem;
  font-weight: 500;
  cursor: pointer;
  text-align: left;
}

.Filter > ul > li > input {
  accent-color: var(--main-Color);
  border-color: #ebebeb;
}

.Filter > ul > li > label {
  font-size: 13px;
  color: #393b6a;
  cursor: pointer;
}

.Filter > ul > li > label:hover {
  color: var(--main-Color);
}

.Your-Filter {
  border: 2px solid #e9ebec;
  padding: 10px;
  border-radius: 10px;
}

.Filter > div {
  display: flex;
  justify-content: space-between;
  font-weight: bold;
  color: #5a5b79;
}

.Filter > div > .delete-filter {
  color: var(--main-Color);
  cursor: pointer;
}

.Filter > div > .delete-filter:hover {
  text-decoration: underline;
}

.Arrange-Hotels {
  display: flex;
  width: 100%;
  /* justify-content: space-evenly; */
  line-height: 46px;
  background: rgb(245, 247, 250);
  border-radius: 5px;
  width: 100%;
}

.Arrange-Hotels > div {
  width: 100%;
  text-align: center;
  border-radius: 5px;
  font-weight: bold;
  font-size: 13px;
  cursor: pointer;
}

.Arrange-Hotels > div:hover {
  color: var(--main-Color);
}

.Arrange-Active {
  background: var(--main-Color);
  color: white !important;
}

.Found-Text {
  font-size: 14px;
  font-family: unset;
  font-weight: bold;
  margin: 20px 10px;
}

.Hotel-List {
  display: flex;
  flex-direction: column;
  gap: 1rem;
  margin: 20px 0;
  min-height: 20%;
  justify-content: center;
}

.Filter-Price > span {
  font-weight: bold;
  color: #5a5b79;
}

.Filter-Price > div {
  font-size: 13px;
}

.Price-Around {
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 1rem;
}

.Price-Around {
  font-size: 15px;
  font-weight: 600;
}

.Price-Around > div {
  width: 50%;
  text-align: center;
  padding: 5px;
  border: 2px solid #dee2e6;
  margin: 10px 0;
  display: flex;
}

.Price-Around > div > input {
  width: 100%;
  border: none;
  text-align: center;
  font-weight: 600;
}

.Price-Around > div > input:focus {
  outline: none;
}

.Loading-Dot {
  height: 100%;
  display: flex;
  gap: 1rem;
  justify-content: center;
  align-items: center;
}

.Focus-Layout-Loading {
  background-color: rgba(0, 0, 0, 0.5);
  bottom: 0;
  left: 0;
  position: fixed;
  right: 0;
  top: 0;
  z-index: 9999;
  display: flex;
  align-items: center;
  justify-content: center;
}

.Message-Searching {
  background: white;
  padding: 30px;
  z-index: 99999;
  width: 30%;
  display: flex;
  justify-content: center;
  align-items: center;
  border-radius: 10px;
  opacity: unset;
  flex-direction: column;
}

.Message-Searching > h5 {
  font-family: unset;
  color: var(--main-Color);
}

.Message-Searching > div {
  font-weight: 600;
  text-align: center;
}

.Message-Searching > img {
  margin: 10px 0;
}

.Checked-Color {
  font-weight: 700;
  pointer-events: none;
}
</style>
