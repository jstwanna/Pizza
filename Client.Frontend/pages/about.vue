<script setup lang="ts">
import statistic from '../assets/svg/statistic.svg';
import rule from '../assets/svg/rule.svg';
import open from '../assets/svg/open.svg';
import dodo from '../assets/svg/aboutDodo.svg';
import book from '../assets/svg/book.svg';

import { ingredientItems, testimonialItems } from '../utils/constants';

useHead({
  title:
    '🍕 О нас | Додо Пицца Москва | Сеть пиццерий №1 в России по количеству пиццерий',
});
</script>

<template>
  <section class="section about">
    <h2 class="section__title">Мы</h2>
    <p class="section__text">
      {{
        `Обычно люди приходят в Додо Пиццу, чтобы просто поесть. Наши промоутеры раздают листовки про кусочек пиццы за двадцать рублей или ещё что-то выгодное. Мы делаем это как первый шаг, чтобы познакомиться. 
      
      Но для нас Додо — не только пицца. Это и пицца тоже, но в первую очередь это большое дело, которое вдохновляет нас, заставляет каждое утро просыпаться и с интересом продолжать работу. 
      
      В чём же наш интерес? Сейчас расскажем.`
      }}
    </p>
    <TestimonialImages :images="testimonialItems[0]" :isMan="true" />
  </section>

  <section class="section ingredient">
    <h3 class="section__subtitle">Идеальные ингредиенты</h3>
    <p class="section__text">
      {{
        `
      Почему мы так хотим познакомиться? Потому что дальше пицца делает всё сама. Люди видят, что она вкусная, и возвращаются снова. Нам главное первый раз это показать. 
      
      Вообще пицца — очень простая штука, её сложно испортить. Достаточно хороших ингредиентов и правильного теста. Это конструктор, если детали качественные, то и результат будет в порядке. Вот они, наши детали: 
      `
      }}
    </p>
    <div class="ingredient__cards">
      <div
        v-for="ingredient in ingredientItems"
        :key="ingredient.id"
        class="ingredient__card"
      >
        <h4 class="ingredient__title">{{ ingredient.title }}</h4>
        {{ ingredient.text }}
      </div>
    </div>
    <TestimonialImages :images="testimonialItems[1]" />
  </section>

  <section class="section">
    <h2 class="section__subtitle">Одинаково вкусно в Москве и Сыктывкаре</h2>
    <p class="section__text">
      Кто угодно может сделать вкусную пиццу. А шеф-повар итальянского ресторана
      сделает и вовсе шедевр. Он молодец. Но представьте, что вам нужно сделать
      вкусную пиццу в сотнях пиццерий, за сотни километров друг от друга. Это
      наш случай, у нас их вон уже сколько:
    </p>
    <img
      :src="statistic"
      alt="Рост сети в 2011-2022 год, график"
      class="section__main-image"
    />
    <TestimonialImages :images="testimonialItems[2]" />
    <p class="section__text">
      {{
        `Пицца должна быть вкусной и везде одинаковой. Пиццерии должны быть одинаково уютными, кассиры неизменно приветливыми, а курьеры — расторопными. 
      
      И это как раз сложно. Но мы умеем!`
      }}
    </p>
  </section>

  <section class="section">
    <h2 class="section__subtitle">Единые стандарты</h2>
    <p class="section__text">
      Цифровые технологии помогают нам вовремя замечать, если что-то идёт
      неправильно. Но как понять, что правильно, а что нет? Для этого у нас есть
      стандарты. Вот, например, про мытьё рук:
    </p>
    <img :src="rule" alt="Правило про мытьё рук" class="section__main-image" />
    <TestimonialImages
      :images="testimonialItems[3]"
      class="section__testimonial_man-hands"
    />
    <p class="section__text">
      Наши стандарты — это не какие-то заумные схемы и формулы, а супер-понятные
      правила. У нас их сотни, буквально про всё. Именно так мы умудряемся
      делать всё хорошо и одновременно быстро расти.
    </p>
  </section>

  <section class="section">
    <h2 class="section__subtitle">Открытость во всём</h2>
    <p class="section__text">
      {{
        `Кто угодно может написать сотню правил, но само по себе это не работает. Нужна сила, благодаря которой стандарты будут соблюдаться. Для нас этой силой стала открытость. Мы сделали всё настолько прозрачным, что отступать от стандартов просто не получается.
      
        В чём конкретно это проявляется?`
      }}
    </p>
    <img
      :src="open"
      alt="Информация о Додо про кухню, контроль и бизнес"
      class="section__main-image"
    />
    <TestimonialImages
      :images="testimonialItems[4]"
      class="section__testimonial_man-hands"
    />
    <p class="section__text">
      Именно открытость заставляет нас выполнять обещания, соблюдать стандарты и
      работать строго в рамках закона. Но открытость для нас — не просто модный
      тренд. Это наше глубокое убеждение, философия и ценность, которую мы хотим
      нести миру.
    </p>
  </section>

  <section class="section">
    <h2 class="section__subtitle">Почему Додо</h2>
    <p class="section__text">
      Знаете почему мы называемся в честь этой странной птицы? Додо, или
      маврикийские дронты, были очень доверчивыми и наивными, и вымерли в конце
      семнадцатого века с приходом колонизаторов.
    </p>
    <div class="section__image-container">
      <img :src="dodo" alt="Фото на витрине Додо" class="section__main-image" />
    </div>
    <TestimonialImages :images="testimonialItems[5]" />
    <p class="section__text">
      {{
        `Жаль, что маврикийские дронты не дожили до сегодняшнего дня. Мы уверены: сейчас доверие, отзывчивость и открытость — серьёзные конкурентные преимущества. Именно благодаря открытости и доверию, мы смогли за семь лет стать самой крупной сетью пиццерий в России. Звучит как парадокс, но мы видим в этом закономерность. 
      
      Мы хотим жить и работать в мире, где люди доверяют друг другу. Мы создаём такой мир, делая очень простой и приземлённый продукт: пиццу. Это лишь способ жить так, как мы хотим!`
      }}
    </p>
  </section>

  <section class="section gallery">
    <img
      src="https://cdn.dodostatic.net/site-static/dist/assets/ee76bdcf48c5180b49a3..jpg"
      alt="Фото со спины у кассы"
      class="gallery__image gallery__image_full"
    />
    <div class="gallery__row">
      <img
        src="https://cdn.dodostatic.net/site-static/dist/assets/e94f688596908bcfad09..jpg"
        alt="Люди веселятся на кухне"
        class="gallery__image gallery__image_half"
      />
      <img
        src="https://cdn.dodostatic.net/site-static/dist/assets/1bd251798ebb3bd14034..jpg"
        alt="Фото девушки у кассы спереди"
        class="gallery__image gallery__image_half"
      />
    </div>
    <img
      src="https://cdn.dodostatic.net/site-static/dist/assets/c17c2ace9e36be315457..jpg"
      alt="Бурная работа на кухне"
      class="gallery__image gallery__image_full"
    />
    <img
      src="https://cdn.dodostatic.net/site-static/dist/assets/c3a45c0939988faa6967..jpg"
      alt="Ребёнок ест пиццу"
      class="gallery__image gallery__image_width-eighty gallery__image_right"
    />
    <div class="gallery__row">
      <img
        src="https://cdn.dodostatic.net/site-static/dist/assets/c53cf3ec823e6a7193a6..jpg"
        alt="Люди едят"
        class="gallery__image gallery__image_half"
      />
      <img
        src="https://cdn.dodostatic.net/site-static/dist/assets/16c0e8b6d4b94bae080a..jpg"
        alt="Девочка ждёт у прилавка"
        class="gallery__image gallery__image_half"
      />
    </div>
    <img
      src="https://cdn.dodostatic.net/site-static/dist/assets/2b4b63d9c3466cc0884e..jpg"
      alt="Девочка с шариками около стены"
      class="gallery__image gallery__image_width-eighty gallery__image_left"
    />
  </section>

  <section class="section book">
    <p class="section__text">
      Если вы испытываете похожие чувства — прочитайте нашу книгу, и может быть
      мы станем друзьями. Если считаете, что это полная ерунда и так не бывает —
      всё равно прочитайте и расскажите, что думаете.
    </p>

    <div class="book__container" @click="$router.push({ hash: '#' })">
      <UIBaseLink to="#" class="book__link">Читать</UIBaseLink>
      <img :src="book" alt="Книга додо" class="book__image" />
    </div>
  </section>
