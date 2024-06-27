<template>
  <transition name="fade">
    <div
      v-if="visible"
      class="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50"
    >
      <div class="bg-white p-6 rounded-lg shadow-lg">
        <h2 class="text-xl font-bold mb-4 text-black">Success!</h2>
        <p class="text-black">Your form has been successfully submitted.</p>
        <button
          @click="hideModal"
          class="mt-4 bg-primary text-white px-4 py-2 rounded"
        >
          Close
        </button>
      </div>
    </div>
  </transition>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "ModalSuccess",
  props: {
    visible: {
      type: Boolean,
      required: true
    }
  },
  emits: ["update:visible"],
  setup(props, { emit }) {
    const hideModal = () => {
      emit("update:visible", false);
    };

    return {
      hideModal
    };
  }
});
</script>

<style scoped>
.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s;
}
.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}
</style>
