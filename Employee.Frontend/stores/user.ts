export const useUserStore = defineStore('user', () => {
  const isMenu = ref<boolean>(false);

  const toggleMenu = () => {
    isMenu.value = !isMenu.value;
    localStorage.setItem('isMenu', isMenu.value.toString());
  };

  onMounted(() => {
    const savedMenuState = localStorage.getItem('isMenu');
    isMenu.value = savedMenuState === 'true';
  });

  return {
    isMenu,
    toggleMenu,
  };
});
