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
