import { Component, useEffect, useState } from "react";
import { Link, NavLink, useLocation, useNavigate, useParams } from "react-router-dom";
import { RestDataSource } from "../webservice/RestDataSource";
import { Category } from "../models/categoryModel";

export function CategoryDetail() {
    const { id } = useParams()
    const location = useLocation()
    const categoryId = location.state
    const navigate = useNavigate()
    const [dataItem, setDataItem] = useState(new Category())
    const dataSource = new RestDataSource("https://localhost:7000/api/Category")

    useEffect(() => {
        if (id) {
            dataSource.GetOne(id, categoryId, (data: Category) => setDataItem(data));
        }
    }, [id])

    const deleteCategory = (category : Category) => {
        dataSource.Delete(category, () => navigate("/categories"))
    }

    return (
        <CategoryCard key={dataItem.categoryID || -1}
            category={dataItem}
            deleteCallback={deleteCategory}
        />
    )
}

type Props = {
    category: Category
    deleteCallback: Function
}

type MyState = {
    category: Category
}
export class CategoryCard extends Component<Props, MyState>{
    constructor(props: Props) {
        super(props)
        this.state = {
            category: props.category || {},
        }
    }

    render() {
        return (
            <div className="container-fluid">
                <h2>Detalles Libro</h2>
                <div className="card shadow">
                    <img className="card-img-top" src={this.state.category.picture} alt="" />
                    <div className="card-body">
                        <p>Titulo: {this.state.category.categoryName}</p>
                        <pre>Description: {this.state.category.description}</pre>
                    </div>
                    <div className="card-footer">
                        <button className="btn btn-sm btn-danger m-1"
                            data-bs-toggle="modal" data-bs-target="#staticBackdrop"
                        >
                            <i className="bi bi-trash"> Delete Category</i>
                        </button>
                        <NavLink className="btn btn-warning ms-2"
                            to={`/category/edit/${this.state.category.id}`}
                            state={this.state.category.categoryID}
                        >
                            <i className="bi bi-pencil-square"> Editar Libro </i>
                        </NavLink>
                    </div>
                </div>
                <Link className="btn btn-primary mt-5" to={`/categories`}>Volver a la lista</Link>

                <div className="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabIndex={-1} aria-labelledby="staticBackdropLabel" aria-hidden="true">
                    <div className="modal-dialog">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h1 className="modal-title fs-5" id="staticBackdropLabel">Modal title</h1>
                                <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div className="modal-body">
                                Are you sure you want to delete the Category
                            </div>
                            <div className="modal-footer">
                                <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">No Cancel</button>
                                <button type="button" className="btn btn-danger" data-bs-dismiss="modal"
                                    onClick={() => this.props.deleteCallback(this.state.category)}>
                                    Yes Delete</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }

}