export default defineNuxtRouteMiddleware((to) => {
  if (to.meta.title) {
    useHead({
      title: getPageTitle(to.meta.title as string),
    });
  }
});
