<script setup lang="ts">
import trash from '../assets/svg/delete.svg';
import minus from '../assets/svg/minus.svg';
import plus from '../assets/svg/plus.svg';

import BaseButton from './UI/BaseButton.vue';

import type { IProductListView, IAdditiveListView } from '../models/models';
import type { ICounterItems } from '../models/models';
import { formatNumber } from '~/utils/utils';

const emits = defineEmits<{
  (event: 'increment', id: number, additive: IAdditiveListView[]): void;
  (event: 'decrement', id: number, additive: IAdditiveListView[]): void;
  (event: 'remove', id: number, additive: IAdditiveListView[]): void;
}>();

const props = defineProps<{ item: ICounterItems<IProductListView> }>();

const handleIncrement = () =>
  emits('increment', props.item.item.id, props.item.additives);
const handleDecrement = () =>
  emits('decrement', props.item.item.id, props.item.additives);
const handleRemove = () =>
  emits('remove', props.item.item.id, props.item.additives);

const totalPrice = computed(() => props.item.count * props.item.price);

const additivesNames = computed(() => {
  if (props.item.additives && props.item.additives.length > 0) {
    return props.item.additives
      .map((additive) => additive.name)
      .join(', ')
      .toLowerCase();
  }

  return null;
});
</script>

<template>
  <article class="cart-block">
    <BaseButton type="button" class="cart-block__trash">
      <img :src="trash" alt="Картинка удаления" @click="handleRemove" />
    </BaseButton>
    <div class="cart-block__info">
      <img
        :src="`/images/${item.item.image}`"
        :alt="`Фото ${item.item.name}`"
        class="cart-block__image"
      />
      <div>
        <h3 class="cart-block__title">
          {{ item.item.name
          }}{{
            item.item.productType !== 'Пицца'
              ? `, ${item.item.characteristics[1].value} шт`
              : ''
          }}
        </h3>
        <span class="cart-block__characteristics">
          {{
            item.item.productType === 'Пицца'
              ? `${item.item.characteristics[1].value} см, ${
                  item.item.characteristics[2].value === 1
                    ? 'традиционное'
                    : 'тонкое'
                } тесто, ${item.item.characteristics[0].value} г`
              : `${item.item.characteristics[1].value} шт`
          }}
        </span>
        <div v-if="additivesNames" class="cart-block__characteristics">
          + {{ additivesNames }}
        </div>
      </div>
    </div>
    <div class="cart-block__control">
      <span class="cart-block__total-price">
        {{ formatNumber(totalPrice) }} ₽
      </span>
      <div class="cart-block__update-container">
        <BaseButton
          type="button"
          class="cart-block__icon"
          @click="handleDecrement"
        >
          <img :src="minus" alt="Картинка минуса" />
        </BaseButton>
        <div class="cart-block__count">{{ item.count }}</div>
        <BaseButton
          type="button"
          class="cart-block__icon"
          @click="handleIncrement"
        >
          <img :src="plus" alt="Картинка плюса" />
        </BaseButton>
      </div>
    </div>
  </article>
</template>

<style scoped lang="scss">
.cart-block {
  position: relative;
  padding: 0.75rem 1rem;
  background: $white;
  margin-bottom: 0.5rem;

  &__trash {
    position: absolute;
    top: 1rem;
    right: 1.5rem;
    display: block;
    height: 1rem;
    width: 1rem;
  }

  &__info {
    display: flex;
    border-bottom: 0.0625rem solid hsl(240, 14%, 90%);
    padding-bottom: 0.75rem;
  }

  &__image {
    width: 4rem;
    height: 4rem;
    flex: 0 0 auto;
    margin-right: 1rem;
  }

  &__title {
    font-weight: $fw-semibold;
    font-size: $fs-base;
    line-height: 1.25rem;
    margin-right: 2rem;
    margin-bottom: 0.25rem;
  }

  &__characteristics {
    font-weight: normal;
    font-size: $fs-xs;
    line-height: 1rem;
    color: $dark-gray;
    white-space: pre-wrap;
  }

  &__control {
    display: flex;
    align-items: center;
    margin-top: 0.75rem;
  }

  &__total-price {
    padding: 0.5rem 0.5rem 0.5rem 0;
    flex: 1 1 auto;
    font-size: $fs-base;
    font-weight: $fw-semibold;
    line-height: 1.25rem;
  }

  &__update-container {
    flex: 0 0 auto;
    display: flex;
    align-items: center;
    justify-content: space-between;
    margin-left: auto;
    width: 6rem;
    height: 2rem;
    background-color: $gray;
    border-radius: 624.9375rem;
  }

  &__icon {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    width: 35.41%;
    height: 100%;
    padding-left: 0.5rem;
    padding-right: 0.5rem;

    &:hover {
      opacity: 0.6;
    }
  }

  &__count {
    height: 100%;
    color: $dark-gray;
    font-weight: 500;
    display: flex;
    justify-content: center;
    align-items: center;
  }
}
</style>
