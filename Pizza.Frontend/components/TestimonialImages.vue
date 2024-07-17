<script setup lang="ts">
import type { Images } from '../models/models';

interface Props {
  isMan?: boolean;
  images: Images;
}

withDefaults(defineProps<Props>(), {
  isMan: false,
});
</script>

<template>
  <div
    :class="['testimonial-images', { 'testimonial-images_type_man': isMan }]"
  >
    <img
      v-for="image in images.images"
      :src="image.src"
      :key="image.id"
      :alt="image.title"
      class="testimonial-images__image"
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
    bottom: 0.9375rem;
  }
}
</style>
