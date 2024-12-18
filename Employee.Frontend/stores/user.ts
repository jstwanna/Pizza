import type { IUser } from '../models/models';

export const useUserStore = defineStore('user', () => {
  const isMenu = ref<boolean>(false);
  const isAuthenticated = ref<boolean>(false);

  const user = ref<IUser | null>(null);

  const toggleMenu = () => {
    isMenu.value = !isMenu.value;
    localStorage.setItem('isMenu', isMenu.value.toString());
  };

  const setAuthentication = (value: boolean) => {
    isAuthenticated.value = value;
  };

  return {
    isMenu,
    isAuthenticated,
    user,
    toggleMenu,
    setAuthentication,
  };
});
