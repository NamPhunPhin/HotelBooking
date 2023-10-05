<template lang="">
  <div class="OrderList">
    <div class="Title mb-4">Đơn hàng của bạn</div>
    <div class="List" v-for="(item, index) in getOrder" :key="index">
      <div class="card mb-3">
        <div class="card-header">
          <div class="row">
            <h5 class="m-0 col-6">Đơn hàng #{{ item.order_id }}</h5>
            <p class="col-6 text-end pe-3">{{ item.status_order }}</p>
          </div>
        </div>
        <div class="row">
          <div class="col-12 p-0">
            <div class="card-body ps-2 pe-2 pb-0">
              <div class="row" v-for="(i, k) in item.details" :key="k">
                <div class="col-8">
                  <div class="row p-3">
                    <div class="col-4">
                      <img
                        :src="
                          i.thumbnail
                            ? IMAGE_PATH + i.thumbnail
                            : IMAGE_PATH + 'Khachsan1.jpg'
                        "
                        class="w-100 rounded"
                        alt=""
                      />
                    </div>
                    <div class="col-8">
                      <h5 class="card-title mb-0 mt-2">
                        {{ i.hotel_name }}
                      </h5>
                      <h6 class="mb-0 mt-2">
                        X{{ i.quatity_room }} {{ i.room_name }}
                      </h6>
                      <p class="card-text mb-0">
                        {{ i.adults }} người lớn
                        {{
                          i.childrens != 0
                            ? ", " + i.childrens + " Trẻ em"
                            : ""
                        }}
                        <br />
                        {{ DateFormat(i.check_in) }} -
                        {{ DateFormat(i.check_out) }} <br>
                        Giá : {{ formatCurrency(i.price) }} <br>
                        Tình trạng phòng : {{ i.status_room }}
                      </p>
                    </div>
                  </div>
                </div>
                <div class="col-4 text-center">
                  <Rating
                    :star="(i.rating / 10) * 5"
                    :starSize="starSize"
                    :hasResults="true"
                    :hasDescription="true"
                    :ratingDescription="desc"
                  />
                </div>
              </div>
              <div class="row ps-2 status_order">
                <div class="col-6">Tổng cộng (bao gồm thuế và phí):</div>
                <div class="col-6 text-end pe-4">
                  {{ formatCurrency(item.total) }}
                </div>
                <div class="col-6">Tình trạng đơn hàng:</div>
                <div class="col-6 text-end pe-4">
                  {{ item.status_order }}
                </div>
                <div class="col-6">Tình trạng thanh toán:</div>
                <div class="col-6 text-end pe-4">
                  {{ item.status_payment }}
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="List" v-if="getOrder.length < 1">
      <div class="card item mb-4">
        <div class="card-body">
          <div class="Image-Empty">
            <img src="/images/empty-cart.png" alt="" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import Rating from "./Rating.vue";
import { mapGetters } from "vuex";
import { GetOrderByUserId } from "@/API/OrderRequests";

export default {
  name: "OrderListComponent",
  components: { Rating },
  data() {
    return {
      IMAGE_PATH: process.env.VUE_APP_IMAGE_PATH,
      showdetail: false,
      getOrder: "",
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
  async created() {
    const order_data = await GetOrderByUserId(this.$route.params.id);
    this.getOrder = order_data.data;

    console.log(order_data);
  },
  methods: {
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
    ...mapGetters("Auth", ["getUser", "getAuthStatus"]),
  },
};
</script>
<style scoped>

p,.status_order {
  font-family: var(--font-Anton);
  font-weight: 300;
}
.OrderList > .Title {
  font-size: 20px;
  font-weight: 600;
}

.Image-Empty {
  margin: 50px 0;
  display: flex;
  justify-content: center;
  align-items: center;
}

.Image-Empty > img {
  height: 200px;
  width: 200px;
  object-fit: cover;
}
</style>
