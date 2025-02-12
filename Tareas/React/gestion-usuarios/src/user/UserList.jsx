import { Component } from "react";
import { UserCard } from "./UserCard";
import { RestDataSource } from "../webservice/RestDataSource";
import { Link } from "react-router-dom";

export class UserList extends Component {
    constructor(props) {
        super(props)
        this.state = {
            userList: [],
            searchInput: "",
            filteredData: [],   
            totalPages: 0,
            currentPage: 1
        }
        this.dataSource = new RestDataSource("http://localhost:3500/users")
        //Paginacion
        this.registersPerPage = 5
        this.LastRecordIndex = this.currentPage * this.registersPerPage
        this.FirstRecordIndex = this.LastRecordIndex - this.registersPerPage
    }

    deleteUser = (user) => {
        this.dataSource.Delete(user, () => this.setState({
            userList: this.state.userList.filter(u => u.id !== user.id)
        }))
    }

    handleChange = (ev) => {
        ev.persist()
        this.setState(state => state.searchInput = ev.target.value)
    }

    handleSearch = () => {
        if (!this.state.searchInput) {
            this.dataSource.GetData(data => this.setState({
                filteredData: data.slice(0, this.registersPerPage),
                userList: data,
                totalPages: Math.ceil(data.length / this.registersPerPage),
                currentPage: 1
            }))
        } else {
            this.dataSource.GetData(data => { 
                let filtered = data.filter((user) => {
                    return user.name.toLowerCase().includes(this.state.searchInput.toLowerCase())
                        || user.email.toLowerCase().includes(this.state.searchInput.toLowerCase())
                })
                this.setState({
                    filteredData: filtered.slice(0, this.registersPerPage),
                    userList: filtered,
                    totalPages: Math.ceil(filtered.length / this.registersPerPage),
                    currentPage: 1
                })
            })
        }
    }

    changePageDirection(direction) {
        let page = this.state.currentPage;
        if (direction == "prev") {
            page = page - 1
        } else {
            page = page + 1
        }

        this.LastRecordIndex = page * this.registersPerPage
        this.FirstRecordIndex = this.LastRecordIndex - this.registersPerPage

        this.setState({
            filteredData: this.state.userList.slice(this.FirstRecordIndex, this.LastRecordIndex),
            currentPage: page
        })
    }

    changePage = (page) => {
        this.LastRecordIndex = page * this.registersPerPage
        this.FirstRecordIndex = this.LastRecordIndex - this.registersPerPage

        this.setState({
            filteredData: this.state.userList.slice(this.FirstRecordIndex, this.LastRecordIndex),
            currentPage: page
        })
    }

    render() {
        return (
            <div className="container-fluid p-2 m-2">
                <h2 className="text-center mb-5">Users List</h2>
                <div className="input-group mb-3">
                    <input type="text" className="form-control" placeholder="search"
                        aria-label="searchComponent" name="searchInput" value={this.state.searchInput} onChange={ this.handleChange } aria-describedby="button-addon2" />
                    <button className="btn btn-outline-success" type="button" onClick={this.handleSearch }>Search</button>
                </div>
                <div className="row mb-4">
                    <div className="col text-center">
                        <Link className="btn btn-primary" to={`/user/create`}>Add User</Link>
                    </div>
                </div>
                <div className="row">
                    {
                        this.state.filteredData.map(u =>
                            <UserCard user={u} key={u.id} deleteCallback={this.deleteUser} />
                        )
                    }
                    < nav aria-label="...">
                        <ul className="pagination">
                            <li className={this.state.currentPage == 1 ? "page-item disabled" : "page-item" }>
                                <a className="page-link" onClick={() => this.changePageDirection("prev")}>Previous</a>
                            </li>
                            {
                                Array.from({ length: this.state.totalPages }, (_, index) => (
                                    <li className="page-item">
                                        <a className={this.setState.currentPage == index + 1 ? "page-link active" : "page-link"} href="#"
                                            onClick={() => this.changePage(index + 1)}>{index + 1}</a>
                                    </li>
                                ))
                            }
                            <li className={this.state.currentPage == this.state.totalPages ? "page-item disabled" : "page-item"}>
                                <a className="page-link" href="#" onClick={() => this.changePageDirection("next")}>Next</a>
                            </li>
                        </ul>
                    </nav>
                </div>
            </div>
        )
    }

    componentDidMount() {
        this.dataSource.GetData(data => this.setState({
            filteredData: data.slice(0, this.registersPerPage),
            userList: data,
            totalPages: Math.ceil(data.length / this.registersPerPage),
            currentPage: 1
        }))
    }
}