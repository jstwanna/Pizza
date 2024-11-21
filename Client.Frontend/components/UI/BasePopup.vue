<script setup lang="ts">
import close from '../../assets/svg/close.svg';

const emits = defineEmits<{
  (event: 'closePopup'): void;
  (event: 'update:modelValue', value: boolean): void;
}>();

interface Props {
  modelValue: boolean;
  customClass?: string;
  closePosition?: 'top' | 'left';
}

const props = withDefaults(defineProps<Props>(), {
  customClass: '',
  closePosition: 'top',
});

const popup = ref<Element | null>(null);

const modelUpdate = computed({
  get: () => props.modelValue,
  set: (newValue: boolean) => emits('update:modelValue', newValue),
});

const closePopup = () => emits('closePopup');

const handleCloseByEsc = (event: KeyboardEvent) => {
  if (event.key === 'Escape' && modelUpdate.value) {
    closePopup();
  }
};

const handleCloseByOverlay = (event: Event) => {
  if (event.target === popup.value) {
    closePopup();
  }
};

const addEventListeners = () => {
  document.addEventListener('keydown', handleCloseByEsc);

  document.addEventListener('click', handleCloseByOverlay);
};

const removeEventListeners = () => {
  document.removeEventListener('keydown', handleCloseByEsc);

  document.removeEventListener('click', handleCloseByOverlay);
};

onMounted(addEventListeners);

onUnmounted(removeEventListeners);

watch(modelUpdate, () => {
  document.body.style.overflowY = modelUpdate.value ? 'hidden' : 'auto';
});
</script>

<template>
  <Teleport to="body">
    <Transition name="popup">
      <section v-if="modelUpdate" ref="popup" :class="['popup', customClass]">
        <div :class="`popup__content popup__content_${closePosition}`">
          <img
            :src="close"
            alt="Фото закрытия попапа"
            @click="closePopup"
            :class="`popup__close popup__close_${closePosition}`"
          />
          <slot name="content" />
        </div>
      </section>
    </Transition>
  </Teleport>
</template>

<style scoped lang="scss">
.popup {
  position: fixed;
  z-index: 30;
  display: flex;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: hsla(0, 0%, 0%, 0.7);

  &__content {
    position: relative;
    font-family: $ff-dodo, system-ui, -apple-system, BlinkMacSystemFont,
      'Segoe UI', Roboto, Oxygen-Sans, Ubuntu, Cantarell, 'Helvetica Neue',
      Arial, sans-serif, 'Apple Color Emoji', 'Segoe UI Emoji',
      'Segoe UI Symbol';

    &_top {
      margin: auto;
    }

    &_left {
      margin-left: auto;
    }
  }

  &__close {
    cursor: pointer;
    position: absolute;
    cursor: pointer;
    @include transition(transform, 0.1s ease-in-out);

    &:hover {
      transform: scale(1.1);
    }

    &_top {
      top: 0.8125rem;
      right: -2.375rem;
    }

    &_left {
      left: -3rem;
      top: calc(50% - 0.75rem);
    }
  }

  &-enter-active,
  &-leave-active {
    @include transition(opacity, 150ms, ease);
  }

  &-enter-from,
  &-leave-to {
    @include transition(opacity, 150ms, ease);
    opacity: 0;
  }
}
</style>
