<script lang="ts" setup>
import smallLogo from '../assets/svg/smallLogo.svg';

import { headerLinks } from '../utils/constants';

const shadow = ref<boolean>(false);

const handleShadow = () => {
  shadow.value = window.scrollY >= 165;
};

const route = useRoute();
const isActive = (to: string) => route.hash === to;

const handleClickToTop = () => {
  window.scrollTo({ top: 0 });
};

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
      <Transition name="slide">
        <div
          class="navigation__logo-container"
          v-if="shadow"
          @click="handleClickToTop"
        >
          <img :src="smallLogo" alt="Лого додо" class="navigation__logo" />
        </div>
      </Transition>

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
          <UIBaseLink to="#">Акции</UIBaseLink>
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
    overflow: hidden;
    display: flex;
    align-items: center;
    max-width: 80rem;
    margin-left: auto;
    margin-right: auto;
  }

  &__logo-container {
    display: inline-block;
    position: relative;
    vertical-align: middle;
    overflow: hidden;
    width: 3.25rem;
    height: 2.25rem;
    padding-right: 1rem;
  }

  &__links {
    display: flex;
    column-gap: 1.25rem;
    margin-right: auto;
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

.slide-enter-active,
.slide-leave-active {
  @include transition(0.25s, ease);
}

.slide-enter,
.slide-leave-to {
  transform: translateX(-3.25rem);
}

.slide-enter-from,
.slide-leave {
  transform: translateX(-3.25rem);
}
</style>
