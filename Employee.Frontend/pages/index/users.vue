<script setup lang="ts">
const searchOrder = ref<string | number>('');

const ordersData = ref([
  {
    name: 'pending',
    lastName: '78282829282',
    login: 'Pizza Pizza Pizza Pizza Pizza Pizza Pizza',
    role: 'ddd',
  },
]);

definePageMeta({
  title: 'Пользователи',
});
</script>

<template>
  <section class="users">
    <ElInput
      type="text"
      placeholder="Поиск по роли или логину"
      v-model="searchOrder"
    />
    <ElTable :data="ordersData" border class="users__table">
      <ElTableColumn prop="name" label="Имя" />
      <ElTableColumn prop="lastName" label="Фамилия" />
      <ElTableColumn prop="login" label="Логин" />
      <ElTableColumn prop="role" label="Роль" />
      <ElTableColumn prop="operations" label="Действия">
        <template #default="scope">Действия</template>
      </ElTableColumn>
    </ElTable>
  </section>
</template>

<style scoped lang="scss">
.users {
  padding: 1.25rem;

  &__table {
    margin-top: 1.25rem;
  }
}
</style>
