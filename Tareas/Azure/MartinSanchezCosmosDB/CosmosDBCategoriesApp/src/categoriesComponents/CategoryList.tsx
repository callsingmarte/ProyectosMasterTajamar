import { Component } from "react";
import { Category } from "../models/categoryModel";
import { Link, NavLink } from "react-router-dom";
import { RestDataSource } from "../webservice/RestDataSource";

type MyState = {
    categoryList: Category[],
    searchInput: string,
    filteredData: Category[],
    totalPages: number,
    currentPage: number    
}

export class CategoryList extends Component<{}, MyState> {    

    state : MyState = {
        categoryList: [] as Category[],
        searchInput: "",
        filteredData: [] as Category[],
        totalPages: 0,
        currentPage: 1
    }

    constructor(props: any) {
        super(props)
    }

    dataSource = new RestDataSource("https://localhost:7000/api/Category")
    //Paginacion
    registersPerPage: number = 5
    lastRecordIndex: number = this.state.currentPage * this.registersPerPage
    firstRecordIndex: number = this.lastRecordIndex - this.registersPerPage

    handleChange = (ev: any) => {
        ev.persist()
        this.setState({searchInput: ev.target.value })
        this.handleSearch()
    }

    handleSearch = () => {
        if (!this.state.searchInput) {
            this.dataSource.GetData((data : Category[]) => this.setState({
                categoryList: data,
                filteredData: data.slice(0, this.registersPerPage),
                totalPages: Math.ceil(data.length / this.registersPerPage),
                currentPage: 1
            }))
        } else {
            //Busqueda por nombre o descripcion
            this.dataSource.GetData((data: Category[]) => {
                let filtered = data.filter((category) => {
                    return category.categoryName!.toLowerCase().includes(this.state.searchInput.toLowerCase()) ||
                        category.description!.toLowerCase().includes(this.state.searchInput.toLowerCase())
                })
                this.setState({
                    categoryList: filtered,
                    filteredData: filtered.slice(0, this.registersPerPage),
                    totalPages: Math.ceil(filtered.length / this.registersPerPage),
                    currentPage: 1
                })
            })
        }
    }

    changePageDirection(direction: string) {
        let page = this.state.currentPage;
        if (direction == "prev") {
            page = page - 1
        } else {
            page = page + 1
        }

        this.lastRecordIndex = page * this.registersPerPage
        this.firstRecordIndex = this.lastRecordIndex - this.registersPerPage

        this.setState({
            filteredData: this.state.categoryList.slice(this.firstRecordIndex, this.lastRecordIndex),
            currentPage: page
        })
    }

    changePage = (page: number) => {
        this.lastRecordIndex = page * this.registersPerPage
        this.firstRecordIndex = this.lastRecordIndex - this.registersPerPage

        this.setState({
            filteredData: this.state.categoryList.slice(this.firstRecordIndex, this.lastRecordIndex),
            currentPage: page
        })
    }

    render() {
        return (
            <div className="container-fluid p-2 m-2">
                <h2>Listado de Categorias</h2>
                <div className="input-group mb-3">
                    <input type="text" className="form-control" placeholder="search"
                        aria-label="searchComponent" name="searchInput" value={this.state.searchInput} onChange={this.handleChange} aria-describedby="button-addon2" />
                    <button className="btn btn-outline-success" type="button" onClick={this.handleSearch}>Search</button>
                </div>
                <div className="text-center mb-5">
                    <Link className="btn btn-primary" to={`/category/create`}>
                        <i className="bi bi-plus">Add Category</i>
                    </Link>
                </div>
                <div className="container">
                    <div className="row row-cols-3 row-cols-md-3 g-4">
                    {
                        this.state.filteredData.map(category =>
                                <div className="col">
                                <div key={ category.id } className="card">
                                        <img src={category.picture} className="card-img-top" />
                                        <div className="card-body">
                                            <h5 className="card-title">{category.categoryName}</h5>
                                            <p className="card-text"> {category.description}</p>
                                        </div>
                                        <div className="card-footer">
                                        <NavLink className="btn btn-info"
                                            to={`/category/details/${category.id}`}
                                            state={category.categoryID}
                                        >
                                                <i className="bi bi-info-circle-fill">
                                                    Details
                                                </i>
                                            </NavLink>
                                        <NavLink className="btn btn-warning ms-2"
                                            to={`/category/edit/${category.id}`}
                                            state={ category.categoryID }
                                        >
                                                <i className="bi bi-pencil-square"> Edit Category </i>
                                            </NavLink>                                            
                                        </div>
                                    </div>
                            </div>
                        )
                    }
                    </div>
                </div>
                { this.state.totalPages > 1 &&
                    <nav aria-label="...">
                        <ul className="pagination">
                            <li className={this.state.currentPage == 1 ? "page-item disabled" : "page-item"}>
                                <a className="page-link" onClick={() => this.changePageDirection("prev")}>Previous</a>
                            </li>
                            {
                                Array.from({ length: this.state.totalPages }, (_, index) => (
                                    <li className="page-item">
                                        <a className={this.state.currentPage == index + 1 ? "page-link active" : "page-link"} href="#"
                                            onClick={() => this.changePage(index + 1)}>{index + 1}</a>
                                    </li>
                                ))
                            }
                            <li className={this.state.currentPage == this.state.totalPages ? "page-item disabled" : "page-item"}>
                                <a className="page-link" href="#" onClick={() => this.changePageDirection("next")}>Next</a>
                            </li>
                        </ul>
                    </nav>
                }
            </div>
        )
    }

    componentDidMount() {
        this.dataSource.GetData((data : Category[]) => this.setState({
            categoryList: data,
            filteredData: data.slice(0, this.registersPerPage),
            totalPages: Math.ceil(data.length / this.registersPerPage),
            currentPage: 1
        }))
    }
}