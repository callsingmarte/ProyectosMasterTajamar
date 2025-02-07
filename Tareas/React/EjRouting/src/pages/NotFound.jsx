import { Component } from "react";
import { BrowserRouter as NavLink } from "react-router-dom";

export class NotFound extends Component {
    render() {
        return (
            <div className="container d-flex justify-content-center align-items-center" style={{ minHeight: "100vh" }}>
                <div className="text-center">
                    <h1 className="display-1 text-danger">404</h1>
                    <p className="lead">Oops! La página que buscas no existe.</p>
                    <p>Podrías volver a la <NavLink to="/" className="btn btn-primary">página de inicio</NavLink>.</p>
                </div>
            </div>
        )
    }
}