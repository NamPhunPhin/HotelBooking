import { createRouter, createWebHistory } from "vue-router";

import HomePage from "@/pages/User/HomePage.vue";
import AuthPage from "@/pages/User/AuthPage.vue";
import ContactPage from "@/pages/User/ContactPage.vue";
import HotelDetailPage from "@/pages/User/HotelDetailPage.vue";
import HotelsPage from "@/pages/User/HotelsPage.vue";
import IntroPage from "@/pages/User/IntroPage.vue";
import CartPage from "@/pages/User/CartPage.vue";

const routes = [
  {
    path: "/",
    component: HomePage,
  },
  {
    path: "/hotels/detail/:roomid/:checkin/:checkout/:countryid/:cityid/:adult/:child/:room",
    component: HotelDetailPage,
  },
  {
    path: "/auth",
    component: AuthPage,
  },
  {
    path: "/auth/:signup",
    component: AuthPage,
  },
  {
    path: "/hotels/:checkin/:checkout/:countryid/:cityid/:adult/:child/:room",
    component: HotelsPage,
    params: true,
  },
  {
    path: "/about",
    component: IntroPage,
  },
  {
    path: "/contact",
    component: ContactPage,
  },
  {
    path: "/cart",
    component: CartPage,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes: routes,
});

export default router;
