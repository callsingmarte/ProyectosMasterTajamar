import { Component } from "react";
import { UserCard } from "./UserCard";
import { RestDataSource } from "../webservice/RestDataSource";
import { Link } from "react-router-dom";

export class UserList extends Component {
    constructor(props) {
        super(props)
        this.state = {
            userList: []
        }
        this.dataSource = new RestDataSource("http://localhost:3500/users")
    }

    deleteUser = (user) => {
        this.dataSource.Delete(user, () => this.setState({
            userList: this.state.userList.filter(u => u.id !== user.id)
        }))
    }

    render() {
        return (
            <div className="container-fluid p-2 m-2">
                <h2 className="text-center mb-5">Users List</h2>
                <div className="row mb-4">
                    <div className="col text-center">
                        <Link className="btn btn-primary" to={`/user/create`}>Add User</Link>
                    </div>
                </div>
                <div className="row">
                    {
                        this.state.userList.map(u =>
                            <UserCard user={u} key={u.id} deleteCallback={this.deleteUser} />
                    )
                }
                </div>
            </div>
        )
    }

    componentDidMount() {
        this.dataSource.GetData(data => this.setState({ userList: data }))
    }
}