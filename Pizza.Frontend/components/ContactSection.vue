<script setup lang="ts">
import type { ContactLink } from '../models/models';

defineProps<{ contact: ContactLink }>();
</script>

<template>
  <div class="contact-section">
    <h2 class="contact-section__title">{{ contact.title }}</h2>
    <UIBaseLink
      v-for="item in contact.links"
      :key="item.id"
      :to="item.to"
      :target="item.name === 'О нас' ? '_self' : '_blank'"
      class="contact-section__link"
    >
      {{ item.name }}
    </UIBaseLink>
  </div>
</template>

<style scoped lang="scss">
.contact-section {
  display: flex;
  flex-direction: column;
  min-width: 8.125rem;
  margin-right: 3.75rem;
  margin-bottom: 3.125rem;

  &__title {
    color: $white;
    font-size: $fs-base;
    font-weight: $fw-medium;
    letter-spacing: 0.0063rem;
    margin-bottom: 0.4375rem;
  }

  &__link {
    margin-bottom: 0.5625rem;
    font-size: $fs-base;
    line-height: 1.2;
    color: $white;
    opacity: 0.7;

    &:hover {
      color: $white;
      opacity: 1;
    }
  }
}
</style>
