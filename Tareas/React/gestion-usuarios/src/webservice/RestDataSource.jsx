import Axios from "axios"

export class RestDataSource {
    constructor(base_url) {
        this.BASE_URL = base_url
    }

    GetData(callback) {
        this.SendRequest("get", this.BASE_URL, callback)
    }

    async GetOne(id, callback) {
        this.SendRequest("get", `${this.BASE_URL}/${id}`, callback)
    }

    async Store(data, callback) {
        const userToSave = { ...data }
        if (!userToSave.id) {
            delete userToSave.id
        }
        this.SendRequest("post", this.BASE_URL, callback, userToSave)
    }

    async Update(data, callback) {
        this.SendRequest("put", `${this.BASE_URL}/${data.id}`, callback, data)
    }

    async Delete(data, callback) {
        this.SendRequest("delete", `${this.BASE_URL}/${data.id}`, callback, data)
    }

    async SendRequest(method, url, callback, data)
    {
        let response = await Axios.request({
            method: method,
            url: url,
            data: data
        })

        callback(response.data)
    }
}