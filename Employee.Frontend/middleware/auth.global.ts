import { clearAuthCookies } from '../utils/clearCookies';

export default defineNuxtRouteMiddleware(async (to) => {
  const userStore = useUserStore();

  const user = useCookie('user');
  const loginTimestamp = useCookie('login-timestamp');

  if (user.value && loginTimestamp.value) {
    userStore.setAuthentication(true);

    const currentTime = Date.now();

    const tokenAge = currentTime - parseInt(loginTimestamp.value);

    if (tokenAge > 1 * 60 * 1000) {
      // await $fetch('/api/base/RefreshToken', {
      //   method: 'POST',
      // });

      loginTimestamp.value = Date.now().toString();
    }

    if (to.path === '/login') {
      return navigateTo('/');
    }
  } else {
    if ((!user.value || !loginTimestamp.value) && to.path !== '/login') {
      clearAuthCookies();

      return navigateTo('/login');
    }
  }
});
