import { Component } from "react";
import { Editor } from "./components/Editor";
import { Display } from "./components/Display";

export default class App extends Component {

    constructor(props) {
        super(props)
        this.state = {
            courses: [
                { title: "Agile", seatCapacity: 20, instructorName: "John Jones"},
                { title: "C#", seatCapacity: 15, instructorName: "John Jones"},
                { title: "Angular", seatCapacity: 13, instructorName: "Ross Miller"},
                { title: "Java", seatCapacity: 10, instructorName: "Alex Walker"}
            ]
        }
    }

    submitData = (newData) => {
        newData.seatCapacity = parseInt(newData.seatCapacity)
        this.state.courses.push(newData)
        this.setState({
            courses: this.state.courses,
        })
    }

    render() {
        return <div className="container-fluid">
            <div className="row p-2">
                <div className="col-6">
                    <Editor submit={ this.submitData } />
                </div>
                <div className="col-6">
                    <Display data={  this.state.courses } />
                </div>
            </div>
        </div>
    }
}