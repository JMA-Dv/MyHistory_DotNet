import "./assets/main.css";
import App from "./App.vue";
import { createApp } from "vue";
import { pinia } from "./pinia";
import { router } from "./router";
import { vuetify } from "./vuetify";

createApp(App).use(pinia).use(router).use(vuetify).mount("#app");
