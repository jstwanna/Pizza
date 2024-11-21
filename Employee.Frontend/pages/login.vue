<script setup lang="ts">
import type { FormInstance, FormRules } from 'element-plus';

interface IRuleForm {
  name: string;
  password: string;
}

const loginFormRef = ref<FormInstance>();
const loginForm = reactive<IRuleForm>({
  name: '',
  password: '',
});

const rules = reactive<FormRules<IRuleForm>>({
  name: [
    {
      required: true,
      message: 'Пожалуйста, введите Ваше имя',
      trigger: 'blur',
    },
  ],
  password: [
    {
      required: true,
      message: 'Пожалуйста, введите пароль',
      trigger: 'blur',
    },
  ],
});

const handleLogin = async (formEl: FormInstance | undefined) => {
  if (!formEl) return;

  await formEl.validate((valid) => {
    if (valid) {
      console.log('submit!');
    }
  });
};

definePageMeta({
  title: 'Авторизация',
});
</script>

<template>
  <main class="login">
    <ElForm
      ref="loginFormRef"
      :model="loginForm"
      :rules="rules"
      class="login__form"
    >
      <h2 class="login__title">Авторизация</h2>
      <ElFormItem prop="name">
        <ElInput
          type="text"
          placeholder="Имя пользователя"
          autocomplete="off"
          v-model="loginForm.name"
          class="login__input"
        />
      </ElFormItem>
      <ElFormItem prop="password">
        <ElInput
          type="password"
          placeholder="Пароль"
          show-password
          autocomplete="off"
          v-model="loginForm.password"
          style="margin-top: 1rem"
          class="login__input"
        />
      </ElFormItem>
      <ElFormItem>
        <ElButton
          type="primary"
          @click="handleLogin(loginFormRef)"
          round
          class="login__button"
        >
          Войти
        </ElButton>
      </ElFormItem>
    </ElForm>
  </main>
</template>

<style scoped lang="scss">
.login {
  flex-grow: 1;

  &__form {
    position: relative;
    width: 32.5rem;
    max-width: 100%;
    padding: 10rem 2.1875rem 0;
    margin: 0 auto;
    overflow: hidden;
  }

  &__title {
    font-size: $fs-3xl;
    margin: 0 auto 2.5rem;
    text-align: center;
    font-weight: $fw-semibold;
  }

  &__button {
    width: 100%;
    margin-top: 1rem;
  }

  &__input-container {
    margin-top: 0.5rem;
  }

  &__input {
    margin-bottom: 0.25rem;
  }
}
</style>
