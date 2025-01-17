<template>
    <header>
      <div class="nav-menu">
        <i class="fa fa-bars" aria-hidden="true" @click="toggleMenu"></i>
        <div class="nav-content" :class="{ 'open-menu': showMobileMenu, 'closed-menu': !showMobileMenu }">
          <div class="logo"><img src="../assets/OtthonBérlés.png" alt="logo"></div>
            <ul class="nav-items">
              <li class="nav-item"><RouterLink to="/" class="nav-link">Ingatlanok</RouterLink></li>
              <li class="nav-item"><RouterLink to="/login" class="nav-link">Bejelentkezés</RouterLink></li>
              <li class="nav-item"><RouterLink to="/profile" class="nav-link">Profil</RouterLink></li>
            </ul>
        </div>
      </div>
    </header>
  
</template>
  
<script>
  import { RouterLink, RouterView } from 'vue-router'

  export default{
    data(){
      return{
        showMobileMenu: false,
      };
    },
    methods: {
      toggleMenu(){
        this.showMobileMenu = !this.showMobileMenu;
      }
    },
  };
  
</script>

<style lang="scss" scoped>
.nav-menu {
  background-color: rgb(36, 133, 237);
}
.nav-content {
  display: flex;
  justify-content: space-between;
  align-items: center;
}
.nav-items {
  display: flex;
  justify-content: center;
  align-items: center;
  list-style: none;
  margin: 0;
  padding: 0;
  li {
    padding: 0 10px;
  }
}
i {
  display: none;
}
.login-button {
  margin-right: 10px;
}
.logo {
  display: flex;
  padding: 0;
  margin: 0;
  height: 7vh;
}

.login-button{
  cursor: pointer;
}
@media screen and (max-width: 768px) {
  .nav-menu {
    padding-top: 10px;
    width: 100%;
    }
  .open-menu {
    opacity: 1;   
  }
  .closed-menu {
    opacity: 0;
    height: 0;
    padding: 0;
  }
  .nav-content {
    flex-direction: column;
    z-index: 100;
    position: sticky;
    transition: all 0.2s ease-out;
  }
  .nav-items {
    flex-direction: column;
    padding:0;
    }
  i {
    display: block;
    text-align: right;
    padding: 0 10px 10px 0;
  }
  .logo{
    display: flex;
    justify-content:center;
    padding: 0;
    margin: 0;
  }
}
</style>
