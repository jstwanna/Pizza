<script setup lang="ts">
import type { Image } from '../../models/models';

defineProps<{ images: Image[] }>();

const carousel = ref<HTMLDivElement | null>(null);
const isDown = ref<boolean>(false);
const startX = ref<number>(0);
const scrollLeft = ref<number>(0);
const showLeftButton = ref<boolean>(false);
const showRightButton = ref<boolean>(true);

const checkButtonsVisibility = () => {
  if (carousel.value) {
    showLeftButton.value = carousel.value.scrollLeft > 0;
    showRightButton.value =
      carousel.value.scrollLeft + carousel.value.clientWidth <
      carousel.value.scrollWidth - 1;
  }
};

const scrollLeftBy = (amount: number) => {
  if (carousel.value) {
    carousel.value.scrollBy({ left: -amount, behavior: 'smooth' });
  }
};

const scrollRightBy = (amount: number) => {
  if (carousel.value) {
    carousel.value.scrollBy({ left: amount, behavior: 'smooth' });
  }
};

const onMouseDown = (e: MouseEvent) => {
  if (!carousel.value) return;
  isDown.value = true;
  startX.value = e.pageX - carousel.value.offsetLeft;
  scrollLeft.value = carousel.value.scrollLeft;
};

const onMouseLeave = () => {
  if (!carousel.value) return;
  isDown.value = false;
};

const onMouseUp = () => {
  if (!carousel.value) return;
  isDown.value = false;
  checkButtonsVisibility();
};

const onMouseMove = (e: MouseEvent) => {
  if (!isDown.value || !carousel.value) return;
  e.preventDefault();
  const x = e.pageX - carousel.value.offsetLeft;
  const walk = (x - startX.value) * 1;
  carousel.value.scrollLeft = scrollLeft.value - walk;
  checkButtonsVisibility();
};

onMounted(() => {
  if (carousel.value) {
    carousel.value.addEventListener('mousedown', onMouseDown);
    carousel.value.addEventListener('mouseleave', onMouseLeave);
    carousel.value.addEventListener('mouseup', onMouseUp);
    carousel.value.addEventListener('mousemove', onMouseMove);
    carousel.value.addEventListener('scroll', checkButtonsVisibility);
    window.addEventListener('resize', checkButtonsVisibility);
    checkButtonsVisibility();
  }
});

onUnmounted(() => {
  if (carousel.value) {
    carousel.value.removeEventListener('mousedown', onMouseDown);
    carousel.value.removeEventListener('mouseleave', onMouseLeave);
    carousel.value.removeEventListener('mouseup', onMouseUp);
    carousel.value.removeEventListener('mousemove', onMouseMove);
    carousel.value.removeEventListener('scroll', checkButtonsVisibility);
    window.removeEventListener('resize', checkButtonsVisibility);
  }
});
</script>

<template>
  <div class="carousel">
    <UIBaseButton
      v-if="showLeftButton"
      type="button"
      class="carousel__control carousel__control_left"
      @click="scrollLeftBy(450)"
    >
      <div class="carousel__icon carousel__icon_left"></div>
    </UIBaseButton>

    <UIBaseButton
      v-if="showRightButton"
      type="button"
      class="carousel__control carousel__control_right"
      @click="scrollRightBy(450)"
    >
      <div class="carousel__icon carousel__icon_right"></div>
    </UIBaseButton>

    <ul class="carousel__items" ref="carousel">
      <li v-for="image in images" :key="image.id">
        <UIBaseButton type="button" class="carousel__button">
          <img :src="image.src" :alt="image.title" class="carousel__item" />
        </UIBaseButton>
      </li>
    </ul>
  </div>
</template>

<style scoped lang="scss">
.carousel {
  width: 100%;
  overflow: hidden;
  height: 17.125rem;
  position: relative;
  padding-left: 3rem;
  padding-right: 3rem;

  &__control {
    cursor: pointer;
    position: absolute;
    z-index: 10;
    height: 3rem;
    width: 3rem;
    top: 50%;
    display: flex;
    justify-content: center;
    align-items: center;
    transform: translateY(-50%);

    &:hover {
      opacity: 0.6;
    }

    &_left {
      left: 0;
    }

    &_right {
      right: 0;
    }
  }

  &__icon {
    width: 0.875rem;
    height: 1.5rem;
    mask-size: contain;
    mask-repeat: no-repeat;
    background-color: $orange;

    &_left {
      mask-image: url("data:image/svg+xml,%3Csvg width='7' height='12' viewBox='0 0 7 12' fill='none' xmlns='http://www.w3.org/2000/svg'%3E%3Cpath d='M6 11L1 6L6 1' stroke='currentColor' stroke-width='2' stroke-linecap='round' stroke-linejoin='round'/%3E%3C/svg%3E");
    }

    &_right {
      mask-image: url("data:image/svg+xml,%3Csvg width='7' height='12' viewBox='0 0 7 12' fill='none' xmlns='http://www.w3.org/2000/svg'%3E%3Cpath d='M1 11L6 6L1 1' stroke='currentColor' stroke-width='2' stroke-linecap='round' stroke-linejoin='round'/%3E%3C/svg%3E");
    }
  }

  &__items {
    cursor: pointer;
    display: flex;
    flex-wrap: nowrap;
    overflow-x: scroll;
    overflow-y: hidden;
    user-select: none;
    scrollbar-width: none;
    padding-top: 0.75rem;
  }

  &__button {
    outline: 0;
  }

  &__item {
    padding: 0.1875rem;
    border-radius: 1.0625rem;
    min-width: 12.7rem;
    user-select: none;
    -webkit-user-drag: none;
  }
}
</style>
