<script setup lang="ts">
interface IUser {
  id: string;
  firstName: string;
  lastName: string;
  userName: string;
  role: string;
  disabled: boolean;
}

const searchOrder = ref<string | number>('');
const users = ref<IUser[] | null>(null);

const { data, error } = useFetch<IUser[]>('/api/employee/GetEmployees', {
  method: 'POST',
});

if (data.value) {
  users.value = data.value;
  console.log(users.value);
} else {
  console.error('Error fetching users', error.value);
}

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
    <template v-if="users != null">
      <ElTable :data="users" border class="users__table">
        <ElTableColumn prop="firstName" label="Имя" />
        <ElTableColumn prop="lastName" label="Фамилия" />
        <ElTableColumn prop="userName" label="Логин" />
        <ElTableColumn prop="role" label="Роль" />
        <ElTableColumn prop="disabled" label="Заблокирован" />
        <ElTableColumn prop="operations" label="Действия">
          <template #default="scope">Действия</template>
        </ElTableColumn>
      </ElTable>
    </template>
  </section>
</template>

<style scoped lang="scss">
.users {
  padding-top: 1.25rem;
  padding-bottom: 1.25rem;

  &__table {
    margin-top: 1.25rem;
  }
}
</style>
