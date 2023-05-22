import { createRouter, createWebHistory } from "vue-router";

import HomePage from "@/pages/User/HomePage.vue";
import AuthPage from "@/pages/User/AuthPage.vue";
import ContactPage from "@/pages/User/ContactPage.vue";
import HotelDetailPage from "@/pages/User/HotelDetailPage.vue";
import HotelsPage from "@/pages/User/HotelsPage.vue";
import IntroPage from "@/pages/User/IntroPage.vue";

const routes = [
  {
    path: "/",
    component: HomePage,
  },
  {
    path: "/hotels/detail",
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
    path: "/hotels",
    component: HotelsPage,
  },
  {
    path: "/about",
    component: IntroPage,
  },
  {
    path: "/contact",
    component: ContactPage,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes: routes,
});

export default router;
