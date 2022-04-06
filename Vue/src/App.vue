<script setup lang="ts">
import MenuComponent from "./component/MenuComponent.vue";
</script>

<template>
<MenuComponent></MenuComponent>
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
  font-family: 'Quicksand', sans-serif;
  background:#f1f2f6;
}
.bl{
  position:fixed;
  bottom:0;
  left:0;
  background: url("https://s3-us-west-2.amazonaws.com/s.cdpn.io/319423/lego-bg-bl.png") no-repeat;
  background-size: 200px 200px;
  width:200px;
  height:200px;
  z-index:-1;
}

.br{
  position:fixed;
  bottom:0;
  right:0;
  background: url("https://s3-us-west-2.amazonaws.com/s.cdpn.io/319423/lego-bg-br.png") no-repeat;
  background-size: 200px 200px;
  width:200px;
  height:200px;
  z-index:-1;
}
</style>
