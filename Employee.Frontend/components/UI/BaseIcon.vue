<script setup lang="ts">
interface IIcon {
  name: string;
  size?: 'xs' | 'sm' | 'md' | 'lg' | 'xl';
}

const props = withDefaults(defineProps<IIcon>(), {
  size: 'xs',
});

const fontSizes: Record<NonNullable<IIcon['size']>, string> = {
  xs: '0.75rem',
  sm: '1.125rem',
  md: '2rem',
  lg: '2.375rem',
  xl: '2.875rem',
};

const fontSizeStyle = computed(() => ({
  fontSize: fontSizes[props.size],
}));
</script>

<template>
  <i class="material-symbols-outlined" :style="fontSizeStyle" v-bind="$attrs">
    {{ name }}
  </i>
</template>

<style scoped lang="scss">
.material-symbols-outlined {
  font-family: 'Material Symbols Outlined';
  font-weight: normal;
  font-style: normal;
  line-height: 1;
  letter-spacing: normal;
  text-transform: none;
  display: inline-block;
  white-space: nowrap;
  word-wrap: normal;
  direction: ltr;
  -webkit-font-feature-settings: 'liga';
  -webkit-font-smoothing: antialiased;
}
</style>
