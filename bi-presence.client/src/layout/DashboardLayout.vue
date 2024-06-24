<template>
  <div class="dashboard-layout">
    <Sidebar />
    <div class="md:pl-80 pl-8 py-20 md:py-[3%]">
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