</template>

<style scoped lang="scss">
.section {
  @include container;
  @include responsive-width;
  margin-bottom: 6.875rem;

  &__title {
    font-size: $fs-5xl;
    line-height: 3.75rem;
    font-weight: $fw-normal;
    padding-top: 3.75rem;
    margin-bottom: 2.6975rem;
  }

  &__subtitle {
    font-size: calc($fs-3xl + 0.3125rem);
    line-height: 1.608125rem;
    letter-spacing: 0.02em;
    margin-top: 1.608125rem;
    margin-bottom: 1.608125rem;
  }

  &__text {
    font-size: $fs-lg;
    font-weight: $fw-medium;
    line-height: 1.625rem;
    width: 75%;
    white-space: pre-line;
    margin-top: 1.125rem;
    margin-bottom: 1.125rem;
  }

  &__main-image {
    width: 75%;
    margin-top: 1.875rem;
    margin-bottom: 1.875rem;
  }

  &__testimonial {
    &_man-hands {
      bottom: -7.5rem;
    }
  }

  &__image-container {
    width: 75%;
  }
}

.ingredient {
  &__cards {
    display: flex;
    gap: 0.9375rem;
    flex-wrap: wrap;
    width: 75%;
    margin: 1.875rem 0;
  }

  &__card {
    font-weight: $fw-medium;
    width: 45%;
    border-radius: 0.625rem;
    background: $light-amber;
    padding: 1.625rem 2.1875rem 2.4375rem 1.625rem;
    font-size: calc($fs-lg + 0.0625rem);
  }

  &__title {
    color: $amber;
    font-size: calc($fs-3xl + 0.375rem);
    font-weight: $fw-semibold;
    letter-spacing: 0.02em;
  }
}

