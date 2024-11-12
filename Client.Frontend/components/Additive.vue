<script setup lang="ts">
import confirm from '../assets/svg/confirm.svg';

import type { AdditiveListView } from '../api/api-generated';

const props = defineProps<{
  additive: AdditiveListView;
  onToggle: (additive: AdditiveListView, isActive: boolean) => void;
}>();

const isActive = ref<boolean>(false);

const toggleActive = () => {
  isActive.value = !isActive.value;
  props.onToggle(props.additive, isActive.value);
};
</script>

<template>
  <li
    :class="['additive', { additive_active: isActive }]"
    @click="toggleActive"
  >
    <img
      :src="`/images/${additive.image}`"
      :alt="`Ингредиент ${additive.name}`"
      class="additive__image"
    />
    <h3 class="additive__title">{{ additive.name }}</h3>
    <span class="additive__price">{{ additive.price }} ₽</span>
    <img
      :src="confirm"
      alt="Картинка галочки"
      class="additive__confirm"
      v-show="isActive"
    />
  </li>
</template>

<style scoped lang="scss">
.additive {
  cursor: pointer;
  box-sizing: border-box;
  position: relative;
  height: 10.375rem;
  width: calc(33.3333% - 0.5rem);
  box-shadow: hsla(241, 82%, 11%, 0.12) 0 0.25rem 1.25rem;
  display: flex;
  align-items: center;
  padding: 0.5rem;
  background: $white;
  border-width: 0.0625rem;
  border-style: solid;
  border-color: $white;
  border-radius: 0.75rem;
  flex-flow: column;
  transition: box-shadow 150ms ease-out, border;

  &:hover {
    box-shadow: $black-150 0 0 0.75rem -0.25rem;
  }

  &_active {
    border-color: $orange;
  }

  &__image {
    height: 5.625rem;
    flex: 0 0 auto;
  }

  &__title {
    font-weight: normal;
    text-align: center;
    font-size: $fs-xs;
    line-height: 1rem;
    flex: 1 0 auto;
    height: 2rem;
  }

  &__price {
    font-weight: $fw-medium;
    font-size: $fs-base;
    line-height: 1.25rem;
    flex: 0 0 auto;
    margin: 0.25rem;
  }

  &__confirm {
    position: absolute;
    top: 0.25rem;
    right: 0.25rem;
  }
}
</style>
