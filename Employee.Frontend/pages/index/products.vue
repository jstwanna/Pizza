<script setup lang="ts">
definePageMeta({
  title: 'Продукты',
});

onMounted(() => {
  const userCookie = useCookie('user');

  const user =
    typeof userCookie.value === 'string'
      ? JSON.parse(userCookie.value)
      : userCookie.value;
});
</script>

<template>Products</template>

<style scoped lang="scss"></style>
