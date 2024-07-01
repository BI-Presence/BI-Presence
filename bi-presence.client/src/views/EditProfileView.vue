<template>
  <div>
    <dashboard-header title="Edit Profile" :name="name" :img-src="imgSrc" />
    <div
      class="border flex flex-col gap-6 border-gray-300 p-8 mt-12 rounded-lg"
    >
      <div class="flex gap-0">
        <div class="w-1/3">
          <label class="font-semibold text-sm">Nama User</label>
          <div>
            <input
              type="text"
              placeholder="Masukkan Nama User"
              name="nama"
              class="border border-gray-300 p-2 rounded"
              :value="temp.fullName"
              @input="onInputChange('fullName', $event)"
            />
          </div>
        </div>
        <div class="w-1/3">
          <label class="font-semibold text-sm">Nama Panggilan</label>
          <div>
            <input
              type="text"
              placeholder="Masukkan Nama Panggilan"
              name="panggilan"
              class="border border-gray-300 p-2 rounded"
              :value="temp.nickname"
              @input="onInputChange('nickname', $event)"
            />
          </div>
        </div>
        <div class="w-1/3">
          <label class="font-semibold text-sm">Foto</label>
          <div>
            <input
              type="file"
              class="border border-gray-300 p-2 rounded"
              @change="onFileChange"
            />
            <div v-if="temp.imageUrl">{{ temp.imageUrl }}</div>
          </div>
        </div>
      </div>

      <div class="flex">
        <div class="w-1/3">
          <label class="font-semibold text-sm">Tempat Lahir</label>
          <div>
            <input
              type="text"
              placeholder="Masukkan tempat lahir"
              name="tempat"
              class="border border-gray-300 p-2 rounded"
              :value="temp.tempatLahir"
              @input="onInputChange('tempatLahir', $event)"
            />
          </div>
        </div>
        <div class="w-1/3">
          <label class="font-semibold text-sm">Tanggal Lahir</label>
          <div>
            <input
              type="date"
              name="tanggal"
              class="border border-gray-300 p-2 rounded"
              :value="formatDate(temp.tanggalLahir)"
              @input="onDateChange('tanggalLahir', $event)"
            />
          </div>
        </div>
        <div class="w-1/3">
          <label class="font-semibold text-sm">Tanggal Join</label>
          <div>
            <input
              type="date"
              name="institusi"
              class="border border-gray-300 p-2 rounded"
              :value="formatDate(temp.createdAt)"
              @input="onDateChange('createdAt', $event)"
            />
          </div>
        </div>
      </div>

      <div class="flex">
        <div class="w-1/3">
          <label class="font-semibold text-sm">Nomor Telepon</label>
          <div>
            <input
              type="number"
              placeholder="Masukkan Nomor Telepon"
              name="telepon"
              class="border border-gray-300 p-2 rounded"
              :value="temp.whatsApp"
              @input="onInputChange('whatsApp', $event)"
            />
          </div>
        </div>
        <div class="w-2/3">
          <label class="font-semibold text-sm">Alamat</label>
          <textarea
            class="border border-gray-300 rounded-lg p-4 w-full"
            placeholder="Masukkan Alamat"
            name="alamat"
            :value="temp.homeAddress"
            @input="onInputChange('homeAddress', $event)"
          />
        </div>
      </div>
    </div>
    <div class="flex gap-4 justify-end mt-6">
      <button class="border border-gray-300 p-2 rounded">Cancel</button>
      <button class="border border-gray-300 p-2 rounded bg-primary text-white">
        Simpan Perubahan
      </button>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from "vue";
import DashboardHeader from "../components/DashboardHeader.vue";

interface Temp {
  fullName: string;
  nickname: string;
  imageUrl: string;
  tempatLahir: string;
  tanggalLahir: string;
  createdAt: string;
  whatsApp: string;
  homeAddress: string;
}

export default defineComponent({
  name: "EditProfileView",
  components: {
    DashboardHeader,
  },
  props: {
    name: {
      type: String,
      required: true,
    },
    imgSrc: {
      type: String,
      required: true,
    },
  },
  setup() {
    const temp = ref<Temp>({
      fullName: "",
      nickname: "",
      imageUrl: "",
      tempatLahir: "",
      tanggalLahir: "",
      createdAt: "",
      whatsApp: "",
      homeAddress: "",
    });

    const formatDate = (date: string): string => {
      if (!date) return "";
      const d = new Date(date);
      return isNaN(d.getTime()) ? "" : d.toISOString().split("T")[0];
    };

    const onInputChange = (field: keyof Temp, e: Event) => {
      temp.value[field] = (e.target as HTMLInputElement).value;
    };

    const onDateChange = (field: keyof Temp, e: Event) => {
      const dateValue = (e.target as HTMLInputElement).value;
      temp.value[field] = dateValue;
    };

    const onFileChange = (e: Event) => {
      const file = (e.target as HTMLInputElement).files?.[0];
      if (file) {
        temp.value.imageUrl = file.name;
      }
    };

    return {
      temp,
      formatDate,
      onInputChange,
      onDateChange,
      onFileChange,
    };
  },
});
</script>

<style scoped>
/* Add any scoped styles here if needed */
</style>
