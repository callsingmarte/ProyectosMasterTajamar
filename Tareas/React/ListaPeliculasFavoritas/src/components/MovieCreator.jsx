import { Component } from "react";
export class MovieCreator extends Component {
    constructor(props) {
        super(props)
        this.state = {
            newMovie: {
                name: "",
                genre: "",
                year: new Date(),
                score: 0,
                viewed: false
            },
        }
    }

    updateNewMovie = (event, field) => {   
        const value = field === "score" && event.target.value ? parseInt(event.target.value) : event.target.value 
        this.setState((originalMovie) => ({
            newMovie: { ...originalMovie.newMovie, [field]: value }
        }))
    }

    createNewMovie = () => {
        this.props.callback(this.state.newMovie);
        this.setState({
            newMovie: {
                name: "",
                genre: "",
                year: new Date(),
                score: 0,
                viewed: false
            }
        })
    }

    render = () =>
        <div className="my-1">
            <div className="row">
                <div className="col">
                    <label>Name</label>
                    <input className="form-control" value={this.state.newMovie.name} onChange={(e) => this.updateNewMovie(e, "name")} />
                </div>
                <div className="col">
                    <label>Genre</label>
                    <input className="form-control" value={this.state.newMovie.genre} onChange={(e) => this.updateNewMovie(e, "genre")} />
                </div>
                <div className="col">
                    <label>Year</label>
                    <input className="form-control" value={this.state.newMovie.year} onChange={(e) => this.updateNewMovie(e, "year")} type="date" />
                </div>
                <div className="col">
                    <label>Score</label>
                    <input className="form-control" value={this.state.newMovie.score} onChange={(e) => this.updateNewMovie(e, "score")} />
                </div>
            </div>
            <div className="col">
                <button className="btn btn-primary mt-1" onClick={this.createNewMovie}>Add</button>
            </div>
        </div>
}