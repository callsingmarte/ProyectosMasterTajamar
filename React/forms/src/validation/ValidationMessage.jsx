import { Component } from "react";
import { ValidationContext } from "./ValidationContext";

export class ValidationMessage extends Component {
    //El contextType nos permite llamar al context
    static contextType = ValidationContext

    render() {
        return this.context.getMessagesForField(this.props.field).map(error =>
            <div className="small bg-danger text-white mt-1 p-1"
                key={ error }> 
                { error }
            </div>
        )
    }
}