import { createApp } from 'vue';
import { createPinia } from 'pinia'
import App from './App.vue';
import router from './router';
import axios from 'axios';
import PrimeVue from 'primevue/config';
import Menubar from "primevue/menubar";
import InputText from "primevue/inputtext"
import Button from "primevue/button";

const app = createApp(App)
app.use(PrimeVue);
app.use(router)
app.use(createPinia());

axios.interceptors.request.use(request => {
    // add auth header with jwt if account is logged in and request is to the api url
    const isLoggedIn = localStorage.getItem('token');
    if (isLoggedIn&&request.headers) {
        console.log("setting auth header");
        request.headers.Authorization = ` ${isLoggedIn}`;
    }

    return request;
});

axios.get("/config/api-url.txt").then((result)=>{
    alert("HELLO");
    if(result.status&&result.status==200){
        app.config.globalProperties.hostname=result.data;
        axios.defaults.baseURL=result.data;
    }
}).catch(()=>{});

app.config.globalProperties.hostname ="http://localhost:5000/"
axios.defaults.baseURL="http://localhost:5000/";


app.component("Menubar", Menubar);
app.component("InputText", InputText);
app.component("Button",Button);

app.mount('#app')