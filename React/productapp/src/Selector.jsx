import * as React from "react";
import { Component } from "react";
import { BrowserRouter as Router, Link, Route, Routes, Navigate, NavLink } from "react-router-dom";
import { ProductDisplay } from "./product/ProductDisplay"
import { SupplierDisplay } from "./supplier/SupplierDisplay"
import { ToggleLink } from "./route/ToggleLink";

export class Selector extends Component {
    //constructor(props) {
    //    super(props)
    //    this.state = {
    //        selection: React.Children.toArray(props.children)[0].props.name
    //    }
    //}

    //setSelection = (ev) => {
    //    ev.persist()
    //    this.setState({selection: ev.target.name})
    //}

    renderMessage = (msg) => <h5 className="bg-info text-white m-2 p-2"> { msg }</h5>

    render() {
        return (
            <Router>
                <div className="container-fluid">
                    <div className="row">
                        <div className="col-2">
                            <div className="row p-2">
                                <ToggleLink to="/" className={({ isActive }) =>
                                    isActive ? 'nav-link btn btn-white text-dark text-center border border-primary'
                                    : 'nav-link btn btn-outline-primary text-dark text-center'
                                } >
                                    Default URL
                                </ToggleLink>
                            </div>
                            <div className="row p-2">
                                <ToggleLink to="/products" className={({ isActive }) =>
                                    isActive ? 'nav-link btn btn-white text-dark text-center border border-primary'
                                        : 'nav-link btn btn-outline-primary text-dark text-center'
                                } >
                                    Products
                                </ToggleLink>
                            </div>
                            <div className="row p-2">
                                <ToggleLink to="/suppliers" className={({ isActive }) =>
                                    isActive ? 'nav-link btn btn-white text-dark text-center border border-primary'
                                        : 'nav-link btn btn-outline-primary text-dark text-center'
                                } >
                                    Suppliers
                                </ToggleLink>
                            </div>
                        </div>
                        <div className="col">
                            <Routes>
                                <Route path="/products" element={<ProductDisplay />} />
                                <Route path="/suppliers" element={<SupplierDisplay />} />
                                <Route path="*" element={<Navigate to="/products" />} />
                            </Routes>
                        </div>
                    </div>
                </div>
            </Router>
        )
    }

    //render() {
    //    return (
    //        <Router>
    //            <div className="container-fluid">
    //                <div className="row">
    //                    <div className="col-2">
    //                        <div className="row p-2">
    //                            <Link to="/products" className="btn btn-pimary text-white text-center">
    //                                Products
    //                            </Link>
    //                        </div>
    //                        <div className="row p-2">
    //                            <Link to="/suppliers" className="btn btn-pimary text-white text-center">
    //                                Suppliers
    //                            </Link>
    //                        </div>
    //                        <div className="col">
    //                            <Routes>
    //                                <Route path="/products" element={<ProductDisplay />} />
    //                                <Route path="/suppliers" element={<SupplierDisplay />} />
    //                            </Routes>
    //                        </div>
    //                    </div>
    //                </div>
    //            </div>
    //        </Router>
    //    )
    //}


    //render() {
    //    return <div className="container-fluid">
    //        <div className="row">
    //            <div className="col-2">
    //                {React.Children.map(this.props.children, c =>
    //                    <button
    //                        className={`btn btn-block m-2 
    //                        ${this.state.selection === c.props.name ? "btn-primary active" : "btn-secondary"}`}
    //                        name={c.props.name}
    //                        onClick={this.setSelection}> 
    //                        { c.props.name }
    //                    </button>
    //                )}
    //            </div>
    //            <div className="col">
    //                {
    //                    React.Children.toArray(this.props.children)
    //                        .filter(c => c.props.name === this.state.selection)
    //                }
    //            </div>
    //        </div>
    //    </div>
    //}

}