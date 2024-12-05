<script setup lang="ts">
import { sideBarLinks } from '../utils/constant';

const userStore = useUserStore();
</script>

<template>
  <header :class="['sidebar', { sidebar_collapsed: !userStore.isMenu }]">
    <nav>
      <ul class="sidebar__links">
        <li
          class="sidebar__link-container"
          v-for="link in sideBarLinks"
          :key="link.id"
        >
          <NuxtLink
            :to="link.link"
            class="sidebar__link"
            activeClass="sidebar__link_active"
          >
            <UIBaseIcon
              :name="link.icon"
              size="sm"
              :class="[
                'sidebar__icon',
                { 'sidebar__icon_menu-open': userStore.isMenu },
              ]"
            />
            <Transition name="fade">
              <span v-if="userStore.isMenu">
                {{ link.title }}
              </span>
            </Transition>
          </NuxtLink>
          <div v-if="!userStore.isMenu" class="sidebar__tooltip">
            {{ link.title }}
          </div>
        </li>
      </ul>
    </nav>
  </header>
</template>

<style scoped lang="scss">
.sidebar {
  width: 13.125rem;
  background-color: $white;
  transition: width 0.3s ease;

  &_collapsed {
    width: 5rem;
  }

  &__links {
    padding: 1.25rem 1rem;
  }

  &__link-container {
    position: relative;

    &:hover .sidebar__tooltip {
      display: block;
    }
  }

  &__link {
    border-radius: 624.9375rem;
    outline: 0;
    display: flex;
    align-items: center;
    min-height: 2.8125rem;
    text-decoration: none;
    color: $black;
    padding: 0.25rem 1rem 0.25rem 0.875rem;
    margin-bottom: 0.25rem;

    &:hover {
      color: $primary;
      background-color: $light-primary;
    }

    &_active {
      color: $white;
      background-color: $primary;
    }
  }

  &__icon {
    &_menu-open {
      margin-right: 0.8125rem;
    }
  }

  &__tooltip {
    font-size: $fs-xs;
    color: $white;
    background-color: $primary;
    position: absolute;
    top: 50%;
    left: 100%;
    margin-left: 1.65rem;
    transform: translateY(-50%);
    border-radius: 0.25rem;
    padding: 0.625rem;
    display: none;
    z-index: 9999;

    &::before {
      content: '';
      position: absolute;
      top: 50%;
      left: -1rem;
      transform: translateY(-50%);
      border-width: 0.5rem;
      border-style: solid;
      border-color: transparent $primary transparent transparent;
    }
  }
}

.fade-enter-active {
  transition: opacity 0.3s ease;
}

.fade-leave-active {
  transition: opacity 0s;
}

.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}

.fade-enter-to,
.fade-leave-from {
  opacity: 1;
}
</style>
