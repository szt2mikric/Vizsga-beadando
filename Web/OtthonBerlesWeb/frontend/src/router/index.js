import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/login',
      name: 'login',
      component: () => import('../views/LoginView.vue')
    },
    {
      path: '/profile',
      name: 'profile',
      component: () => import('../views/ProfileView.vue')
    },
    {
      path: '/register',
      name: 'register',
      component: () => import('../components/Register.vue')
    },
    {
      path: '/logincomd',
      name: 'logincomp',
      component: () => import('../components/Login.vue')
    },
    {
      path: '/modifies',
      name: 'modifies/:id',
      component: () => import('../components/Modifies.vue')
    }
  ]
})

export default router
