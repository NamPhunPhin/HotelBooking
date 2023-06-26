import { createRouter, createWebHistory } from "vue-router";

import HomePage from "@/pages/User/HomePage.vue";
import AuthPage from "@/pages/User/AuthPage.vue";
import ContactPage from "@/pages/User/ContactPage.vue";
import HotelDetailPage from "@/pages/User/HotelDetailPage.vue";
import HotelsPage from "@/pages/User/HotelsPage.vue";
import IntroPage from "@/pages/User/IntroPage.vue";
import CartPage from "@/pages/User/CartPage.vue";
import AccountPage from "@/pages/User/AccountPage.vue";
import { GetLocalStorage } from "../service/AccountService";

const routes = [
  {
    path: "/",
    component: HomePage,
  },
  {
    path: "/hotels/detail/:id",
    component: HotelDetailPage,
  },
  {
    path: "/auth",
    component: AuthPage,
    name: "login",
    meta: {
      requiresAuth: false,
    },
  },
  {
    path: "/auth/:signup",
    component: AuthPage,
    name: "signup",
    meta: {
      requiresAuth: false,
    },
  },
  {
    path: "/hotels",
    component: HotelsPage,
    params: true,
  },
  {
    path: "/account",
    component: AccountPage,
    meta: {
      requiresAuth: true,
    },
  },
  {
    path: "/account/:id",
    component: AccountPage,
    meta: {
      requiresAuth: true,
    },
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
  {
    path: "/payment",
    component: CartPage,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes: routes,
});

const isLogined = GetLocalStorage("user");

// eslint-disable-next-line no-unused-vars
router.beforeEach((to, from, next) => {
  if ("requiresAuth" in to.meta) {
    if (to.meta.requiresAuth && !isLogined) {
      next("/auth");
    } else if (!to.meta.requiresAuth && isLogined) {
      next("/");
    } else {
      next();
    }
  } else {
    next();
  }
});

export default router;
