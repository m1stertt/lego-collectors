<script setup lang="ts">
import { UserStore } from "@/stores/userStore";
import { logout } from '@/composables/logout'

function log(){
  logout();
}
const userStore = UserStore();
const items = [
  { to: "/", label: "Home", icon: "pi pi-fw pi-home" },
  //{ to: "/chat", label: "Chats", icon: "pi pi-fw pi-book" },
  { to: "/legocollection", label: "Add new lego", icon: "pi " },
];
</script>

<template>
  <div v-if="userStore.email.length > 0" style="padding-bottom:20px;">
    <Menubar :model="items">
      <template #start>
          <router-link to="/"><img src="https://www.pngall.com/wp-content/uploads/5/Lego-Toy-PNG-High-Quality-Image.png" alt="Image" height="50" class="mr-2"></router-link>
      </template>
      <template #end>
          <span style="height:auto; line-height:50px;">{{ userStore.email }}</span>
          <Button icon="pi pi-sign-out" class="p-button-text" v-on:click="log()" />
      </template>
    </Menubar>
  </div>
  <div class="grid">
    <div class="col-12 md:col-8 md:col-offset-2 lg:col-6 lg:col-offset-3">
      <RouterView />
    </div>
  </div>
</template>

<style>
</style>
