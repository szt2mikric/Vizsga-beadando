<template>

    <div class="col-xl-3 col-sm-6 mb-5 container">
        <div class=" py-5 px-4" v-for="item in items" :key="item.ID">
            <div class="card">
                <i width="100" class="fa-solid fa-user img-fluid mb-3 align-self-center icon"/>
                <h5 class="mb-0">{{ item.Customer_fullname}}</h5><span class="small text-uppercase text-muted">{{ item.Customer_email }}</span>
<!--                 <div class="text-center fs-6 md-3">
                    <router-link :to="{ name: 'Modifies', params:{id:item.ID} }" class="modifies btn">Módosítás</router-link>
                </div> -->
            </div>
        </div>
    </div>

</template>

<script>
import router from '@/router';
import axios from 'axios';
  
export default{
    data(){
        return{
            items: [],
        };
    },
    created(){
        this.getCustomers();
    },
    methods:{
        async getCustomers(){
            try{
                const response = await axios.get("http://localhost:3000/customers");
                this.items=response.data;
                console.log(this.items);
            } catch {
                console.log(err);
            }
        }
    }
}

</script>

<style scoped>

body {
    background: #ecf0f3;
    font-family: 'Poppins', sans-serif;
}

.card{
    max-width: 350px;
    margin: auto 80px auto 0;
    padding: 40px 30px 30px 30px;
    background-color: #ecf0f3;
    border-radius: 15px;
    box-shadow: 13px 13px 20px #cbced1, -13px -13px 20px #fff;
}

.icon{
    margin-top: 3%;
}

h5{
    text-align: center;
    font-weight: 600;
    font-size: 1.4rem;
    letter-spacing: 1.3px;
    color: #555;
}

span{
    text-align: center;
    margin-bottom: 2%;
}

.btn{
    box-shadow: none;
    max-height: 30px;
    width: 100%;
    padding: 2px;
    background-color: rgb(36, 133, 237);
    border-radius: 25px;
    letter-spacing: 1.3px;
}

.btn:hover{
    background-color: lightblue;
}

.modifies{
    color: white;
    text-decoration: none;
}

</style>