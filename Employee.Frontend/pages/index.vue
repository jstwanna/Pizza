<script setup lang="ts"></script>

<template>
  <div class="home">
    <SideBar />
    <main class="home__main">
      <AppHeader />
      <NuxtPage />
    </main>
  </div>
</template>

<style scoped lang="scss">
.home {
  display: flex;
  min-height: 100dvh;

  &__main {
    display: flex;
    flex-direction: column;
    flex-grow: 1;
    padding-left: 1rem;
    padding-right: 1rem;
    position: relative;
    overflow: hidden;
  }
}
</style>
