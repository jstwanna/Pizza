const title = 'Додо Админка';

export const getPageTitle = (pageTitle: string) => {
  if (pageTitle) {
    return `${pageTitle} - ${title}`;
  }

  return `${title}`;
};
