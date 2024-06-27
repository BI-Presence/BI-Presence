import { createRouter, createWebHistory } from "vue-router";
// import HomeView from "../views/HomeView.vue";
import LoginView from "../views/LoginView.vue";
import PresenceView from "../views/PresenceView.vue";
import DashboardLayout from "../layout/DashboardLayout.vue";
import DashboardView from "../views/DashboardView.vue";

const routes = [
  {
    path: "/",
    name: "Home",
    component: PresenceView,
  },
  {
    path: "/login",
    name: "Login",
    component: LoginView,
  },
  {
    path: "/dashboard",
    name: "Dashboard",
    component: DashboardLayout,
    redirect: "/dashboard",
    children: [
      {
        path: "/dashboard",
        name: "Dashboard",
        component: DashboardView,
      },
    ],
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
