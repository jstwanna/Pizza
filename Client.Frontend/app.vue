<script setup lang="ts">
import { isUserLoggedIn } from './utils/userHelper';

onMounted(async () => {
  const user = localStorage.getItem('user');
  const loginTimestamp = localStorage.getItem('login-timestamp');

  const router = useRouter();

  if (user && loginTimestamp) {
    const loginTime = parseInt(loginTimestamp, 10);
    const currentTime = Date.now();
    const tokenExpiration = 30 * 60 * 1000;

    if (currentTime - loginTime < tokenExpiration) {
      isUserLoggedIn.value = true;
    } else {
      await $fetch('/api/identity/base/RefreshToken');

      const newTimestamp = Date.now();
      localStorage.setItem('login-timestamp', newTimestamp.toString());
      isUserLoggedIn.value = true;
    }
  } else {
    localStorage.clear();
    router.push('/');
  }
});
</script>

<template>
  <div class="app">
    <AppHeader />

    <main class="app__main">
      <NuxtPage />
    </main>

    <AppFooter />
  </div>
</template>

<style scoped lang="scss">
.app {
  font-size: $fs-base;
  font-family: $ff-dodo, system-ui, -apple-system, BlinkMacSystemFont,
    'Segoe UI', Roboto, Oxygen-Sans, Ubuntu, Cantarell, 'Helvetica Neue', Arial,
    sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
  font-weight: $fw-normal;
  line-height: 1.4;

  min-width: 70.5rem;
  min-height: 100dvh;

  color: $black;

  font-synthesis: none;
  text-rendering: optimizeLegibility;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  -webkit-text-size-adjust: 100%;
}
</style>
