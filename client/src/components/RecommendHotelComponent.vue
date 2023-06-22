<template>
  <div class="RecommendHotel-Container">
    <h3 class="text-center">
      Những chỗ nghỉ <span class="text-danger">nổi bật khuyến nghị</span> cho
      bạn
    </h3>
    <div class="Select-Nav">
      <div
        :class="
          isSelected == item.name
            ? 'Select-Item Selected-Active'
            : 'Select-Item'
        "
        @click="SelectTitleHandleClick(item.city_id)"
        v-for="(item, index) in getDataCitiesAndQuatityHotels"
        :key="index"
      >
        {{ item.name }}
      </div>
    </div>

    <div class="Recommend-Container row mt-3">
      <div
        class="col-lg-3"
        v-for="(item, index) in getDataHotels"
        :key="index"
        v-show="!getStatusHotels.isLoading"
      >
        <div class="card border-0 mt-3" v-if="!getStatusHotels.isLoading">
          <img
            class="card-img-top hotels-Image"
            :src="item.thumbnail != '' && IMAGE_PATH + item.thumbnail"
            alt="Card image cap"
          />
          <div class="card-body p-0 mt-1">
            <div class="card-title mb-0">
              <b>{{ item.name }}</b>
            </div>
            <div class="card-text text-info">
              <b style="font-size: 13px"
                ><i class="fa-solid fa-location-dot"></i> {{ item.address }}</b
              >
            </div>
            <div
              class="card-text text-danger fs-6"
              v-if="item.min_price != null"
            >
              <b>
                <div v-if="item.min_discount != 0" class="price-hotels">
                  <span>{{ FormatCurrency(item.min_price_discount) }}</span>
                  {{ " " }}
                  <strike>{{ FormatCurrency(item.min_price) }}</strike>
                </div>
                <span v-else>{{ FormatCurrency(item.min_price) }}</span>
              </b>
            </div>
          </div>
        </div>
      </div>

      <div
        v-show="getStatusHotels.isLoading"
        class="text-center Loading-Hotels col-lg-12"
      >
        <div class="spinner-border text-danger" role="status">
          <span class="sr-only">Loading...</span>
        </div>
      </div>

      <div class="col-lg-12 text-center">
        <button class="btn btn-danger p-3 mt-5">
          <b>Xem thêm các khách sạn ({{ isSelected }})</b>
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import HotelData from "../Data/HotelData";
import { mapGetters, mapActions } from "vuex";

export default {
  name: "RecommendHotelComponent",
  data() {
    return {
      IMAGE_PATH: process.env.VUE_APP_IMAGE_PATH,
      HotelData: HotelData,
      isSelected: this.getDataCitiesAndQuatityHotels,
    };
  },

  created() {
    this.GetHotelsByCityId(1);
    this.isSelected = "Hồ Chí Minh";
  },

  computed: {
    ...mapGetters("Home", [
      "getDataCitiesAndQuatityHotels",
      "getDataHotels",
      "getStatusHotels",
    ]),
  },
  methods: {
    ...mapActions("Home", ["GetHotelsByCityId"]),

    FormatCurrency(number) {
      return new Intl.NumberFormat("vi-VN", {
        style: "currency",
        currency: "VND",
      }).format(number);
    },

    SelectTitleHandleClick(cityId) {
      for (
        let index = 0;
        index < this.getDataCitiesAndQuatityHotels.length;
        index++
      ) {
        if (this.getDataCitiesAndQuatityHotels[index].city_id == cityId) {
          this.isSelected = this.getDataCitiesAndQuatityHotels[index].name;
          this.GetHotelsByCityId(
            this.getDataCitiesAndQuatityHotels[index].city_id
          );
        }
      }
    },
  },
};
</script>

<style>
.RecommendHotel-Container {
  margin: 50px 0;
}

.RecommendHotel-Container > h3 {
  margin: 40px 0 20px 0;
}

.Select-Nav {
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}

.Select-Nav > .Select-Item {
  font-weight: 600;
  padding: 10px;
  border-bottom: 1px solid var(--gray-Color);
}

.Select-Nav > .Select-Item:hover {
  color: var(--main-Color);
  cursor: pointer;
  border-bottom: 2px solid var(--main-Color);
}

.Selected-Active {
  color: var(--main-Color) !important;
  border-bottom: 2px solid var(--main-Color) !important;
}

.Loading-Hotels {
  margin-top: 3rem !important;
  min-height: 200px;
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}

.hotels-Image {
  height: 200px !important;
  object-fit: cover !important;
}

.price-hotels > strike {
  font-size: 10px;
  color: rgb(171, 171, 171);
}
</style>
