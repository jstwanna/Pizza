<script setup lang="ts">
import bonus from '../assets/images/037a3fb78d87f378fd10..jpg';
</script>

<template>
  <article class="bonus-card">
    <img :src="bonus" alt="Фото бонуса" />
    <p class="bonus-card__description">Здесь будут ваши акции</p>
  </article>
</template>

<style scoped lang="scss">
.bonus-card {
  flex: 0 0 auto;
  width: 15rem;
  height: 22.5rem;
  background: $white;
  box-shadow: $black-100 0 0.375rem 1.25rem;
  border-radius: 1rem;
  text-align: center;
  margin-right: 1.5rem;
  padding: 1.5rem;
  display: flex;
  flex-flow: column;
  -webkit-box-pack: justify;
  justify-content: space-between;
  position: relative;
  cursor: pointer;

  &__description {
    color: rgb(92, 99, 112);
    font-size: $fs-base;
    line-height: 1.5rem;
    font-weight: $fw-medium;
    margin-bottom: 3.25rem;
  }
}
</style>
