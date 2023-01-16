import { createRouter, createWebHistory } from "vue-router";

export const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      redirect: "/login",
    },
    {
      path: "/login",
      name: "login",
      component: () => import("../pages/login/index.vue"),
    },
    {
      path: "/home",
      name: "home",
      component: () => import("../pages/home/index.vue"),
    },
  ],
});
