<script lang="ts" setup>
import smallLogo from '../assets/svg/smallLogo.svg';
import emptyCart from '../assets/svg/empty-cart.svg';

import { headerLinks } from '../utils/constants';

const shadow = ref<boolean>(false);

const isCartOpen = ref<boolean>(false);

const handleShadow = () => {
  shadow.value = window.scrollY >= 165;
};

const handleClickToTop = () => {
  window.scrollTo({ top: 0 });
};

const toggleCartPopup = () => {
  isCartOpen.value = !isCartOpen.value;
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
    <div class="navigation__menu">
      <div class="navigation__logo-container" @click="handleClickToTop">
        <img
          :src="smallLogo"
          alt="Лого додо"
          class="navigation__logo"
          :class="{ navigation__logo_shifted: shadow }"
        />
      </div>

      <nav
        class="navigation__links-container"
        :class="{ 'navigation__links-container_shifted': shadow }"
      >
        <ul class="navigation__links">
          <li
            v-for="link in headerLinks"
            :key="link.id"
            class="navigation__link-container"
          >
            <UIBaseLink :to="link.to">
              {{ link.title }}
            </UIBaseLink>
          </li>
        </ul>
      </nav>

      <UIBaseButton
        type="button"
        class="navigation__basket"
        @click="toggleCartPopup"
      >
        Корзина
      </UIBaseButton>
    </div>
  </div>

  <UIBasePopup
    v-model="isCartOpen"
    @closePopup="toggleCartPopup"
    closePosition="left"
    customClass="cart-popup"
  >
    <template #content>
      <div class="cart-popup__content">
        <div class="cart-popup__empty">
          <img
            :src="emptyCart"
            alt="Картинка пустой пиццы и сиба-ину"
            class="cart-popup__empty-img"
          />
          <h2 class="cart-popup__empty-title">Пока тут пусто</h2>
          <p class="cart-popup__empty-text">
            Добавьте пиццу. Или две! А мы доставим ваш заказ от 649₽
          </p>
        </div>
      </div>
    </template>
  </UIBasePopup>
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
    position: relative;
    display: flex;
    align-items: center;
    @include container;
  }

  &__logo-container {
    cursor: pointer;
    display: inline-block;
    vertical-align: middle;
    overflow: hidden;
    position: relative;
    width: 3.25rem;
    padding-right: 1rem;
    height: 2.25rem;
    @include transition;

    &:hover {
      opacity: 0.7;
    }
  }

  &__logo {
    transform: translateX(-3.25rem);
    @include transition(transform, 0.25s, ease);

    &_shifted {
      transform: translateX(0);
    }
  }

  &__links-container {
    display: inline-flex;
    align-items: center;
    transform: translateX(-3.25rem);
    @include transition(transform, 0.25s, ease);

    &_shifted {
      transform: translateX(0);
    }
  }

  &__links {
    white-space: nowrap;
    display: flex;
    gap: 1.25rem;
    vertical-align: middle;
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

    &:hover {
      color: $orange;
    }
  }

  &__basket-container {
    position: absolute;
    right: 0;
    top: 0;
    height: 100%;
  }

  &__basket {
    margin-left: auto;
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

.cart-popup {
  &__content {
    width: 26.875rem;
    height: 100%;
    background-color: $white;
    padding: 1.875rem;
  }

  &__empty {
    display: flex;
    flex-flow: column;
    align-items: center;
    justify-content: center;
    height: 100%;
  }

  &__empty-img {
    max-width: 19.625rem;
    width: 100%;
    padding: 0.25rem;
  }

  &__empty-title {
    font-size: $fs-xl;
    margin-top: 1.0625rem;
    margin-bottom: 1.0625rem;
    font-weight: $fw-semibold;
  }

  &__empty-text {
    max-width: 13.375rem;
    font-size: $fs-sm;
    white-space: pre-wrap;
    text-align: center;
    font-weight: $fw-medium;
  }
}
</style>
