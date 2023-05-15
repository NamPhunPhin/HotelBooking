<template>
  <NavbarComponent />
  <HomePage />
  <FooterComponent />
</template>

<script>
import NavbarComponent from "./components/NavbarComponent.vue";
import FooterComponent from "./components/FooterComponent.vue";
import HomePage from "./pages/User/HomePage.vue";
// import IntroPage from "./pages/User/IntroPage.vue";
// import AuthPage from "./pages/User/AuthPage.vue";

export default {
  name: "App",
  components: { NavbarComponent, FooterComponent, HomePage },
};
</script>

<style>
@import url("https://fonts.cdnfonts.com/css/mallory");
@import url("https://fonts.googleapis.com/css2?family=Anton&display=swap");

:root {
  --main-Color: rgb(220, 53, 69);
  --gray-Color: rgb(153, 153, 153);
  --font-Mallory: "Mallory", sans-serif;
  --font-Anton: "Anton", sans-serif;
  --border-Input: 1px solid rgb(215, 215, 215);
}

h1,
h2,
h3,
h4,
h5,
h6 {
  font-family: var(--font-Anton);
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
