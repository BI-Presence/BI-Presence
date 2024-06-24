<template>
  <div
    class="relative z-50 aspect-[1/0.75] w-5 cursor-pointer md:hidden"
    @click="handleToggle"
  >
    <div
      :class="[
        'absolute h-[0.2rem] w-full -translate-y-1/2 rounded-lg transition-all duration-300 ease-in-out',
        isOpen ? 'top-1/2 rotate-45 bg-white' : 'top-0 rotate-0 bg-primary',
      ]"
    ></div>
    <div
      :class="[
        'absolute top-1/2 h-[0.2rem] w-full -translate-y-full rounded-lg bg-primary transition-all duration-300 ease-in-out',
        isOpen ? 'scale-x-0' : 'scale-x-100',
      ]"
    ></div>
    <div
      :class="[
        'absolute h-[0.2rem] w-full -translate-y-1/2 rounded-lg transition-all duration-300 ease-in-out',
        isOpen ? 'top-2/4 -rotate-45 bg-white' : 'bottom-0 rotate-0 bg-primary',
      ]"
    ></div>
  </div>
</template>

<script lang="ts">
export default {
  name: "MenuIcon",
  props: {
    isOpen: {
      type: Boolean,
      required: true,
    },
  },
  methods: {
    handleToggle() {
      this.$emit("toggle");
    },
  },
};
</script>
