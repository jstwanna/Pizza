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

  vite: {
    css: {
      preprocessorOptions: {
        scss: {
          additionalData: `
        @import "./assets/scss/_variables.scss";
        @import "./assets/scss/_mixins.scss";
        `,
        },
      },
    },
  },

  nitro: {
    devProxy: {
      '/api': {
        target: 'https://localhost:7056/api/',
        changeOrigin: true,
        secure: false,
      },

      '/images': {
        target: 'https://localhost:7212/images/',
        changeOrigin: true,
        secure: false,
      },
    },
  },
});
