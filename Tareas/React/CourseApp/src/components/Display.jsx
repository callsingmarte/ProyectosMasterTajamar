import { Component } from "react";

export class Display extends Component {
    render() {       
        console.log(this.props.data)
        if (!Array.isArray(this.props.data) || this.props.data.length == 0) {
            return <div className="h5 bg-secondary p-2 text-white">
                No data
            </div>
        } else {
            return <div className="container-fluid bg-secondary p-2" >
                <table className="table table-bordered">
                    <thead className="table-primary">
                        <tr>
                            <th>Title</th>
                            <th>Seat Capacity</th>
                            <th>Instructor Name</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.props.data.map(course =>
                            <tr key={course.title}>
                                <td>{course.title}</td>
                                <td>{course.seatCapacity}</td>
                                <td>{course.instructorName}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        }
    }
}