import { createRouter, createWebHistory } from 'vue-router'

import Login from '../components/Login.vue'

const routes = [
  {
    path: '/login', component: Login
  },
]
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
})

export default router
