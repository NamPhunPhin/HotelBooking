<template>
  <NavbarComponent />
  <!-- <img src="/images/banner.png" alt="" /> -->
</template>

<script>
import NavbarComponent from "./components/NavbarComponent.vue";
export default {
  name: "App",
  components: { NavbarComponent },
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
