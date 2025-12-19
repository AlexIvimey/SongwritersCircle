<script lang="ts">
import { useUserStore } from '../stores/user'
export default {
  setup(){
    const userStore = useUserStore()
    return { userStore }
  },
  data() {
    return {
      username: '',
      password: '',
    }
  },
  methods: {
    login() {
      this.userStore.createAccount(this.username, this.password)
    },
  },
  computed: {
  
  },
}
</script>
<template>
  <form id="loginForm" @submit="login">
    <input type="text" v-model="username" placeholder="username" required />
    <input type="text" v-model="password" placeholder="password" required />
    <button type="submit">submit</button>
  </form>
</template>
