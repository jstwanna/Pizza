<script lang="ts" setup>
import type { OftenOrderCard } from '../models/models';

interface Props {
  title: string;
  products: OftenOrderCard[];
}

defineProps<Props>();

const handleCardClick = (clickedCard: OftenOrderCard) => {
  console.log('Card clicked:', clickedCard);
};
</script>

<template>
  <section class="category">
    <h2 class="category__title">{{ title }}</h2>
    <div class="category__products">
      <Product
        v-for="product in products"
        :key="product.id"
        :product="product"
        @card-click="handleCardClick"
      />
    </div>
  </section>
</template>

<style lang="scss" scoped>
.category {
  @include container;

  &__title {
    @include section-title;
  }

  &__products {
    display: flex;
    flex-wrap: wrap;
    column-gap: 2.3333rem;
  }
}
</style>
