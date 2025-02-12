import { Component } from "react";
import { UserList } from "./user/UserList";
import { BrowserRouter as Router, Navigate, Route, Routes } from "react-router-dom";
import UserEditorWrapper from "./user/UserEditor";

export default class App extends Component {

    render() {
        return (
            <div className="container">            
                <Router>
                    <Routes>
                        <Route path="/userList" element={<UserList />}></Route>
                        <Route path="/user/:mode/:id?" element={<UserEditorWrapper />}></Route>
                        <Route path="/user/id" element={<Navigate to="/userList" />}></Route>
                        <Route path="*" element={<Navigate to="/userList" />}></Route>
                    </Routes>
                </Router>
            </div>
        )
    }
}