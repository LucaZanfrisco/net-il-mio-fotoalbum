<template >
    <div class="container">
        <div>
            <img class="img-fluid w-100" :src="'data:image/png;base64,' + store.photoDetail.image"
                :alt="store.photoDetail.title">
            <h1 class="text-center">{{ store.photoDetail.title }}</h1>
            <div class="d-flex justify-content-center align-items-center gap-3 mt-4" id="tags">
                <div v-for="category in store.photoDetail.categories">{{ category.name }}
                </div>
            </div>
        </div>
        <hr class="mt-4">
        <p class="text-center"><em>{{ store.photoDetail.description }}</em></p>


    </div>
</template>
<script>
import { store } from '../store';

export default {
    name: "Detail",
    data() {
        return {
            store,
        }
    }
}
</script>
<style lang="scss" scoped>
.container {
    padding-top: 150px;
    padding-bottom: 50px;

    div {
        position: relative;
        #tags{
            position: absolute;
            bottom: 6px;
            right: 10px;
            div{
                background-color: transparent;
                border: 1px solid wheat;
                color: white;
                font-weight: bold;
                padding: 5px 10px;
                border-radius: 50px;
                letter-spacing: 1px;
            }
        }
        img {
            border-radius: 25px;
        }

        h1 {
            position: absolute;
            z-index: 1;
            top: -20px;
            left: 50%;
            transform: translate(-50%, 0);
            background-color: white;
            padding: 10px 20px;
            border-radius: 50px;
        }
    }


}</style>