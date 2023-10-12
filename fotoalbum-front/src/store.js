import { reactive } from 'vue'
import axios from 'axios';
import { compileScript } from 'vue/compiler-sfc';
export const store = reactive({
    searchText: "",
    photoList: [],
    textEmail: "",
    textMessage: "",
    searchPhoto(){
        axios.get('https://localhost:7069/api/PhotoApi/GetPhotosByTitle', {
            params: {
                search: this.searchText
            }
        }).then(response => {
            this.photoList = response.data;
        })
    },
    getAllPhotos() {
        axios.get('https://localhost:7069/api/PhotoApi/GetAllPhotos')
            .then(response => {
                this.photoList = response.data
            }).catch(error => {
                console.log(error)
            })
    },
    sendMessage(){
        axios.post("https://localhost:7069/api/PhotoApi/Message", {
            email: this.textEmail,
            message: this.textMessage,
        }).then(response => {
            console.log(response)
        })
    }
})