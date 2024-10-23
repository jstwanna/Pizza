import { TestimonialImages } from './../.nuxt/components.d';
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

export interface Image {
  id: number;
  src: string;
  title: string;
}

export interface Images {
  images: Image[];
}

export interface Link {
  id: number;
  title: string;
  to: string;
}

export interface ExternalLink {
  id: number;
  title: string;
  src: string;
  to: string;
}

export interface Stat {
  id: number;
  title: string;
  text: string;
}

export interface Ingredient {
  id: number;
  title: string;
  text: string;
}
