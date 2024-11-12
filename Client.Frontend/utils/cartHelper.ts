import type { ProductListView } from '../api/api-generated';
import type { ICounterItems } from '../models/models';

export const cartItems = ref<ICounterItems<ProductListView>[]>([]);

export const addToCart = (product: ICounterItems<ProductListView>) => {
  const existingProduct = cartItems.value.find(
    (item) =>
      item.item.id === product.item.id &&
      item.additives.length === product.additives.length &&
      item.additives.every((cartAdditive) =>
        product.additives.some((additive) => additive.id === cartAdditive.id)
      )
  );

  if (existingProduct) {
    existingProduct.count += product.count;
  } else {
    cartItems.value.push(product);
  }
};

export const isCartNotEmpty = computed(() => cartItems.value.length > 0);

export const getTotalPrice = computed(() =>
  cartItems.value.reduce((total, item) => total + item.price * item.count, 0)
);

export const getTotalCount = computed(() =>
  cartItems.value.reduce((total, item) => total + item.count, 0)
);

export const calculateBonusPoints = (
  orderAmount: number,
  coefficient: number = 0.05
): number => {
  return Math.round(orderAmount * coefficient);
};
