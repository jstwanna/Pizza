<script setup lang="ts">
import BaseButton from './BaseButton.vue';

import type { ProductListView } from '../../api/api-generated';

defineProps<{ card: ProductListView }>();
</script>

<template>
  <div class="combo-preview">
    <div class="combo-preview__row">
      <img
        :src="`/images/${card.image}`"
        :alt="`Фото ${card.name}`"
        class="combo-preview__image"
      />
      <div class="combo-preview__info">
        <h4 class="combo-preview__title">{{ card.name }}</h4>
        <div class="combo-preview__meta-description">
          {{ card.characteristics[1].value }} шт, традиционное тесто 30,
          {{ card.characteristics[0].value }} г
        </div>
        <div class="combo-preview__control">
          <BaseButton
            type="button"
            :disabled="true"
            class="combo-preview__change"
          >
            Заменить
          </BaseButton>
          <BaseButton type="button" class="combo-preview__switch">
            Изменить состав
          </BaseButton>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss">
.combo-preview {
  width: 100%;
  min-height: 5.875rem;
  position: relative;
  margin-bottom: 0.75rem;
  box-shadow: rgba(6, 5, 50, 0.1) 0rem 0.125rem 0.25rem;
  padding: 0.75rem;
  background: $white;
  border-radius: 1rem;
  transition: box-shadow 0.15s ease-in-out, border-color;
  border-width: 0.0625rem;
  border-style: solid;
  border-color: $white;
  border-image: initial;
  cursor: pointer;

  &:hover {
    box-shadow: rgba(6, 5, 50, 0.1) 0px 0.375rem 1.25rem;
  }

  &__row {
    display: flex;
  }

  &__image {
    width: 4.25rem;
    height: 4.25rem;
  }

  &__info {
    margin-left: 0.625rem;
  }

  &__title {
    font-size: $fs-base;
    line-height: 1.25rem;
    margin-bottom: 0.25rem;
    padding-right: 2.375rem;
    font-weight: 600;
  }

  &__meta-description {
    font-size: $fs-xs;
    margin-bottom: 0.25rem;
    line-height: 1rem;
  }

  &__control {
    display: flex;
    gap: 1rem;
    margin-top: 24px;
  }

  &__change {
    font-size: $fs-sm;
    padding: 0.5rem 1rem;
    background-color: $pink;
    color: $deep-amber;

    &:disabled {
      cursor: not-allowed;
      opacity: 0.4;
    }
  }

  &__switch {
    font-size: $fs-sm;
    padding: 0.5rem 1rem;
    white-space: nowrap;
    color: $deep-amber;
    @include transition;

    &:hover {
      color: $orange;
    }
  }
}
</style>
