import { Component } from "react";

export class MovieBanner extends Component {
    render = () =>
        <h4 className="bg-primary text-white text-center p-2">
            {this.props.name}'s WatchList
            ({this.props.movies.filter(m => !m.viewed).length} movies to view)
        </h4>
}