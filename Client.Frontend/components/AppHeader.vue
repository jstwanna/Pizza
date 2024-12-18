<script lang="ts" setup>
import type { IUser } from '../models/models';
import { user, isUserLoggedIn, isLoginPopup } from '../utils/userHelper';
import { headerMenuItems, userMenuItems } from '../utils/constants';

const input = ref<HTMLInputElement | null>(null);

const userPhone = ref<string>('');
const rawPhone = ref<string>('');

const router = useRouter();

const resetPhone = () => {
  userPhone.value = '';
  rawPhone.value = '';
};

const handleOpenPopup = () => {
  isLoginPopup.value = !isLoginPopup.value;
  resetPhone();
};

const formatPhoneNumber = (phone: string): string => {
  const mainPart = phone.slice(1);
  return `+7 ${mainPart.slice(0, 3)}${
    mainPart.length > 3 ? ' ' : ''
  }${mainPart.slice(3, 6)}${mainPart.length > 6 ? '-' : ''}${mainPart.slice(
    6,
    8
  )}${mainPart.length > 8 ? '-' : ''}${mainPart.slice(8)}`.trim();
};

const handlePhoneInput = (event: Event) => {
  const input = event.target as HTMLInputElement;
  let value = input.value.replace(/\D/g, '');

  if (!value) {
    resetPhone();
    return;
  }

  value = value.startsWith('7') ? value : `7${value}`;
  value = value.slice(0, 11);

  rawPhone.value = value;

  userPhone.value = formatPhoneNumber(value);
};

const onLogin = async () => {
  try {
    await $fetch('/api/identity/client/LoginClient', {
      method: 'POST',
      body: {
        phone: rawPhone.value,
      },
    });

    const loginTimestamp = Date.now();
    localStorage.setItem('login-timestamp', loginTimestamp.toString());

    const userInfo = await $fetch<IUser>('/api/identity/base/GetUserInfo', {
      method: 'POST',
    });

    localStorage.setItem('user', JSON.stringify(userInfo));

    user.value = userInfo;
    isUserLoggedIn.value = true;
    router.push('/');
  } catch {
    console.error('Login error');
  } finally {
    isLoginPopup.value = false;
  }
};

const isPhoneComplete = computed(() => rawPhone.value.length === 11);

const filteredUserMenuItems = computed(() => {
  if (!isUserLoggedIn.value) {
    return userMenuItems.filter((item) => item.id === 1);
  }
  return userMenuItems;
});

watch(isLoginPopup, () => {
  if (isLoginPopup.value) {
    nextTick(() => {
      input.value?.focus();
    });
  }
});
</script>

