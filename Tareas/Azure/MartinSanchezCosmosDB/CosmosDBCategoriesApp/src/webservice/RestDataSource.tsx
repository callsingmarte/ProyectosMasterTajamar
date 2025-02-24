import Axios from "axios"
import { Category } from "../models/categoryModel";
export class RestDataSource {

    private BASE_URL: string;

    constructor(base_url: string) {
        this.BASE_URL = base_url
    }

    GetData(callback: Function) {
        this.SendRequest("get", this.BASE_URL, callback);
    }

    async GetOne(id: string, partialKey: string, callback: Function) {
        this.SendRequest("get", `${this.BASE_URL}/${id}?categoryID=${partialKey}`, callback)
    }

    async Store(data: FormData, callback: Function) {
        this.SendRequest("post", this.BASE_URL, callback, data, { "Content-Type": "multipart/form-data" })
    }

    async Update(id: string, data: FormData, callback : Function) {
        this.SendRequest("put", `${this.BASE_URL}/${id}`, callback, data, { "Content-Type": "multipart/form-data" })
    }

    async Delete(data: Category, callback : Function) {
        this.SendRequest("delete", `${this.BASE_URL}/${data.id}?categoryID=${data.categoryID}`, callback, data)
    }

    async SendRequest(method: string, url: string, callback: Function, data?: any, headers?: any)
    {
        let response = await Axios.request({
            method: method,
            url: url,
            data: data,
            headers: headers
        })

        callback(response.data)
    }

}