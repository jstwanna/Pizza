<script lang="ts" setup>
import { carouselItems } from '../utils/constants';
import { formatNumber } from '../utils/utils';

import { CatalogClient, ApiException } from '../api/api-generated';
import type { ProductListView, PizzaListView } from '../api/api-generated';

interface ProcessedData {
  pizzas: PizzaListView[];
  snacks: ProductListView[];
  breakfast: ProductListView[];
}

const catalogApi = new CatalogClient();
const catalog = ref<ProcessedData | null>(null);
const order = ref<ProductListView[]>([]);

const currentPizza = ref<PizzaListView | null>();
const currentSnacksBreakfast = ref<ProductListView | null>(null);

const isPizzaOpen = ref<boolean>(false);
const isProductOpen = ref<boolean>(false);

useHead({
  title:
    'Пицца Москва — заказать с доставкой на дом бесплатно, доставка еды из пиццерии Додо',
});

const handleGetPizza = (pizza: PizzaListView) => {
  isPizzaOpen.value = true;
  currentPizza.value = pizza;
};

const handleGetProduct = (product: ProductListView) => {
  isProductOpen.value = true;
  currentSnacksBreakfast.value = product;
};

onMounted(() => {
  const savedCatalog = localStorage.getItem('catalog');

  if (savedCatalog) {
    catalog.value = JSON.parse(savedCatalog);
  } else {
    catalogApi
      .getAllProducts()
      .then((res) => {
        const processedData: ProcessedData = {
          pizzas: res.pizzas,
          snacks: [],
          breakfast: [],
        };

        res.products.forEach((product) => {
          if (product.productType === 'Завтрак') {
            processedData.breakfast.push(product);
          } else if (product.productType === 'Закуски') {
            processedData.snacks.push(product);
          }
        });

        catalog.value = processedData;

        localStorage.setItem('catalog', JSON.stringify(processedData));
      })
      .catch((error: ApiException) =>
        console.error('Error while receiving goods:', error.message)
      );
  }

  if (catalog.value) {
    const snacks = catalog.value.snacks ?? [];
    const breakfast = catalog.value.breakfast ?? [];

    const allProducts = [...snacks, ...breakfast];

    const shuffledProducts = allProducts.sort(() => 0.5 - Math.random());
    order.value = shuffledProducts.slice(0, 4);
  }
});
</script>

<template>
  <section class="carousel">
    <UIBaseCarousel :images="carouselItems" />
  </section>

  <section class="often-order">
    <h2 class="often-order__title">Часто заказывают</h2>
    <ul class="often-order__cards">
      <OrderCard v-for="card in order" :key="card.id" :card="card" />
    </ul>
  </section>

  <section class="category" id="pizza">
    <h2 class="category__title">Пицца</h2>
    <div class="category__products">
      <article
        class="product"
        v-for="pizza in catalog?.pizzas"
        :key="pizza.id"
        @click="handleGetPizza(pizza)"
      >
        <template v-if="pizza.pizzas != null">
          <div class="product__main">
            <img
              :src="`/images/${pizza.pizzas[0].image}`"
              class="product__image"
            />
            <h3 class="product__title">{{ pizza.pizzas[0].pizzaType }}</h3>
            {{ pizza.desctiption }}
          </div>
          <div class="product__footer">
            <div class="product__cost">
              {{ formatNumber(pizza.pizzas[0].price) }} ₽
            </div>
            <UIBaseButton type="button" class="product__button">
              Собрать
            </UIBaseButton>
          </div>
        </template>
      </article>
    </div>
  </section>

  <section class="category" id="snacks">
    <h2 class="category__title">Закуски</h2>
    <div class="category__products">
      <article
        class="product"
        v-for="snack in catalog?.snacks"
        :key="snack.id"
        @click="handleGetProduct(snack)"
      >
        <template v-if="snack != null">
          <div class="product__main">
            <img :src="`/images/${snack.image}`" class="product__image" />
            <h3 class="product__title">{{ snack.name }}</h3>
            {{ snack.description }}
          </div>
          <div class="product__footer">
            <div class="product__cost">{{ formatNumber(snack.price) }} ₽</div>
            <UIBaseButton type="button" class="product__button">
              В корзину
            </UIBaseButton>
          </div>
        </template>
      </article>
    </div>
  </section>

  <section class="category" id="breakfast">
    <h2 class="category__title">Завтрак</h2>
    <div class="category__products">
      <article
        class="product"
        v-for="breakfast in catalog?.breakfast"
        :key="breakfast.id"
        @click="handleGetProduct(breakfast)"
      >
        <template v-if="breakfast != null">
          <div class="product__main">
            <img :src="`/images/${breakfast.image}`" class="product__image" />
            <h3 class="product__title">{{ breakfast.name }}</h3>
            {{ breakfast.description }}
          </div>
          <div class="product__footer">
            <div class="product__cost">
              {{ formatNumber(breakfast.price) }} ₽
            </div>
            <UIBaseButton type="button" class="product__button">
              В корзину
            </UIBaseButton>
          </div>
        </template>
      </article>
    </div>
  </section>

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
        <img
          src="https://cdn.dodostatic.net/site-static/dist/assets/911e3a5bc67fc765b604..jpg"
          alt="Фото зоны доставки"
          class="delivery__image"
        />
        <span class="delivery__image-text">Зона доставки</span>
      </UIBaseButton>
    </div>
  </section>

  <UIBasePopup
    v-model="isPizzaOpen"
    customClass="main-popup"
    @closePopup="isPizzaOpen = false"
  >
    <template #content v-if="currentPizza?.pizzas != null">
      <div class="main-popup__content">
        <div class="main-popup__image-container">
          <img
            :src="`/images/${currentPizza.pizzas[1].image}`"
            :alt="`Фото ${currentPizza.pizzas[0].pizzaType}`"
            class="main-popup__image"
          />
        </div>
        <div class="pizza-popup__info-content"></div>
      </div>
    </template>
  </UIBasePopup>

  <UIBasePopup
    v-model="isProductOpen"
    customClass="main-popup"
    @closePopup="isProductOpen = false"
  >
    <template #content v-if="currentSnacksBreakfast != null">
      <div class="main-popup__content">
        <div class="main-popup__image-container">
          <img
            :src="`/images/${currentSnacksBreakfast.image}`"
            :alt="`Фото ${currentSnacksBreakfast.name}`"
            class="main-popup__image"
          />
        </div>
        <div class="main-popup__container">
          <div class="main-popup__info"></div>
          <div class="main-popup__button-container">
            <UIBaseButton type="button" class="main-popup__button">
              В корзину за {{ currentSnacksBreakfast.price }}
            </UIBaseButton>
          </div>
        </div>
      </div>
    </template>
  </UIBasePopup>
