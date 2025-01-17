<template>
 <section>
    <div>
        <div class="col-xl-3 col-sm-6 mb-5  container">
            <div class="py-5 px-4" v-for="item in items" :key="item.ID">
                <div class="card col-lg-4 col-md-6 col-sm-12 mb-4">
                    <i width="100" class="fa-solid fa-house img-fluid mb-3 align-self-center icon"/>
                    <h4 class="mb-3">{{ item.Properties_city}}</h4>
                    <p class="small text-muted">Típus: {{ item.Properties_type }}</p>
                    <p class="small text-muted">Szobák száma: {{ item.Properties_roomNumber }}</p>
                    <p class="small text-muted">Lakbér (Forint): {{ item.Properties_price}}</p>
                    <p class="small text-muted">Berendezett: {{ item.Properties_isFurnished}}</p>
                    <p class="small text-muted">Költözhető: {{ item.Properties_possibilityOfMoving}}</p>
                    <p class="small text-muted">Egyéb: {{ item.Properties_others}}</p>
                </div>
            </div>
        </div>
    </div>
</section>
</template>

<script>

import axios from 'axios';
  
export default{
    data(){
        return{
            items: [],
        };
    },
    created(){
        this.getProperties();
    },
    methods:{
        async getProperties(){
            try{
                const response = await axios.get("http://localhost:3000/properties");
                this.items=response.data;
                console.log(this.items);
            } catch {
                console.log(err);
            }
        }
    }
}

</script>

<style>

body {
    background: #ecf0f3;
    font-family: 'Poppins', sans-serif;
    height: 100%;

}

.card{
    width: 350px;
    height: 440px;
    background-color: #ecf0f3;
    border-radius: 15px;
    box-shadow: 13px 13px 20px #cbced1, -13px -13px 20px #fff;
}

.icon{
    margin-top: 3%;
}

h4{
    text-align: center;
    font-weight: 600;
    font-size: 1.4rem;
    letter-spacing: 1.3px;
    color: #555;
}

p{
    text-align: center;
}

button{
    box-shadow: none;
    width: 100%;
    height: 40px;
    border-radius: 25px;
    box-shadow: 3px 3px 3px #b1b1b1,
        -3px -3px 3px #fff;
    letter-spacing: 1.3px;
}

button:hover{
    background-color: lightblue;
}

.propertymoredetail{
    text-decoration: none;
}

@media(max-width: 380px) {
    .container {
        margin: 30px 20px;
        padding: 20px 15px 15px 15px;
    }
}
</style>