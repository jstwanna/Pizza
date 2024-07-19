<script setup lang="ts">
import type { Images } from '../models/models';

interface Props {
  isMan?: boolean;
  images: Images;
}

withDefaults(defineProps<Props>(), {
  isMan: false,
});

const imagesContainerRef = ref<HTMLElement | null>(null);
const imageRefs = ref<HTMLImageElement[]>([]);

const setImageRef = (el: HTMLImageElement) => {
  if (el) {
    imageRefs.value.push(el);
  }
};

const handleScroll = () => {
  if (!imagesContainerRef.value) return;

  const halfScreenHeight = window.innerHeight / 1.25;
  const containerTop = imagesContainerRef.value.getBoundingClientRect().top;

  imageRefs.value.forEach((img) => {
    if (img && containerTop < halfScreenHeight) {
      img.classList.add('testimonial-images__image_type_animate');
    }
  });
};

onMounted(() => {
  nextTick(() => {
    window.addEventListener('scroll', handleScroll);
    handleScroll();
  });
});

onBeforeUnmount(() => {
  window.removeEventListener('scroll', handleScroll);
});
</script>

<template>
  <div
    :class="['testimonial-images', { 'testimonial-images_type_man': isMan }]"
    ref="imagesContainerRef"
  >
    <img
      v-for="image in images.images"
      :src="image.src"
      :key="image.id"
      :alt="image.title"
      :ref="(el) => setImageRef(el as HTMLImageElement)"
      :class="[
        'testimonial-images__image',
        { 'testimonial-images__image_type_man': image.id === 1 },
      ]"
    />
  </div>
</template>

<style scoped lang="scss">
.testimonial-images {
  position: relative;

  &_type {
    &_man {
      bottom: -1.875rem;
      padding-bottom: 8%;
      margin-bottom: -6%;
    }
  }

  &__image {
    width: 30%;
    position: absolute;
    right: 0;
    opacity: 0;
    bottom: 0.9375rem;
    transform: translate(0, -15%);
    transition: transform 0.45s cubic-bezier(0.6, 0.2, 0.1, 1) 0s,
      opacity 0.5s cubic-bezier(0.6, 0.2, 0.1, 1) 0s;

    &_type {
      &_man {
        transform: translate(-15%, 0);
      }

      &_animate {
        transform: translate(0, 0);
        opacity: 1;
      }
    }
  }
}
</style>
