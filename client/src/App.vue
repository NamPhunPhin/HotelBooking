<template>
  <div>
    <NavbarComponent/>
    <FooterComponent/>
  </div>
</template>

<script>
import NavbarComponent from './components/NavbarComponent.vue';
import FooterComponent from './components/FooterComponent.vue';

export default {
  name: "App",
  components: {NavbarComponent, FooterComponent},
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
