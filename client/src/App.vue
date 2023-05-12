<template>
  <NavbarComponent />
  <AuthPage />
  <FooterComponent />
</template>

<script>
import NavbarComponent from "./components/NavbarComponent.vue";
import FooterComponent from "./components/FooterComponent.vue";
import AuthPage from "./pages/User/AuthPage.vue";

export default {
  name: "App",
  components: { NavbarComponent, FooterComponent, AuthPage },
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

.Button-Main {
  background: var(--main-Color);
  border-radius: 10px;
}
</style>
