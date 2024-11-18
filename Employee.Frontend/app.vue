<script setup lang="ts"></script>

<template>
  <div class="app">
    <NuxtPage />
  </div>
</template>

<style scoped lang="scss">
.app {
  font-family: $ff-dodo, system-ui, -apple-system, BlinkMacSystemFont,
    'Segoe UI', Roboto, Oxygen-Sans, Ubuntu, Cantarell, 'Helvetica Neue', Arial,
    sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji', 'Segoe UI Symbol';
  font-size: $fs-base;
  line-height: 1.2;
  font-weight: $fw-normal;

  color: $black;
  min-height: 100dvh;

  display: flex;
  flex-direction: column;

  font-synthesis: none;
  text-rendering: optimizeLegibility;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}
</style>
