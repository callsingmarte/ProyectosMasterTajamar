import { Component } from "react"
import { ValidationMessage } from "../validation/ValidationMessage"
import { FormValidator } from "../validation/FormValidator"
import { ValidateForm } from "../validation/WholeFormValidation"

export class Editor extends Component {

    constructor(props) {
        super(props)
        this.state = {
            name: "",
            email: "",
            emailConfirm: "",
            order: "",
            terms: false
            //toppings: ["Strawberries"]
            //twoScoops: false
        }

        this.rules = {
            name:  { required: true, minlength: 3, alpha: true },
            email: { required: true, email: true, equals: "emailConfirm" },
            order: { required: true },
            emailConfirm: { required: true, email: true, equals: "email"},
            terms: { true: true }
        }

        //this.flavors = ["Chocolate", "Double Chocolate", "Triple Chocolate", "Vanilla"]
        //this.toppings = ["Sprinkles", "Fudge Sauce", "Strawberries", "Maple Syrup"]
    }

    updateFormValue = (event) => {
        this.setState({ [event.target.name]: event.target.value })
    }
    //Esto ya no es necesario porque lo hacemos desde otro componente
    // () => this.props.submit(this.state)

    updateFormValueOptions = (event) => {
        let options = [...event.target.options].filter(o => o.selected).map(o => o.value)
        this.setState({ [event.target.name]: options })
    }

    updateFormValueCheck = (event) => {
        const { name, checked } = event.target
        event.persist()

        this.setState(state => {
            const newToppings = checked ? [...state.toppings, name] :
                state.toppings.filter(top => top !== name)

            return { toppings: newToppings }
        })
    }

    render() {
        return (
            <div className="h5 bg-info text-white p-2">
                <FormValidator data={this.state} rules={this.rules}
                    submit={this.props.submit} validateForm={ValidateForm} >
                    <ValidationMessage field="form" />
                    <div className="form-group">
                        <label>Name: </label>
                        <input className="form-control"
                            name="name"
                            value={this.state.name}
                            onChange={this.updateFormValue}
                        />
                        <ValidationMessage field="name" />
                    </div>
                    <div className="form-group">
                        <label>Email: </label>
                        <input className="form-control"
                            name="email"
                            value={this.state.email}
                            onChange={this.updateFormValue}
                        />
                        <ValidationMessage field="email" />
                    </div>
                    <div className="form-group">
                        <label>Confirm Email: </label>
                        <input className="form-control"
                            name="emailConfirm"
                            value={this.state.emailConfirm}
                            onChange={this.updateFormValue}
                        />
                        <ValidationMessage field="email" />
                    </div>
                    <div className="form-group">
                        <label>Order: </label>
                        <input className="form-control"
                            name="order"
                            value={this.state.order}
                            onChange={this.updateFormValue}
                        />
                        <ValidationMessage field="order" />
                    </div>
                </FormValidator>
            </div>
        )
    }
}


                //<div className="form-group">
                //    <label>Ice Cream Flavors: </label>
                //    <select className="form-control"
                //        name="flavor"
                //        value={this.state.flavor}
                //        onChange={ this.updateFormValue }
                //    >
                //        {
                //            this.flavors.map(flavor =>
                //                <option value={flavor} key={flavor}>{flavor}</option>                        
                //        )}
                       
                //    </select>
                //</div>
                //<div className="form-group">
                //    <label>Ice Cream Toppings: </label>
                //    <select className="form-control"
                //        multiple={ true }
                //        name="toppings"
                //        value={this.state.toppings}
                //        onChange={ this.updateFormValueOptions }
                //    >
                //        {
                //            this.toppings.map(top =>
                //                <option value={top} key={top}>
                //                    {top}
                //                </option>                        
                //        )}                       
                //    </select>
                //</div>
                //<div className="form-group">
                //    <label>Ice Cream Flavors: </label>
                //    {this.flavors.map(flavor => 
                //        <div className="form-check" key={flavor}>
                //            <input className="form-check-input"
                //                type="radio"
                //                value={flavor}
                //                name="flavor"
                //                checked={this.state.flavor === flavor}
                //                onChange={ this.updateFormValue }
                //            />
                //            <label className="form-check-label">{ flavor }</label>
                //        </div>
                //    )}
                //</div>
                //<div className="form-group">
                //    <div className="form-check">
                //        <input className="form-check-input"
                //            type="checkbox"
                //            name="twoScoops"
                //            checked={this.state.twoScoops}
                //            onChange={this.updateFormValueCheck}
                //        />
                //        <label className="form-check-label">Two Scoops</label>
                //    </div>
                //</div>
                //<div className="form-group">
                //    <label>Ice Cream Toppings:</label>
                //    {this.toppings.map(top =>
                //        <div className="form-check" key={top}>
                //            <input
                //                className="form-check-input"
                //                type="checkbox"
                //                name={top}
                //                value={this.state[top]}
                //                checked={this.state.toppings.indexOf(top) > -1}
                //                onChange = { this.updateFormValueCheck }
                //            />                            
                //            <label className="form-check-label">
                //                { top }
                //            </label>
                //        </div>
                //    )}
                //</div>
