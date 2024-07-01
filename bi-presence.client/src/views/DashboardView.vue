<template>
  <div class="dashboard-view">
    <dashboard-header
      title="Dashboard"
      name="Gibran Fasha"
      img-src="src/assets/gibs.jpeg"
    />
  </div>
</template>

<script lang="ts">
import DashboardHeader from "../components/DashboardHeader.vue";
export default {
  components: { DashboardHeader },
  name: "DashboardView",
};
</script>
