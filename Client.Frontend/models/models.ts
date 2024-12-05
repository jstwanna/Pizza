export interface ICatalogItemListView {
  category: string;
  viewType: string;
  image: string;
  name: string;
  description: string;
  products: IProductListView[];
}

export interface IProductListView {
  id: number;
  price: number;
  productType: string;
  image: string;
  name: string;
  description: string;
  characteristics: ICharacteristicsListView[];
  additives: IAdditiveListView[];
}

export interface ICharacteristicsListView {
  name: string;
  value: number;
}

export interface IAdditiveListView {
  id: number;
  price: number;
  name: string;
  image: string;
}

export interface IGetCategoryListResponse {
  categories: string[];
}

export interface IContactLink {
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

export interface ITab {
  id: number;
  title: string;
  disabled?: boolean;
}

export interface ICounterItems<T> {
  count: number;
  price: number;
  additives: IAdditiveListView[];
  item: T;
}

export interface IUser {
  username: string;
  role: string;
}
