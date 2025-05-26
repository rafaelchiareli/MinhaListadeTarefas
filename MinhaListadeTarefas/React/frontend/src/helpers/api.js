import axios from 'axios';

const Api = axios.create({
    withCredentials: false,
    baseURL: "https://localhost:7025/api"
})

export default Api;