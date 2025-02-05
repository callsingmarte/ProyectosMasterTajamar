import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import { Component } from 'react'

import { TodoBanner } from "./components/TodoBanner"
import { TodoCreator } from "./components/TodoCreator"
import { VisibilityControl } from "./components/VisibilityControl"
import { TodoRow } from './components/TodoRow'

export default class App extends Component {
    constructor(props){
        super(props)
        this.state = {
            userName: "Adam",
            todoItems: [{ action: "Buy Flowers", done: false },
                { action: "Get Shoes", done: false },
                { action: "Collect Tickets", done: true },
                { action: "Call Joe", done: false}
            ],
            showCompleted: true
            //newItemText: ""
        }
    }

    //updateNewTextValue = (event) => {
    //    this.setState({ newItemText: event.target.value })
    //}

    createNewTodo = (task) => {
        if (!this.state.todoItems.find(items => items.action === task)) {
            this.setState({
                todoItems: [...this.state.todoItems, { action: task, done: false }],
            //    newItemText: ""
            }, () => localStorage.setItem("todos", JSON.stringify(this.state)))
        }
    }

    toggleTodo = (todo) => this.setState({
        todoItems: this.state.todoItems.map(item => item.action === todo.action ? {...item, done: !item.done} : item)
    })

    componentDidMount = () => {
        let data = localStorage.getItem("todos")
        this.setState(data != null ? JSON.parse(data) : {
            userName: "Adam",
            todoItems: [{ action: "Buy Flowers", done: false },
            { action: "Get Shoes", done: false },
            { action: "Collect Tickets", done: true },
            { action: "Call Joe", done: false }
            ],
            showCompleted: true
        })
    }

    todoTableRows = (doneValue) => this.state.todoItems.filter(item => item.done === doneValue)
        .map(item =>
            <TodoRow key={item.action} item={item} callback={this.toggleTodo} />
    //    <tr key={item.action}>
    //        <td>{ item.action }</td>
    //        <td><input type="checkbox" checked={item.done} onChange={() => this.toggleTodo(item)} /></td>
    //    </tr>    
    )

    //changeStateData = () => {
    //    this.setState({
    //        userName: this.state.userName === "Adam" ? "Bob" : "Adam"
    //    })
    //}

    render = () => 
        <div>
            <TodoBanner name={this.state.userName} tasks={ this.state.todoItems } />
            <div className="container-fluid">
                <TodoCreator callback={this.createNewTodo} />
            </div>
            <table className="table table-striped table-bordered">
                <thead>
                    <tr>
                        <th>Description</th>
                        <th>Done</th>
                    </tr>
                </thead>
                <tbody>
                    { this.todoTableRows(false) }
                </tbody>
            </table>
            <div className="bg-secondary text-white text-center p-2">
                <VisibilityControl description="Completed tasks"
                    isChecked={this.state.showCompleted}
                    callback={(checked) => this.setState({ showCompleted: checked }) }
                ></VisibilityControl>
            </div>
            {
                this.state.showCompleted && 
                <table className="table table-striped table-bordered">
                    <thead>
                        <tr>
                            <th>Description</th>
                            <th>Done</th>
                        </tr>    
                    </thead>
                    <tbody>
                            {this.todoTableRows(true)}
                    </tbody>
                </table>
            }
        </div>
}

//<div className="my-1">
//    <input className="form-control" value={this.state.newItemText}
//        onChange={this.updateNewTextValue} />
//    <button className="btn btn-primary mt-1" onClick={this.createNewTodo}>
//        Add new to do
//    </button>
//</div>

//<div className="bg-primary text-white text-center p-2">
//    {this.state.userName}'s To do list
//    ({this.state.todoItems.filter(t => !t.done).length} items to do)
//</div>

//<button className="btn btn-primary m-2" onClick={this.changeStateData}>
//    Change
//</button>

//return (
//    <div>
//        <div className="bg-primary text-white text-center p-2">
//            {this.state.userName}'s To do list
//        </div>
//        <button className="btn btn-primary m-2" onClick={this.changeStateData}>
//            Change
//        </button>
//    </div>
//)
