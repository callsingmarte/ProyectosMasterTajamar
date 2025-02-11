//Ejemplo hook
//const [counter, setCounter] = useState(0)

import { useState, useEffect } from "react"
import axios from 'axios'
import { Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap"

function App() {
    const baseUrl = "https://localhost:44326/Products_DB"
    const [data, setData] = useState([])
    const [modalInsertar, setModalInsertar] = useState(false)
    const [modalEditar, setModalEditar] = useState(false)
    const [productSelected, setProductSelected] = useState({ id: "", name: "", category: "", price: "" })
    const [modalEliminar, setModalEliminar] = useState(false)

    const toggleModalInsertar = () => setModalInsertar(!modalInsertar)
    const toggleModalEditar = () => setModalEditar(!modalEditar)
    const toggleModalEliminar = () => setModalEliminar(!modalEliminar)

    const handleChange = (e) => {
        const { name, value } = e.target
        setProductSelected({ ...productSelected, [name]: value })
    }

    const fetchProducts = async () => {
        try {
            const response = await axios.get(baseUrl)
            setData(response.data)
        } catch (error) {
            console.error(error)
        }
    }

    const selectProduct = (product, action) => {
        setProductSelected(product)
        action === "Editar" ? toggleModalEditar() : toggleModalEliminar()
    }

    const addProduct = async () => {
        try {
            const { id, ...newProduct } = productSelected
            const response = await axios.post(baseUrl, newProduct)
            setData([...data, response.data])
            toggleModalInsertar()
        } catch(error){
            console.error(error)
        }
    }

    const updateProduct = async () => {
        try {
            await axios.put(`${baseUrl}/${productSelected.id}`, productSelected)
            setData(data.map((p) => (p.id === productSelected.id ? productSelected : p)))
        } catch (error) {
            console.error(error)
        }
    }

    const deleteProduct = async () => {
        try {
            await axios.delete(`${baseUrl}/${productSelected.id}`)
            setData(data.filter((p) => p.id !== productSelected.id))
            toggleModalEliminar()
        } catch (error) {
            console.error(error)
        }
    }

    useEffect(() => {
        fetchProducts()
    })

    return (
        <>
            <div className="container mt-4">
                    <button className="btn btn-secondary mb-3" onClick={ toggleModalInsertar }>Insert New Product</button>
                <table className="table table-striped">
                    <thead className="bg-info text-white">
                        <tr>
                            <th>ID</th>
                            <th>Name</th>
                            <th>Category</th>
                            <th>Price</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            data.map((p) => (
                                <tr key={p.id}>
                                    <td>{p.id}</td>
                                    <td>{p.name}</td>
                                    <td>{p.category}</td>
                                    <td>${Number(p.price).toFixed(2)}</td>
                                    <td>
                                        <button className="btn btn-primary me-2" onClick={() => selectProduct(p, "Editar") } >Edit</button>
                                        <button className="btn btn-danger" onClick={() => selectProduct(p,"Eliminar") }>Delete</button>
                                    </td>
                                </tr>
                            ))
                        }
                    </tbody>
                </table>
            </div>
            <Modal isOpen={modalInsertar} toggle={toggleModalInsertar}>
                <ModalHeader toggle={ toggleModalInsertar }>Insert Product</ModalHeader>
                    <ModalBody>
                    <input type="text" className="form-control mb-2" name="name" placeholder="Name" onChange={ handleChange } />
                    <input type="text" className="form-control mb-2" name="category" placeholder="Category" onChange={ handleChange } />
                    <input type="text" className="form-control mb-2" name="price" placeholder="Price" onChange={ handleChange } />
                    </ModalBody>
                    <ModalFooter>
                    <button className="btn btn-primary" onClick={ addProduct }>Insert</button>
                    <button className="btn btn-danger" onClick={toggleModalInsertar }>Cancel</button>
                    </ModalFooter>
            </Modal>
            <Modal isOpen={modalEditar} toggle={toggleModalEditar}>
                <ModalHeader toggle={toggleModalEditar}>Edit Product</ModalHeader>
                <ModalBody>
                    <input type="text" className="form-control mb-2" value={ productSelected.id} readOnly />
                    <input type="text" className="form-control mb-2" name="name" value={ productSelected.name } onChange={handleChange} />
                    <input type="text" className="form-control mb-2" name="category" value={productSelected.category} onChange={handleChange} />
                    <input type="text" className="form-control mb-2" name="price" value={productSelected.price} onChange={handleChange} />
                </ModalBody>
                <ModalFooter>
                    <button className="btn btn-primary" onClick={updateProduct}>Update</button>
                    <button className="btn btn-danger" onClick={toggleModalEditar}>Cancel</button>
                </ModalFooter>
            </Modal>
            <Modal isOpen={modalEliminar} toggle={toggleModalEliminar}>
                <ModalBody>
                    Are you sure to delete "{productSelected.name}" ?
                </ModalBody>
                <ModalFooter>
                    <button className="btn btn-danger" onClick={deleteProduct} >Yes</button>
                    <button className="btn btn-secondary" onClick={ toggleModalEliminar }>No</button>
                </ModalFooter>
            </Modal>
        </>
    )
}

export default App