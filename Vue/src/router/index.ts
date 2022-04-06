import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import Login from "@/views/Login.vue";
import Register from "@/views/Register.vue";
import Home from "@/views/Home.vue";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    alias: ['/login'],
    name:"Login",
    component: Login,
  },
  {
    path: "/register",
    name:"Register",
    component: Register,
  },
  {
    path: "/Home",
    name:"Home",
    component: Home,
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

import { UserStore } from "@/stores/userStore";

router.beforeEach((to, from, next) => {
  const publicPages = ['/login', '/register'];
  const authRequired = !publicPages.includes(to.path);
  const loggedIn = localStorage.getItem('token');
  //@todo Confirm token here on backend?
  const userStore = UserStore();
  if (authRequired && !loggedIn) {
    next('/login');
  } else {
    if(loggedIn){
      if(!userStore.loggedInUser.id){
        userStore.getProfile().then(r=>{
          console.log(r);
        }).catch(r=>console.log(r));
      }
    }
    next();
  }
});


export default router
