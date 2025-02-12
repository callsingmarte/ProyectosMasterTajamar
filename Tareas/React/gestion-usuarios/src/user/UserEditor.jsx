import { Component, useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { RestDataSource } from "../webservice/RestDataSource";


function UserEditorWrapper() {
    const { mode, id } = useParams()
    const navigate = useNavigate()
    const [dataItem, setDataItem] = useState({ id: "", name: "", email: "" })
    const dataSource = new RestDataSource("http://localhost:3500/users")

    useEffect(() => {
        if (mode === "edit" && id) {
            dataSource.GetOne(id, data => setDataItem(data));
        }
    }, [mode, id])

    const save = (data) => {
        const callback = () => navigate("/userList")
        if (!data.id) {
            dataSource.Store(data, callback)
        } else {
            dataSource.Update(data, callback)
        }
    }

    return (
        <UserEditor
            key={dataItem.id || -1}
            user={dataItem}
            saveCallback={save}
        />
    )
}

class UserEditor extends Component {
    constructor(props) {
        super(props)
        this.state = {
            formData: {
                id: props.user.id || "",
                name: props.user.name || "",
                email: props.user.email || "",
            }
        }
    }

    handleChange = (ev) => {
        ev.persist()
        this.setState(state => state.formData[ev.target.name] = ev.target.value)
    }

    handleClick = () => {
        this.props.saveCallback(this.state.formData)
    }

    render() {
        return (
            <div className="m-2">                
                <div className="form-group">
                    <label>ID</label>
                    <input className="form-control"
                        name="id"
                        value={this.state.formData.id}
                        disabled
                    />
                </div>
                <div className="form-group">
                    <label>Name</label>
                    <input className="form-control"
                        name="name"
                        value={this.state.formData.name}
                        onChange={this.handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>Email</label>
                    <input className="form-control"
                        name="email"
                        value={this.state.formData.email}
                        onChange={this.handleChange}
                    />
                </div>
                <div className="text-center">
                    <button className="btn btn-primary m-1" onClick={this.handleClick}>
                        Save
                    </button>
                    <Link className="btn btn-secondary m-1" to="/userList">
                        Cancel
                    </Link>
                </div>
            </div>
        )
    }
}

export default UserEditorWrapper