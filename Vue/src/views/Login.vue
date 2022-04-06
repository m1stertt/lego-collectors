<template>
  <div class="col-md-12">
    <div class="container">
      <h3 class="e-shop-font">Login Page</h3>
      <div class="card">
        <div class="card-body">
          <div class="form-group">
            <label for="email">Email:</label>
            <input id="email" v-model="user.email" ref="email" type="email" class="form-control" placeholder="Enter email" name="email" />
          </div>
          <div class="form-group">
            <label for="pwd">Password:</label>
            <input id="pwd" v-model="user.password" ref="psw" type="password" class="form-control" placeholder="Enter password" name="pwd" />
          </div>
          <span class="p-buttonset">
              <Button label="Sign in" v-on:click="login" />
              <Button label="Sign up" v-on:click="signup" />
          </span>
          <div class="clearfix">
            <button type="button" class="signin" v-on:click="login">Sign in</button>
            <button type="button" class="signup error" v-on:click="signup">Sign up</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
//import axios from 'axios';
import Swal from 'sweetalert2';
import { UserStore } from "@/stores/userStore";
import router from '../router'
const userStore = UserStore();
const user={email:"",password:""};

function signup(){
  router.push({ name: 'Register' });
}

function login(){
  if(checkValidation()){
    userStore.loginUser(user.email,user.password).then(response => {
      if(response.message=="Success"){
        router.push({name:"Home"});
      }else{
        Swal.fire("Error : Something went wrong.");
      }
    }).catch(error => {
      if (error.response) {
        Swal.fire(error.response.data);
      }else{
        Swal.fire("Error : Something went wrong.");
      }
    });/*
        axios.post(this.hostname + "api/auth/Login",{
          email: this.user.email,
          password: this.user.password,
          })
            .then(response => {
              if(response.status){
                localStorage.setItem('token', JSON.stringify(response.data.token));
                response.data.token = "";
                localStorage.setItem('user', JSON.stringify(response.data));
                this.$router.push({name:"Home"});
              }
            })
            .catch(error => {
              if (error.response) {
                Swal.fire(error.response.data);
              }
            });*/
  }
}

function checkValidation(){
  if(!user.email){
    this.$refs.email.focus();
    Swal.fire("Give email !");
    return;
  }
  if(!(/\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/).test(user.email)){
    this.$refs.email.focus();
    Swal.fire("Invalid email !");
    return;
  }
  if(!user.password){
    this.$refs.password.focus();
    Swal.fire("Give password");
    return;
  }
  return true;
}
</script>

<style scoped>
.container{
  max-width: 360px;
}
button:hover {
  opacity:1;
}
.signin, .signup {
  float: left;
  width: 50%;
}
.clearfix::after {
  content: "";
  clear: both;
  display: table;
}
</style>