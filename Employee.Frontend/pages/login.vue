<script setup lang="ts">
import type { FormInstance, FormRules } from 'element-plus';
import type { IUser } from '../models/models';

interface IRuleForm {
  login: string;
  password: string;
}

const userStore = useUserStore();

const loginFormRef = ref<FormInstance>();
const loginForm = reactive<IRuleForm>({
  login: '',
  password: '',
});
const isFormLoading = ref<boolean>(false);

const rules = reactive<FormRules<IRuleForm>>({
  login: [
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

const router = useRouter();

const handleLogin = async (formEl: FormInstance | undefined) => {
  await apiFetch({
    path: 'employee/LoginEmployee',
    body: {
      login: 'admin',
      password: 'admin',
    },
  });

  const get = await apiFetch<IUser>({
    path: 'base/GetUserInfo',
    returnContent: true,
  });

  console.log(get.role);

  // if (!formEl) return;

  // await formEl.validate(async (valid) => {
  //   if (valid) {
  //     isFormLoading.value = true;

  //     try {
  //       await $fetch('/api/employee/LoginEmployee', {
  //         method: 'POST',
  //         body: {
  //           login: loginForm.login,
  //           password: loginForm.password,
  //         },
  //       });

  //       const loginTimestamp = useCookie('login-timestamp', {
  //         maxAge: 60 * 60 * 24 * 30,
  //       });
  //       loginTimestamp.value = Date.now().toString();

  //       const currentUser = await $fetch<IUser>('/api/base/GetUserInfo', {
  //         method: 'POST',
  //       });

  //       userStore.setAuthentication(true);
  //       const user = useCookie('user', {
  //         maxAge: 60 * 60 * 24 * 30,
  //       });
  //       user.value = JSON.stringify(currentUser);

  //       userStore.user = currentUser;
  //       router.push('/');
  //     } catch {
  //       console.error('Login error');
  //     } finally {
  //       isFormLoading.value = false;
  //     }
  //   }
  // });
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
      <ElFormItem prop="login">
        <ElInput
          type="text"
          placeholder="Имя пользователя"
          autocomplete="off"
          v-model="loginForm.login"
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
          :loading="isFormLoading"
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
    background-color: $white;
    width: 32.5rem;
    max-width: 100%;
    padding: 2.1875rem 2.1875rem 1.0625rem;
    margin: 10rem auto 0;
    border-radius: 0.25rem;
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
