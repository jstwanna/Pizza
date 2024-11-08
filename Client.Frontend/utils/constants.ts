import type {
  ContactLink,
  Image,
  Images,
  Link,
  ExternalLink,
  Stat,
  Ingredient,
} from '../models/models';

import appStore from '../assets/svg/appStore.svg';
import googlePlay from '../assets/svg/googlePlay.svg';
import appGallery from '../assets/svg/appGallery.svg';

import ok from '../assets/svg/ok.svg';
import vk from '../assets/svg/vk.svg';
import youtube from '../assets/svg/youtube.svg';

import aboutMan from '../assets/svg/aboutMan.svg';
import aboutChat from '../assets/svg/aboutChat.svg';
import aboutSecondChat from '../assets/svg/aboutSecondChat.svg';
import ingredientPeople from '../assets/svg/ingredientPeople.svg';
import ingredientChat from '../assets/svg/ingredientChat.svg';
import ingredientSecondChat from '../assets/svg/ingredientSecondChat.svg';
import statisticPeople from '../assets/svg/statisticPeople.svg';
import statisticChat from '../assets/svg/statisticChat.svg';
import statisticSecondChat from '../assets/svg/statisticSecondChat.svg';
import rulePeople from '../assets/svg/rulePeople.svg';
import ruleChat from '../assets/svg/ruleChat.svg';
import ruleSecondChat from '../assets/svg/ruleSecondChat.svg';
import openPeople from '../assets/svg/openPeople.svg';
import openChat from '../assets/svg/openChat.svg';
import openSecondChat from '../assets/svg/openSecondChat.svg';
import dodoPeople from '../assets/svg/dodoPeople.svg';
import dodoChat from '../assets/svg/dodoChat.svg';
import dodoSecondChat from '../assets/svg/dodoSecondChat.svg';

export const headerMenuItems: Link[] = [
  {
    id: 1,
    title: 'Работа в Додо',
    to: '#',
  },
  {
    id: 2,
    title: 'О нас',
    to: '/about',
  },
  {
    id: 3,
    title: 'Контакты',
    to: '#',
  },
];

export const headerLinks = computed<Link[]>(() => [
  {
    id: 1,
    title: 'Пиццы',
    to: '#pizza',
  },
  {
    id: 3,
    title: 'Закуски',
    to: '#snacks',
  },
  {
    id: 12,
    title: 'Завтрак',
    to: '#breakfast',
  },
  {
    id: 2,
    title: 'Комбо',
    to: '#',
  },
  {
    id: 4,
    title: 'Коктейли',
    to: '#',
  },
  {
    id: 5,
    title: 'Кофе',
    to: '#',
  },
  {
    id: 6,
    title: 'Напитки',
    to: '#',
  },
  {
    id: 7,
    title: 'Десерты',
    to: '#',
  },
  {
    id: 8,
    title: 'Любят дети',
    to: '#',
  },
  {
    id: 9,
    title: 'Соусы',
    to: '#',
  },
  {
    id: 10,
    title: 'Другие товары',
    to: '#',
  },
  {
    id: 11,
    title: 'Акции',
    to: '#',
  },
]);

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
        to: '#',
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

export const carouselItems: Image[] = [
  {
    id: 1,
    src: 'https://cdn.inappstory.ru/story/ngh/cs7/1ef/cl7wilwwcfglss7efbpaaft/custom_cover/logo-350x440.webp?k=IgAAAAAAAAAEAQ&v=599731850',
    title: 'Додо лето',
  },
  {
    id: 2,
    src: 'https://cdn.inappstory.ru/story/cz6/kdm/pu7/r5tndlrq37nenv4iwclqhru/custom_cover/logo-350x440.webp?k=IgAAAAAAAAAEAQ&v=951641400',
    title: 'Леди-баг комбо',
  },
  {
    id: 3,
    src: 'https://cdn.inappstory.ru/story/gxm/n1i/knm/bj8rd3u5wrnpu9krxxrcpbc/custom_cover/logo-350x440.webp?k=IgAAAAAAAAAEAQ&v=3161425840',
    title: 'История кофе',
  },
  {
    id: 4,
    src: 'https://cdn.inappstory.ru/story/4tb/ebr/9gq/tgubdtglh2v03d1puluxgts/custom_cover/logo-350x440.webp?k=IgAAAAAAAAAEAQ&v=2256198318',
    title: 'Новые соусы',
  },
  {
    id: 5,
    src: 'https://cdn.inappstory.ru/story/uts/pwz/2po/fr2csrffmowblqlfmtcjau2/custom_cover/logo-350x440.webp?k=IgAAAAAAAAAEAQ&v=1914710796',
    title: 'Доставка пиццы другу',
  },
  {
    id: 6,
    src: 'https://cdn.inappstory.ru/story/g14/x7g/zif/y5wadnsstj5vxxvmndm6gce/custom_cover/logo-350x440.webp?k=IgAAAAAAAAAEAQ&v=2930947821',
    title: 'Подписка за рассылку',
  },
  {
    id: 7,
    src: 'https://cdn.inappstory.ru/story/hpn/ned/umu/8u3fkyrblr4hnf4px3r7tqg/custom_cover/logo-350x440.webp?k=IgAAAAAAAAAEAQ&v=4128893999',
    title: 'Пицца кусочками',
  },
  {
    id: 8,
    src: 'https://cdn.inappstory.ru/story/y89/y0l/nv2/pjhpkwzmf5yk4acrf4ech2h/custom_cover/logo-350x440.webp?k=IgAAAAAAAAAEAQ&v=907332844',
    title: 'Добрый кола',
  },
];

