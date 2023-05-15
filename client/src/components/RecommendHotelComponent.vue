<template>
  <div class="RecommendHotel-Container">
    <h3 class="text-center">
      Những chỗ nghỉ <span class="text-danger">nổi bật khuyến nghị</span> cho
      bạn
    </h3>
    <div class="Select-Nav">
      <div
        :class="
          isSelected == item.city
            ? 'Select-Item Selected-Active'
            : 'Select-Item'
        "
        @click="SelectTitleHandleClick(item.city)"
        v-for="(item, index) in HotelData"
        :key="index"
      >
        {{ item.city }}
      </div>
    </div>

    <div class="Recommend-Container row mt-3">
      <div class="col-lg-3" v-for="(item, index) in HotelData" :key="index">
        <div class="card border-0 mt-3">
          <img
            class="card-img-top"
            :src="'/images/' + item.src"
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
            <div class="card-text text-danger fs-6">
              <b>VND {{ item.price }}</b>
            </div>
          </div>
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
export default {
  name: "RecommendHotelComponent",
  data() {
    return {
      HotelData: HotelData,
      isSelected: "",
    };
  },
  methods: {
    SelectTitleHandleClick(country) {
      this.isSelected = country;
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
</style>
