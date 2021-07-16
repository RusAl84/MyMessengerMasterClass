import Axios from 'axios'

const axios = Axios.create({
    baseURL: 'http://localhost:5000',
})

export default class API {
    // Получает сообщение по id
    static async getMessage(id) {
        const resp = await axios.get(`/api/mes/${id}`)
        return resp.data
    }

    // Отправка сообщения
    static async sendMessage(userName, messageText) {
        await axios.post(`/api/mes`, {
            messageText, // text: text
            userName,
        })
    }
}
