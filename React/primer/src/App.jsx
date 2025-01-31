//import { Component } from "react";
//Se puede definir asi pero esto impide quese pueda importar desde otro sitio
//export default class extends Component
//Esta es otra forma de definirlo
//export default class App extends Component {
//    constructor(props) {
//        super(props)
//        this.state = {
//            count: 4
//        }
//    }
//    isEven() { return this.state.count % 2 === 0 ? 'Even' : 'Odd' }
//    getClassName(val) {
//        return val % 2 === 0 ? "bg-primary text-white text-center p-2 m-1" :
//             "bg-secondary text-white text-center p-2 m-1"
//    }
//    //Siempre que tengamos una funcion que maneje eventos lanzarla asi con el fat arrow
//    handleClick = () => this.setState({count: this.state.count + 1})
//    render = () =>
//        <h4 className={this.getClassName(this.state.count)}>
//            <button className="btn btn-info m-2" onClick={this.handleClick}>Click Me</button>
//        </h4>
//}

import React from "react";
import { Message } from "./Message"
import { Summary } from "./Summary";

export default function App() {
    return (
        <div>
            <h1 className="bg-success text-white text-center p-2">
                Hola Master
            </h1>
            <Message greeting="Hello" name="Maria"/>
            <Message greeting="Hola" name="Pepe" />
            <Summary names={["Bob", "Alice", "Dora"]} />
        </div>
    )
}

//export const App = () => 
//    <h1 className="bg-success text-white text-center p-2">
//        Hola Master
//    </h1>

//export default App;