<template lang="">
  <div class="TotalCart card">
    <div class="row card-body">
      <div class="col-6 text-sm-start">
        <div class="total-price">Total Price</div>
        <div class="item-qty">{{ Qtychekitem() }}, including taxes & fees</div>
      </div>
      <div class="col-6 text-end">509.123 đ</div>
      <div class="btn-action btn btn-primary w-100 mt-3">Next</div>
    </div>
  </div>
</template>
<script>
import CartData from "@/Data/CartData";

export default {
  name: "TotalCartComponent",
  data() {
    return {
      CartData: CartData,
    };
  },
  methods: {
    Qtychekitem: ()=>{
        let qty = 0 ;
        let item = CartData;
        for (let i = 0; i < item.length; i++) {
            if (item[i].action==true) {
                qty= qty+1;
            }
        }
        return qty ;
    },
  },
};
</script>
<style>
.TotalCart {
  margin-top: 24px;
  padding: 16px 12px;
  width: 100%;
}

@media screen and (max-width: 767px) {
  .TotalCart {
    margin: 0;
  }
}
</style>
