<template lang="">
  <div class="row total-list">
    <!-- List item -->
    <div class="col-md-8 List">
      <div class="ListCart">
        <!-- Show Quantity items -->
        <div class="card mb-4">
          <div class="card-body itemQTY">
            <h4 class="mt-2 mb-2">Your cart ({{ CartData.length }})</h4>
          </div>
        </div>
        <!-- List items -->
        <div class="list-items" v-for="(item, index) in CartData" :key="index">
          <div class="card item mb-4">
            <div class="card-body">
              <div class="row info-item justify-content-between w-100">
                <div class="col-3 img">
                  <!-- item's img -->
                  <img :src="'/images/' + item.src" alt="" class="w-100" />
                </div>
                <div class="col-8 p-0 text-start">
                  <!-- item's hotel name -->
                  <h5>{{ item.hotel }}</h5>
                  <div class="address-comm-rate d-flex">
                    <!-- rating item -->
                    <div class="rate-star">
                      <Rating
                        :star="(item.rate / 10) * 5"
                        :starSize="starSize"
                        :hasResults="true"
                        :hasDescription="true"
                        :ratingDescription="desc"
                      />
                    </div>
                    <!-- address & comments -->
                    <div class="address-comm">
                      <!-- address -->
                      <p>
                        <i class="fa-solid fa-location-dot fa-sm"></i>
                        {{ item.city }}
                      </p>
                      <!-- comments -->
                      <p>{{ item.comQTY }} comments</p>
                    </div>
                  </div>
                </div>
                <div class="col-1 del-icon p-0 text-end"><i class="fa-solid fa-trash-can fa-xl"></i></div>
              </div>
            </div>
            <div
              :class="'bg-' + index + ' card-footer'"
              v-on:click="checkAcpt(index)"
            >
              <div class="row room-price">
                <div class="col-md room-checkin-checkout">
                  <!-- room name -->
                  <div class="form-check">
                    <input
                      :class="
                        'check-' + index + ' form-check-input' + ' room-check'
                      "
                      type="checkbox"
                      v-model="item.action"
                      value=""
                      id="flexCheckDefault"
                    />
                    <label
                      class="form-check-label room-name"
                      for="flexCheckDefault"
                    >
                      {{ item.name }}
                    </label>
                  </div>
                  <p class="daycheck">
                    {{ CalDate(item.checkin) }} - {{ CalDate(item.checkout) }}
                  </p>
                </div>
                <!-- item price -->
                <div class="col-md text-end">
                  <p class="m-0 price">{{ formatCurrency(item.price) }}</p>
                  <p class="m-0 tax">Bao gồm thuế và phí</p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <!-- Total-Payment Button -->
    <div class="col-md Total">
      <div class="TotalCart card">
        <div class="row card-body">
          <div class="col-6 text-sm-start">
            <div class="total-price">Total Price</div>
            <div class="item-qty">
              {{ Qtychekitem() }}, including taxes & fees
            </div>
          </div>
          <div class="col-6 text-end">{{ formatCurrency(SumTotal()) }} </div>
          <div class="btn-action btn btn-primary w-100 mt-3">Next</div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import CartData from "@/Data/CartData";
import Rating from "./Rating.vue";

export default {
  name: "ListCartComponent",
  components: { Rating },
  data() {
    return {
      CartData: CartData,
      desc: [
        {
          text: "Poor",
          class: "star-poor",
        },
        {
          text: "Below Average",
          class: "star-belowAverage",
        },
        {
          text: "Average",
          class: "star-average",
        },
        {
          text: "Good",
          class: "star-good",
        },
        {
          text: "Excellent",
          class: "star-excellent",
        },
      ],
      starSize: "lg", //xs/6x
    };
  },
  methods: {
    CalDate(date) {
      let day = date.slice(0, 2);
      let month = date.slice(3, 5);
      let year = date.slice(6, 10);
      let daytime = day + " tháng " + month + " năm " + year;
      return daytime;
    },
    checkAcpt: (id) => {
      let item = CartData;
      let Chekclass = ".check-" + id;
      let Bgclass = ".bg-" + id;
      let bg = document.querySelector(Bgclass);
      let check = document.querySelector(Chekclass);
      if (item[id].action != true) {
        bg.setAttribute(
          "style",
          "background-color: rgb(235, 240, 252) !important;"
        );
        CartData[id].action == true;
      } else {
        bg.setAttribute("style", "background-color: White;");
        CartData[id].action == false;
      }
      check.click();
    },
    Qtychekitem()  {
      let qty = 0;
      let item = CartData;
      for (let i = 0; i < item.length; i++) {
        if (item[i].action == true) {
          qty = qty + 1;
        }
      }
      return qty;
    },
    SumTotal() {
      let total = 0;
      let item = CartData;
      for (let i = 0; i < item.length; i++) {
        if (item[i].action == true) {
          total = total + item[i].price ;
        }
      }
      return total ;
    },
    formatCurrency(value) {
      let done = Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(value) ;
      return done ;
    }
  },
};
</script>
<style scoped>
.ListCart {
  margin-top: 24px;
  margin-right: 16px;
  padding: 0px;
  width: 100%;
}

.info-item {
  padding: 0px !important;
}

.img img {
  border-radius: 5px;
}

.rate-star {
  display: inline-block;
}

.progress-rate {
  background-color: rgb(255, 255, 255);
  width: 20%;
  display: block;
  margin-left: auto;
  position: relative;
  top: -25px;
}

.address-comm p {
  color: var(--font-Graycolor);
  font-size: 16.5px;
}

.room-price {
  padding: 5px 0px !important;
  font-size: 18px;
}

.price {
  font-weight: 500;
}

.daycheck,
.tax {
  font-size: 15px;
  margin-bottom: 0px;
  color: var(--font-Graycolor);
}

.room-name {
  color: var(--blue-Color);
}

.room-check {
  border: 1px solid var(--blue-Color) !important;
}

.card-footer {
  background-color: white !important;
  cursor: pointer;
}

.total-list {
  padding: 0 70px;
}

.TotalCart {
  margin-top: 24px;
  padding: 16px 12px;
  width: 100%;
}

.del-icon{
  cursor: pointer;
}

@media screen and (max-width: 767px) {
  .TotalCart {
    margin: 0;
  }

  .total-list {
    padding: 0px;
  }

  .List {
    padding: 0px;
  }

  .Total {
    height: 200px;
    padding: 0px;
  }

  .TotalCart{
    position: fixed;
    bottom: 0px;
  }
}
</style>
