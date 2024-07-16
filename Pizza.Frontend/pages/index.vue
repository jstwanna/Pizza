<script lang="ts" setup>
import map from '../assets/images/911e3a5bc67fc765b604..jpg';

import { orderCards, carouselItems } from '../utils/constants';
import type { OftenOrderCard } from '../models/models';

const handleCardClick = (clickedCard: OftenOrderCard) => {
  console.log('Card clicked:', clickedCard);
};
</script>

<template>
  <section class="carousel">
    <UIBaseCarousel :images="carouselItems" />
  </section>

  <section class="often-order">
    <h2 class="often-order__title">Часто заказывают</h2>
    <ul class="often-order__cards">
      <OrderCard
        v-for="card in orderCards"
        :card="card"
        @cardClick="handleCardClick"
      />
    </ul>
  </section>

  <CategorySection title="Пиццы" :products="orderCards" />

  <section class="delivery">
    <h2 class="delivery__title">Доставка и оплата</h2>
    <div class="delivery__container">
      <h3 class="delivery__subtitle">60 минут или пицца бесплатно</h3>
      <p class="delivery__text">
        Если не успеем доставить за 60 минут, вы получите извинительную пиццу.
        Её можно будет добавить в один из следующих заказов.
      </p>
      Все цены в меню указаны без учета скидок
    </div>
    <div class="delivery__container">
      <h3 class="delivery__subtitle delivery__subtitle_capitalize">От 599 ₽</h3>
      <p class="delivery__text">Минимальная сумма доставки</p>
      <h3 class="delivery__subtitle">7 000 ₽</h3>
      <p class="delivery__text">Максимальная сумма при оплате наличными</p>
      Изображения продуктов могут отличаться от продуктов в заказе.
    </div>
    <div class="delivery__container">
      <h3 class="delivery__subtitle">Зона доставки ограничена</h3>
      <UIBaseButton type="button" class="delivery__button">
        <img :src="map" alt="Фото зоны доставки" class="delivery__image" />
        <span class="delivery__image-text">Зона доставки</span>
      </UIBaseButton>
    </div>
  </section>
</template>

<style lang="scss" scoped>
.carousel {
  max-width: 86rem;
  margin-left: auto;
  margin-right: auto;
}

.often-order {
  max-width: 80rem;
  margin-left: auto;
  margin-right: auto;

  &__title {
    font-weight: $fw-medium;
    font-size: $fs-2xl;
    margin-top: 1rem;
    margin-bottom: 1rem;
  }

  &__cards {
    display: flex;
    align-items: flex-start;
    flex-wrap: wrap;
    margin-top: 0.5625rem;
    margin-bottom: 1.25rem;
  }
}

.delivery {
  display: flex;
  flex-wrap: wrap;
  max-width: 80rem;
  margin-left: auto;
  margin-right: auto;

  &__title {
    width: 100%;
    @include section-title;
  }

  &__container {
    width: 35%;
    margin-right: 4%;
    margin-bottom: 3.75rem;
    font-weight: $fw-medium;

    &:last-child {
      width: 22%;
      margin-right: 0;
    }
  }

  &__subtitle {
    margin-bottom: 0.3125rem;
    font-weight: $fw-medium;
    font-size: $fs-lg;
    color: $orange;
    text-transform: uppercase;

    &_capitalize {
      text-transform: capitalize;
    }
  }

  &__text {
    margin-bottom: 1.25rem;
  }

  &__button {
    position: relative;
    display: block;
    overflow: hidden;
    border-radius: 0;
  }

  &__image {
    width: 100%;
    @include transition(2s, ease);

    &:hover {
      transform: scale(1.2) translate(-0.9375rem, -0.9375rem);
      filter: saturate(2);
    }
  }

  &__image-text {
    pointer-events: none;
    font-size: $fs-xl;
    position: absolute;
    top: 50%;
    left: 50%;
    text-align: center;
    transform: translate(-50%, -50%);
  }
}
</style>
