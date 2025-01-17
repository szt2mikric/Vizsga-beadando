<!-- <template>
    <div class="modifies">
        <div class="text-center mt-4 name">Adatok módosítása</div>
        <form class="p-3 mt-3">
            <div class="form-field d-flex align-items-center">
                <span class="far fa-user"></span>
                <input type="text" name="userName" placeholder="Teljes név" v-model="Customer_fullname">
            </div>
            <div class="form-field d-flex align-items-center">
                <input type="email" name="email" placeholder="Email cím"  v-model="Customer_email">
            </div>
            <div class="form-field d-flex align-items-center">
                <input type="password" name="password" placeholder="Jelszó"  v-model="Customer_password"> 
            </div>
            <div class="form-field d-flex align-items-center">
                <input type="password" name="password-confirmation" placeholder="Jelszó megerősítés">
            </div>
            <button class="btn mt-3">Frissítés</button>
        </form>
    </div>
</template>

<script>
export default {
    data() {
        return {
            Customer_fullname: "",
            Customer_email: "",
            Customer_password:"",
        };
    },
    created() {
        this.getCustomerById();
    },
    methods: {
        async getCustomerById() {
            try {
                const response = await axios.get(`http://localhost:3000/customers/${this.$route.params.id}`);
                this.CustomerFullname = response.data.Customer_fullname;
                this.CustomerEmail = response.data.Customer_email;
                this.CustomerPassword = response.data.Customer_password;
            } catch (err) {
                console.log(err);
            }
        }
    }
}
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

.modifies {
    max-width: 350px;
    min-height: 450px;
    margin: 80px auto;
    padding: 40px 30px 30px 30px;
    background-color: #ecf0f3;
    border-radius: 15px;
    box-shadow: 13px 13px 20px #cbced1, -13px -13px 20px #fff;
}

.modifies .name {
    font-weight: 600;
    font-size: 1.4rem;
    letter-spacing: 1.3px;
    padding-left: 10px;
    color: #555;
}

.modifies .form-field input {
    width: 100%;
    display: block;
    border: none;
    outline: none;
    background: none;
    font-size: 1.2rem;
    color: #666;
    padding: 10px 15px 10px 10px;
}

.modifies .form-field {
    padding-left: 10px;
    margin-bottom: 20px;
    border-radius: 20px;
    box-shadow: inset 8px 8px 8px #cbced1, inset -8px -8px 8px #fff;
}

.modifies .btn {
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

.modifies .btn:hover {
    background-color: lightblue;
}

.modifies a {
    text-decoration: none;
    font-size: 0.8rem;
    color: #03A9F4;
}

.modifies a:hover {
    color: #039BE5;
}

@media(max-width: 380px) {
    .modifies {
        margin: 30px 20px;
        padding: 20px 15px 15px 15px;
    }
}

</style> -->