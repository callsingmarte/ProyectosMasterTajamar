import { Component } from "react";
import { BrowserRouter as Router, Link, Route, Routes, Navigate, NavLink } from "react-router-dom";

export class NavBar extends Component {


    render() {
        return (
                <div className="container-fluid">
                    <div className="row">
                        <div className="col p-2">
                            <NavLink to="/home" className={({ isActive }) =>
                                isActive ? 'nav-link btn btn-white text-dark text-center border border-primary'
                                    : 'nav-link btn btn-outline-primary text-dark text-center'
                            } >
                            Home
                            </NavLink>
                        </div>
                        <div className="col p-2">
                            <NavLink to="/about" className={({ isActive }) =>
                                isActive ? 'nav-link btn btn-white text-dark text-center border border-primary'
                                    : 'nav-link btn btn-outline-primary text-dark text-center'
                            } >
                                Contact
                            </NavLink>
                        </div>
                        <div className="col p-2">
                            <NavLink to="/contact" className={({ isActive }) =>
                                isActive ? 'nav-link btn btn-white text-dark text-center border border-primary'
                                    : 'nav-link btn btn-outline-primary text-dark text-center'
                            } >
                                Suppliers
                            </NavLink>
                        </div>
                    </div>
                </div>

        )
    }
}