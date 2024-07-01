<template>
  <div>
    <div class="container bg-white text-black max-w-full p-2">
      <!-- Top Content -->
      <div
        class="flex flex-wrap justify-between items-center mx-auto max-w-screen-xl p-4"
      >
        <span
          class="self-center text-2xl font-semibold whitespace-nowrap dark:text-dark"
        >
          Overview
        </span>
        <div class="flex items-center space-x-6 rtl:space-x-reverse">
          <button
            class="flex w-44 items-center justify-around text-lg font-semibold whitespace-nowrap dark:text-dark"
          >
            <h1>Vicky Maulana</h1>
            <img
              :src="Img"
              alt="profile"
              class="w-10 h-10 border-2 border-black rounded-full object-cover"
            />
          </button>
        </div>
      </div>

      <!-- Statistic Section -->
      <div class="py-10">
        <h1 class="ps-7 text-lg opacity-50">
          Statistik Hari Ini - 20 Juni 2024
        </h1>
        <div
          class="grid grid-cols-2 lg:grid-cols-4 justify-around items-center mx-auto max-w-screen-xl w-full"
        >
          <CardComp :dataTitle="dataPresenceType" />
        </div>
      </div>

      <!-- Table -->
       
    </div>
  </div>
</template>

<script setup lang="ts">
import Img from "../assets/foto.jpeg";
import CardComp from "../components/CardComp.vue";
import Suitcase from "@/assets/Vector.svg";
import Car from "@/assets/Vector-1.svg";
import Sick from "@/assets/Vector-2.svg";
import { ref, onMounted } from "vue";

interface DataTitle {
  title: string;
  img?: string;
  value: number;
  color: string;
}

// Data Presence Total
const dataTitle = ref<DataTitle[]>([
  {
    title: "Total Karyawan",
    img: `
      <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" class="w-10 md:w-20 size-20 text-white">
        <path strokeLinecap="round" strokeLinejoin="round" d="M18 18.72a9.094 9.094 0 0 0 3.741-.479 3 3 0 0 0-4.682-2.72m.94 3.198.001.031c0 .225-.012.447-.037.666A11.944 11.944 0 0 1 12 21c-2.17 0-4.207-.576-5.963-1.584A6.062 6.062 0 0 1 6 18.719m12 0a5.971 5.971 0 0 0-.941-3.197m0 0A5.995 5.995 0 0 0 12 12.75a5.995 5.995 0 0 0-5.058 2.772m0 0a3 3 0 0 0-4.681 2.72 8.986 8.986 0 0 0 3.74.477m.94-3.197a5.971 5.971 0 0 0-.94 3.197M15 6.75a3 3 0 1 1-6 0 3 3 0 0 1 6 0Zm6 3a2.25 2.25 0 1 1-4.5 0 2.25 2.25 0 0 1 4.5 0Zm-13.5 0a2.25 2.25 0 1 1-4.5 0 2.25 2.25 0 0 1 4.5 0Z" />
      </svg>`,
    value: Math.floor(Math.random() * 10),
    color: "#99B6FF",
  },
  {
    title: "Total Kelompok Satuan Kerja",
    img: `<svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-10 md:w-20 size-20 text-white">
  <path stroke-linecap="round" stroke-linejoin="round" d="M2.25 7.125C2.25 6.504 2.754 6 3.375 6h6c.621 0 1.125.504 1.125 1.125v3.75c0 .621-.504 1.125-1.125 1.125h-6a1.125 1.125 0 0 1-1.125-1.125v-3.75ZM14.25 8.625c0-.621.504-1.125 1.125-1.125h5.25c.621 0 1.125.504 1.125 1.125v8.25c0 .621-.504 1.125-1.125 1.125h-5.25a1.125 1.125 0 0 1-1.125-1.125v-8.25ZM3.75 16.125c0-.621.504-1.125 1.125-1.125h5.25c.621 0 1.125.504 1.125 1.125v2.25c0 .621-.504 1.125-1.125 1.125h-5.25a1.125 1.125 0 0 1-1.125-1.125v-2.25Z" />
</svg>
`,
    value: Math.floor(Math.random() * 10),
    color: "#EB99FF",
  },
]);

// Data PresenceType
const dataPresenceType = ref<DataTitle[]>([
  {
    title: "Total Masuk",
    img: `
      <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" class="w-10 md:w-20 size-20 text-white">
        <path strokeLinecap="round" strokeLinejoin="round" d="M18 18.72a9.094 9.094 0 0 0 3.741-.479 3 3 0 0 0-4.682-2.72m.94 3.198.001.031c0 .225-.012.447-.037.666A11.944 11.944 0 0 1 12 21c-2.17 0-4.207-.576-5.963-1.584A6.062 6.062 0 0 1 6 18.719m12 0a5.971 5.971 0 0 0-.941-3.197m0 0A5.995 5.995 0 0 0 12 12.75a5.995 5.995 0 0 0-5.058 2.772m0 0a3 3 0 0 0-4.681 2.72 8.986 8.986 0 0 0 3.74.477m.94-3.197a5.971 5.971 0 0 0-.94 3.197M15 6.75a3 3 0 1 1-6 0 3 3 0 0 1 6 0Zm6 3a2.25 2.25 0 1 1-4.5 0 2.25 2.25 0 0 1 4.5 0Zm-13.5 0a2.25 2.25 0 1 1-4.5 0 2.25 2.25 0 0 1 4.5 0Z" />
      </svg>`,
    value: Math.floor(Math.random() * 10),
    color: "#99D2FF",
  },
  {
    title: "Total Izin",
    img: `<img src="${Suitcase}" alt="Suitcase" class="w-10 md:w-20 h-20"/>`,
    value: Math.floor(Math.random() * 10),
    color: "#FF9999",
  },
  {
    title: "Total Sakit",
    img: `<img src="${Sick}" alt="Sick" class="w-10 md:w-20 h-20"/>`,
    value: Math.floor(Math.random() * 10),
    color: "#FFBE99",
  },
  {
    title: "Total Cuti",
    img: `<img src="${Car}" alt="Car" class="w-10 md:w-20 h-20"/>`,
    value: Math.floor(Math.random() * 10),
    color: "#99B6FF",
  },
]);

</script>

<style scoped>
.container {
  max-width: 1200px;
  margin: 0 auto;
}
</style>
