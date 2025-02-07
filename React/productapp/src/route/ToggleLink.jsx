import * as React from "react"
import { Component } from "react"
import { useNavigate, useMatch, Navigate } from "react-router-dom"


//export class ToggleLink extends Component {
//    constructor(props) {
//        super(props)
//        this.state = {
//            doRedirect: false
//        }
//    }

//    handleClick = () => {
//        this.setState({ doRedirect: true }, () => {
//            setTimeout(() => this.setState({ doRedirect: false }), 0)
//        })
//    }

//    render() {
//        const baseClasses = className || "m-2 btn btn-block";
//        const active = activeClass || "btn-primary"
//        const inactive = inActiveClass || "btn-secondary"

//        const combinedClasses = `${baseClasses} ${this.state.doRedirect ? active : inactive}`

//        return (
//            <React.Fragment>
//                {this.state.doRedirect && <Navigate to={this.props.to} replace />}
//                <button className={combinedClasses} onClick={this.handleClick}>
//                    { this.props.children }
//                </button>
//            </React.Fragment>
//        )

//    }

//}


export function ToggleLink({ to, children, className, activeClass, inActiveClass }) {

    const navigate = useNavigate() //Hook de navegación
    const match = useMatch(to) //Hook verifica si la ruta coincide

    const baseClasses = className || "m-2 btn btn-block";
    const active = activeClass || "btn-primary"
    const inactive = inActiveClass || "btn-secondary"

    const combinedClasses = `${baseClasses} ${match ? active : inactive}`

    const handleClick = () => {
        navigate(to)
    }

    return (
        <button className={combinedClasses} onClick={handleClick} >
            { children }
        </button>
    )
}