<template>
  <div class="surface-card p-4 shadow-2 border-round">
    <div class="text-center mb-5">
      <router-link to="/login">Back</router-link>
      <div class="card">
        <div class="card-body">
          <h1>Sign Up</h1>
          <p>Please fill in this form to create an account.</p>
          <hr>

          <label for="email"><b>Email</b></label>
          <input id="email" v-model="user.email" ref="email" type="email" placeholder="Enter Email" name="email" />

          <label for="psw"><b>Password</b></label>
          <input id="psw" v-model="user.password" ref="psw" type="password" placeholder="Enter Password" name="psw" />

          <label for="psw-repeat"><b>Repeat Password</b></label>
          <input id="psw-repeat" v-model="user.repeatPassword" type="password" placeholder="Repeat Password" name="psw-repeat" />

          <Button type="submit" v-on:click="signup">Sign Up</Button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
import Swal from 'sweetalert2';
import { UserStore } from "@/stores/userStore";

export default({
  data(){
    return{
      user:{
        email:"",
        password:"",
      },
    }
  },
  setup() {
  },
  methods:{
    signup(){
      if(this.checkValidation()){
        const userStore = UserStore();
        axios.post("api/auth/RegisterUser",{
            email: this.user.email,
            password: this.user.password,
          })
            .then(response => {
              console.log(response);
              if (response.status) {
                Swal.fire("Successfully registered")
                    .then(() => {
                      this.$router.push("/login")
                    });
              }else{
                Swal.fire("Error : Something went wrong.");
              }
            })
            .catch(error => {
              console.log(error);
              if (error.response) {
                Swal.fire(error.response.data);
              }
            });
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
        this.$refs.psw.focus();
        Swal.fire("Give password !");
        return;
      }
      if(this.user.password != this.user.repeatPassword){
        this.$refs.psw.focus();
        Swal.fire("Password and repeat password mismatched !");
        return;
      }
      return true;
    },
  }
})
</script>

<style scoped>
.container{
  width: 40%;
  padding: 16px;
}
input[type=text], input[type=password], input[type=email] {
  width: 100%;
  padding: 15px;
  margin: 5px 0 22px 0;
  display: inline-block;
  border: none;
  background: #f1f1f1;
}
input[type=text]:focus, input[type=password]:focus, input[type=email]:focus {
  background-color: #ddd;
  outline: none;
}
hr {
  border: 1px solid #f1f1f1;
  margin-bottom: 25px;
}
button:hover {
  opacity:1;
}
.CancelBtn, .SignupBtn {
  float: left;
  width: 50%;
}
.clearfix::after {
  content: "";
  clear: both;
  display: table;
}
</style>