import { Component } from "react";
import { ValidationContext } from "./ValidationContext";

type Props = {
    field: any
}
export class ValidationMessage extends Component<Props> {

    //El contextType nos permite llamar al context
    static contextType = ValidationContext
    declare context: React.ContextType<typeof ValidationContext>;

    render() {
        const messages = this.context?.getMessagesForField(this.props.field) || [];
        return messages.map((error : any) =>
            <div className="small bg-danger text-white mt-1 p-1"
                key={error}>
                {error}
            </div>
        )
    }
}