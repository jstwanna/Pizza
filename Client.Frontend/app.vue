<script setup lang="ts">
import { isUserLoggedIn } from './utils/userHelper';

onMounted(() => {
  const user = localStorage.getItem('user');
  const loginTimeStamp = localStorage.getItem('login-timestamp');

  const router = useRouter();
  const route = useRoute();

  if (route.path === '/profile' && !isUserLoggedIn) {
    router.push('/');
  }

  if (user && loginTimeStamp) {
    isUserLoggedIn.value = true;
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
