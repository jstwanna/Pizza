<script setup lang="ts">
import BaseButton from './BaseButton.vue';

import type { ITab } from '../../models/models';

const props = defineProps<{
  tabs: ITab[];
  modelValue: number;
}>();

const emits = defineEmits<{
  (e: 'update:modelValue', value: number): void;
}>();

const selectedIndex = ref<number>(props.modelValue);

const selectTab = (id: number) => {
  selectedIndex.value = id;
  emits('update:modelValue', id);
};
</script>

<template>
  <div class="tabs">
    <BaseButton
      type="button"
      v-for="tab in tabs"
      :key="tab.id"
      @click="selectTab(tab.id)"
      :disabled="tab.disabled || false"
      :class="[
        'tabs__button',
        { tabs__button_active: selectedIndex === tab.id },
      ]"
    >
      {{ tab.title }}
    </BaseButton>
  </div>
</template>

<style scoped lang="scss">
.tabs {
  border-radius: 624.9375rem;
  background-color: $gray;
  min-height: 2rem;
  display: flex;
  position: relative;
  overflow: hidden;
  margin-top: 0.5rem;
  margin-bottom: 0.5rem;

  &__button {
    border-radius: 624.9375rem;
    width: 100%;
    margin: 0.125rem;
    font-size: $fs-xs;

    &_active {
      background-color: $white;
      box-shadow: rgba(6, 5, 50, 0.19) 0 0.375rem 1.25rem;
    }

    &:disabled {
      cursor: not-allowed;
    }
  }
}
</style>
