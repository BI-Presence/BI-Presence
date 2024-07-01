import { createRouter, createWebHistory } from "vue-router";
// import HomeView from "../views/HomeView.vue";
import LoginView from "../views/LoginView.vue";
import PresenceView from "../views/PresenceView.vue";
import DashboardLayout from "../layout/DashboardLayout.vue";
import DashboardView from "../views/DashboardView.vue";
import EditProfileView from "../views/EditProfileView.vue";
import DataEmployeeView from "../views/DataEmployeeView.vue";
import DashboardViewSuper from "../views/DashboardView-supervisor.vue";
import DashboardViewEmploy from "../views/DashboardView-employee.vue";

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
        path: "/dashboard/supervisor",
        name: "DashboardSupervisor",
        component: DashboardViewSuper,
      },
      {
        path: "/dashboard/employee",
        name: "DashboardEmployee",
        component: DashboardViewEmploy,
      },
      {
        path: "/dashboard/editprofile",
        name: "Edit Profile",
        component: EditProfileView,
      },
      {
        path: "/dashboard/dataemployee",
        name: "Data Employee",
        component: DataEmployeeView,
      },
    ],
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
