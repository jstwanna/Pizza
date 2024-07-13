export enum OrderType {
  Pizza = 'pizza',
  Combo = 'combo',
  Snack = 'snack',
  Cocktails = 'cocktails',
  Coffee = 'coffee',
  Beverages = 'beverages',
  Dessert = 'dessert',
  Sauces = 'sauces',
  Other = 'other',
}

export interface OftenOrderCard {
  id: number;
  type: OrderType;
  src: string;
  title: string;
  description: string;
  cost: number;
  oldCost: number | null;
}

export interface ContactLink {
  id: number;
  title: string;
  links: {
    id: number;
    name: string;
    to: string;
  }[];
}
