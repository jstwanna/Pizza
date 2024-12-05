import { isUserLoggedIn } from '../utils/userHelper';

export default defineNuxtRouteMiddleware((to, from) => {
  if (!isUserLoggedIn.value) {
    return navigateTo('/');
  }
});
