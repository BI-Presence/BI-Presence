<template>
    <div
      v-for="(item, index) in dataTitle"
      :key="index"
      class="flex flex-row items-center rounded-lg shadow md:flex-row md:max-w-xl my-4 w-auto mx-7 lg:my-0"
      :style="{ backgroundColor: item.color }"
    >
      <div class="ms-5" v-html="item.img"></div>
      <div class="flex flex-col justify-between p-4 leading-normal">
        <h5
          class="mb-2 text-xs font-bold tracking-tight text-gray-900 dark:text-white"
        >
          {{ item.title }}
        </h5>
        <p class="mb-3 font-normal text-5xl text-white dark:text-white">
          {{ item.value }}
        </p>
      </div>
  </div>
</template>

<script setup lang="ts">
import { defineProps } from "vue";

const props = defineProps({
  dataTitle: {
    type: Array as () => {
      title: string;
      img?: string;
      value: number;
      color: string;
    }[],
    required: true,
  },
});
</script>

<style scoped>
/* Optional: Adjustments to make the image perfectly round */
img {
  object-fit: cover;
}
</style>
