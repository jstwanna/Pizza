<script setup lang="ts"></script>

<template>
  <div class="home">
    <SideBar />
    <main class="home__main">
      <AppHeader />
      <!-- <NuxtPage /> -->
      <section class="aaa">
        <div>dadadad</div>
      </section>
    </main>
  </div>
</template>

<style scoped lang="scss">
.home {
  display: flex;
  width: 100%;
  min-height: 100dvh;

  &__main {
    display: flex;
    flex-direction: column;
    flex-grow: 1;
  }
}
</style>