<template>
  <header class="header">
    <ul class="header__wrapper">
      <li v-for="link in headerMenuItems" :key="link.id">
        <UIBaseLink :to="link.to" activeClass="header__link_active">
          {{ link.title }}
        </UIBaseLink>
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
        <UIBaseLink
          :to="link.link"
          class="header__profile-item"
          v-for="link in filteredUserMenuItems"
          :key="link.id"
        >
          <span
            :class="`header__profile-image header__profile-image_${link.type}`"
          ></span>
          <span class="header__profile-description">{{ link.title }}</span>
        </UIBaseLink>
        <UIBaseButton
          type="button"
          class="header__sign-in"
          @click="handleOpenPopup"
          v-if="!isUserLoggedIn"
        >
          Войти
        </UIBaseButton>
      </div>
    </div>
  </header>

  <Navigation />

  <UIBasePopup
    v-model="isLoginPopup"
    @close-popup="handleOpenPopup"
    customClass="popup-login"
    :index="50"
  >
    <template #content>
      <div class="popup-login__content">
        <h3 class="popup-login__title">Вход на сайт</h3>
        <p class="popup-login__text">
          Подарим подарок на день рождения, сохраним адрес доставки и расскажем
          об акциях
        </p>
        <form @submit.prevent="onLogin" novalidate class="popup-login__form">
          <span class="popup-login__input-label">Номер телефона</span>
          <input
            type="tel"
            v-model="userPhone"
            placeholder="+7 999 999-99-99"
            @input="handlePhoneInput"
            ref="input"
            class="popup-login__input"
          />
          <UIBaseButton
            type="submit"
            :disabled="!isPhoneComplete"
            class="popup-login__button"
          >
            Выслать код
          </UIBaseButton>
        </form>
        <div class="popup-login__warning">
          Продолжая, вы соглашаетесь
          <UIBaseLink to="#" class="popup-login__legal">
            со сбором и обработкой персональных данных и пользовательским
            соглашением
          </UIBaseLink>
        </div>
      </div>
    </template>
  </UIBasePopup>
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
    margin-left: 0.25rem;
    margin-right: 0.25rem;

    @media screen and (max-width: 80rem) {
      padding: 0.75rem calc(50% - 30rem);
    }
  }

  &__info-container {
    @include container;
    @include responsive-width;
    display: flex;
    justify-content: space-between;
    padding-top: 1.5rem;
    padding-bottom: 1rem;
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
    font-size: $fs-xs;
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

  &__profile-item {
    position: relative;
    display: flex;
    align-items: center;
    flex-direction: column;
    cursor: pointer;

    &:hover {
      .header__profile-image {
        background-color: $orange;
        transform: translateY(-0.25rem);
      }

      .header__profile-description {
        color: $orange;
      }
    }
  }

  &__profile-image {
    @include transition($duration: 150ms, $timing-function: ease);
    background-color: $black;
    height: 1.75rem;
    width: 1.75rem;

    &_coin {
      mask-image: url('/coin.svg');
    }

    &_bonus {
      mask-image: url('/bonus.svg');
    }

    &_profile {
      mask-image: url('/profile.svg');
    }
  }

  &__profile-description {
    @include transition($duration: 150ms, $timing-function: ease);
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

.popup-login {
  &__content {
    padding: 2rem;
    display: flex;
    flex-direction: column;
    min-height: 24.9375rem;
    width: 25.5625rem;
  }

  &__title {
    margin: 0 0 0.5rem;
    font-size: $fs-4xl;
    font-weight: $fw-medium;
    line-height: 2.25rem;
  }

  &__text {
    font-weight: 600;
    line-height: 1.25rem;
    color: $dark-gray;
    margin: 0 0 1.5rem;
  }

  &__input-label {
    margin-bottom: 0.5rem;
    font-weight: $fw-medium;
    font-size: $fs-sm;
    line-height: 1.125rem;
    color: $dark-gray;
    display: block;
  }

  &__input {
    text-align: left;
    display: block;
    outline: none;
    box-shadow: none;
    appearance: none;
    position: relative;
    height: 3.5rem;
    padding: 0.875rem 1rem;
    border-radius: 0.75rem;
    width: 100%;
    border: 0.0625rem solid hsl(240, 14%, 90%);
    resize: none;
    font-size: $fs-base;
    line-height: 1.25rem;
    font-weight: $fw-medium;
    @include transition(all, 100ms, ease-out);

    &:focus {
      border-color: $orange;
    }

    &::placeholder {
      color: hsl(232, 10%, 70%);
    }
  }

  &__button {
    height: 3rem;
    padding: 0.75rem 1.5rem;
    font-size: $fs-base;
    line-height: 1.5rem;
    margin-top: 2.3125rem;
    background-color: $orange;
    color: $white;
    width: 100%;

    &:hover {
      background-color: $dark-orange;
    }

    &:disabled {
      opacity: 0.6;
      cursor: not-allowed;
      background-color: $orange;
    }
  }

  &__warning {
    font-size: $fs-xs;
    line-height: 1rem;
    color: $dark-gray;
    text-align: center;
    margin-top: 0.5rem;
  }

  &__legal {
    font-size: $fs-xs;
    color: $orange;
  }
}
</style>