.gallery {
  &__image {
    margin-bottom: 0.625rem;
    max-width: 100%;
    border-radius: 0.5rem;

    &_full {
      width: 100%;
    }

    &_half {
      width: 50%;
    }

    &_width-eighty {
      width: 80%;
    }

    &_right {
      margin-left: 20%;
    }

    &_left {
      margin-right: 20%;
    }
  }

  &__row {
    display: flex;
    gap: 0.625rem;
    height: 23.625rem;
  }
}

.book {
  &__container {
    cursor: pointer;
    position: relative;

    &:hover {
      .book__link {
        background-color: $second-orange;
      }
    }
  }

  &__link {
    font-size: $fs-lg;
    font-weight: $fw-medium;
    position: absolute;
    top: 77%;
    left: 51%;
    padding: 0.9375rem 3.125rem;
    letter-spacing: 0.03em;
    color: $white;
    background-color: $orange;
    transform: perspective(62.5rem) rotate(-27deg) skew(27deg) translate(0, 0);
    box-shadow: $light-orange -0.3125rem 0.25rem;
    margin-top: 0.4375rem;
    border-radius: 0.5rem;
  }

  &__image {
    width: 75%;
    margin: 4.0625rem auto;
    position: relative;
    backface-visibility: hidden;
  }
}
</style>
