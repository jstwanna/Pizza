<script lang="ts" setup>
import type { OftenOrderCard } from '../models/models';
import { OrderType } from '../models/models';
import { formatNumber } from '../utils/utils';

const emit = defineEmits<{
  (e: 'cardClick', card: OftenOrderCard): void;
}>();

const props = defineProps<{ card: OftenOrderCard }>();

const handleClickCard = () => {
  emit('cardClick', props.card);
};
</script>

<template>
  <li class="order-card" @click="handleClickCard">
    <img
      :src="card.src"
      :alt="`Фото ${card.title}`"
      class="order-card__image"
    />
    <div class="order-card__info">
      <h3 class="order-card__title">{{ card.title }}</h3>
      <span class="order-card__cost">
        <template v-if="card.type === OrderType.Pizza">от</template>
        {{ formatNumber(card.cost) }} ₽
      </span>
      <OldPrice :oldCost="card.oldCost" />
    </div>
  </li>
</template>

<style lang="scss" scoped>
.order-card {
  @include transition(150ms, ease-out);
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
    margin-left: 0.5px;
  }

  &__title {
    max-width: 9.1875rem;
    font-size: $fs-base;
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
