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
        <div class="relative flex items-center space-x-6 rtl:space-x-reverse">
          <button
            @click="toggleDropdown"
            class="flex w-44 items-center justify-around text-lg font-semibold whitespace-nowrap dark:text-dark"
          >
            <h1>Vicky Maulana</h1>
            <img
              :src="Img"
              alt="profile"
              class="w-10 h-10 border-2 border-black rounded-full object-cover"
            />
          </button>
          <div
            v-if="dropdownVisible"
            class="absolute right-12 mt-20 w-48 bg-white border border-gray-200 rounded shadow-lg"
          >
            <ul class="py-1">
              <li>
                <a
                  href="#"
                  class="block px-4 py-2 text-gray-800 hover:bg-gray-100"
                  >Edit Profile</a
                >
              </li>
            </ul>
          </div>
        </div>
      </div>

      <!-- Middle Content -->
      <div class="flex">
        <div
          class="grid grid-cols-2 md:grid-cols-2 justify-around items-center mx-auto max-w-screen-xl w-full"
        >
          <CardComp :dataTitle="dataTitle" />
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

      <!-- Chart Section -->
      <div class="py-10">
        <h1 class="ps-7 text-lg opacity-50">Statistik Bulan Ini - Juni 2024</h1>
        <div
          class="grid lg:grid-cols-2 lg:place-items-stretch gap-12 justify-around mx-auto max-w-screen-xl lg:w-full lg:px-7"
        >
          <div
            class="relative bg-slate-100 p-2 border-2 outline-2 place-items-center w-full h-fit"
          >
            <div class="flex justify-between">
              <div class="">
                <p class="opacity-50">Activity</p>
                <h1 class="font-semibold">Average Kehadiran</h1>
              </div>
            </div>
            <canvas
              style="width: 400px; height: 200px"
              ref="chartCanvasVertical"
            ></canvas>
          </div>
          <div class="bg-slate-100 border-2 p-2 outline-2 w-full h-fit">
            <p class="opacity-50">Statistics</p>
            <h1 class="font-semibold">Tipe Absensi</h1>
            <canvas ref="chartCanvasHorizontal"></canvas>
          </div>
        </div>
      </div>
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
import {
  Chart,
  type ChartConfiguration,
  type ChartData,
  registerables,
} from "chart.js";

Chart.register(...registerables);

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

// Reactive property for dropdown visibility
const dropdownVisible = ref(false);

// Method to toggle dropdown visibility
const toggleDropdown = () => {
  dropdownVisible.value = !dropdownVisible.value;
};

// Method to generate labels based on the selected timeframe
const generateLabels = (timeframe: string): string[] => {
  switch (timeframe) {
    case "month":
      return Array.from({ length: 30 }, (_, i) => `Day ${i + 1}`);
    default:
      return [];
  }
};

const label = ref<string>("month");
console.log("🚀 ~ label:", label.value);

const chartCanvasVertical = ref<HTMLCanvasElement | null>(null);
let chartInstance: any = null;

// Vertical Chart
const createChartVertikal = () => {
  if (!chartCanvasVertical.value) return;

  const ctx = chartCanvasVertical.value.getContext("2d");
  if (!ctx) return;

  const labels = generateLabels("month"); // Default to 'week'
  // console.log("🚀 ~ setTimeframe ~ labels: 0", labels.value)
  const currentDayIndex = new Date().getDate();
  const currentDayLabel = labels[currentDayIndex - 1];
  // console.log("🚀 ~ setTimeframe ~ currentDayLabel.value: 0", currentDayLabel.value)

  console.log("🚀 ~ createChartVertikal ~ labels:", labels);
  console.log("🚀 ~ createChartVertikal ~ currentDayIndex:", currentDayIndex);
  console.log("🚀 ~ createChartVertikal ~ currentDayLabel:", currentDayLabel);

  const data: ChartData<"bar"> = {
    labels: labels,
    datasets: [
      {
        label: "Dataset 1",
        data: labels.map(() => [0, Math.floor(Math.random() * 100)]),
        backgroundColor: labels.map((label: any) =>
          label === currentDayLabel ? "#015699" : "#F0E5FC"
        ),
        barPercentage: 0.5,
      },
    ],
  };

  const config: ChartConfiguration<"bar"> = {
    type: "bar",
    data: data,
    options: {
      responsive: true,
      plugins: {
        legend: {
          display: false, // Hide the legend
        },
      },
      scales: {
        x: {
          beginAtZero: true,
          grid: {
            color: "#f1f5f9",
          },
        },
        y: {
          beginAtZero: true,
        },
      },
    },
  };

  chartInstance = new Chart(ctx, config);
};

// Horizontal Chart
const chartCanvasHorizontal = ref<HTMLCanvasElement | null>(null);
const createChartHorizontal = () => {
  if (!chartCanvasHorizontal.value) return;

  const ctx = chartCanvasHorizontal.value.getContext("2d");
  if (!ctx) return;

  const labels = ["Masuk", "Izin", "Sakit", "Cuti"];
  const data: ChartData<"bar"> = {
    labels: labels,
    datasets: [
      {
        // axis: 'y',
        label: "My First Dataset",
        data: [
          Math.floor(Math.random() * 100),
          Math.floor(Math.random() * 100),
          Math.floor(Math.random() * 100),
          Math.floor(Math.random() * 100),
        ],
        // fill: false,
        backgroundColor: ["#35A6FF", "#FF3535", "#FF7E35", "#346EFF"],
        borderWidth: 1,
      },
    ],
  };

  const config: ChartConfiguration<"bar"> = {
    type: "bar",
    data: data,
    options: {
      indexAxis: "y",
      plugins: {
        legend: {
          display: false, // Hide the legend
        },
      },
      scales: {
        x: {
          grid: {
            color: "#f1f5f9",
          },
        },
        y: {
          grid: {
            color: "#f1f5f9",
          },
        },
      },
    },
  };

  chartInstance = new Chart(ctx, config);
};

onMounted(() => {
  createChartHorizontal();
  createChartVertikal();
});
</script>

<style scoped>
.container {
  max-width: 1200px;
  margin: 0 auto;
}
</style>
