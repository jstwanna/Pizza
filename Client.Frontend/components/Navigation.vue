<script lang="ts" setup>
import smallLogo from '../assets/svg/smallLogo.svg';
import emptyCart from '../assets/svg/empty-cart.svg';
import coin from '/coin.svg';
import right from '../assets/svg/right.svg';
import bottom from '../assets/svg/bottom.svg';

import BaseButton from './UI/BaseButton.vue';

import { headerLinks } from '../utils/constants';
import {
  getTotalCount,
  isCartNotEmpty,
  cartItems,
  getTotalPrice,
  calculateBonusPoints,
} from '../utils/cartHelper';
import type { AdditiveListView } from '../api/api-generated';
import { formatNumber, pluralizeWord } from '../utils/utils';
import type { Link } from '~/models/models';

const shadow = ref<boolean>(false);
const isCartOpen = ref<boolean>(false);
const isDropdownOpen = ref<boolean>(false);
const visibleLinks = ref<Link[]>([]);
const hiddenLinks = ref<Link[]>([]);
const dropdownRef = ref<HTMLElement | null>(null);
const dropdownButtonRef = ref<HTMLElement | null>(null);

const handleShadow = () => {
  shadow.value = window.scrollY >= 165;
};

const handleClickToTop = () => {
  window.scrollTo({ top: 0 });
};

const toggleCartPopup = () => {
  isCartOpen.value = !isCartOpen.value;
};

const handleRemoveProduct = (id: number, additives: AdditiveListView[]) => {
  cartItems.value = cartItems.value.filter(
    (cartItem) =>
      cartItem.item.id !== id ||
      cartItem.additives.length !== additives.length ||
      !cartItem.additives.every((cartAdditive) =>
        additives.some((additive) => additive.id === cartAdditive.id)
      )
  );
};

const findCartItem = (id: number, additives: AdditiveListView[]) => {
  return cartItems.value.find(
    (item) =>
      item.item.id === id &&
      item.additives.length === additives.length &&
      item.additives.every((cartAdditive) =>
        additives.some((additive) => additive.id === cartAdditive.id)
      )
  );
};

const handleIncrementCount = (id: number, additives: AdditiveListView[]) => {
  const product = findCartItem(id, additives);
  if (product) product.count++;
};

const handleDecrementCount = (id: number, additives: AdditiveListView[]) => {
  const product = findCartItem(id, additives);
  if (product) {
    product.count > 1 ? product.count-- : handleRemoveProduct(id, additives);
  }
};

const formatPrice = computed(() => formatNumber(getTotalPrice.value));

const toggleDropdown = () => {
  isDropdownOpen.value = !isDropdownOpen.value;
};

const updateLinks = () => {
  if (window.innerWidth < 1280) {
    visibleLinks.value = headerLinks.slice(0, -3);
    hiddenLinks.value = headerLinks.slice(-3);
  } else {
    visibleLinks.value = headerLinks;
    hiddenLinks.value = [];
  }
};

const handleClickOutside = (event: MouseEvent) => {
  if (
    dropdownRef.value &&
    !dropdownRef.value.contains(event.target as Node) &&
    dropdownButtonRef.value &&
    !dropdownButtonRef.value.contains(event.target as Node)
  ) {
    isDropdownOpen.value = false;
  }
};

onMounted(() => {
  window.addEventListener('scroll', handleShadow);
  window.addEventListener('resize', updateLinks);

  document.addEventListener('click', handleClickOutside);

  updateLinks();
});

