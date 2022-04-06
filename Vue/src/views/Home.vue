<template>
  <button type="button" class="error" v-on:click="logoutClick" style="width:150px;">Logout</button>
  <br>
  Home
  <div class="grid">
    <div class="col">1</div>
    <div class="col">2</div>
    <div class="col">3</div>
  </div>
</template>

<script>
import { logout } from '@/composables/logout'

export default {
  name: "Home",
  methods:{
    logoutClick(){
      logout()
      this.$router.push('/login');
    }
  }
}
</script>


<style scoped>

</style>