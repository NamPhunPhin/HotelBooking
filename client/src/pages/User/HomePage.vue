<template>
  <div class="Home-Container">
    <div class="Banner-Searching">
      <div class="Text-Banner">
        <h3>KHÁCH SẠN, KHU NGHỈ DƯỠNG, NHÀ TRỌ & HƠN THẾ NỮA</h3>
        <span>Nhận giá tốt nhất cho > 2.000.000 chỗ nghỉ, trên toàn cầu</span>
      </div>
      <div class="Searching-Component">
        <SearchBoxComponent />
      </div>
    </div>
    <div class="Home-Body container">
      <TopDestinationsSlideComponent />
      <RecommendHotelComponent />
      <RecommendRoomComponent />
      <TopDestinationsSlideComponent :is-out-side="true" />
    </div>
  </div>
</template>

<script>
import SearchBoxComponent from "../../components/SearchBoxComponent.vue";
import TopDestinationsSlideComponent from "../../components/TopDestinationsSlideComponent.vue";
import RecommendHotelComponent from "../../components/RecommendHotelComponent.vue";
import RecommendRoomComponent from "../../components/RecommendRoomComponent.vue";
export default {
  components: {
    SearchBoxComponent,
    TopDestinationsSlideComponent,
    RecommendHotelComponent,
    RecommendRoomComponent,
  },
};
</script>

<style>
.Banner-Searching {
  height: 320px;
  background-image: url(../../../public/images/carousel_3.jpg);
  position: relative;
  margin-bottom: 20rem;
}

.Text-Banner {
  color: white;
  width: 100%;
  text-align: center;
  position: absolute;
  top: 30px;
}

.Text-Banner > h4 {
  font-size: 24px;
}

.Text-Banner > span {
  font-size: 18px;
}

.Searching-Component {
  position: absolute;
  width: 100%;
  top: 45%;
}

@media only screen and (max-width: 850px) {
  .Text-Banner {
    position: unset;
    padding: 20px;
  }

  .Searching-Component {
    position: unset;
    padding: 20px;
  }

  .Banner-Searching {
    margin-bottom: 20px;
    height: unset;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
  }
}
</style>
