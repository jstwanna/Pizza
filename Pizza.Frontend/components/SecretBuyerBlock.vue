<script setup lang="ts">
import secretBuyer from '../assets/svg/secretBuyer.svg';
</script>

<template>
  <div class="secret">
    <div class="secret__container">
      <img
        :src="secretBuyer"
        alt="Секретный покупатель"
        class="secret__image"
      />
      <p class="secret__text">
        Проверьте нашу кухню и получите додокоины — хватит на две пиццы
      </p>
      <UIBaseLink to="/control" class="secret__link" target="_blank">
        Заполнить анкету
      </UIBaseLink>
    </div>
  </div>
</template>

<style scoped lang="scss">
.secret {
  color: $white;
  background-color: $orange;

  &__container {
    height: 3.75rem;
    display: flex;
    align-items: center;
    max-width: 80rem;
    margin-left: auto;
    margin-right: auto;
  }

  &__image {
    display: block;
    width: 3rem;
    height: 3.125rem;
    margin-right: 1.25rem;
  }

  &__text {
    font-weight: $fw-medium;
    font-size: $fs-lg;
    margin-right: auto;
  }

  &__link {
    color: $orange;
    background-color: $pink;
    border-radius: 624.9375rem;
    font-size: $fs-base;
    height: 2.5rem;
    padding: 0.5rem 1.25rem;
    line-height: 1.5rem;

    &:hover {
      background-color: $light-pink;
    }

    &:active {
      opacity: 0.5;
    }
  }
}
</style>
