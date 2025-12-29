import { createRouter, createWebHistory } from 'vue-router'

import Login from '../components/Login.vue'
import Home from '@/components/Home.vue'

const routes = [
  {
    path: '/', component: Login
  },
  {
    path: '/home', component: Home
  }
]
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
})

export default router
