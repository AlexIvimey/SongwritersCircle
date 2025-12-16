<script lang="ts">
import { defineComponent } from 'vue'
import { mapState } from 'pinia'
import { useUserStore } from '../stores/user'
export default defineComponent({
  data() {
    return {
      username: '',
      password: '',
    }
  },
  methods: {
    login() {},
  },
  computed: {
    ...mapState(useUserStore, ['user']),
  },
})
</script>
<template>
  <form type="submit" v-model="login">
    <input type="text" v-model="username" placeholder="username" required />
    <input type="text" v-model="password" placeholder="password" required />
  </form>
</template>
