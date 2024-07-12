import type { OftenOrderCard } from '../models/models';
import { OrderType } from '../models/models';

import dodster from '../assets/images/11EE796F96D11392A2F6DD73599921B9.jpg';
import pepperoni from '../assets/images/11EE7D612FC7B7FCA5BE822752BEE1E5.jpg';
import theePizzas from '../assets/images/11EE7E219680B50B85AD6F6813EA1902.jpg';
import twoSauces from '../assets/images/11EE7E218642FE309ADC80670C938F1A.jpg';

interface Link {
  id: number;
  title: string;
  to: string;
}

export const headerMenuItems: Link[] = [
  {
    id: 1,
    title: 'Работа в Додо',
    to: '/work',
  },
  {
    id: 2,
    title: 'О нас',
    to: 'about',
  },
  {
    id: 3,
    title: 'Контакты',
    to: '/contacts',
  },
];

export const headerLinks: Link[] = [
  {
    id: 1,
    title: 'Пиццы',
    to: '#pizza',
  },
  {
    id: 2,
    title: 'Комбо',
    to: '#combo',
  },
  {
    id: 3,
    title: 'Закуски',
    to: '#snacks',
  },
  {
    id: 4,
    title: 'Коктейли',
    to: '#cocktails',
  },
  {
    id: 5,
    title: 'Кофе',
    to: '#coffee',
  },
  {
    id: 6,
    title: 'Напитки',
    to: '#beverages',
  },
  {
    id: 7,
    title: 'Десерты',
    to: '#dessert',
  },
  {
    id: 8,
    title: 'Любят дети',
    to: '#children love',
  },
  {
    id: 9,
    title: 'Соусы',
    to: '#sauces',
  },
  {
    id: 10,
    title: 'Другие товары',
    to: '#other-goods',
  },
];

export const orderCards: OftenOrderCard[] = [
  {
    id: 1,
    type: OrderType.Snack,
    src: dodster,
    title: 'Додстер',
    description:
      'Легендарная горячая закуска с цыпленком, томатами, моцареллой, соусом ранч в тонкой пшеничной лепешке',
    cost: 209,
    oldCost: null,
  },
  {
    id: 2,
    type: OrderType.Pizza,
    src: pepperoni,
    title: 'Пепперони фреш',
    description:
      'Пикантная пепперони, увеличенная порция моцареллы, томаты, фирменный томатный соус',
    cost: 319,
    oldCost: null,
  },
  {
    id: 3,
    type: OrderType.Combo,
    src: theePizzas,
    title: '3 пиццы',
    description:
      'Три удовольствия в нашем меню — это 3 средние пиццы на ваш выбор. Цена комбо зависит от выбранных пицц и может быть увеличена',
    cost: 1199,
    oldCost: 1637,
  },
  {
    id: 4,
    type: OrderType.Combo,
    src: twoSauces,
    title: '2 соуса',
    description: 'Комбинируйте пары соусов для ярких перекусов',
    cost: 75,
    oldCost: 90,
  },
];