</template>

<style lang="scss" scoped>
.carousel {
  max-width: 86rem;
  margin-left: auto;
  margin-right: auto;
}

.often-order {
  @include container;

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
    column-gap: 1.5rem;
  }
}

.delivery {
  display: flex;
  flex-wrap: wrap;
  @include container;

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
    @include transition($duration: 2s, $timing-function: ease);

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

.category {
  @include container;
  padding-top: 58px;
  margin-top: -58px;

  &__title {
    @include section-title;
  }

  &__products {
    display: flex;
    flex-wrap: wrap;
    column-gap: 2.3333rem;
  }
}

.product {
  display: flex;
  flex-flow: column;
  justify-content: space-between;
  cursor: pointer;
  width: 18.25rem;
  margin-bottom: 3.75rem;

  &__main {
    width: 100%;
    font-size: $fs-sm;
    line-height: 1.25rem;
    color: $dark-gray;
  }

  &__image {
    position: relative;
    top: 0;
    @include transition(top, 150ms, ease-out);
    width: 90%;
    object-fit: cover;
    margin-top: 5%;
    margin-left: 5%;

    &:hover {
      top: 0.1875rem;
    }
  }

  &__title {
    color: $black;
    margin-top: 0.5rem;
    margin-bottom: 0.5rem;
    font-size: $fs-xl;
    line-height: 1.5rem;
    font-weight: $fw-medium;
  }

  &__footer {
    margin-top: 1rem;
    display: flex;
    justify-content: space-between;
  }

  &__cost {
    flex: 0 1 auto;
    padding-right: 0.25rem;
    font-size: $fs-xl;
    font-weight: $fw-semibold;
    line-height: 1.375rem;
    display: flex;
    flex-flow: column;
    justify-content: center;
  }

  &__button {
    min-height: 2.5rem;
    max-width: 60%;
    min-width: 7.5rem;
    padding: 0.5rem 1.25rem;
    line-height: 1.5rem;
    color: $deep-amber;
    background-color: $pink;

    &:hover {
      background-color: $light-pink;
    }

    &:active {
      opacity: 0.5;
    }
  }
}

.main-popup {
  &__content {
    width: 57.75rem;
    background-color: $white;
    box-shadow: hsla(0, 0%, 0%, 0.2) 0 1.875rem 3.75rem;
    border-radius: 1.25rem;
    height: 38.125rem;
    display: flex;
  }

  &__image-container {
    position: relative;
    vertical-align: top;
    width: 33.125rem;
    max-height: 38.125rem;
  }

  &__image {
    width: 100%;
    user-select: none;
    margin: 5.75rem 3.25rem 0;
    width: 26.625rem;
    height: 26.625rem;
  }

  &__info-content {
    position: relative;
    float: right;
    vertical-align: top;
    width: 24.625rem;
    height: 38.125rem;
    padding: 1.875rem 0;
    background: $white;
    border-top-right-radius: 1.25rem;
    border-bottom-right-radius: 1.25rem;
  }

  &__container {
    position: relative;
    float: right;
    vertical-align: top;
    width: 24.625rem;
    height: 38.125rem;
    padding: 1.875rem 0;
    background: $white;
    border-top-right-radius: 1.25rem;
    border-bottom-right-radius: 1.25rem;
  }

  &__button-container {
    position: relative;
    z-index: 1;
    margin: 1.5rem 1.875rem 1.875rem;
  }

  &__button {
    background-color: $orange;
    color: $white;
    width: 100%;
    padding: 0.75rem 3rem;
    text-align: center;
    font-weight: 500;
    text-decoration: none;
    user-select: none;

    &:hover {
      background-color: $dark-orange;
    }
  }

  &__info {
  }
}
</style>
