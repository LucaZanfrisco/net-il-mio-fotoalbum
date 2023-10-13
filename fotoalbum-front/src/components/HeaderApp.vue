<template>
    <header>
        <div class="d-flex justify-content-between align-items-center h-100 container">
            <div><img src="../../public/logo-fotoalbum.jpg" alt="Logo" class="img-fluid"></div>
            <ul class="list-unstyled d-flex align-items-center gap-3 m-0">
                <li><router-link :to="{name: 'Home'}">Home</router-link></li>
                <li>Contatti</li>
                <li><a href="https://localhost:7069/">Dashboard</a></li>
                <li> 
                    <button class="btn btn-primary" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRight" aria-controls="offcanvasRight">Messaggio</button>
                </li>
            </ul>
            <div>
                <input v-model="store.searchText" @keyup="store.searchPhoto()" type="text" name="filter" placeholder="Filtra le foto per nome" class="form-control">
            </div>
        </div>
       

<div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasRight" aria-labelledby="offcanvasRightLabel">
  <div class="offcanvas-header">
    <h5 class="offcanvas-title" id="offcanvasRightLabel">Invia un Messaggio</h5>
    <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
  </div>
  <div class="offcanvas-body">
    <form action="" method="post">
        <div v-if="store.responseStatus === 400" class="alert alert-danger">Compilare tutti i campi</div>
        <div v-if="store.responseStatus === 200" class="alert alert-success">Messagio inviato con successo</div>
        <div class="my-2">
            <label for="email" class="form-label fs-4 fw-bold">Email</label>
            <input type="email" name="email" class="form-control" v-model="store.textEmail">
        </div>
        <div class="my-2">
            <label for="message" class="form-label fs-4 fw-bold">Messaggio</label>
            <textarea rows="5" type="text" name="message" class="form-control" v-model="store.textMessage"></textarea>
        </div>
        <button type="button"  @click="store.sendMessage()" class="btn btn-success">Invia</button>
    </form>
  </div>
</div>
    </header>
</template>
<script>

import { store } from '../store.js'
export default {
    name: 'HeaderApp',
    data() {
        return {
            store
        }
    },
}
</script>
<style lang="scss" scoped>
header {
    height: 85px;
    background-color: white;
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    z-index: 2;
    border-bottom: 1px solid lightgrey;
    div{
        img{
            height: 75px;
        }
    }
    a{
        text-decoration: none;
        color: black;
        &:hover{
            cursor: pointer;
            color: red;
        }
    }
}
</style>