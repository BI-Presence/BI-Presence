<template>
  <div class="dashboard-layout">
    <Sidebar />
    <div class="md:pl-80 px-8 md:pr-16 py-20 md:py-[3%]">
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
