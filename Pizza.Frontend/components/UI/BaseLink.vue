<script lang="ts" setup>
interface Props {
  to: string | Object;
}

defineProps<Props>();
</script>

<template>
  <NuxtLink :to="to" class="link" active-class="link_active">
    <slot />
  </NuxtLink>
</template>

<style lang="scss" scoped>
.link {
  color: $black;
  font-size: $fs-sm;
  font-weight: $fw-semibold;
  text-decoration: none;
  @include transition(0.25s, ease);

  &:hover,
  &_active {
    color: $orange;
  }
}
</style>
