import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import Login from "@/views/Login.vue";
import Register from "@/views/Register.vue";
import Home from "@/views/Home.vue";
import AddLego from "@/views/AddLego.vue"

const routes: Array<RouteRecordRaw> = [
  {
    path: "/login",
    name:"Login",
    component: Login,
  },
  {
    path: "/register",
    name:"Register",
    component: Register,
  },
  {
    path: "/",
    name:"Home",
    component: Home,
  },
  {
    path: '/add',
    name:"Add",
    component:AddLego,
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
    if(!authRequired&&loggedIn){
      next("/");
    }else{
      next();
    }
  }
});


export default router
