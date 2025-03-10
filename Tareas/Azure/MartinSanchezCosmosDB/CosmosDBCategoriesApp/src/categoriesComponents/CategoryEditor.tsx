import { Component, useEffect, useState } from "react"
import { useLocation, useNavigate, useParams } from "react-router-dom"
import { RestDataSource } from "../webservice/RestDataSource"
import { Category } from "../models/categoryModel"
import { FormValidator } from "../validation/FormValidator"
import { ValidateForm } from "../validation/WholeFormValidation"
import { ValidationMessage } from "../validation/ValidationMessage"
function CategoryEditor() {
    const { mode, id } = useParams()
    const location = useLocation()
    const categoryId = location.state
    const navigate = useNavigate()
    const [dataItem, setDataItem] = useState( new Category())
    const dataSource = new RestDataSource("https://localhost:7000/api/Category")

    useEffect(() => {
        if (mode === "edit" && id && categoryId) {
            dataSource.GetOne(id, categoryId, (data: Category) => setDataItem(data));
        }
    }, [mode, id])

    const save = (data: Category, picture: File) => {
        const callback = () => navigate("/categories")
        const formData = new FormData()

        formData.append("category.CategoryName", data.categoryName!);
        if (data.description) {
            formData.append("category.Description", data.description);
        }

        if (data.description) {
            formData.append("category.Picture", data.picture!);
        }

        if (picture) {
            formData.append("picture", picture);
        }

        if (!data.id && !data.categoryID) {
            dataSource.Store(formData, callback)
        } else {
            formData.append("category.id", data.id!);
            formData.append("category.CategoryID", data.categoryID!);

            dataSource.Update(data.id!, formData, callback)
        }
    }

    return (
        <CategoryForm
            key={dataItem.id || -1}
            category={dataItem}
            saveCallback={save}
        />
    )
}

type Props = {
    category?: Category 
    saveCallback: Function
}

type MyState = {
    formData: Category,
    picturePreview: string,
    pictureToUpload: File | null
}

class CategoryForm extends Component<Props, MyState> {
    constructor(props : Props) {
        super(props)
        this.state = {
            formData: props.category ? { ...props.category } : {},
            picturePreview: "",
            pictureToUpload: null
        }
    }

    rules = {
        categoryName: { required: true}
    }

    handleChange = (ev : any) => {
        ev.persist()
        this.setState((prevState: MyState) =>
        ({
            formData: {
                ...prevState.formData,
                [ev.target.name]: ev.target.value
            }
        }))
    }

    handleClick = () => {
        this.props.saveCallback(this.state.formData, this.state.pictureToUpload)
    }

    handleChangePicture = (event: any) => {
        const file = event.target.files?.[0]
        if (file) {
            this.setState({
                pictureToUpload: file,
                picturePreview: URL.createObjectURL(file)
            })
        }
    }

    clearNewPicture = () => {
        this.setState({
            pictureToUpload: null,
            picturePreview: ""
        })
    }

    render() {
        return (
            <div className="container-fluid">
                <h2> {this.state.formData.id ? "Editar Categoria" : "Crear Categoria"}</h2>
                <FormValidator data={this.state.formData} rules={this.rules}
                    submit={this.handleClick} validateForm={ValidateForm}
                >
                    <ValidationMessage field="form" />
                    <div className="row">
                        <div className="col">
                            {this.state.formData.id &&
                                <div className="form-group">
                                    <label>ID</label>
                                    <input className="form-control"
                                        name="id"
                                        value={this.state.formData.id}
                                        disabled
                                    />
                                </div>
                            }
                            {this.state.formData.id &&
                                <div className="form-group">
                                    <label>CategoryID</label>
                                    <input className="form-control"
                                        name="categoryID"
                                        value={this.state.formData.categoryID}
                                        disabled
                                    />
                                </div>
                            }
                            <div className="form-group">
                                <label>Name</label>
                                <input className="form-control"
                                    name="categoryName"
                                    value={this.state.formData.categoryName}
                                    onChange={this.handleChange}
                                />
                                <ValidationMessage field="categoryName" />
                            </div>
                            <div className="form-group">
                                <label>Description</label>
                                <input className="form-control"
                                    name="description"
                                    value={this.state.formData.description}
                                    onChange={this.handleChange}
                                />
                                <ValidationMessage field="description" />
                            </div>
                        </div>
                        <div className="col">
                            {this.state.formData.picture &&
                                <img className="img-fluid img-thumbnail" width="400px" src={this.state.formData.picture} alt="" />
                            }
                            <div className="form-group">
                                <label>Picture</label>
                                <input className="form-control"
                                    name="picture"
                                    value={this.state.formData.picture}
                                    onChange={this.handleChange}
                                />
                                <ValidationMessage field="picture" />
                            </div>

                            {this.state.picturePreview &&
                                <div className="form-group">
                                    <label>new Picture</label>
                                    <img className="img-fluid img-thumbnail" width="400px" src={this.state.picturePreview} alt="" />
                                </div>
                            }
                            <div className="form-group mt-3">
                                <button type="button" className="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
                                    {this.state.picturePreview ? "Change Picture" : "Add Picture"}
                                </button>
                                {this.state.picturePreview &&
                                    <button className="btn btn-secondary" type="button" onClick={this.clearNewPicture}>
                                        Clear new Picture
                                    </button>
                                }
                            </div>

                        </div>
                    </div>
                </FormValidator>

                <div className="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabIndex={-1} aria-labelledby="staticBackdropLabel" aria-hidden="true" ref={ this.modalRef }>
                    <div className="modal-dialog">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h1 className="modal-title fs-5" id="staticBackdropLabel">Modal title</h1>
                                <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div className="modal-body">
                                <div className="form-group">
                                    <label>Picture</label>
                                    {this.state.picturePreview &&
                                        <img className="img-fluid img-thumbnail" width="400px" src={this.state.picturePreview} alt="" />
                                    }
                                    <input className="form-control"
                                        name="pictureToUpload"
                                        onChange={this.handleChangePicture}
                                        type="file"
                                        accept="image/*"
                                    />
                                </div>
                            </div>
                            <div className="modal-footer">
                                <button type="button" className="btn btn-success" data-bs-dismiss="modal">Save</button>
                                <button type="button" onClick={this.clearNewPicture} data-bs-dismiss="modal" className="btn btn-secondary">Cancel</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}

export default CategoryEditor