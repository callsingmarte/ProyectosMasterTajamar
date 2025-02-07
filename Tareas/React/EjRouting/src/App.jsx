import { Component } from "react";
import { NavBar } from "./components/Navbar";
import { BrowserRouter as Router, Route, Routes, Navigate } from "react-router-dom";
import { NotFound } from "pages/NotFound";
import { Contact } from "pages/Contact";
import { About } from "pages/About";
import { Home } from "pages/Home";

export default class App extends Component {
    render() {
        return (
            <Router>
                <Routes>
                    <Route path="/" element={<Navigate to="/home" />} />
                    <Route path="/home" element={<Home />} />
                    <Route path="/about" element={<About />} />
                    <Route path="/contact" element={<Contact />} />
                    <Route path="*" element={<NotFound />} />
                </Routes>
            </Router>
        )
    }
}