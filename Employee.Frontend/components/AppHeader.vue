<script setup lang="ts">
import { clearAuthCookies } from '../utils/clearCookies';

const userStore = useUserStore();
const router = useRouter();

const handleLogout = async () => {
  await $fetch('/api/base/Logout', {
    method: 'POST',
  });

  clearAuthCookies();
  router.push('/login');
};    

onMounted(() => {
  const savedMenuState = localStorage.getItem('isMenu');
  userStore.isMenu = savedMenuState === 'true';
});
</script>

<template>
  <header class="header">
    <UIBaseIcon
      :name="userStore.isMenu ? 'arrow_menu_close' : 'arrow_menu_open'"
      size="sm"
      class="header__menu-icon"
      @click="userStore.toggleMenu"
    />
    <UIBaseBreadcrumbs />
    <ElButton type="primary" style="margin-left: auto" @click="handleLogout">
      Выйти
    </ElButton>
  </header>
</template>

<style scoped lang="scss">
.header {
  display: flex;
  align-items: center;
  height: 3.125rem;

  &__menu-icon {
    cursor: pointer;
    height: 1.5rem;
    width: 1.5rem;
    transition: all 0.35s linear;

    &:hover {
      opacity: 0.6;
    }
  }

  &__image {
    cursor: pointer;
    border-radius: 0.625rem;
    height: 2.5rem;
    width: 2.5rem;
    margin-left: auto;
  }

  &__breadcrumb {
    margin-left: 1.4375rem;
  }

  &__links {
    display: flex;
    padding-top: 0.25rem;
    padding-bottom: 0.25rem;
    border-bottom: 0.0625rem solid $gray;
    border-top: 0.0625rem solid $gray;
  }

  &__link-container {
    height: 1.625rem;
    line-height: 1.625rem;
    border: 0.0625rem solid $gray;
    font-size: $fs-xs;
    margin-left: 0.3125rem;

    &:first-child {
      margin-left: 1.25rem;
    }
  }
}
</style>
