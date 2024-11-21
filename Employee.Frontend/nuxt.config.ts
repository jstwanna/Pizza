// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: '2024-04-03',
  devtools: { enabled: true },

  css: ['./assets/scss/main.scss'],

  app: {
    head: {
      htmlAttrs: {
        lang: 'ru',
      },
      link: [{ rel: 'icon', type: 'image/svg+xml', href: '/logo.svg' }],
    },
  },

  modules: ['@pinia/nuxt', '@element-plus/nuxt'],

  pinia: {
    storesDirs: ['./stores/**'],
  },

  vite: {
    css: {
      preprocessorOptions: {
        scss: {
          api: 'modern-compiler',
          additionalData: `@use './assets/scss/_variables.scss' as *;`,
        },
      },
    },
  },

  routeRules: {
    '/': { redirect: '/products' },
  },
});
