import { createApp } from 'vue'
import { createPinia } from 'pinia'
import { Axios } from 'axios'
import '../node_modules/bootstrap/dist/css/bootstrap.min.css'
import '../node_modules/@fortawesome/fontawesome-free/css/all.css'

import App from './App.vue'
import router from './router'

const app = createApp(App)

app.use(createPinia())
app.use(router)

app.mount('#app')
