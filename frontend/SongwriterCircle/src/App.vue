<script lang="ts">
</script>
<template>
  <div>This is the app file</div>
  <div>The current route for the app is {{ $route.fullPath }}</div>
  <nav>
    <RouterLink to="/">Home</RouterLink>
    <RouterLink to="/login">Login</RouterLink>
  </nav>
  <main>
    <RouterView />
  </main>
</template>

<style scoped></style>
