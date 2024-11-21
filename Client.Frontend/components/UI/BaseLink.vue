<script lang="ts" setup>
type TargetAttribute = '_blank' | '_self' | '_parent' | '_top';

interface Props {
  to: string | Object;
  target?: TargetAttribute;
  activeClass?: string;
}

withDefaults(defineProps<Props>(), {
  target: '_self',
  activeClass: '',
});
</script>

<template>
  <NuxtLink :to="to" class="link" :active-class="activeClass" :target="target">
    <slot />
  </NuxtLink>
</template>

<style lang="scss" scoped>
.link {
  color: $black;
  font-size: $fs-sm;
  font-weight: $fw-semibold;
  text-decoration: none;

  @include transition($duration: 0.25s, $timing-function: ease);

  &:hover {
    color: $orange;
  }
}
</style>
