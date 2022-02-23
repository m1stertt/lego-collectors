import { createRouter,createWebHistory} from 'vue-router'
import Login from "@/components/Login";
import Register from "@/components/Register";
import Home from "@/components/Home";

const routes = [
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
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});
router.beforeEach((to, from, next) => {
    const publicPages = ['/login', '/register'];
    const authRequired = !publicPages.includes(to.path);
    const loggedIn = localStorage.getItem('token');
    
    //@todo Confirm token here on backend?

    if (authRequired && !loggedIn) {
        next('/login');
    } else {
        next();
    }
});
export default router;