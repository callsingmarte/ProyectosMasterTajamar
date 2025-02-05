import React from "react";
import { SimpleButton } from './SimpleButton'
export function CallBackButton(props) {
    let { theme, ...childProps } = props
    return (
        <SimpleButton {...childProps} className={`btn btn-${props.theme} btn-sm m-1`} />
    )
}

CallBackButton.defaultProps = {
    text: "Default text",
    theme: "warning",

}

//<button className={`btn btn-${props.theme} btn-sm m-1`}
//    onclick={props.callback}
//>
//    {props.text}
//</button>
