<template>
  <div class="h-full">
    <div class="fixed left-8 top-10 z-[70]">
      <MenuIcon :isOpen="open" @toggle="toggleMenu" />
    </div>
    <div
      :class="[
        'fixed bottom-0 top-0 w-[18rem] overflow-hidden md:bg-primary',
        open ? 'rounded-none bg-primary' : '-z-50 bg-transparent md:z-50',
        'px-[5%] py-8',
      ]"
    >
      <aside
        id="default-sidebar"
        :class="[
          'fixed left-0 top-0 z-10 flex h-screen w-[18rem] flex-col gap-20 transition-transform md:absolute md:w-full',
          open ? 'translate-x-0' : '-translate-x-full',
          'md:translate-x-0',
        ]"
        aria-label="Sidebar"
      >
        <div class="w-full overflow-y-auto px-3 pt-20">
          <div
            class="mb-4 flex w-full cursor-pointer items-center justify-center gap-4"
            @click="goHome"
          >
            <img
              src="../assets/logo-sidebar.svg"
              width="160"
              height="50"
              alt="Logo"
            />
          </div>
        </div>
        <ul class="flex flex-col gap-3 px-3 text-white">
          <li>
            <router-link
              to="/"
              :class="[
                'flex items-center gap-4 rounded-lg px-5 py-3',
                isActive('/dashboard') ? 'bg-[#85aadd]' : '',
              ]"
            >
              <svg
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 24 24"
                fill="currentColor"
                class="size-6"
              >
                <path
                  fill-rule="evenodd"
                  d="M2.25 13.5a8.25 8.25 0 0 1 8.25-8.25.75.75 0 0 1 .75.75v6.75H18a.75.75 0 0 1 .75.75 8.25 8.25 0 0 1-16.5 0Z"
                  clip-rule="evenodd"
                />
                <path
                  fill-rule="evenodd"
                  d="M12.75 3a.75.75 0 0 1 .75-.75 8.25 8.25 0 0 1 8.25 8.25.75.75 0 0 1-.75.75h-7.5a.75.75 0 0 1-.75-.75V3Z"
                  clip-rule="evenodd"
                />
              </svg>

              <p class="text-xl">Overview</p>
            </router-link>
          </li>
          <li>
            <router-link
              to="/tugas"
              :class="[
                'flex items-center gap-4 rounded-lg px-5 py-3',
                isActive('/tugas') ? 'bg-[#85aadd]' : '',
              ]"
            >
              <svg
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 24 24"
                fill="currentColor"
                class="size-6"
              >
                <path
                  fill-rule="evenodd"
                  d="M8.25 6.75a3.75 3.75 0 1 1 7.5 0 3.75 3.75 0 0 1-7.5 0ZM15.75 9.75a3 3 0 1 1 6 0 3 3 0 0 1-6 0ZM2.25 9.75a3 3 0 1 1 6 0 3 3 0 0 1-6 0ZM6.31 15.117A6.745 6.745 0 0 1 12 12a6.745 6.745 0 0 1 6.709 7.498.75.75 0 0 1-.372.568A12.696 12.696 0 0 1 12 21.75c-2.305 0-4.47-.612-6.337-1.684a.75.75 0 0 1-.372-.568 6.787 6.787 0 0 1 1.019-4.38Z"
                  clip-rule="evenodd"
                />
                <path
                  d="M5.082 14.254a8.287 8.287 0 0 0-1.308 5.135 9.687 9.687 0 0 1-1.764-.44l-.115-.04a.563.563 0 0 1-.373-.487l-.01-.121a3.75 3.75 0 0 1 3.57-4.047ZM20.226 19.389a8.287 8.287 0 0 0-1.308-5.135 3.75 3.75 0 0 1 3.57 4.047l-.01.121a.563.563 0 0 1-.373.486l-.115.04c-.567.2-1.156.349-1.764.441Z"
                />
              </svg>
              <p class="text-xl">Absensi Employee</p>
            </router-link>
          </li>
          <li>
            <router-link
              to="/presensi"
              :class="[
                'flex items-center gap-4 rounded-lg px-5 py-3',
                isActive('/presensi') ? 'bg-[#85aadd]' : '',
              ]"
            >
              <svg
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 24 24"
                fill="currentColor"
                class="size-6"
              >
                <path
                  fill-rule="evenodd"
                  d="M5.625 1.5H9a3.75 3.75 0 0 1 3.75 3.75v1.875c0 1.036.84 1.875 1.875 1.875H16.5a3.75 3.75 0 0 1 3.75 3.75v7.875c0 1.035-.84 1.875-1.875 1.875H5.625a1.875 1.875 0 0 1-1.875-1.875V3.375c0-1.036.84-1.875 1.875-1.875ZM9.75 17.25a.75.75 0 0 0-1.5 0V18a.75.75 0 0 0 1.5 0v-.75Zm2.25-3a.75.75 0 0 1 .75.75v3a.75.75 0 0 1-1.5 0v-3a.75.75 0 0 1 .75-.75Zm3.75-1.5a.75.75 0 0 0-1.5 0V18a.75.75 0 0 0 1.5 0v-5.25Z"
                  clip-rule="evenodd"
                />
                <path
                  d="M14.25 5.25a5.23 5.23 0 0 0-1.279-3.434 9.768 9.768 0 0 1 6.963 6.963A5.23 5.23 0 0 0 16.5 7.5h-1.875a.375.375 0 0 1-.375-.375V5.25Z"
                />
              </svg>

              <p class="text-xl">Data Employee</p>
            </router-link>
          </li>
        </ul>
        <div
          class="flex cursor-pointer flex-col gap-3 px-3 text-white"
          @click="handleSignOut"
        >
          <div
            class="flex items-center gap-4 px-5 py-3 bg-red-500 w-fit rounded-lg self-center"
          >
            <p class="text-xl">Signout</p>
          </div>
        </div>
      </aside>
    </div>
  </div>
</template>

<script>
import { ref } from "vue";
import { useRouter } from "vue-router";
import MenuIcon from "./MenuIcon.vue";

export default {
  name: "Sidebar",
  components: {
    MenuIcon,
  },
  setup() {
    const open = ref(false);
    const router = useRouter();
    const pathname = router.currentRoute.value.path;

    const toggleMenu = () => {
      open.value = !open.value;
    };

    const goHome = () => {
      router.push("/");
    };

    const handleSignOut = async () => {
      // Implement your sign out logic here

      setTimeout(() => {
        router.push("/login");
      }, 1000);
    };

    const isActive = (path) => {
      return pathname === path;
    };

    return {
      open,
      toggleMenu,
      goHome,
      handleSignOut,
      isActive,
    };
  },
};
</script>

<style scoped>
/* Add any necessary scoped styles here */
</style>
