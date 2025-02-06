import { Component } from "react";
import { SupplierTableRow } from "./SupplierTableRow";

export class SupplierTable extends Component {
    render() {
        return <table className="table table-sm table-striped table-bordered">
            <thead>
                <tr>
                    <th colSpan="5" className="bg-primary text-white text-center h4 p-2">
                        Suppliers
                    </th>
                </tr>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>City</th>
                    <th>Products</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {
                    this.props.suppliers.map(s =>
                        <SupplierTableRow supplier={s} key={s.id}
                            editCallback={this.props.editCallback}
                            deleteCallback={this.props.deleteCallback}
                        />
                    )
                }
            </tbody>
        </table>
    }
}