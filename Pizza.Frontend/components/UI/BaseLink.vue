<script lang="ts" setup>
type TargetAttribute = '_blank' | '_self' | '_parent' | '_top';

interface Props {
  to: string;
  target?: TargetAttribute;
  activeClass?: string | null;
}

withDefaults(defineProps<Props>(), {
  target: '_self',
  activeClass: null,
});
</script>

<template>
  <NuxtLink :to="to" class="link" active-class="link_active" :target="target">
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

  &:hover {
    color: $orange;
  }
}
</style>
