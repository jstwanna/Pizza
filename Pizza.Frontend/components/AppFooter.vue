<script lang="ts" setup>
import dodo from '../assets/svg/dodo.svg';

import {
  contactLinks,
  mobileApps,
  statsFooter,
  footerLinks,
  socialLinks,
} from '../utils/constants';

const currentYear = computed(() => new Date().getFullYear());
</script>

<template>
  <SecretBuyerBlock />

  <footer class="footer">
    <div class="footer__container">
      <div class="footer__contacts">
        <div class="footer__navigation-links">
          <ContactSection
            v-for="contact in contactLinks"
            :contact="contact"
            :key="contact.id"
          />
        </div>
        <div class="footer__download">
          <div class="footer__mobile-apps">
            <UIBaseLink
              v-for="mobile in mobileApps"
              :key="mobile.id"
              :to="mobile.to"
              class="footer__mobile-icon"
            >
              <img :src="mobile.src" :alt="mobile.title" class="" />
            </UIBaseLink>
          </div>
          <UIBaseLink to="mailto:feedback@dodopizza.com" class="footer__link">
            feedback@dodopizza.com
          </UIBaseLink>
        </div>
      </div>

      <div class="footer__stats">
        <div class="footer__stat" v-for="stat in statsFooter" :key="stat.id">
          <span class="footer__stat-title">{{ stat.title }}</span>
          <p class="footer__stat-text">{{ stat.text }}</p>
        </div>
      </div>

      <div class="footer__copyright">
        <div class="footer__wrapper">
          <img :src="dodo" alt="Лого Дода Пицца" class="footer__logo" />
          <span class="footer__date">© {{ currentYear }}</span>
        </div>
        <div class="footer__info">
          <UIBaseLink
            v-for="link in footerLinks"
            :key="link.id"
            :to="link.to"
            class="footer__link footer__link_type_info"
            :target="
              link.title === 'Калорийность и состав' ? '_blank' : '_self'
            "
          >
            {{ link.title }}
          </UIBaseLink>
        </div>
        <div class="footer__social">
          <UIBaseLink
            v-for="social in socialLinks"
            :key="social.id"
            :to="social.to"
            target="_blank"
            class="footer__social-link"
          >
            <img
              :src="social.src"
              :alt="social.title"
              class="footer__social-image"
            />
          </UIBaseLink>
        </div>
      </div>
      <div class="footer__organization-info">
        © 2024 ООО “Додо Франчайзинг”<br />ОГРН 1131101001844, ИНН 1101140415<br />167001,
        Республика Коми, г. Сыктывкар, Октябрьский проспект, д. 16
      </div>
    </div>
  </footer>
</template>

<style lang="scss" scoped>
.footer {
  padding-bottom: 1.25rem;
  background-color: $dark;

  &__container {
    max-width: 80rem;
    margin-left: auto;
    margin-right: auto;
    padding-top: 1.875rem;
  }

  &__contacts {
    display: flex;
    justify-content: space-between;
  }

  &__navigation-links {
    display: flex;
    flex-grow: 1;
    height: 100%;
  }

  &__download {
    display: flex;
    flex-grow: 1;
    flex-basis: 30%;
    flex-flow: column;
    align-items: flex-end;
    margin-bottom: 1.6875rem;
  }

  &__mobile-apps {
    display: flex;
    flex-wrap: wrap;
    justify-content: end;
    gap: 0.75rem;
    margin-bottom: 1rem;
  }

  &__mobile-icon {
    &:hover {
      opacity: 0.6;
    }
  }

  &__link {
    font-size: $fs-base;
    color: $white;
    opacity: 0.7;

    &:hover {
      color: $white;
      opacity: 1;
    }

    &_type {
      &_info {
        margin-right: 1rem;
      }
    }
  }

  &__stats {
    display: flex;
    padding-bottom: 1.6875rem;
  }

  &__stat {
    color: $white;
    display: flex;
    flex-flow: column;
    max-width: 22.15%;
    margin-right: 3.75rem;
  }

  &__stat-title {
    margin-top: 1rem;
    margin-bottom: 0.5625rem;
    font-size: $fs-3xl;
  }

  &__stat-text {
    opacity: 0.5;
  }

  &__copyright {
    display: flex;
    flex-wrap: wrap;
    align-items: center;
    justify-content: space-between;
    border-top: 0.0625rem solid $white-100;
    padding-top: 1.5625rem;
    margin-top: -0.125rem;
  }

  &__logo {
    width: 6.875rem;
    opacity: 0.7;
    margin-right: 0.5rem;
    margin-bottom: -0.0625rem;
  }

  &__wrapper {
    color: $white-700;
    display: flex;
    align-items: center;
    margin-right: 1rem;
  }

  &__info {
    display: flex;
    flex-grow: 1;
  }

  &__social {
    display: flex;
  }

  &__social-link {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 2rem;
    height: 2rem;
    margin-left: 0.5rem;
    border-radius: 0.25rem;
    background-color: $white-200;

    &:hover {
      background-color: $white-500;
    }
  }

  &__social-image {
    width: 1.125rem;
    height: 1.125rem;
  }

  &__organization-info {
    margin-top: 1.25rem;
    font-size: $fs-xs;
    color: $dark-gray;
  }
}
</style>
