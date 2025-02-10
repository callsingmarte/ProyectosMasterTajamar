import { Component } from "react";
import { FormValidator } from "../validation/FormValidator";
import { ValidationMessage } from "../validation/ValidationMessage";
import { ValidateForm } from "../validation/WholeFormValidation"
export class Editor extends Component {
    constructor(props) {
        super(props)
        this.state = {
            title: "",
            seatCapacity: 0,
            instructorName: ""
        }

        this.rules = {
            title: { required: true, alpha: true },
            seatCapacity: { required: true, numeric: true }
        }
    }

    updateFormValue = (event) => {
        this.setState({[event.target.name]: event.target.value })
    }

    updateFormValueOptions = (event) => {
        let options = [...event.target.options].filter(o => o.select).map(o => o.value)
        this.setState({[event.target.name]: options})
    }

    render() {
        return (
            <div className="h5 bg-info text-white p-2">
                <FormValidator data={this.state} rules={this.rules}
                    submit={this.props.submit} validateForm={ValidateForm}>
                    <ValidationMessage field="form" />
                    <div className="form-group">
                        <label>Title:</label>
                        <input className="form-control"
                            name="title"
                            value={this.state.title}
                            onChange={ this.updateFormValue }
                        ></input>
                        <ValidationMessage field="title" />
                    </div>
                    <div className="form-group">
                        <label>seat Capacity:</label>
                        <input className="form-control"
                            name="seatCapacity"
                            value={this.state.seatCapacity}
                            onChange={ this.updateFormValue }
                        ></input>
                        <ValidationMessage field="seatCapacity" />
                    </div>
                    <div className="form-group">
                        <label>Instructor Name:</label>
                        <input className="form-control"
                            name="instructorName"
                            value={this.state.instructorName}
                            onChange={ this.updateFormValue }
                        ></input>
                    </div>
                </FormValidator>
            </div>
        )
    }

}