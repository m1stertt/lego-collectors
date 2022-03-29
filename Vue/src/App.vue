<template>
  <Menubar :model="items">
    <template #start>
      <a href="#"><img alt="logo" src="https://cdn-icons-png.flaticon.com/512/724/724302.png" height="40" class="mr-2"></a>
    </template>
    <template #end>
      Logged in as: ...
      <InputText placeholder="Search" type="text" />
    </template>
  </Menubar>
  <div style="width:100%;height:40px;color:white;text-align:center;padding-top:5px;margin-bottom:50px;">
    <!--Menu area-->
  </div>
  <div class="container">
    <router-view></router-view>
  </div>
</template>

<script>
import { logout } from '@/composables/logout'
export default {
  name: 'App',
  setup(){

  },
  methods:{
    logoutClick(){
      logout()
      this.$router.push('/login');
    },
  },
  components: {

  },
  data() {
        return {
            items: [
                {
                   label:'Collection',
                   icon:'pi pi-fw pi-file',
                   items:[
                      {
                         label:'New',
                         icon:'pi pi-fw pi-plus',
                         items:[
                            {
                               label:'Lego',
                               icon:'pi pi-fw pi-bookmark'
                            },
                            {
                               label:'Lego Stock',
                               icon:'pi pi-fw pi-video'
                            },

                         ]
                      },
                      {
                         label:'Delete',
                         icon:'pi pi-fw pi-trash',
                         items:[
                            {
                               label:'Lego',
                               icon:'pi pi-fw pi-bookmark'
                            },
                            {
                               label:'Lego Stock',
                               icon:'pi pi-fw pi-video'
                            },

                         ]
                      },
                      {
                         label:'Update',
                         icon:'pi pi-fw pi-pencil',
                         items:[
                            {
                               label:'Lego',
                               icon:'pi pi-fw pi-bookmark'
                            },
                            {
                               label:'Lego Stock',
                               icon:'pi pi-fw pi-video'
                            },

                         ]
                      },
                   ]
                },
                {
                   label:'Logout',
                   icon:'pi pi-fw pi-power-off',
                   command: () => { this.logoutClick()}
                }
             ]
        }
    }
}

</script>

<style>
button {
  background-color: #0069D9;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 100%;
  opacity: 0.9;
}

.success{
  background-color:#04AA6D;
}

.error{
  background-color:red;
}

.form-signin {
  width: 100%;
  max-width: 330px;
  padding: 15px;
  margin: auto;
}

.form-signin .checkbox {
  font-weight: 400;
}

.form-signin .form-floating:focus-within {
  z-index: 2;
}

.form-signin input[type="email"] {
  margin-bottom: -1px;
  border-bottom-right-radius: 0;
  border-bottom-left-radius: 0;
}

.form-signin input[type="password"] {
  margin-bottom: 10px;
  border-top-left-radius: 0;
  border-top-right-radius: 0;
}
</style>