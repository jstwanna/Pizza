<script setup lang="ts"></script>

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

  min-width: 64rem;
  min-height: 100dvh;

  color: $black;

  font-synthesis: none;
  text-rendering: optimizeLegibility;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  -webkit-text-size-adjust: 100%;

  &__main {
    max-width: 80rem;
    margin-left: auto;
    margin-right: auto;
  }
}
</style>
