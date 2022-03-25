import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import axios from 'axios';
import VueAxios from 'vue-axios';
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";

const app = createApp(App)
axios.get("/config/api-url.txt").then((result)=>{
    if(result.status&&result.status==200){
        app.config.globalProperties.hostname=result.data;
    }else{
        app.config.globalProperties.hostname ="http://localhost:5000/"
    }
}).catch(()=>{});
app.config.globalProperties.hostname ="http://localhost:5000/"
app.use(router)
app.use(VueAxios, axios)
app.mount('#app')