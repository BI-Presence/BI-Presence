<template>
  <div class="dashboard-layout">
    <Sidebar />
    <div class="pl-72 py-[3%]">
      <router-view />
    </div>
  </div>
</template>

<script lang="ts">
import Sidebar from "../components/Sidebar.vue";

export default {
  name: "DashboardLayout",
  components: {
    Sidebar,
  },
};
</script>
