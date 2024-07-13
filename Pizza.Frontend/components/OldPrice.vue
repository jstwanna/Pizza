<script setup lang="ts">
import { formatNumber } from '../utils/utils';

defineProps<{ oldCost: number | null }>();
</script>

<template>
  <div class="old-cost" v-if="oldCost != null">
    <span class="old-cost__line"></span>
    {{ formatNumber(oldCost) }} ₽
  </div>
</template>

<style scoped lang="scss">
.old-cost {
  position: relative;
  font-weight: $fw-medium;
  width: min-content;
  white-space: nowrap;

  &__line {
    position: absolute;
    width: 110%;
    height: 55%;
    left: -5%;
    bottom: 15%;
    background-color: $orange;
    mask-image: url('/line.svg');
  }
}
</style>
