// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: "2024-04-03",
  devtools: { enabled: true },
  nitro: {
    devProxy: {
      "/api": {
        target: "https://localhost:7056/",
        changeOrigin: true,
        secure: false,
      },
    },
  },
});
