<script lang="ts" setup>
import type { CatalogItemListView } from '../api/api-generated';
import { formatNumber } from '../utils/utils';

const emit = defineEmits<{
  (e: 'cardClick', card: CatalogItemListView): void;
}>();

const props = defineProps<{ card: CatalogItemListView }>();

const handleClickProduct = (card: CatalogItemListView) => {
  emit('cardClick', card);
};

const getOldCost = (price: number): number | null => {
  const shouldHaveOldCost = Math.random() > 0.5;
  if (shouldHaveOldCost) {
    const additionalCost = Math.floor(Math.random() * 201) + 300;
    return price + additionalCost;
  }

  return null;
};
</script>

<template>
  <li class="order-card" @click="handleClickProduct(props.card)">
    <img
      :src="`/images/${card.image}`"
      :alt="`Фото ${card.name}`"
      class="order-card__image"
    />
    <div class="order-card__info">
      <h3 class="order-card__title">{{ card.name }}</h3>
      <span class="order-card__cost">
        {{ formatNumber(card.products[0].price) }} ₽
      </span>
      <OldPrice :oldCost="getOldCost(card.products[0].price)" />
    </div>
  </li>
</template>

<style lang="scss" scoped>
.order-card {
  @include transition($duration: 150ms, $timing-function: ease-out);
  box-shadow: $black-150 0 0.25rem 1.375rem -0.375rem;
  border-radius: 0.75rem;
  display: flex;
  cursor: pointer;
  width: 16.25rem;
  padding: 1rem;
  flex: 0 0 auto;

  &:hover {
    box-shadow: $black-150 0 0 0.75rem -0.25rem;
  }

  &__image {
    flex: 0 0 auto;
    width: 5rem;
    height: 5rem;
  }

  &__info {
    flex: 1 1 auto;
    display: flex;
    flex-flow: column;
    justify-content: center;
    margin-left: 0.5rem;
  }

  &__title {
    max-width: 9.1875rem;
    font-size: $fs-sm;
    text-overflow: ellipsis;
    white-space: nowrap;
    overflow: hidden;
    font-weight: $fw-medium;
    line-height: 1.25rem;
  }

  &__cost {
    font-weight: $fw-medium;
    margin-top: 0.25rem;
  }

  &__old-cost {
    position: relative;
    font-weight: $fw-medium;
    width: min-content;
    white-space: nowrap;
  }

  &__discount {
    position: absolute;
    width: 110%;
    height: 55%;
    left: -5%;
    bottom: 15%;
  }
}
</style>
