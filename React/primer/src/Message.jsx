import React from "react"
export function Message(props) {
    //let classes = props.name === "Maria" ? "bg-warning p-2" : "bg-success p-2";
    //return <h4 className={classes}>
    //    {props.greeting}, {props.name}
    //</h4>

    let classes;
    switch (props.name) {
        case "Maria":
            classes = "bg-warning p-2"
            break;
        case "Pepe":
            classes = "bg-success p-2"
            break;
        default:
            classes = "bg-danger p-2"

    }    

    return <h4 className={classes}>
        {props.greeting}, {props.name}
    </h4>
}