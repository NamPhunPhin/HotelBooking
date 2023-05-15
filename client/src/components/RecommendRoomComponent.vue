<template>
  <div class="RecommendRoom-Container">
    <h3 class="text-center">
      Những <span class="text-danger">phòng tốt nhất</span> được đề xuất dành
      cho bạn!
    </h3>

    <div class="List-Item row">
      <div class="col-lg-2" v-for="(item, index) in RoomData" :key="index">
        <div class="card">
          <img
            class="card-img-top"
            :src="'/images/' + item.src"
            alt="Card image cap"
          />
          <div class="card-body p-0 m-3">
            <div class="card-title mb-0">
              <b>{{ item.name }}</b>
            </div>
            <div class="card-text text-info">
              <b style="font-size: 13px"
                ><i class="fa-solid fa-hotel"></i> {{ item.hotel }}</b
              >
            </div>
            <div class="card-text text-success">
              <b style="font-size: 13px"
                ><i class="fa-solid fa-location-dot"></i> {{ item.address }}</b
              >
            </div>
            <div class="card-text text-danger fs-6 text-end">
              <b>{{ item.price }} ₫</b>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import RoomData from "../Data/RoomData";
export default {
  name: "RecommendRoomComponent",
  data() {
    return {
      RoomData: RoomData,
    };
  },
};
</script>

<style>
.RecommendRoom-Container {
  margin: 50px 0;
}

.RecommendRoom-Container > h3 {
  margin: 40px 0 20px 0;
}
</style>
