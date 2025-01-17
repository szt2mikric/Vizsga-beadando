<template>
    <div class="reg">
      <div class="logo2"><img src="../assets/OtthonBérlés.png" alt="logo"></div>
        <div class="text-center mt-4 name">
            Otthon Bérlés
        </div>
        <form class="p-3 mt-3">
            <div class="form-field d-flex align-items-center">
                <span class="far fa-user"></span>
                <input type="text" name="userName" placeholder="Teljes név" v-model="Customer_fullname">
            </div>
            <div class="form-field d-flex align-items-center">
                <span class="fa-solid fa-envelope"></span>
                <input type="email" name="email" placeholder="Email cím" v-model="Customer_email">
            </div>
            <div class="form-field d-flex align-items-center">
                <span class="far fa-key"></span>
                <input type="password" name="password" placeholder="Jelszó" v-model="Customer_password" class="pass">
            </div>
<!--             <div class="form-field d-flex align-items-center">
                <span class="fas fa-key"></span>
                <input type="password" name="password-confirmation" placeholder="Jelszó megerősítés" class="pass-conf">
            </div> -->
            <button class="btn mt-3" @click="saveCustomer">Regisztráció</button>
        </form>
        <div class="text-center fs-6">
            <button class="btn mt-3"><RouterLink to="/logincomp" class="log-btn">Bejelentkezés</RouterLink></button>
        </div>
    </div>

</template>

<script>
import axios from 'axios';

export default{
    data(){
        return{
            Customer_fullname: "",
            Customer_email: "",
            Customer_password:"",
        };
    },
    methods:{
        async saveCustomer(){
            try{
                await axios.post("http://localhost:3000/customers",{
                Customer_fullname:this.Customer_fullname,
                Customer_email:this.Customer_email,
                Customer_password: this.Customer_password,
            });
            (this.Customer_fullname = ""),
            (this.Customer_email = ""),
            (this.Customer_password= "");
            this.$route.push("/")
            } catch(err){
                console.log(err);
            }
        },
    },
};
</script>

<style>
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
    font-family: 'Poppins', sans-serif;
}

body {
    background: #ecf0f3;
}

.reg {
    max-width: 350px;
    min-height: 500px;
    margin: 80px auto;
    padding: 40px 30px 30px 30px;
    background-color: #ecf0f3;
    border-radius: 15px;
    box-shadow: 13px 13px 20px #cbced1, -13px -13px 20px #fff;
}

.logo2 {
    width: 80px;
    margin: auto;
}

.logo2 img {
    background-color: rgb(36, 133, 237);

    width: 100%;
    height: 80px;
    object-fit: cover;
    border-radius: 50%;
    box-shadow: 0px 0px 3px #5f5f5f,
        0px 0px 0px 5px #ecf0f3,
        8px 8px 15px #a7aaa7,
        -8px -8px 15px #fff;
}

.reg .name {
    font-weight: 600;
    font-size: 1.4rem;
    letter-spacing: 1.3px;
    padding-left: 10px;
    color: #555;
}

.reg .form-field input {
    width: 100%;
    display: block;
    border: none;
    outline: none;
    background: none;
    font-size: 1.2rem;
    color: #666;
    padding: 10px 15px 10px 10px;
}

.reg .form-field {
    padding-left: 10px;
    margin-bottom: 20px;
    border-radius: 20px;
    box-shadow: inset 8px 8px 8px #cbced1, inset -8px -8px 8px #fff;
}

.reg .form-field .fas {
    color: #555;
}

.reg .btn {
    box-shadow: none;
    width: 100%;
    height: 40px;
    background-color: rgb(36, 133, 237);
    color: #fff;
    border-radius: 25px;
    box-shadow: 3px 3px 3px #b1b1b1,
        -3px -3px 3px #fff;
    letter-spacing: 1.3px;
}

.reg .btn:hover {
    background-color: lightblue;
}

.reg a {
    text-decoration: none;
    font-size: 0.8rem;
    color: #03A9F4;
}

.reg a:hover {
    color: #039BE5;
}

.reg .log-btn{
    color: #fff;
}
@media(max-width: 380px) {
    .reg {
        margin: 30px 20px;
        padding: 20px 15px 15px 15px;
    }
}

</style>