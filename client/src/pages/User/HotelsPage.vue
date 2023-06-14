<template>
  <div class="Hotels-Container">
    <SearchNavbarComponent />
    <div class="container mt-3 Hotels-Wrapper">
      <div class="Left-Side">
        <div class="Search-Field">
          <i class="fa-solid fa-magnifying-glass"></i>
          <input type="text" placeholder="Nhập tên khách sạn" />
        </div>

        <div class="Your-Filter">
          <div class="Filter">
            <div>
              <span>Bộ lọc của quý khách</span>
              <span class="delete-filter">Xoá</span>
            </div>
            <ul>
              <li>
                <input type="checkbox" name="" id="noidung" />
                <label for="noidung"
                  >Loại giường: Đơn/hai giường đơn Loại giường: Đơn/hai giường
                  đơn Loại giường: Đơn/hai giường đơn</label
                >
              </li>
            </ul>
          </div>
        </div>

        <hr />

        {{ PriceLowestFormat }}

        <div class="Filter-Price">
          <span>Giá mỗi đêm </span>
          <div>
            <label for="customRange1" class="form-label">Tối thiểu</label>
            <input
              type="range"
              class="form-range"
              max="10000000"
              min="500000"
              id="customRange1"
              v-model="FilterData.PriceLowest"
            />
            <label for="customRange2" class="form-label">Tối đa</label>
            <input
              type="range"
              :min="FilterData.PriceLowest"
              max="10000000"
              class="form-range"
              id="customRange2"
              v-model="FilterData.PriceHighest"
            />

            <div class="Price-Around">
              <div>
                <input
                  type="text"
                  disabled
                  :value="FormatCurrency(FilterData.PriceLowest)"
                />
              </div>
              <span>to</span>
              <div>
                <input
                  type="text"
                  disabled
                  :value="FormatCurrency(FilterData.PriceHighest)"
                />
              </div>
            </div>
          </div>
        </div>

        <hr />

        <div class="Filter">
          <span>Bộ lọc dịch vụ phổ biến</span>
          <ul>
            <li>
              <input type="checkbox" name="" id="noidung" />
              <label for="noidung"
                >Loại giường: Đơn/hai giường đơn Loại giường: Đơn/hai giường đơn
                Loại giường: Đơn/hai giường đơn</label
              >
            </li>
          </ul>
        </div>

        <hr />

        <div class="Filter">
          <span>Khoảng cách đến trung tâm</span>
          <ul>
            <li>
              <input type="checkbox" name="" id="citycenter1" />
              <label for="citycenter1"
                >Bên trong trung tâm thành phố (291)</label
              >
            </li>
            <li>
              <input type="checkbox" name="" id="citycenter2" />
              <label for="citycenter2">cách trung tâm &lt; 2 km (189)</label>
            </li>
            <li>
              <input type="checkbox" name="" id="citycenter3" />
              <label for="citycenter3">cách trung tâm 2-5 km (303)</label>
            </li>
            <li>
              <input type="checkbox" name="" id="citycenter4" />
              <label for="citycenter4">cách trung tâm 5-10 km (163)</label>
            </li>
            <li>
              <input type="checkbox" name="" id="citycenter5" />
              <label for="citycenter5">cách trung tâm > 10 km (603)</label>
            </li>
          </ul>
        </div>

        <hr />

        <div class="Filter">
          <span>Khu vực</span>
          <ul>
            <li>
              <input type="checkbox" name="" id="noidung1" />
              <label for="noidung1">Hồ Chí Minh (11)</label>
            </li>
          </ul>
        </div>

        <hr />

        <div class="Filter">
          <span>Loại giường</span>
          <ul>
            <li>
              <input type="checkbox" name="" id="noidung1" />
              <label for="noidung1">Đôi (572)</label>
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
          <div class="Arrange-Active">Phổ Biến</div>
          <div>Giá Thấp Nhất</div>
          <div>Giá Cao Nhất</div>
          <div>Đánh Giá</div>
          <div>Đang Giảm Giá</div>
        </div>
        <div class="Found-Text">Nha Trang: tìm thấy 500 khách sạn</div>

        <div class="Hotel-List">
          <HotelItemComponent @click="DetailHotelHandleClick(1)" />
          <HotelItemComponent />
          <HotelItemComponent />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { useRoute } from "vue-router";
import HotelItemComponent from "../../components/HotelItemComponent.vue";
import SearchNavbarComponent from "../../components/SearchNavbarComponent.vue";
export default {
  name: "HotelsPage",

  created() {},

  mounted() {
    const router = useRoute();
    this.DataSearch.countryId = router.query.country;
    this.DataSearch.cityId = router.query.city;
    this.DataSearch.CheckIn = router.query.checkin;
    this.DataSearch.CheckOut = router.query.checkout;
    this.DataSearch.Rooms = router.query.rooms;
    this.DataSearch.AdultPeople = router.query.adults;
    this.DataSearch.ChildrenPeople = router.query.children;
    console.log(this.DataSearch);
  },
  data() {
    return {
      FilterData: {
        PriceLowest: 500000,
        PriceHighest: 10000000,
      },
      DataSearch: {
        cityId: 2,
        countryId: 1,
        CheckOut: "",
        CheckIn: "",
        Rooms: 1,
        AdultPeople: 2,
        ChildrenPeople: 0,
      },
    };
  },
  methods: {
    FormatCurrency(number) {
      return new Intl.NumberFormat("vi-VN", {
        style: "currency",
        currency: "VND",
      }).format(number);
    },
    DetailHotelHandleClick(roomID) {
      window.open(
        `/hotels/detail/${roomID}?checkin=${this.DataSearch.CheckIn}&checkout=${this.DataSearch.CheckOut}&country=${this.DataSearch.countryId}&city=${this.DataSearch.cityId}&adults=${this.DataSearch.AdultPeople}&children=${this.DataSearch.ChildrenPeople}&rooms=${this.DataSearch.Rooms}`,
        "_blank"
      );
    },
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
</style>
