<script setup lang="ts">
interface IBreadcrumbItem {
  path: string;
  title: string;
}

const route = useRoute();

const breadcrumbs = computed(() => {
  const breadcrumbItems: IBreadcrumbItem[] = [];

  const matchedRoutes = route.matched;

  matchedRoutes.forEach((route) => {
    const title = (route.meta.title as string) || 'Домашняя';

    breadcrumbItems.push({
      path: route.path,
      title,
    });
  });

  return breadcrumbItems;
});
</script>

<template>
  <el-breadcrumb separator="/" class="header__breadcrumb">
    <TransitionGroup name="breadcrumb">
      <el-breadcrumb-item
        v-for="breadcrumb in breadcrumbs"
        :key="breadcrumb.path"
        :to="{ path: breadcrumb.path }"
      >
        {{ breadcrumb.title }}
      </el-breadcrumb-item>
    </TransitionGroup>
  </el-breadcrumb>
</template>

<style scoped lang="scss">
.breadcrumb-enter-active,
.breadcrumb-leave-active {
  transition: all 0.3s ease-in-out;
}

.breadcrumb-enter,
.breadcrumb-leave-to {
  opacity: 0;
  transform: translateX(1.25rem);
}

.breadcrumb-enter-to,
.breadcrumb-leave {
  opacity: 1;
  transform: translateX(0);
}

.breadcrumb-move {
  transition: all 0.3s ease-in-out;
}
</style>
