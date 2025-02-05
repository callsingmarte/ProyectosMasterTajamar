import { Component } from 'react'
export class MoviewRow extends Component {
    render = () => 
        <tr>
            <td>{this.props.item.name} </td>
            <td>{this.props.item.genre} </td>
            <td>{this.props.item.year} </td>
            <td>                 
                <input type="number" value={this.props.item.score}
                    onChange={(e) => this.props.updateScore(this.props.item, parseInt(e.target.value))} min="0" max="10"/>            
            </td>
            <td>
                <input type="checkbox" checked={this.props.item.viewed}
                    onChange={() => this.props.callback(this.props.item) }
                />
            </td>
            <td>
                <button className="btn btn-danger" onClick={() => this.props.deleteRow(this.props.item)}>Eliminar</button>
            </td>
        </tr>
}