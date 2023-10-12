<template>
    <header>
        <div class="d-flex justify-content-between align-items-center h-100 container">
            <div><img src="../../public/logo-fotoalbum.jpg" alt="Logo" class="img-fluid"></div>
            <ul class="list-unstyled d-flex align-items-center gap-3 m-0">
                <li>Home</li>
                <li>Contatti</li>
                <li><a href="https://localhost:7069/">Dashboard</a></li>
            </ul>
            <div>
                <input type="text" name="filter" placeholder="Filtra le foto per nome" class="form-control">
            </div>
        </div>
    </header>
</template>
<script>
export default {
    name: 'HeaderApp',
    data() {
        return {

        }
    }
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