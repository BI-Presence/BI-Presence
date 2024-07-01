<template>
  <div class="w-full flex items-center justify-between">
    <h1 class="font-semibold text-2xl">{{ title }}</h1>
    <div class="flex gap-4 font-medium items-center">
      <p>{{ name }}</p>
      <img
        src="../assets/gibs.jpeg"
        alt="profile picture"
        class="w-14 rounded-full"
      />
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "DashboardHeader",
  props: {
    title: {
      type: String,
      required: true,
    },
    name: {
      type: String,
      required: true,
    },
    imgSrc: {
      type: String,
      required: true,
    },
  },
});
</script>

<style scoped>
/* Add any scoped styles here if needed */
</style>
