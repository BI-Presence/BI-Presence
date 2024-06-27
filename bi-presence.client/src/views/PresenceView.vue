<script setup lang="ts">
import { ref, computed } from "vue";
import ModalSuccess from "../components/ModalSuccess.vue";
import LoadingIndicator from "../components/LoadingIndicator.vue";

const input = ref<HTMLInputElement | null>(null);
const selectedFileName = ref<string>("Only .jpg, .jpeg, .png");
const showModal = ref<boolean>(false);
const loading = ref<boolean>(false);
const showWarning = ref<boolean>(false); // validation image file (.jpg, .jpeg, .png)
const warningMessage = ref<string>(""); // validation to upload image before pressing button "submit"
const previewImage = ref<string>("src/assets/ic_image.png");
const isFileValid = ref<boolean>(false);

// Validation "file" input
const handleFileChange = (e: Event) => {
  const target = e.target as HTMLInputElement;
  const files = target.files;
  if (files && files.length > 0) {
    const file = files[0];
    const fileType = file.type;

    if (
      fileType === "image/jpeg" ||
      fileType === "image/png" ||
      fileType === "image/jpg"
    ) {
      selectedFileName.value = file.name;
      showWarning.value = false;
      isFileValid.value = true;

      const reader = new FileReader();
      reader.onload = (event: ProgressEvent<FileReader>) => {
        if (event.target && typeof event.target.result === "string") {
          previewImage.value = event.target.result;
        }
      };
      reader.readAsDataURL(file);
    } else {
      showWarning.value = true;
      warningMessage.value =
        "Please upload a valid image file (.jpg, .jpeg, .png).";
      selectedFileName.value = "Only .jpg, .jpeg, .png";
      previewImage.value = "../assets/ic_image.png";
      isFileValid.value = false;
    }
  } else {
    selectedFileName.value = "Only .jpg, .jpeg, .png";
    previewImage.value = "../assets/ic_image.png";
    isFileValid.value = false;
  }
};

// Button Submit Handler
const handleSubmit = async (e: Event) => {
  e.preventDefault();
  if (!input.value || input.value.files?.length === 0) {
    showWarning.value = true;
    warningMessage.value = "Please upload an image before submitting the form.";
    return;
  }
  if (isFileValid.value) {
    loading.value = true;
    try {
      // Simulate an asynchronous API call
      await new Promise((resolve) => setTimeout(resolve, 2000));
      console.log("🚀 ~ input:", input.value.files);
      showModal.value = true;
    } catch (error) {
      console.error("Error submitting the form:", error);
    } finally {
      loading.value = false;
    }
  } else {
    showWarning.value = true;
  }
};

// Elipsis if char more then 13
const truncatedFileName = computed(() => {
  if (selectedFileName.value === "Only .jpg, .jpeg, .png") {
    return selectedFileName.value;
  } else {
    if (selectedFileName.value.length > 13) {
      return `${selectedFileName.value.slice(0, 13)}...`;
    } else {
      return selectedFileName.value;
    }
  }
});
</script>

<template>
  <div class="bg-primary p-12 flex justify-center items-center min-h-screen">
    <form
      class="w-fit lg:w-customFrame bg-white text-black rounded-3xl shadow-lg flex flex-col items-center py-5"
      style="height: auto"
      @submit="handleSubmit"
    >
      <!-- title -->
      <img src="../assets/logo-bi.svg" alt="logo" class="mb-4 w-32" />
      <h1 class="text-black text-center mb-4" style="font-size: 32px">
        BI - Presence
      </h1>

      <div class="grid justify-items-center" style="width: 290px">
        <!-- preview -->
        <div
          class="flex items-center justify-center bg-white border-4 rounded-lg border-primary w-72 h-72"
        >
          <img class="crop w-48 h-48" :src="previewImage" alt="ic_image" />
        </div>
        <!-- upload -->
        <div class="mb-5 grid grid-cols-2 pt-4">
          <label
            for="file_input"
            class="col-span-1 flex items-center border-2 border-primary rounded-lg cursor-pointer bg-white text-primary py-2 justify-center dark:text-primary focus:outline-none dark:border-primary dark:placeholder-gray-400 dark:bg-white dark:hover:bg-slate-200 dark:hover:border-2 dark:hover:border-primary dark:hover:border-opacity-90hover:text-white transition font-bold w-full"
          >
            <img
              src="../assets/upload.png"
              alt="upload icon"
              class="h-6 mr-2"
            />
            <h1>Upload Foto</h1>
            <input
              class="hidden"
              ref="input"
              id="file_input"
              type="file"
              @change="handleFileChange"
              aria-describedby="file_input_help"
            />
          </label>
          <label class="col-span-1 flex items-center opacity-50 text-left ps-2">
            {{ truncatedFileName }}
          </label>
        </div>
        <!-- warning message -->
      </div>
      <div v-if="showWarning" class="text-red-500 col-span-2 mb-4">
        {{ warningMessage }}
      </div>

      <button
        type="submit"
        class="text-white bg-primary hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-fit border-2 border-white sm:w-auto px-5 py-2.5 text-center dark:bg-primary dark:hover:bg-primary dark:hover:opacity-90 dark:hover:border-2 dark:hover:text-white dark:focus:ring-blue-800 transition"
        :disabled="loading || !isFileValid"
      >
        <span v-if="loading">Loading...</span>
        <span v-else>Submit</span>
      </button>

      <!-- divider -->
      <div class="grid grid-cols-3 items-center">
        <div class="grid justify-items-end pe-1">
          <hr class="w-20 border-t-2 border-primary border-1 my-4" />
        </div>
        <p class="text-center">Ingin melakukan login?</p>
        <div class="grid justify-items-start ps-1">
          <hr class="w-20 border-t-2 border-primary border-1 my-4" />
        </div>
      </div>

      <!-- login -->
      <div class="pt-4 mb-3">
        <a
          href="#/login"
          class="text-primary bg-white hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full border-2 border-primary sm:w-auto px-5 py-2.5 text-center dark:bg-white dark:hover:bg-slate-200 dark:hover:border-2 dark:hover:border-primary dark:hover:border-opacity-90 dark:hover:text-primary dark:focus:ring-blue-800 transition"
        >
          Login
        </a>
      </div>
    </form>
    <ModalSuccess
      :visible="showModal && !loading"
      @update:visible="showModal = $event"
    />
    <LoadingIndicator :visible="loading" />
  </div>
</template>

<style scoped>
.text-ellipsis {
  text-overflow: ellipsis;
  max-width: 15ch; /* limits to approximately 15 characters wide */
}
</style>