export const ingredientItems: Ingredient[] = [
  {
    id: 1,
    title: 'Тесто',
    text: 'Самая тонкая вещь. Главное - сделать его «живым». Это целый квест из граммов, градусов, процентов и часов с минутами. Процесс непростой, но у нас получается!',
  },
  {
    id: 2,
    title: 'Моцарелла',
    text: 'Сыр в пицце - ключевой ингредиент. Мы используем настоящую моцареллу от российских поставщиков. Сыр должен тянуться, как на картинке.',
  },
  {
    id: 3,
    title: 'Начинка',
    text: 'Есть два главных правила вкусной начинки: не экономить на начинке; фанатично соблюдать режим хранения. Это и весь секрет.',
  },
  {
    id: 4,
    title: 'Томатный соус',
    text: 'Главное, что нужно знать про хороший томатный соус: он должен быть сделан из томатов. Звучит логично, но задумайтесь!',
  },
];

export const testimonialItems: Images[] = [
  {
    images: [
      {
        id: 1,
        src: aboutMan,
        title: 'Картина человека',
      },
      {
        id: 2,
        src: aboutChat,
        title: 'Эй, тут начинают что-то рассказывать.',
      },
      {
        id: 3,
        src: aboutSecondChat,
        title: 'Стой без нас не смотри!',
      },
    ],
  },
  {
    images: [
      {
        id: 1,
        src: ingredientPeople,
        title: 'Картинка людей',
      },
      {
        id: 2,
        src: ingredientChat,
        title: 'Вроде несложно...',
      },
      {
        id: 3,
        src: ingredientSecondChat,
        title: 'Ага, но давай-ка лучше закажем.',
      },
    ],
  },
  {
    images: [
      {
        id: 1,
        src: statisticPeople,
        title: 'Картинка смотрящих людей',
      },
      {
        id: 2,
        src: statisticChat,
        title: 'Я думал, Додо есть только у нас, в Ульяновске...',
      },
      {
        id: 3,
        src: statisticSecondChat,
        title: 'Ой, смотри, продолжает расти!',
      },
    ],
  },
  {
    images: [
      {
        id: 1,
        src: rulePeople,
        title: 'Картинка соприкасающихся людей',
      },
      {
        id: 2,
        src: ruleChat,
        title: 'Мне не показалось? Ты меня сейчас потрогал?',
      },
      {
        id: 3,
        src: ruleSecondChat,
        title: 'Ладно, иду мыть руки...',
      },
    ],
  },
  {
    images: [
      {
        id: 1,
        src: openPeople,
        title: 'Картинка фотографирующих людей',
      },
      {
        id: 2,
        src: openChat,
        title:
          'Странно, что они не держат в секрете все свои, ну, секреты, ведь кто-то может узнать и...',
      },
      {
        id: 3,
        src: openSecondChat,
        title: 'Что, сделать так же? А это идея, давай.',
      },
    ],
  },
  {
    images: [
      {
        id: 1,
        src: dodoPeople,
        title: 'Картинка людей смотрящих на Додо',
      },
      {
        id: 2,
        src: dodoChat,
        title:
          'Эти создания восхитительны, какие утончённые линии, какая грация!',
      },
      {
        id: 3,
        src: dodoSecondChat,
        title: 'О боже, ровно это ты и обо мне говорил...',
      },
    ],
  },
];
