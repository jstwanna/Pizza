<script setup lang="ts">
const handleLogout = () => {
  console.log('logout');
};
</script>

<template>
  <section class="bonus" id="client-bonuses">
    <div class="bonus__content">
      <h2 class="bonus__title">Бонусы</h2>
      <div class="bonus__cards">
        <BonusCard />
      </div>
      <UIBaseLink to="profile#" class="bonus__link">Все наши акции</UIBaseLink>
    </div>
  </section>

  <section class="profile" id="personal-data">
    <div class="profile__content">
      <h2 class="profile__title">Личные данные</h2>
      <div class="profile__info">
        <span class="profile__label">Номер телефона</span>
        <div class="profile__phone">+7 926 913 78 03</div>
      </div>
    </div>
    <h2 class="profile__title profile__title_type_order">История заказов</h2>
    <span class="profile__no-orders">Последние 90 дней заказов не было</span>
    <div>
      <UIBaseButton type="button" class="profile__logout" @click="handleLogout">
        Выйти
      </UIBaseButton>
    </div>
  </section>
</template>

<style scoped lang="scss">
.bonus {
  padding-top: 2.75rem;

  &__content {
    overflow: hidden;
    width: 100%;
    padding: 2rem calc(50% - 40rem);
    background-color: $gray;

    @media screen and (max-width: 80rem) {
      padding: 2rem calc(50% - 30rem);
    }
  }

  &__title {
    margin-bottom: 1.5rem;
    font-size: $fs-2xl;
    font-weight: $fw-semibold;
    line-height: 1.75rem;
  }

  &__cards {
    padding-top: 0.5625rem;
    padding-bottom: 1.25rem;
  }

  &__link {
    color: $orange;
    font-weight: $fw-medium;
    margin-top: 1.5rem;
    font-size: $fs-sm;

    &:hover {
      color: $dark-orange;
    }
  }
}

.profile {
  @include container;
  margin-top: -2rem;
  padding: 4rem 0.25rem 7.5rem;
  @include responsive-width;

  &__content {
    width: 22rem;
    margin-bottom: 3.25rem;
  }

  &__title {
    margin-bottom: 1.75rem;
    font-weight: $fw-medium;
    font-size: $fs-2xl;

    line-height: 1.75rem;

    &_type {
      &_order {
        margin-bottom: 0.5rem;
      }
    }
  }

  &__label {
    display: block;
    color: $dark-gray;
    margin-bottom: 0.25rem;
    font-weight: $fw-medium;
    font-size: $fs-sm;
    line-height: 1.125rem;
  }

  &__phone {
    display: block;
    outline: none;
    height: 3rem;
    padding: 0.875rem 1rem;
    border-radius: 0.75rem;
    cursor: not-allowed;
    width: 100%;
    border: 0.0625rem solid hsl(240, 14%, 90%);
    background-color: $gray;
    color: $dark-gray;
    font-size: $fs-base;
    line-height: 1.25rem;
    font-weight: $fw-medium;
  }

  &__no-orders {
    font-size: $fs-sm;
    line-height: 1.25rem;
    color: $dark-gray;
    margin-bottom: 1rem;
  }

  &__logout {
    margin-top: 5.125rem;
    height: 2.5rem;
    padding: 0.5rem 1.25rem;
    background-color: $gray;
    color: $dark-gray;

    &:hover {
      color: $black;
    }
  }
}
</style>
