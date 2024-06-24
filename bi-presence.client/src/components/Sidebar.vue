<template>
  <div class="h-full">
    <div class="fixed left-8 top-10 z-50">
      <MenuIcon :isOpen="open" @toggle="toggleMenu" />
    </div>
    <div
      :class="[
        'fixed bottom-0 top-0 w-[16rem] overflow-hidden md:bg-primary',
        open ? 'rounded-none bg-primary' : '-z-50 bg-transparent md:z-50',
        'px-[5%] py-8',
      ]"
    >
      <aside
        id="default-sidebar"
        :class="[
          'fixed left-0 top-0 z-10 flex h-screen w-[16rem] flex-col gap-20 transition-transform md:absolute md:w-full',
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
              <i class="icon-home text-4xl"></i>
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
              <i class="icon-assignment text-4xl"></i>
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
              <i class="icon-checklist text-4xl"></i>
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
