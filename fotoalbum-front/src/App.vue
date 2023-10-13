<script>
import HeaderApp from './components/HeaderApp.vue';
import { router } from './router';

export default{
  name: 'App',
  components: {
    HeaderApp,
  }
}
</script>

<template>
  <HeaderApp></HeaderApp>
  <router-view></router-view>
</template>

<style scoped>
</style>
