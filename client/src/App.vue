<template>
  <NavbarComponent />
  <CartPage/>
  <!-- <FooterComponent /> -->
</template>

<script>
import NavbarComponent from "./components/NavbarComponent.vue";
// import FooterComponent from "./components/FooterComponent.vue";
// import ContactPage from "./pages/User/ContactPage.vue";
// import HomePage from "./pages/User/HomePage.vue";
// import IntroPage from "./pages/User/IntroPage.vue";
// import AuthPage from "./pages/User/AuthPage.vue";
import CartPage from "./pages/User/CartPage.vue";

export default {
  name: "App",
  components: { NavbarComponent, CartPage },
};
</script>

<style>
@import url("https://fonts.cdnfonts.com/css/mallory");
@import url("https://fonts.googleapis.com/css2?family=Anton&display=swap");
@import url("https://fonts.googleapis.com/css2?family=Dancing+Script&family=Gilda+Display&family=Italianno&family=Lora:ital,wght@0,400;0,500;0,600;0,700;1,400;1,500;1,600;1,700&family=Playfair+Display:ital,wght@0,400;0,500;0,600;0,700;0,800;0,900;1,400;1,500;1,600;1,700;1,800;1,900&family=Poppins:ital,wght@0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap");

:root {
  --main-Color: rgb(220, 53, 69);
  --gray-Color: rgb(153, 153, 153);
  --blue-Color: rgb(62, 108, 234);
  --font-Graycolor: rgb(112, 112, 112);
  --custom-Color : rgb(255, 255, 255);
  --font-Mallory: "Mallory", sans-serif;
  --font-Anton: "Anton", sans-serif;
  --border-Input: 1px solid rgb(215, 215, 215);
  --font-Display: "Playfair Display", serif;
  --font-Dancing: "Dancing Script", cursive;
  --bgFooter: #2e2e2e;
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
