<template >
    <main class="container">
        <ul class="list-unstyled row row-cols-1 row-cols-md-2 row-cols-lg-3 row-cols-xxl-4 text-center gy-2">
            <li v-for="photo in photoslist">
                <div class="card">
                    <img :src="'data:image/png;base64,' + photo.image" :alt="photo.title" class="img-fluid">
                    <h3 class="py-3">{{ photo.title }}</h3>
                    <p><em>{{ photo.description }}</em></p>
                </div>
            </li>
        </ul>
    </main>
</template>
<script>
import axios from 'axios';
export default {
    name: 'MainApp',
    data() {
        return {
            photoslist: null,
        }
    },
    methods: {
        getAllPhotos() {
            axios.get('https://localhost:7069/api/PhotoApi/GetAllPhotos')
                .then(response => {
                    this.photoslist = response.data
                }).catch(error => {
                    console.log(error)
                })
        }
    },
    beforeMount() {
        this.getAllPhotos();
    }
}
</script>
<style lang="scss" scoped>
main {
    padding-top: 100px;
}
</style>