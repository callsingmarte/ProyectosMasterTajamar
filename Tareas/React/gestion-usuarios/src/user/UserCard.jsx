import { Component } from "react";
import { Link } from "react-router-dom";

export class UserCard extends Component {
    render() {
        let user = this.props.user
        return (
            <div className="col mb-2">
                <div className="card shadow">
                    <div className="card-body">
                        <p>Name: { user.name }</p>
                        <p>Email: {user.email}</p>
                        { user.address ?
                            <pre>
                                Address:
                                City: {user.address.city} Street: {user.address.street}
                            </pre>      
                            :
                            "No address"
                        }
                    </div>
                    <div className="card-footer">
                        <Link className="btn btn-warning" to={`/user/edit/${user.id}`}>Edit</Link>
                        <button className="btn btn-sm btn-danger m-1"
                            onClick={() => this.props.deleteCallback(user) }
                        >
                            Delete
                        </button>
                    </div>
                </div>            
            </div>
        )
    }
}