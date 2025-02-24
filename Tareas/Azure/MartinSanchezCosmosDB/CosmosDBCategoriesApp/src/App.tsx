import { Component } from "react";
import { BrowserRouter as Router, Navigate, Route, Routes } from "react-router-dom";
import { CategoryList } from "./categoriesComponents/CategoryList";
import CategoryEditor from "./categoriesComponents/CategoryEditor";
import { CategoryDetail } from "./categoriesComponents/CategoryDetail";

export default class App extends Component {

    render() {
        return (
            <div className="container">
                <Router>
                    <Routes>
                        <Route path="/categories" element={<CategoryList />}></Route>
                        <Route path="/category/details/:id" element={<CategoryDetail />}></Route>
                        <Route path="/category/:mode/:id?" element={<CategoryEditor />} ></Route>
                        <Route path="/" element={<Navigate to="/categories" />}></Route>
                        <Route path="*" element={<Navigate to="" />}></Route>
                    </Routes>
                </Router>
            </div>
        )
    }
}