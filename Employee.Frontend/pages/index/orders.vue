<script setup lang="ts">
const searchOrder = ref<string | number>('');

const ordersData = ref([
  {
    status: 'pending',
    phone: '78282829282',
    products: 'Pizza Pizza Pizza Pizza Pizza Pizza Pizza',
  },
]);

definePageMeta({
  title: 'Заказы',
});
</script>

<template>
  <section class="orders">
    <ElInput
      type="text"
      placeholder="Поиск по ФИО или сумме заказа"
      v-model="searchOrder"
    />
    <ElTable :data="ordersData" border class="orders__table">
      <el-table-column prop="status" label="Статус заказа" />
      <el-table-column prop="phone" label="Телефон" />
      <el-table-column prop="products" label="Содержимое" />
      <ElTableColumn prop="operations" label="Действия">
        <template #default="scope">Действия</template>
      </ElTableColumn>
    </ElTable>
  </section>
</template>

<style scoped lang="scss">
.orders {
  padding: 1.25rem;

  &__table {
    width: 100%;
    margin-top: 1.25rem;
  }
}
</style>
