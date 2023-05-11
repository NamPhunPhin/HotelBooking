<template>
<<<<<<< HEAD
  <NavbarComponent />
  <!-- <img src="/images/banner.png" alt="" /> -->
</template>

<script>
import NavbarComponent from "./components/NavbarComponent.vue";
export default {
  name: "App",
  components: { NavbarComponent },
=======
  <div>
    <FooterComponent></FooterComponent>
  </div>
</template>

<script>
import FooterComponent from './components/FooterComponent.vue';

export default {
  name: "App",
  components: {FooterComponent},
>>>>>>> e723f27c7fd85c43c58ad734d28efb1cbf1cc7e1
};
</script>

<style>
@import url("https://fonts.cdnfonts.com/css/mallory");

:root {
  --main-Color: rgb(220, 53, 69);
  --font-Mallory: "Mallory", sans-serif;
}

* {
  margin: none;
  padding: none;
}
</style>
