<script lang="ts" setup>
import BaseTabs from '~/components/UI/BaseTabs.vue';

import { carouselItems } from '../utils/constants';
import { CatalogClient, ApiException } from '../api/api-generated';
import type {
  CatalogItemListView,
  ProductListView,
  AdditiveListView,
} from '../api/api-generated';
import { addToCart, cartItems } from '../utils/cartHelper';
import type { ITab, ICounterItems } from '../models/models';

const catalogApi = new CatalogClient();

const pizzaItems = ref<CatalogItemListView[]>([]);
const breakfastItems = ref<CatalogItemListView[]>([]);
const snackItems = ref<CatalogItemListView[]>([]);
const comboItems = ref<CatalogItemListView[]>([]);
const randomOrderItems = ref<CatalogItemListView[]>([]);

const isPizzaPopup = ref<boolean>(false);
const isComboOpen = ref<boolean>(false);
const isBreakfastOrSnackOpen = ref<boolean>(false);

const currentProduct = ref<CatalogItemListView | null>(null);

const selectedSizeTab = ref<number>(25);
const selectedTypeTab = ref<number>(1);

const isThinDoughDisabled = computed(() => selectedSizeTab.value === 25);
const isTypeTabDisabled = computed(() => selectedTypeTab.value === 2);

const selectedAdditives = ref<AdditiveListView[]>([]);

const pizzaSizeTabs = computed<ITab[]>(() => [
  {
    id: 25,
    title: '25 см',
    disabled: isTypeTabDisabled.value,
  },
  {
    id: 30,
    title: '30 см',
  },
  {
    id: 35,
    title: '35 см',
  },
]);

const pizzaTypeTabs = computed<ITab[]>(() => [
  {
    id: 1,
    title: 'Традиционное',
  },
  {
    id: 2,
    title: 'Тонкое',
    disabled: isThinDoughDisabled.value,
  },
]);

const currentVariant = computed(() => {
  return currentProduct.value?.products.find(
    (product) =>
      product.characteristics.some(
        (char) => char.name === 'Размер' && char.value === selectedSizeTab.value
      ) &&
      product.characteristics.some(
        (char) =>
          char.name === 'Тип теста' && char.value === selectedTypeTab.value
      )
  );
});

const currentWeight = computed(() => {
  const weightCharacteristic = currentVariant.value?.characteristics.find(
    (char) => char.name === 'Вес'
  );
  return weightCharacteristic ? weightCharacteristic.value : 0;
});

const totalPrice = computed(() => {
  const additivesPrice = selectedAdditives.value.reduce(
    (sum, additive) => sum + additive.price,
    0
  );

  return currentVariant.value!.price + additivesPrice;
});

const resetPizzaOptions = () => {
  selectedSizeTab.value = 25;
  selectedTypeTab.value = 1;
};

const togglePopup = (type: string = 'any') => {
  if (type === 'Пицца') {
    isPizzaPopup.value = !isPizzaPopup.value;

    selectedAdditives.value = [];
    if (!isPizzaPopup.value) resetPizzaOptions();
  } else if (type === 'Комбо') {
    isComboOpen.value = !isComboOpen.value;
  } else {
    isBreakfastOrSnackOpen.value = !isBreakfastOrSnackOpen.value;
  }
};

const handleProductClick = (product: CatalogItemListView) => {
  currentProduct.value = null;

  togglePopup(product.category);

  currentProduct.value = product;
};

const handleAddToCart = (product: ICounterItems<ProductListView>) => {
  addToCart(product);
  togglePopup(product.item.productType);
};

const handleValidateCart = (product: CatalogItemListView) => {
  if (product.category === 'Пицца' || product.category === 'Комбо') {
    handleProductClick(product);
  } else {
    addToCart({
      count: 1,
      price: product.products[0].price,
      additives: [],
      item: product.products[0],
    });
  }
};

const handleToggleAdditive = (
  additive: AdditiveListView,
  isActive: boolean
) => {
  if (isActive) {
    selectedAdditives.value.push(additive);
  } else {
    selectedAdditives.value = selectedAdditives.value.filter(
      (item) => item.id !== additive.id
    );
  }
};

useHead({
  title:
    'Пицца Москва — заказать с доставкой на дом бесплатно, доставка еды из пиццерии Додо',
});

