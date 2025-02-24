import { Component } from "react";
import { ValidateData } from "./Validation";
import { ValidationContext } from "./ValidationContext";
import { Link } from "react-router-dom";

type Props = {
    data: any,
    rules: any,
    submit: Function,
    children: any,
    validateForm: Function
}

type MyState = {
    errors: any,
    dirty: any, 
    formSubmitted: boolean,
    getMessagesForField: (field?: string) => []
}

export class FormValidator extends Component<Props, MyState> {
    constructor(props : Props) {
        super(props)
        this.state = {
            errors: {},
            dirty: {},
            formSubmitted: false,
            getMessagesForField: this.getMessagesForField
        }
    }

    static getDerivedStateFromProps(props: Props, state : MyState) {
        const errors = ValidateData(props.data, props.rules)
        let newState = { ...state, errors}
        console.log(state.errors)
        if (state.formSubmitted && Object.keys(errors).length === 0) {
            let formErrors = props.validateForm(props.data);
            if (formErrors.length > 0) {
                newState.errors = { ...errors, form: formErrors };
            }
        }

        return newState
    }

    get formValid() {
        return Object.keys(this.state.errors).length === 0
    }

    handleChange = (ev: any) =>
    { 
        ev.persist()
        let name = ev.target.name
        this.setState((prevState: MyState) => ({
            dirty: {
                ...prevState.dirty,
                [name]: true
            }
        }));
    }

    handleClick = () => {
        this.setState({ formSubmitted: true }, () => {
            if (this.formValid) {
                let formErrors = this.props.validateForm(this.props.data)
                if (formErrors.length === 0) {
                    this.props.submit()
                }
            }
        })
    }
    getButtonClasses() {
        return this.state.formSubmitted && !this.formValid ? "btn-danger" : "btn-primary"
    }

    getMessagesForField = (field? : string) => {
        return (this.state.formSubmitted || this.state.dirty[field!])
            ? this.state.errors[field!] || [] : []
    }

    render() {
        return (
            <>
                <ValidationContext.Provider value={this.state}>
                    <div onChange={this.handleChange}>
                        {this.props.children}
                    </div>
                </ValidationContext.Provider>
                <div className="text-center mt-5">
                    <button className={`btn ${this.getButtonClasses()}`}
                        onClick={this.handleClick}
                        disabled={this.state.formSubmitted && !this.formValid}
                    >
                        Submit
                    </button>
                    <Link className="btn btn-secondary m-1" to="/categories">
                        Cancel
                    </Link>
                </div>
            </>
        )
    }
}