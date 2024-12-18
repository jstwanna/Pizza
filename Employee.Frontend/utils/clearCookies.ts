export const clearAuthCookies = () => {
  const user = useCookie('user');
  const loginTimestamp = useCookie('login-timestamp');

  if (user.value) user.value = null;
  if (loginTimestamp.value) loginTimestamp.value = null;
};
