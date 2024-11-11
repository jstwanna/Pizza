import type { ProductListView } from '../api/api-generated';
import type { ICounterItems } from '../models/models';

export const cartItems = ref<ICounterItems<ProductListView>[]>([]);

export const addToCart = (product: ICounterItems<ProductListView>) => {
  const existingProduct = cartItems.value.find(
    (item) =>
      item.item.id === product.item.id && item.additives === product.additives
  );

  if (existingProduct) {
    existingProduct.count += product.count;
  } else {
    cartItems.value.push(product);
  }
};

export const isCartNotEmpty = computed(() => cartItems.value.length > 0);
