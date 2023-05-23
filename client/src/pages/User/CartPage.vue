<template lang="">
  <div class="AcItem container-fluid" v-if="CartData.length>0">
    <ListCartComponent />
  </div>
  <div class="AcItem container-fluid" v-else>
    <EmptyCartComponent />
  </div>
</template>
<script>
import EmptyCartComponent from '../../components/EmptyCartComponent.vue';
import ListCartComponent from "@/components/ListCartComponent.vue";
import CartData from "@/Data/CartData";

export default {
  name: "CartPage",
  components: { ListCartComponent, EmptyCartComponent },
  data() {
    return {
        CartData: CartData,
    };
  },
};
</script>
<style scoped>
.AcItem {
  width: 100%;
}
</style>
