import { Component, useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { RestDataSource } from "../webservice/RestDataSource";
import { ValidationMessage } from "../validation/ValidationMessage";
import { FormValidator } from "../validation/FormValidator";
import { ValidateForm } from "../validation/WholeFormValidation"

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
        this.rules = {
            name: { required: true },
            email: { required: true, email: true },
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
                <FormValidator data={this.state.formData} rules={this.rules}
                    submit={this.handleClick} validateForm={ValidateForm}>
                    <ValidationMessage field = "form" />
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
                        <ValidationMessage field="name" />
                    </div>
                    <div className="form-group">
                        <label>Email</label>
                        <input className="form-control"
                            name="email"
                            value={this.state.formData.email}
                            onChange={this.handleChange}
                        />
                        <ValidationMessage field="email" />
                    </div>
                </FormValidator>
            </div>
        )
    }
}

export default UserEditorWrapper