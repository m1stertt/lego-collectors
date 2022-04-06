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
  <div class="bg-gray-900" style="padding:5px;">
    <Menubar class="bg-gray-900 text-gray-400" style="border:0;border-radius:0;" :model="items">
      <template #start>
          <router-link to="/"><img src="https://www.pngall.com/wp-content/uploads/5/Lego-Toy-PNG-High-Quality-Image.png" alt="Image" height="50" class="mr-2"></router-link>
      </template>
      <template #end>
          <span style="height:auto; line-height:50px;">{{ userStore.email }}</span>
          <Button icon="pi pi-sign-out" class="p-button-text" v-on:click="log()" />
      </template>
    </Menubar>
  </div>
</div>
<div class="col-12 md:col-10 md:col-offset-1 lg:col-10 lg:col-offset-1">
  <RouterView />
</div>
<div class="bl">
</div>
<div class="br">
</div>
</template>

<style>
body{
  padding:0px;
  margin:0px;
}
.p-menubar .p-menubar-root-list > .p-menuitem > .p-menuitem-link .p-menuitem-text{
  color:var(--gray-400) !important;
}
.p-menuitem-link:hover{
  background:#424242!important;
}
.bl{
  position:absolute;
  bottom:0;
  left:0;
  background:url("https://s3-us-west-2.amazonaws.com/s.cdpn.io/319423/lego-bg-bl.png");
  background-repeat: no-repeat;
  background-size: 200px 200px;
  width:200px;
  height:200px;
}

.br{
  position:absolute;
  bottom:0;
  right:0;
  background:url("https://s3-us-west-2.amazonaws.com/s.cdpn.io/319423/lego-bg-br.png");
  background-repeat: no-repeat;
  background-size: 200px 200px;
  width:200px;
  height:200px;
}
</style>
