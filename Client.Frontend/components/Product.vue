<script setup lang="ts">
import type { CatalogItemListView } from '../api/api-generated';
import { formatNumber } from '../utils/utils';

const props = defineProps<{ product: CatalogItemListView }>();

const emits = defineEmits<{
  (e: 'cardClick', card: CatalogItemListView): void;
  (e: 'addToCart', card: CatalogItemListView): void;
}>();

const buttonText = computed(() =>
  props.product.category === 'Пицца' || props.product.category === 'Комбо'
    ? 'Выбрать'
    : 'В корзину'
);

const handleClickCard = () => {
  emits('cardClick', props.product);
};

const handleAddToCart = () => {
  emits('addToCart', props.product);
};

const minPrice = computed(() =>
  Math.min(...props.product.products.map((p) => p.price))
);
</script>

<template>
  <article class="product" @click="handleClickCard">
    <div class="product__main">
      <img
        :src="`/images/${product.image}`"
        :alt="`Фото ${product.name}`"
        class="product__image"
      />
      <h3 class="product__title">{{ product.name }}</h3>
      {{ product.description }}
    </div>
    <div class="product__footer">
      <div class="product__cost">
        {{
          `${product.category === 'Пицца' ? 'от ' : ''} ${formatNumber(
            minPrice
          )}`
        }}
        ₽
      </div>
      <UIBaseButton
        type="button"
        class="product__button"
        @click="handleAddToCart"
      >
        {{ buttonText }}
      </UIBaseButton>
    </div>
  </article>
</template>

<style scoped lang="scss">
.product {
  display: flex;
  flex-flow: column;
  justify-content: space-between;
  cursor: pointer;
  width: 18.25rem;
  margin-bottom: 3.75rem;

  &__main {
    width: 100%;
    font-size: $fs-sm;
    line-height: 1.25rem;
    color: $dark-gray;
  }

  &__image {
    position: relative;
    top: 0;
    @include transition(top, 150ms, ease-out);
    width: 90%;
    object-fit: cover;
    margin-top: 5%;
    margin-left: 5%;

    &:hover {
      top: 0.1875rem;
    }
  }

  &__title {
    color: $black;
    margin-top: 0.5rem;
    margin-bottom: 0.5rem;
    font-size: $fs-xl;
    line-height: 1.5rem;
    font-weight: $fw-medium;
  }

  &__footer {
    margin-top: 1rem;
    display: flex;
    justify-content: space-between;
  }

  &__cost {
    flex: 0 1 auto;
    padding-right: 0.25rem;
    font-size: $fs-xl;
    font-weight: $fw-semibold;
    line-height: 1.375rem;
    display: flex;
    flex-flow: column;
    justify-content: center;
  }

  &__button {
    min-height: 2.5rem;
    max-width: 60%;
    min-width: 7.5rem;
    padding: 0.5rem 1.25rem;
    line-height: 1.5rem;
    color: $deep-amber;
    background-color: $pink;

    &:hover {
      background-color: $light-pink;
    }

    &:active {
      opacity: 0.5;
    }
  }
}
</style>
