<template>
  <div class="Home-Container" ref="HomeContainer">
    <div class="Banner-Searching">
      <div class="Text-Banner">
        <h3>KHÁCH SẠN, KHU NGHỈ DƯỠNG, NHÀ TRỌ & HƠN THẾ NỮA</h3>
        <span>Nhận giá tốt nhất cho > 2.000.000 chỗ nghỉ, trên toàn cầu</span>
      </div>
      <div class="Searching-Component" v-if="!view.topOfPage">
        <SearchBoxComponent />
      </div>
    </div>
    <div class="Home-Body container">
      <TopDestinationsSlideComponent
        v-if="!getStatusCitiesAndQuatityHotels.isLoading"
        :data-city="getDataCitiesAndQuatityHotels"
      />

      <div v-else class="text-center m-5">
        <div class="spinner-border text-danger" role="status">
          <span class="sr-only">Loading...</span>
        </div>
      </div>

      <RecommendHotelComponent />
      <RecommendRoomComponent />
      <TopDestinationsSlideComponent
        v-if="!getStatusCountriesAndQuatityHotels.isLoading"
        :data-country="getDataCountriesAndQuatityHotels"
        :is-out-side="true"
      />
      <div v-else class="text-center isLoading m-5">
        <div class="spinner-border text-danger" role="status">
          <span class="sr-only">Loading...</span>
        </div>
      </div>
    </div>
  </div>
  <div class="Search-Nav" v-if="view.topOfPage">
    <SearchNavbarComponent />
  </div>
</template>

<script>
import SearchBoxComponent from "../../components/SearchBoxComponent.vue";
import TopDestinationsSlideComponent from "../../components/TopDestinationsSlideComponent.vue";
import RecommendHotelComponent from "../../components/RecommendHotelComponent.vue";
import SearchNavbarComponent from "../../components/SearchNavbarComponent.vue";
import RecommendRoomComponent from "../../components/RecommendRoomComponent.vue";
import { mapGetters, mapActions } from "vuex";
export default {
  data() {
    return {
      view: {
        topOfPage: false,
      },
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

  components: {
    SearchBoxComponent,
    TopDestinationsSlideComponent,
    RecommendHotelComponent,
    RecommendRoomComponent,
    SearchNavbarComponent,
  },

  mounted() {
    console.log(this.getDataCountriesAndQuatityHotels);
  },

  created() {
    this.CitiesAndQuatityHotelsAction(1);
    this.CountriesOutSideAndHotelsAction(1);
  },

  computed: {
    ...mapGetters("Home", [
      "getDataCitiesAndQuatityHotels",
      "getStatusCitiesAndQuatityHotels",
      "getDataCountriesAndQuatityHotels",
      "getStatusCountriesAndQuatityHotels",
    ]),
  },

  methods: {
    ...mapActions("Home", [
      "CitiesAndQuatityHotelsAction",
      "CountriesOutSideAndHotelsAction",
    ]),

    NavSearchHandleScroll() {
      document.documentElement.scrollTop > 550
        ? (this.view.topOfPage = true)
        : (this.view.topOfPage = false);
    },
  },

  beforeMount() {
    window.addEventListener("scroll", this.NavSearchHandleScroll);
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

.Search-Nav {
  width: 100%;
  position: fixed;
  top: 0;
  z-index: 9999;
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

  .isLoading {
    min-width: 200px;
  }
}
</style>
