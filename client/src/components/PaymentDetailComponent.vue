<template lang="">
  <div class="Paymentdetail">
    <div class="card shadow border-0 m-2">
      <div class="card-header">
        <h4 class="card-title">Tóm tắt đặt phòng</h4>
      </div>
      <div
        class="card-body text-capitalize"
        v-for="(item, index) in getCart"
        :key="index"
      >
        <i class="fa-solid fa-hotel"></i>
        <h5 class="d-inline-block m-0">KHÁCH SẠN</h5>
        <div class="row mt-4">
          <div class="col-4">
            <img
              :src="IMAGE_PATH + item.Hotel.thumbnail"
              alt=""
              class="w-100 rounded"
            />
          </div>
          <div class="col-8">
            <h5>{{ item.Hotel.name }}</h5>
            <Rating
              :star="(item.Hotel.rating / 10) * 5"
              :starSize="starSize"
              :hasResults="true"
              :hasDescription="true"
              :ratingDescription="desc"
            />
          </div>
        </div>
        <p class="m-0">
          <i class="fa-regular fa-calendar-days"></i>
          {{ DateFormat(item.Info.checkin) }} -
          {{ DateFormat(item.Info.checkout) }}
        </p>
        <p class="m-0">
          <i class="fa-solid fa-bed"></i> {{ item.Info.room_number }} phòng
          {{ item.Room_Type.name }}
        </p>
        <p class="m-0">
          <i class="fa-regular fa-user"></i> {{ item.Info.adult }} Người lớn{{
            item.Info.children != 0 ? ", " + item.Info.children + " Trẻ em" : ""
          }}
        </p>
        <div class="text-end" v-show="showdetail == false">
          <p class="btn text-primary m-0" v-on:click="showhide()">
            <u>Chi tiết</u> <i class="fa-solid fa-chevron-down"></i>
          </p>
        </div>
        <div v-show="showdetail == true">
          <hr />
          <p class="text-success m-0">
            <i class="fa-solid fa-check"></i> <b>Bao gồm bữa sáng</b>
          </p>
          <p class="m-0">
            <i class="fa-solid fa-wifi"></i>
            <span class="text-success">Wifi miễn phí</span>
          </p>
          <hr />
          <p class="text-danger m-0">
            Nhanh lên! Phòng cuối cùng của chúng tôi ở mức giá này cho ngày bạn
            chọn
          </p>
        </div>
        <div class="text-end" v-show="showdetail == true">
          <p class="btn text-primary m-0" v-on:click="showhide()">
            <u>Ẩn</u> <i class="fa-solid fa-chevron-up"></i>
          </p>
        </div>
      </div>
    </div>
    <div class="card shadow border-0 m-2">
      <div class="card-body">
        <h5 class="card-title">Chi tiết giá</h5>
        <div class="row">
          <div class="col-6">
            <p class="m-0">Tổng cộng</p>
            <p class="m-0 gray">cộng thuế và phí</p>
          </div>
          <div class="col-6 text-end">{{ formatCurrency(getTotal) }}</div>
        </div>
        <hr />
        <div class="row">
          <div class="col-6"><p class="m-0">Tổng quý khách trả</p></div>
          <div class="col-6 text-end">{{ formatCurrency(getTotal) }}</div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import Rating from "./Rating.vue";
import { mapGetters } from "vuex";

export default {
  name: "PaymentDetailComponent",
  components: { Rating },
  data() {
    return {
      IMAGE_PATH: process.env.VUE_APP_IMAGE_PATH,
      showdetail: false,
      desc: [
        {
          text: "Không hài lòng",
          class: "star-poor",
        },
        {
          text: "Hài lòng",
          class: "star-belowAverage",
        },
        {
          text: "Rất tốt",
          class: "star-average",
        },
        {
          text: "Tuyệt vời",
          class: "star-good",
        },
        {
          text: "Trên cả tuyệt vời",
          class: "star-excellent",
        },
      ],
      starSize: "lg", //xs/6x
    };
  },
  methods: {
    showhide() {
      this.showdetail = !this.showdetail;
    },
    DateFormat(DateInput) {
      var date = new Date(DateInput);
      return `${date.getDate()} tháng ${
        date.getMonth() + 1
      } ${date.getFullYear()}`;
    },
    formatCurrency(value) {
      let done = Intl.NumberFormat("vi-VN", {
        style: "currency",
        currency: "VND",
      }).format(value);
      return done;
    },
  },
  computed: {
    ...mapGetters("Cart", ["getCart", "getTotal"]),
  },
};
</script>
<style scoped>
.gray {
  color: rgba(83, 83, 83, 0.795);
}
</style>
