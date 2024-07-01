<template>
  <div class="flex flex-col gap-12">
    <DashboardHeader
      title="Data Employee"
      name="Gibran Fasha"
      img-src="src/assets/gibs.jpeg"
    />
    <div class="flex flex-col gap-12 border-2 border-slate-200 p-8 rounded-lg">
      <div
        class="flex flex-col gap-4 xl:flex-row xl:items-center md:justify-between"
      >
        <div class="flex flex-col gap-2">
          <h1 class="text-2xl font-semibold">Data Employee</h1>
          <p class="text-[0.8rem] text-slate-400">
            Terakhir kali diubah pada 31 Agustus 2023
          </p>
        </div>

        <div class="flex flex-col xl:flex-row md:justify-end gap-4 xl:w-1/2">
          <div
            class="flex xl:w-2/3 gap-2 items-center border-2 border-gray-200 rounded-lg p-2"
          >
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke-width="1.5"
              stroke="currentColor"
              class="size-6"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                d="m21 21-5.197-5.197m0 0A7.5 7.5 0 1 0 5.196 5.196a7.5 7.5 0 0 0 10.607 10.607Z"
              />
            </svg>

            <input
              type="text"
              placeholder="Search by name"
              class="w-full focus:outline-none"
            />
          </div>

          <button class="text-white bg-blue-500 px-4 py-2 rounded-lg">
            + Tambah
          </button>
        </div>
      </div>

      <div class="overflow-x-auto">
        <table class="w-full text-left">
          <thead class="border-b-2">
            <tr>
              <th class="px-8">Gambar</th>
              <th>Nama</th>
              <th class="">Divisi</th>
              <th>Satuan Kerja</th>
              <th class="">Email</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr class="border-b h-[4.5rem] hover:h-20 transition-all bg-white">
              <td class="font-semibold px-8">Sample Title 1</td>
              <td class="text-[0.8rem] text-slate-400">Sample Name 1</td>
              <td class="text-[0.8rem] text-slate-400">sample.pdf</td>
              <td class="text-[0.8rem] text-slate-400">
                Divisi Pengembangan dan Inovasi Digital
              </td>
              <td class="text-[0.8rem] text-slate-400">
                syahrialalzaidan@gmail.com
              </td>
              <td class="pr-4">
                <div class="flex justify-center gap-4 items-center">
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    fill="none"
                    viewBox="0 0 24 24"
                    stroke-width="1.5"
                    stroke="currentColor"
                    class="size-6 hover:scale-110 cursor-pointer"
                  >
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      d="m16.862 4.487 1.687-1.688a1.875 1.875 0 1 1 2.652 2.652L6.832 19.82a4.5 4.5 0 0 1-1.897 1.13l-2.685.8.8-2.685a4.5 4.5 0 0 1 1.13-1.897L16.863 4.487Zm0 0L19.5 7.125"
                    />
                  </svg>
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    fill="none"
                    viewBox="0 0 24 24"
                    stroke-width="1.5"
                    stroke="currentColor"
                    class="size-6 hover:scale-110 cursor-pointer"
                  >
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      d="m14.74 9-.346 9m-4.788 0L9.26 9m9.968-3.21c.342.052.682.107 1.022.166m-1.022-.165L18.16 19.673a2.25 2.25 0 0 1-2.244 2.077H8.084a2.25 2.25 0 0 1-2.244-2.077L4.772 5.79m14.456 0a48.108 48.108 0 0 0-3.478-.397m-12 .562c.34-.059.68-.114 1.022-.165m0 0a48.11 48.11 0 0 1 3.478-.397m7.5 0v-.916c0-1.18-.91-2.164-2.09-2.201a51.964 51.964 0 0 0-3.32 0c-1.18.037-2.09 1.022-2.09 2.201v.916m7.5 0a48.667 48.667 0 0 0-7.5 0"
                    />
                  </svg>
                </div>
              </td>
            </tr>
            <tr
              class="border-b h-[4.5rem] hover:h-20 transition-all bg-gray-100"
            >
              <td class="font-semibold px-8">Sample Title 2</td>
              <td class="text-[0.8rem] text-slate-400">Sample Name 2</td>
              <td class="text-[0.8rem] text-slate-400">sample2.pdf</td>
              <td class="text-[0.8rem] text-slate-400">
                Divisi Pengembangan dan Inovasi Digital
              </td>
              <td class="text-[0.8rem] text-slate-400">
                syahrialalzaidan@gmail.com
              </td>
              <td class="pr-4">
                <div class="flex justify-center gap-4 items-center">
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    fill="none"
                    viewBox="0 0 24 24"
                    stroke-width="1.5"
                    stroke="currentColor"
                    class="size-6 hover:scale-110 cursor-pointer"
                  >
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      d="m16.862 4.487 1.687-1.688a1.875 1.875 0 1 1 2.652 2.652L6.832 19.82a4.5 4.5 0 0 1-1.897 1.13l-2.685.8.8-2.685a4.5 4.5 0 0 1 1.13-1.897L16.863 4.487Zm0 0L19.5 7.125"
                    />
                  </svg>
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    fill="none"
                    viewBox="0 0 24 24"
                    stroke-width="1.5"
                    stroke="currentColor"
                    class="size-6 hover:scale-110 cursor-pointer"
                  >
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      d="m14.74 9-.346 9m-4.788 0L9.26 9m9.968-3.21c.342.052.682.107 1.022.166m-1.022-.165L18.16 19.673a2.25 2.25 0 0 1-2.244 2.077H8.084a2.25 2.25 0 0 1-2.244-2.077L4.772 5.79m14.456 0a48.108 48.108 0 0 0-3.478-.397m-12 .562c.34-.059.68-.114 1.022-.165m0 0a48.11 48.11 0 0 1 3.478-.397m7.5 0v-.916c0-1.18-.91-2.164-2.09-2.201a51.964 51.964 0 0 0-3.32 0c-1.18.037-2.09 1.022-2.09 2.201v.916m7.5 0a48.667 48.667 0 0 0-7.5 0"
                    />
                  </svg>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import DashboardHeader from "../components/DashboardHeader.vue";

export default {
  components: {
    DashboardHeader,
  },
};
</script>

<style scoped>
/* Add any custom styles if needed */
</style>
