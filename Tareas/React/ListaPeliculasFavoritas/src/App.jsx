import { Component } from "react";
import { MovieBanner } from "./components/MovieBanner";
import { MovieCreator } from "./components/MovieCreator";
import { MoviewRow } from "./components/MovieRow";
import { VisibilityControl } from "./components/VisibilityControl";

export default class App extends Component {
    constructor(props) {
        super(props)
        this.state = {
            username: "Martin",
            movies: [
                { name: "La tumba de las luciernagas", genre: "Anime", year: "1995-10-2", score: 6, viewed: true },
                { name: "El viaje de Chihiro", genre: "Anime", year: "2001-6-20", score: 9, viewed: false },
                { name: "Your Name", genre: "Anime", year: "2016-7-26", score: 8, viewed: false },
            ],
            showViewed: true
        }
    }

    createNewMovie = (movie) => {
        if (!this.state.movies.find(items => items.name === movie.name) &&  movie.name !== "") {
            this.setState({
                movies: [...this.state.movies, {
                    name: movie.name,
                    genre: movie.genre,
                    year: movie.year,
                    score: movie.score,
                    viewed: false
                }],
            }, () => localStorage.setItem("movies", JSON.stringify(this.state)))
        }
    }

    toggleMovie = (movie) => this.setState({
        movies: this.state.movies.map(item => item.name === movie.name ? { ...item, viewed: !item.viewed } : item)
    })

    updateScore = (movie, newScore) => this.setState({
        movies: this.state.movies.map(item => item.name === movie.name ? {
            ...item,
            score: newScore && newScore >= 0 && newScore <= 10 ? newScore : 0
        } : item)
    }, () => localStorage.setItem("movies", JSON.stringify(this.state)))

    movieTableRows = (viewedValue) => this.state.movies.filter(item => item.viewed === viewedValue)
        .map(item =>
            <MoviewRow key={item.name} item={item} callback={this.toggleMovie} deleteRow={this.deleteRow} updateScore={this.updateScore} />
        )

    componentDidMount = () => {
        let data = localStorage.getItem("movies")
        this.setState(data != null ? JSON.parse(data) : {
            username: "Martin",
            movies: [
                { name: "La tumba de las luciernagas", genre: "Anime", year: "1995-10-2", score: 6, viewed: true },
                { name: "El viaje de Chihiro", genre: "Anime", year: "2001-6-20", score: 9, viewed: false },
                { name: "Your Name", genre: "Anime", year: "2016-7-26", score: 8, viewed: false },
            ],
            showViewed: true
        })
    }
    deleteRow = (movie) => {
        let index = this.state.movies.findIndex((item) => item.name === movie.name );
        if (index > -1) {
            this.state.movies.splice(index, 1)
            this.setState({ movies: [...this.state.movies] },
                () => localStorage.setItem("movies", JSON.stringify(this.state)))
        }
    }
    render = () =>
        <div>
            <MovieBanner name={this.state.username} movies={this.state.movies} />
            <div className="container-fluid">
                <MovieCreator callback={this.createNewMovie} />
            </div>
            <table className="table table-striped table-bordered">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Genre</th>
                        <th>Year</th>
                        <th>Score</th>
                        <th>Viewed</th>
                    </tr>
                </thead>
                <tbody>
                    {this.movieTableRows(false)}
                </tbody>
            </table>
            <div className="bg-secondary text-white text-center p-2">
                <VisibilityControl description="Viewed movies"
                    isChecked={this.state.showViewed}
                    callback={(checked) => this.setState({ showViewed: checked })}
                ></VisibilityControl>
            </div>
            {
                this.state.showViewed &&
                <table className="table table-striped table-bordered">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Genre</th>
                            <th>Year</th>
                            <th>Score</th>
                            <th>Viewed</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.movieTableRows(true)}
                    </tbody>
                </table>
            }
        </div>
}