onUnmounted(() => {
  window.removeEventListener('scroll', handleShadow);
  window.removeEventListener('resize', updateLinks);

  document.removeEventListener('click', handleClickOutside);
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
            v-for="link in visibleLinks"
            :key="link.id"
            class="navigation__link-container"
          >
            <UIBaseLink :to="link.to">
              {{ link.title }}
            </UIBaseLink>
          </li>

          <li
            v-if="hiddenLinks.length"
            class="navigation__link-container navigation__link-container_more"
          >
            <div
              class="navigation__more"
              @click="toggleDropdown"
              ref="dropdownButtonRef"
            >
              <span>Ещё</span>
              <img
                :src="bottom"
                alt="Стрелка вниз"
                class="navigation__more-icon"
              />
              <ul
                v-if="isDropdownOpen"
                class="navigation__dropdown"
                ref="dropdownRef"
              >
                <li v-for="link in hiddenLinks" :key="link.id">
                  <UIBaseLink :to="link.to" class="navigation__dropdown-item">
                    {{ link.title }}
                  </UIBaseLink>
                </li>
              </ul>
            </div>
          </li>

          <li class="navigation__link-container">
            <UIBaseLink to="#">Акции</UIBaseLink>
          </li>
        </ul>
      </nav>

      <UIBaseButton
        type="button"
        class="navigation__cart"
        @click="toggleCartPopup"
      >
        Корзина
        <template v-if="isCartNotEmpty">
          <div class="navigation__cart-line"></div>
          {{ getTotalCount }}
        </template>
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
        <div v-if="isCartNotEmpty" class="cart-popup__main">
          <h3 class="cart-popup__title">
            {{ getTotalCount }}
            {{ pluralizeWord(getTotalCount, ['товар', 'товара', 'товаров']) }}
            {{ `на ${formatPrice} ₽` }}
          </h3>
          <div class="cart-popup__products">
            <CartBlock
              v-for="cart in cartItems"
              :key="cart.item.id"
              :item="cart"
              @remove="handleRemoveProduct"
              @increment="handleIncrementCount"
              @decrement="handleDecrementCount"
            />
          </div>
          <div class="cart-popup__bottom-content">
            <div class="cart-popup__subtotal">
              <span>
                {{ getTotalCount }}
                {{
                  pluralizeWord(getTotalCount, ['товар', 'товара', 'товаров'])
                }}
              </span>
              <span>{{ formatPrice }} ₽</span>
            </div>
            <div class="cart-popup__subtotal cart-popup__subtotal_coin">
              <span>Начислим додокоины</span>
              <span style="display: flex">
                + {{ calculateBonusPoints(getTotalPrice) }}
                <img
                  :src="coin"
                  alt="Додо коин фото"
                  style="
                    height: 0.875rem;
                    width: 0.875rem;
                    padding-left: 0.125rem;
                  "
                />
              </span>
            </div>
            <div class="cart-popup__total">
              <span>Сумма заказа</span>
              <span>{{ formatPrice }} ₽</span>
            </div>
            <BaseButton type="button" class="cart-popup__button">
              К оформлению заказа
              <img :src="right" alt="Иконка направо" class="cart-popup__icon" />
            </BaseButton>
          </div>
        </div>
        <div class="cart-popup__empty" v-else>
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
    @include responsive-width;
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

    &_more {
      height: min-content;
      padding-top: 1rem;
      padding-bottom: 0;
      display: flex;
      align-items: center;
      position: relative;

      &::after {
        content: '•';
        margin-left: 0.75rem;
      }
    }
  }

  &__more {
    display: flex;
    background-color: $gray;
    border-radius: 2.5rem;
    padding: 0.4375rem 0.75rem;
    align-items: center;
    cursor: pointer;
  }

  &__dropdown {
    position: absolute;
    margin-top: 0.5rem;
    padding-top: 0.25rem;
    padding-bottom: 0.25rem;
    top: 100%;
    left: 0;
    background: $white;
    border-radius: 0.5rem;
    z-index: 10;
    box-shadow: $black-100 0 -0.125rem 0.25rem;
    width: 10rem;
  }

  &__dropdown-item {
    display: block;
    padding: 0.5rem;

    &:hover {
      background-color: $gray;
    }
  }

  &__more-icon {
    margin-left: 0.375rem;
  }

  & &__link {
    color: $black;
    text-decoration: none;
    @include transition;

    &:hover {
      color: $orange;
    }
  }

  &__cart {
    display: flex;
    align-items: center;
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

  &__cart-line {
    height: 1.5rem;
    width: 0.0625rem;
    margin: 0 0.75rem;
    background: $white;
    opacity: 0.4;
  }
}

.cart-popup {
  &__sticky-footer {
    position: sticky;
    bottom: 0;
    background-color: $white;
    padding: 1rem 1.5rem;
    box-shadow: $black-100 0 -0.125rem 0.25rem;
    z-index: 100;
  }

  &__content {
    width: 26.875rem;
    height: 100%;
    background-color: $gray;
  }

  &__products {
    display: flex;
    flex-direction: column;
  }

  &__main {
    overflow-y: scroll;
    display: flex;
    flex-direction: column;
    height: 100%;
    @include scrollbar;
  }

  &__title {
    font-weight: $fw-medium;
    font-size: $fs-2xl;
    line-height: 1.75rem;
    margin-top: 1.5rem;
    margin-bottom: 1.25rem;
    padding-left: 1rem;
    padding-right: 1rem;
  }

  &__bottom-content {
    margin-top: auto;
    background-color: $white;
    box-shadow: $black-100 0 -0.125rem 0.25rem;
    padding: 1rem 1.5rem 1.5rem;
  }

  &__subtotal {
    font-weight: $fw-semibold;
    display: flex;
    justify-content: space-between;
    font-size: $fs-xs;
    line-height: 0.875rem;

    &_coin {
      margin-top: 0.5rem;
      border-bottom: 0.0625rem solid hsl(240, 14%, 90%);
      padding-bottom: 1rem;
      margin-bottom: 1rem;
    }
  }

  &__total {
    display: flex;
    justify-content: space-between;
    font-size: $fs-base;
    font-weight: $fw-semibold;
    line-height: 1.25rem;
  }

  &__button {
    position: relative;
    width: 100%;
    margin-top: 1rem;
    padding: 0.75rem 3.375rem 0.75rem 3rem;
    background-color: $orange;
    color: $white;
    line-height: 1.5rem;

    &:hover {
      background-color: $dark-orange;
    }
  }

  &__icon {
    position: absolute;
    right: 0.5rem;
    top: calc(50% - 0.8125rem);
  }

  &__empty {
    padding: 1.875rem;
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
