import type { IUser } from '../models/models';

export const user = ref<IUser | null>(null);
export const isUserLoggedIn = ref<boolean>(false);

export const isLoginPopup = ref<boolean>(false);
