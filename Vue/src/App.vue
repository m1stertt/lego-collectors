<script setup lang="ts">
import { UserStore } from "@/stores/userStore";
import TabMenu from "primevue/tabmenu";
const userStore = UserStore();
const items = [
  { to: "/", label: "Home", icon: "pi pi-fw pi-home" },
  //{ to: "/chat", label: "Chats", icon: "pi pi-fw pi-book" },
  { to: "/friends", label: "Friends" },
];
</script>

<template>
  <div v-if="userStore.email.length > 0" style="padding-bottom:20px;">
    <TabMenu :model="items"></TabMenu>
    <span> Logged in as: {{ userStore.userName }} </span>
  </div>
  <RouterView />
</template>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}
</style>
