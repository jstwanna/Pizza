<script lang="ts" setup>
import { headerLinks } from '../utils/constants';

const shadow = ref<boolean>(false);

const handleShadow = () => {
  shadow.value = window.scrollY >= 165;
};

const route = useRoute();
const isActive = (to: string) => route.path === to;

onMounted(() => {
  window.addEventListener('scroll', handleShadow);
});

onUnmounted(() => {
  window.removeEventListener('scroll', handleShadow);
});
</script>

<template>
  <div :class="['navigation', { navigation_shadow: shadow }]">
    <nav class="navigation__menu">
      <ul class="navigation__links">
        <li
          v-for="link in headerLinks"
          :key="link.id"
          class="navigation__link-container"
        >
          <a
            :href="link.to"
            :class="[
              'navigation__link',
              { navigation__link_active: isActive(link.to) },
            ]"
          >
            {{ link.title }}
          </a>
        </li>
        <li class="navigation__link-container">
          <UIBaseLink to="/bonus">Акции</UIBaseLink>
        </li>
      </ul>
      <UIBaseButton type="button" class="navigation__basket">
        Корзина
      </UIBaseButton>
    </nav>
  </div>
</template>

<style lang="scss" scoped>
.navigation {
  position: sticky;
  top: 0;
  background-color: $light-white;
  z-index: 10;
  backdrop-filter: blur(1.25rem);

  &_shadow {
    box-shadow: $black-100 0 0.25rem 1.875rem;
  }

  &__menu {
    display: flex;
    justify-content: space-between;
    align-items: center;
    max-width: 80rem;
    margin-left: auto;
    margin-right: auto;
  }

  &__links {
    display: flex;
    column-gap: 1.25rem;
  }

  &__link-container {
    line-height: 1;
    font-size: $fs-sm;
    font-weight: $fw-semibold;
    padding-top: 1.375rem;
    padding-bottom: 1.375rem;
  }

  &__link {
    color: $black;
    text-decoration: none;
    @include transition;

    &:hover,
    &_active {
      color: $orange;
    }
  }
  &__basket {
    color: $white;
    line-height: 1.5rem;
    height: 2.5rem;
    padding: 0.5rem 1.25rem;
    background-color: $orange;

    &:hover {
      background-color: $dark-orange;
    }
  }
}
</style>
