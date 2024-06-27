<template>
  <div
    class="bg-primary min-h-screen flex flex-col items-center justify-center"
  >
    <div
      class="bg-[#F9F9F9] flex flex-col items-center justify-center md:p-10 p-4 rounded-lg w-4/5 md:w-3/5"
    >
      <img src="../assets/logo-bi.svg" alt="logo" class="w-32" />
      <p class="text-2xl">BI - Presence</p>

      <form @submit="handleLogin" class="flex flex-col mt-12 gap-6 w-full">
        <div class="flex flex-col gap-2">
          <label>Email</label>
          <input
            v-model="email"
            type="text"
            placeholder="Masukkan Email Anda"
            class="w-full rounded-md focus:outline-none border border-slate-400 px-4 py-2 md:py-4"
          />
        </div>

        <div class="flex flex-col gap-2">
          <label>Password</label>
          <input
            v-model="password"
            type="password"
            placeholder="Masukkan Password Anda"
            class="w-full rounded-md focus:outline-none border border-slate-400 px-4 py-2 md:py-4"
          />
        </div>

        <button
          type="submit"
          class="text-white self-center mt-8 bg-primary hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm border-2 border-white w-28 px-5 py-2.5 text-center dark:bg-primary dark:hover:bg-primary dark:hover:opacity-90 dark:hover:border-2 dark:hover:text-white dark:focus:ring-blue-800 transition"
        >
          <span>Login</span>
        </button>
      </form>

      <!-- divider -->
      <div class="grid grid-cols-3 items-center">
        <div class="grid justify-items-end pe-1">
          <hr class="w-20 border-t-2 border-primary border-1 my-4" />
        </div>
        <p class="text-center">Ingin melakukan Absensi?</p>
        <div class="grid justify-items-start ps-1">
          <hr class="w-20 border-t-2 border-primary border-1 my-4" />
        </div>
      </div>

      <!-- login -->
      <div class="pt-4 mb-3">
        <a
          href="/"
          class="text-primary w-28 bg-white hover:text-white hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm border-2 border-primary px-5 py-2.5 text-center dark:bg-white dark:hover:bg-slate-200 dark:hover:border-2 dark:hover:border-primary dark:hover:border-opacity-90 dark:hover:text-primary dark:focus:ring-blue-800 transition"
        >
          Absensi
        </a>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from "vue";

// State variables for email and password
const email = ref<string>("");
const password = ref<string>("");

// Handle login function
const handleLogin = (e: Event) => {
  e.preventDefault();
  const loginData = {
    email: email.value,
    password: password.value,
  };
  console.log(JSON.stringify(loginData));
};
</script>
