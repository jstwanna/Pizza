<script lang="ts" setup>
interface Props {
  type: 'button' | 'submit' | 'reset';
  disabled?: boolean;
}

const emit = defineEmits<{ (event: 'click'): void }>();

withDefaults(defineProps<Props>(), {
  disabled: false,
});

const handleClickButton = () => emit('click');
</script>

<template>
  <button
    :type="type"
    :disabled="disabled"
    @click.stop="handleClickButton"
    class="button"
  >
    <slot />
  </button>
</template>

<style lang="scss" scoped>
.button {
  border: 0;
  background-color: transparent;
  cursor: pointer;
  font-weight: $fw-medium;
  padding: 0;
  @include transition;
  border-radius: 624.9375rem;
}
</style>
