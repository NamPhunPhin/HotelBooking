<template>
  <div class="TopDestinations-Container">
    <h3 class="text-center">
      {{
        isOutSide ? "Các điểm đến nổi tiếng ngoài" : "Các điểm đến thu hút nhất"
      }}
      <span class="text-danger">Việt Nam</span>
    </h3>

    <div class="Country-Slide">
      <div class="Icon-Control-Left" @click="LeftHandleClick()">
        <i class="fa-solid fa-chevron-left"></i>
      </div>

      <div
        class="Item-List text-center"
        ref="CarouselCountry"
        @mousedown.prevent="DragStart"
        @mousemove.prevent="Dragging"
        @mouseup.prevent="DragStop()"
        @mouseout="DragStop()"
      >
        <span
          class="Slide-Item"
          v-for="(item, index) in isOutSide ? CountryData : CityData"
          :key="index"
          @click="DestinationHandleClick(item)"
        >
          <img
            :src="item.image_name != '' && IMAGE_PATH + item.image_name"
            alt=""
          />
          <div class="City-Name">{{ item.name }}</div>
          <div class="Hotel-Number text-secondary">
            {{ item.quatity_hotels }} khách sạn
          </div>
        </span>
      </div>

      <div class="Icon-Control-Right" @click="RightHandleClick()">
        <i class="fa-solid fa-chevron-right"></i>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "TopDestinationsSlideComponent",
  props: ["isOutSide", "dataCity", "dataCountry"],
  data() {
    return {
      IMAGE_PATH: process.env.VUE_APP_IMAGE_PATH,
      isDragStart: false,
      prevPageX: 0,
      prevScrollLeft: 0,
      CityData: this.dataCity,
      CountryData: this.dataCountry,
    };
  },

  methods: {
    DestinationHandleClick(item) {
      this.$emit("destination-event", item);
    },

    DragStart(e) {
      this.isDragStart = !this.isDragStart;
      this.prevPageX = e.pageX;
      this.prevScrollLeft = this.$refs.CarouselCountry.scrollLeft;
    },
    Dragging(e) {
      e.preventDefault();
      if (!this.isDragStart) {
        return;
      }
      let positionDiff = e.pageX - this.prevPageX;
      this.$refs.CarouselCountry.scrollLeft =
        this.prevScrollLeft - positionDiff;
    },
    DragStop() {
      this.isDragStart = false;
    },
    RightHandleClick() {
      this.$refs.CarouselCountry.scrollLeft +=
        this.$refs.CarouselCountry.clientWidth;
    },
    LeftHandleClick() {
      this.$refs.CarouselCountry.scrollLeft -=
        this.$refs.CarouselCountry.clientWidth;
    },
  },
};
</script>

<style>
.Country-Slide {
  width: 100%;
  overflow-x: auto;
  position: relative;
  margin: 50px 0;
}

.TopDestinations-Container {
  margin: 100px 0;
}

.Item-List {
  white-space: nowrap;
  overflow: hidden;
  cursor: pointer;
  scroll-behavior: smooth;
}

.Icon-Control-Left {
  position: absolute;
  left: 0;
  top: 0;
  bottom: 0;
  align-self: center;
  width: 40px;
  display: flex;
  justify-content: center;
  align-items: center;
  cursor: pointer;
  background: linear-gradient(
    to left,
    rgba(255, 255, 255, 0),
    rgb(255, 255, 255)
  );
}

.Icon-Control-Left > i {
  font-size: 20px;
}

.Icon-Control-Right > i {
  font-size: 20px;
}

.Icon-Control-Right:hover {
  background: linear-gradient(
    to right,
    rgba(255, 255, 255, 0.6),
    rgb(255, 255, 255)
  );
  color: var(--main-Color);
}

.Icon-Control-Left:hover {
  background: linear-gradient(
    to left,
    rgba(255, 255, 255, 0.6),
    rgb(255, 255, 255)
  );
  color: var(--main-Color);
}

.Icon-Control-Right {
  position: absolute;
  right: 0;
  top: 0;
  bottom: 0;
  align-self: center;
  width: 40px;
  display: flex;
  justify-content: center;
  align-items: center;
  cursor: pointer;
  background: linear-gradient(
    to right,
    rgba(255, 255, 255, 0),
    rgb(255, 255, 255)
  );
}

.Slide-Item > img {
  border-radius: 50%;
  border-style: solid;
  border-width: 1px;
  height: 124px;
  width: 124px;
  transition: 0.2s all ease-in-out;
  border-color: #dddfe2;
}

.Slide-Item > img:hover {
  transform: scale(1.1);
}

.Slide-Item {
  display: inline-block;
  width: 190px;
  padding: 20px;
  word-wrap: break-word;
}

.City-Name {
  font-weight: 600;
  font-family: var(--font-Mallory);
  margin-top: 10px;
}

.Hotel-Number {
  font-size: 13px;
}
</style>
