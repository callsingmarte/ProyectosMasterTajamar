import React, { useEffect, useState } from "react"
import { useNavigate, useParams } from "react-router-dom"
import { RestDataSource } from "./webservice/RestDataSource"
import { ProductEditor } from "./product/ProductEditor"

export function IsolatedEditor()
{
    const { mode, id } = useParams()
    const navigate = useNavigate()
    //Esto es un hook, se compone de la variable y el metodo que lo va a manejar
    //donde la variable es dataItem y el metodo setDataItem
    const [dataItem, setDataItem] = useState({ name: "", category: "", price: "" })
    const dataSource = new RestDataSource("http://localhost:3500/products")
    //Al cargar datos usaremos este patron
    useEffect(() => {
        if (mode === "edit" && id) {
            dataSource.GetOne(id, data => setDataItem(data));
        }
    }, [mode, id])

    const save = (data) => {
        const callback = () => navigate("/isolated")
        if (!data.id) {
            dataSource.Store(data, callback)
        } else {
            dataSource.Update(data, callback)
        }
    }

    return (
        <ProductEditor
            key={dataItem.id || -1 }
            product={dataItem}
            saveCallback={save}
            cancelCallback={() => navigate("/isolated") }
        />
    )
}