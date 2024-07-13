import type { OftenOrderCard, ContactLink } from '../models/models';
import { OrderType } from '../models/models';

import dodster from '../assets/images/11EE796F96D11392A2F6DD73599921B9.jpg';
import pepperoni from '../assets/images/11EE7D612FC7B7FCA5BE822752BEE1E5.jpg';
import theePizzas from '../assets/images/11EE7E219680B50B85AD6F6813EA1902.jpg';
import twoSauces from '../assets/images/11EE7E218642FE309ADC80670C938F1A.jpg';

import appStore from '../assets/svg/appStore.svg';
import googlePlay from '../assets/svg/googlePlay.svg';
import appGallery from '../assets/svg/appGallery.svg';

import ok from '../assets/svg/ok.svg';
import vk from '../assets/svg/vk.svg';
import youtube from '../assets/svg/youtube.svg';

interface Link {
  id: number;
  title: string;
  to: string;
}

interface ExternalLink {
  id: number;
  title: string;
  src: string;
  to: string;
}

interface Stat {
  id: number;
  title: string;
  text: string;
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
    to: '/about',
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
  {
    id: 11,
    title: 'Акции',
    to: '#',
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

export const contactLinks: ContactLink[] = [
  {
    id: 1,
    title: 'Додо Пицца',
    links: [
      {
        id: 1,
        name: 'О нас',
        to: '/about',
      },
      {
        id: 2,
        name: 'Додо-книга',
        to: '#',
      },
      {
        id: 3,
        name: 'Блог «Сила ума»',
        to: '#',
      },
    ],
  },
  {
    id: 2,
    title: 'Работа',
    links: [
      {
        id: 1,
        name: 'В пиццерии',
        to: '/work',
      },
    ],
  },
  {
    id: 3,
    title: 'Партнёрам',
    links: [
      {
        id: 1,
        name: 'Франшиза',
        to: '#',
      },
      {
        id: 2,
        name: 'Инвестиции',
        to: '#',
      },
      {
        id: 3,
        name: 'Поставщикам',
        to: '#',
      },
      {
        id: 4,
        name: 'Предложить помещение',
        to: '#',
      },
    ],
  },
  {
    id: 4,
    title: 'Это интересно',
    links: [
      {
        id: 1,
        name: 'Почему мы готовим без перчаток?',
        to: '#',
      },
      {
        id: 2,
        name: 'Экскурсии и мастер-классы',
        to: '#',
      },
      {
        id: 3,
        name: 'Корпоративные заказы',
        to: '#',
      },
    ],
  },
];

export const mobileApps: ExternalLink[] = [
  {
    id: 1,
    title: 'Мобильное приложение для iOS',
    src: appStore,
    to: 'https://apps.apple.com/ru/app/додо-пицца-доставка-ресторан/id894649641?mt=8',
  },
  {
    id: 2,
    title: 'Мобильное приложение для Android',
    src: googlePlay,
    to: 'https://play.google.com/store/apps/details?id=ru.dodopizza.app&referrer=af_tranid%3DB1sS-CLYjPqgFiqtxnfqwg%26c%3Dweb%26af_ad%3Dicon%26pid%3Ddodopizza.site',
  },
  {
    id: 3,
    title: 'Мобильное приложение для Huawei,',
    src: appGallery,
    to: 'https://appgallery.huawei.com/app/C101170713?sharePrepath=ag&locale=ru_RU&source=website',
  },
];

export const statsFooter: Stat[] = [
  {
    id: 1,
    title: '3 142 384 350 ₽',
    text: 'Выручка российской сети в этом месяце. В прошлом — 8 189 658 037 ₽',
  },
  {
    id: 2,
    title: '1096 пиццерий',
    text: 'в 22 странах, от Великобритании до Нигерии',
  },
];

export const footerLinks: Link[] = [
  {
    id: 1,
    title: 'Правовая информация',
    to: '#',
  },
  {
    id: 2,
    title: 'Калорийность и состав',
    to: 'https://drive.google.com/file/d/1GWaKPdU7t5URgMkh_X4pJqmyZuGr9FdQ/edit',
  },
  {
    id: 3,
    title: 'Помощь',
    to: '#',
  },
];

export const socialLinks: ExternalLink[] = [
  {
    id: 1,
    title: 'Лого одноклассников',
    src: ok,
    to: 'https://ok.ru/dodopizza',
  },
  {
    id: 2,
    title: 'Лого вконтакте',
    src: vk,
    to: 'https://vk.com/dodo',
  },
  {
    id: 3,
    title: 'Лого ютуб',
    src: youtube,
    to: 'https://www.youtube.com/dodomovie',
  },
];
