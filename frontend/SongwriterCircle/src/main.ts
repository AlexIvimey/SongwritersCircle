import { createApp } from 'vue'
import { createPinia } from 'pinia'

import router from './router'
import App from './App.vue'
import Login from './components/Login.vue'
const app = createApp(App)

app.component('login', Login)

app.use(createPinia())
app.use(router)

app.mount('#app')