onMounted(async () => {
  try {
    const { items } = await catalogApi.getCatalogItems();
    items.forEach((item: CatalogItemListView) => {
      switch (item.category) {
        case 'Пицца':
          pizzaItems.value.push(item);
          break;
        case 'Завтрак':
          breakfastItems.value.push(item);
          break;
        case 'Закуски':
          snackItems.value.push(item);
          break;
        case 'Комбо':
          comboItems.value.push(item);
          break;
        default:
          console.error(`Unknown type: ${item.category}`);
      }
    });
    const combinedItems = [...breakfastItems.value, ...snackItems.value];
    randomOrderItems.value = combinedItems
      .sort(() => Math.random() - 0.5)
      .slice(0, 4);
  } catch (error) {
    console.error('Error loading catalog:', (error as ApiException).name);
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
      <OrderCard
        v-for="card in randomOrderItems"
        @cardClick="handleProductClick"
        :key="card.name"
        :card="card"
      />
    </ul>
  </section>

  <CategorySection
    id="pizza"
    title="Пицца"
    :products="pizzaItems"
    @cardClick="handleProductClick"
    @addToCart="handleValidateCart"
  />

  <CategorySection
    id="snacks"
    title="Закуски"
    :products="snackItems"
    @cardClick="handleProductClick"
    @addToCart="handleValidateCart"
  />

  <CategorySection
    id="breakfast"
    title="Завтрак"
    :products="breakfastItems"
    @cardClick="handleProductClick"
    @addToCart="handleValidateCart"
  />

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
    v-model="isPizzaPopup"
    customClass="main-popup"
    @closePopup="togglePopup('Пицца')"
  >
    <template #content v-if="currentVariant">
      <div class="main-popup__content">
        <div class="main-popup__image-container">
          <img
            :src="`/images/${currentVariant.image}`"
            :alt="`Фото ${currentVariant.name}`"
            class="main-popup__image"
          />
        </div>
        <div class="main-popup__container">
          <div class="main-popup__info">
            <h3 class="main-popup__title">{{ currentProduct?.name }}</h3>
            <span class="main-popup__count-info">
              {{ selectedSizeTab }} см,
              {{
                selectedTypeTab === 1 ? 'традиционное тесто,' : 'тонкое тесто,'
              }}
              {{ currentWeight }} г
            </span>
            <div class="main-popup__description">
              {{ currentProduct?.description }}
            </div>
            <BaseTabs :tabs="pizzaSizeTabs" v-model="selectedSizeTab" />
            <BaseTabs
              :tabs="pizzaTypeTabs"
              v-model="selectedTypeTab"
              style="margin-top: 0"
            />
            <template v-if="currentVariant.additives.length > 0">
              <span class="main-popup__add">Добавить по вкусу</span>
              <ul class="main-popup__additives">
                <Additive
                  v-for="additive in currentVariant.additives"
                  :additive="additive"
                  :key="additive.id"
                  :onToggle="handleToggleAdditive"
                />
              </ul>
            </template>
          </div>
          <div class="main-popup__button-container">
            <UIBaseButton
              type="button"
              class="main-popup__button"
              @click="
                handleAddToCart({
                  count: 1,
                  price: totalPrice,
                  additives: selectedAdditives,
                  item: currentVariant,
                })
              "
            >
              В корзину за {{ totalPrice }}
            </UIBaseButton>
          </div>
        </div>
      </div>
    </template>
  </UIBasePopup>

  <UIBasePopup
    v-model="isBreakfastOrSnackOpen"
    customClass="main-popup"
    @closePopup="togglePopup"
  >
    <template #content v-if="currentProduct !== null">
      <div class="main-popup__content">
        <div class="main-popup__image-container">
          <img
            :src="`/images/${currentProduct.image}`"
            :alt="`Фото ${currentProduct.name}`"
            class="main-popup__image"
          />
        </div>
        <div class="main-popup__container">
          <div class="main-popup__info">
            <h3 class="main-popup__title">{{ currentProduct.name }}</h3>
            <span class="main-popup__count-info">
              {{ currentProduct.products[0].characteristics[1].value }} шт,
              {{ currentProduct.products[0].characteristics[0].value }} г
            </span>
            <div class="main-popup__description">
              {{ currentProduct.description }}
            </div>
            <div class="main-popup__count">
              {{ currentProduct.products[0].characteristics[1].value }} шт
            </div>
          </div>
          <div class="main-popup__button-container">
            <UIBaseButton
              type="button"
              class="main-popup__button"
              @click="
                handleAddToCart({
                  count: 1,
                  price: currentProduct.products[0].price,
                  additives: [],
                  item: currentProduct.products[0],
                })
              "
            >
              В корзину за {{ currentProduct.products[0].price }}
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
  padding-top: 3.625rem;
  margin-top: -3.625rem;

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

  &__container {
    position: relative;
    float: right;
    vertical-align: top;
    width: 24.625rem;
    height: 38.125rem;
    padding: 1.875rem 0;
    background: hsl(0, 0%, 99%);
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
    position: relative;
    overflow: auto;
    display: flex;
    flex-flow: column;
    height: 29.875rem;
    padding-left: 1.875rem;
    padding-right: 1.875rem;
    @include scrollbar;
  }

  &__title {
    font-size: $fs-2xl;
    line-height: 1.75rem;
    font-weight: 500;
  }

  &__count-info {
    color: $dark-gray;
    padding-top: 0.1875rem;
    padding-bottom: 0.3125rem;
    font-size: $fs-sm;
    line-height: 1.25rem;
  }

  &__description {
    font-size: $fs-sm;
  }

  &__count {
    font-size: $fs-xs;
    line-height: 2rem;
    margin-top: 1.375rem;
    display: flex;
    align-items: center;
    justify-content: center;
    background-color: $gray;
    height: 2rem;
    border-radius: 624.9375rem;
  }

  &__combo {
    margin-top: 1rem;
  }

  &__combo-scroll {
    position: relative;
    height: 100%;
    overflow-x: auto;
    padding-left: 0.9375rem;
    padding-right: 0.9375rem;
  }

  &__add {
    margin-top: 0.875rem;
    margin-bottom: 0.75rem;
    font-size: $fs-xl;
    line-height: 1.5rem;
    font-weight: $fw-semibold;
  }

  &__additives {
    display: flex;
    flex-wrap: wrap;
    gap: 0.5rem;
  }
}
</style>
