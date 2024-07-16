<script lang="ts" setup>
import { headerMenuItems } from '../utils/constants';

const handleClickLoyalty = () => {
  console.log('aaa');
};
</script>

<template>
  <header class="header">
    <ul class="header__wrapper">
      <li v-for="link in headerMenuItems" :key="link.id">
        <UIBaseLink :to="link.to" activeClass="header__link_active">{{
          link.title
        }}</UIBaseLink>
      </li>
    </ul>

    <div class="header__info-container">
      <div class="header__info">
        <div>
          <UIBaseLink to="/">
            <img
              src="/headerLogo.svg"
              alt="Лого пиццы додо"
              class="header__logo"
            />
          </UIBaseLink>
          <div class="header__statistic">
            <div>Сеть №1 в России</div>
            <UIBaseLink
              to="https://docs.google.com/document/d/1OqaMef63wANPbsGCE8RD5QW9ve8Z7QBE/edit"
              target="_blank"
              class="header__statistic-link"
            >
              по количеству пиццерий
            </UIBaseLink>
          </div>
        </div>

        <div>
          <h1 class="header__delivery">
            Доставка пиццы
            <UIBaseButton type="button" class="header__button">
              Москва
            </UIBaseButton>
          </h1>
          <div class="header__stars">
            31 мин
            <span class="header__dot"></span>
            4.81
            <svg
              xmlns="http://www.w3.org/2000/svg"
              width="16"
              height="16"
              fill="none"
              viewBox="0 0 16 16"
              class="header__star-icon"
            >
              <defs>
                <linearGradient id="3b64717f-ee07-4c0a-ad59-1d94c88b4b10a">
                  <stop offset="50%" stop-color="#FFD200"></stop>
                  <stop
                    offset="50%"
                    stop-color="#999"
                    stop-opacity="0.5"
                  ></stop>
                </linearGradient>
              </defs>
              <path
                fill="url(#3b64717f-ee07-4c0a-ad59-1d94c88b4b10a)"
                d="M8.451 1.49a1 1 0 0 0-.902 0c-.245.123-.378.359-.461.528-.09.182-.185.427-.296.712l-.928 2.39a3 3 0 0 1-.07.173v.002H5.79c-.036.006-.086.01-.184.02l-2.504.214c-.272.024-.51.044-.695.077-.176.032-.418.09-.6.274a1 1 0 0 0-.28.826c.03.256.186.45.307.583.126.139.302.3.503.485l1.987 1.823.125.118.002.002v.003c-.006.033-.016.079-.036.168l-.592 2.66a9 9 0 0 0-.145.73c-.024.184-.042.445.087.68a1 1 0 0 0 .733.508c.265.038.504-.072.667-.16a9 9 0 0 0 .632-.392l2.036-1.332c.086-.056.13-.085.164-.104L8 12.476l.003.002c.033.019.078.048.164.104l2.036 1.332c.246.161.458.3.632.393.163.087.401.197.667.159a1 1 0 0 0 .733-.508c.13-.235.11-.496.087-.68a9 9 0 0 0-.145-.73l-.592-2.66c-.02-.09-.03-.135-.035-.168v-.003l.001-.002.125-.118 1.987-1.823c.201-.185.377-.346.503-.485.12-.133.276-.327.308-.583a1 1 0 0 0-.281-.826c-.182-.183-.424-.242-.6-.274-.185-.033-.423-.053-.695-.077l-2.504-.215a3 3 0 0 1-.184-.018h-.003l-.002-.003a3 3 0 0 1-.069-.172l-.928-2.39a10 10 0 0 0-.296-.713c-.083-.17-.216-.405-.46-.529"
              ></path>
            </svg>
          </div>
        </div>
      </div>

      <div class="header__profile">
        <UIBaseButton
          type="button"
          class="header__loyalty"
          @click="handleClickLoyalty"
        >
          <span class="header__coin"></span>
          <span class="header__dodo-coins">Додокоины</span>
        </UIBaseButton>
        <UIBaseButton type="button" class="header__sign-in">
          Войти
        </UIBaseButton>
      </div>
    </div>
  </header>

  <Navigation />
</template>

<style lang="scss" scoped>
.header {
  position: relative;

  &__link {
    &_active {
      color: $orange;
    }
  }

  &__wrapper {
    height: 3.25rem;
    padding: 0.75rem calc(50% - 40rem);
    border-bottom: 0.0625rem solid $gray;
    display: flex;
    align-items: center;
    gap: 1.25rem;
  }

  &__info-container {
    max-width: 80rem;
    display: flex;
    justify-content: space-between;
    padding: 1.5rem 0 1rem;
    margin-left: auto;
    margin-right: auto;
  }

  &__info {
    display: flex;
    column-gap: 2.5rem;
  }

  &__logo {
    @include transition;
    cursor: pointer;

    &:hover {
      opacity: 0.7;
    }
  }

  &__statistic {
    font-weight: $fw-semibold;
    font-size: $fs-xs;
    line-height: 0.875rem;
    margin-left: 3.0625rem;
  }

  &__statistic-link {
    color: $orange;
    text-decoration: none;
    @include transition;

    &:hover {
      color: $dark-orange;
    }
  }

  &__delivery {
    font-size: $fs-lg;
    font-weight: $fw-medium;
    line-height: 1.2;
  }

  &__button {
    color: $orange;

    &:hover {
      color: $dark-orange;
    }
  }

  &__stars {
    font-size: $fs-base - 0.0625rem;
    font-weight: $fw-medium;
    margin-top: 0.0625rem;
  }

  &__modal-container {
    position: relative;
    display: inline-block;
  }

  &__dot {
    display: inline-block;
    width: 0.1875rem;
    height: 0.1875rem;
    margin: 0.1875rem 0.375rem;
    border-radius: 0.1875rem;
    background-color: $black;
  }

  &__star-icon {
    margin-bottom: -0.125rem;

    & > path {
      fill: $yellow;
    }
  }

  &__profile {
    display: flex;
    align-items: center;
    gap: 2rem;
  }

  &__loyalty {
    position: relative;
    display: flex;
    align-items: center;
    flex-direction: column;
    cursor: pointer;

    &:hover {
      .header__coin {
        background-color: $orange;
        transform: translateY(-0.25rem);
      }

      .header__dodo-coins {
        color: $orange;
      }
    }
  }

  &__coin {
    @include transition(150ms, ease);
    background-color: $black;
    mask-image: url('/coin.svg');
    height: 1.75rem;
    width: 1.75rem;
  }

  &__dodo-coins {
    @include transition(150ms, ease);
    font-size: $fs-sm;
    font-weight: $fw-semibold;
    white-space: nowrap;
    line-height: 1.125rem;
  }

  &__sign-in {
    background-color: $gray;
    color: $dark-gray;
    font-size: $fs-sm;
    line-height: 1rem;
    height: 2rem;
    padding: 0.5rem 1rem;

    &:hover {
      color: $black;
    }
  }
}
</style>
