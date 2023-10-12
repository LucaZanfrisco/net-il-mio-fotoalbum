import { reactive } from 'vue'
import axios from 'axios';
import { compileScript } from 'vue/compiler-sfc';
export const store = reactive({
    searchText: "",
    photoList: [],
    textEmail: "",
    textMessage: "",
    responseStatus: 0,
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
        axios.post("https://localhost:7069/api/MessageApi/SendMessage", {
            email: this.textEmail,
            text: this.textMessage,
        }).then(response => {
            this.responseStatus = response.status
        }).catch(error =>{
            this.responseStatus = error.response.status
        })
    }
})