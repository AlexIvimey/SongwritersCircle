<script lang="ts">
  import { useTitle } from '@vueuse/core'
  const title = useTitle();
  title.value = 'SongwritersCircle'
</script>
<template>
  <nav>
    <RouterLink to="/">Login</RouterLink>
    <RouterLink to="/home">Home</RouterLink>
  </nav>
  <main>
    <RouterView />
  </main>
</template>

<style scoped></style>
