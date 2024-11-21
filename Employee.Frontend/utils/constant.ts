interface ISideBarLink {
  id: number;
  link: string;
  title: string;
  icon: string;
}

export const sideBarLinks: ISideBarLink[] = [
  {
    id: 1,
    link: '/products',
    title: 'Продукты',
    icon: 'inventory',
  },
  {
    id: 2,
    link: '/orders',
    title: 'Заказы',
    icon: 'library_books',
  },
  {
    id: 3,
    link: '/users',
    title: 'Пользователи',
    icon: 'group',
  },
];
