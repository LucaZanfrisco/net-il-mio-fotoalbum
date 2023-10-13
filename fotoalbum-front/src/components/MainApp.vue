<template >
    <main class="container">
        <div v-if="store.photoList.length === 0">
            <div class="alert alert-danger">Nessuna foto trovata</div>
        </div>
        <ul v-else class="list-unstyled row row-cols-1 row-cols-md-2 row-cols-lg-3 row-cols-xxl-4 text-center gy-2">
            <li v-for="photo in store.photoList">
                <router-link :to="{name: 'Detail', params:{id:photo.id, slug: photo.title }}" class="card text-decoration-none" @click="store.getPhotoDetail(photo.id)">
                    <img :src="'data:image/png;base64,' + photo.image" :alt="photo.title" class="img-fluid">
                    <h3 class="py-3">{{ photo.title }}</h3>
                    <p><em>{{ photo.description }}</em></p>
                </router-link>
            </li>
        </ul>
    </main>
</template>
<script>
import { store } from '../store.js'
export default {
    name: 'MainApp',
    data() {
        return {
            store
        }
    },
    beforeMount() {
        store.getAllPhotos()
    }
}
</script>
<style lang="scss" scoped>
main {
    padding-top: 100px;
}
.card{
    height: 100%;
    &:hover{
        cursor: pointer;
    }
    img{
        aspect-ratio: 3/2;
    }
}
</style>