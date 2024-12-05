let openPopupsCount = ref<number>(0);

export const lockScroll = () => {
  openPopupsCount.value++;
  if (openPopupsCount.value === 1) {
    document.body.style.overflowY = 'hidden';
  }
};

export const unlockScroll = () => {
  openPopupsCount.value--;
  if (openPopupsCount.value <= 0) {
    openPopupsCount.value = 0;
    document.body.style.overflowY = 'auto';
  }
};
