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
          <div class="clearfix">
            <button type="button" class="signin" v-on:click="login">Sign in</button>
            <button type="button" class="signup error" v-on:click="signup">Sign up</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
//import axios from 'axios';
import Swal from 'sweetalert2';
import { UserStore } from "@/stores/userStore";
const userStore = UserStore();

export default {
  data(){
    return{
      user:{
        email:"",
        password:""
      }
    }
  },
  methods:{
    signup(){
      this.$router.push({ name: 'Register' });
    },
    login(){
      if(this.checkValidation()){
        userStore.loginUser(this.user.email,this.user.password).then(response => {
          if(response.status){
            localStorage.setItem('token', JSON.stringify(response.data.token));
            response.data.token = "";
            localStorage.setItem('user', JSON.stringify(response.data));
            this.$router.push({name:"Home"});
          }
        }).catch(error => {
          if (error.response) {
            Swal.fire(error.response.data);
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
    },
    checkValidation(){
      if(!this.user.email){
        this.$refs.email.focus();
        Swal.fire("Give email !");
        return;
      }
      if(!(/\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/).test(this.user.email)){
        this.$refs.email.focus();
        Swal.fire("Invalid email !");
        return;
      }
      if(!this.user.password){
        this.$refs.password.focus();
        Swal.fire("Give password");
        return;
      }
      return true;
    }
  }
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