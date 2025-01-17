import { ref, computed } from 'vue'
import { defineStore } from 'pinia'

export const useCounterStore = defineStore('counter', () => {
  const count = ref(0)
  const doubleCount = computed(() => count.value * 2)
  const isLoggedIn = ref(false) 

  function increment() {
    count.value++
  }

  function login() {

    isLoggedIn.value = true
  }

  return { count, doubleCount, increment, isLoggedIn, login }
})
