import { createApp } from "vue";
import App from "./App.vue";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap";
import router from "./Routes/router";
import store from "./Store";

createApp(App).use(store).use(router).mount("#app");
