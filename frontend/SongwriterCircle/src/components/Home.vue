<script lang="ts">
import { useUserStore } from '../stores/user'
export default {
  setup(){
    const userStore = useUserStore()
    return { userStore }
  },
}
</script>
<template>
<h2>Welcome to the SongwriterCircle</h2>
<h4>Create your first song!!</h4>
</template>
