import { createWebHistory, createRouter } from 'vue-router';

import MainApp from './components/MainApp.vue';
import DetailApp from './components/DetailApp.vue';

const router = createRouter({
    history: createWebHistory(),
    routes: [
        {
            path: '/',
            name: "Home",
            component: MainApp
        },
        {
            path: '/photo/:id/:slug',
            name: 'Detail',
            component: DetailApp
        }
    ]
})

export { router };