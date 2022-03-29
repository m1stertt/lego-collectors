import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import axios from 'axios';
import VueAxios from 'vue-axios';
import PrimeVue from 'primevue/config';
import Menubar from "primevue/menubar";
import InputText from "primevue/inputtext"
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";

const app = createApp(App)
axios.get("/config/api-url.txt").then((result)=>{
    if(result.status&&result.status==200){
        app.config.globalProperties.hostname=result.data;
    }
}).catch(()=>{});
app.config.globalProperties.hostname ="http://localhost:5000/"
app.use(PrimeVue);
app.use(router)
app.use(VueAxios, axios);

app.component("Menubar", Menubar);
app.component("InputText", InputText);

app.mount('#app')