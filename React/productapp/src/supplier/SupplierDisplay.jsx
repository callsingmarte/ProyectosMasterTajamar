import { Component } from "react";
import { SupplierEditor } from "./SupplierEditor";
import { SupplierTable } from "./SupplierTable";
import { connect } from "react-redux"
import { saveSupplier, deleteSupplier } from "../store"
import { SUPPLIERS } from "../store/dataTypes";
import { EditorConnector } from "../store/EditorConnector";
import { TableConnector } from "../store/TableConnector";
import { startCreatingSupplier } from "../store/stateActions";


const ConnectedEditor = EditorConnector(SUPPLIERS, SupplierEditor)
const ConnectedTable = TableConnector(SUPPLIERS, SupplierTable)

const mapStateToProps = (storeData) => ({
    editing: storeData.stateData.editing,
    selected: storeData.modelData.suppliers.find(item => item.id === storeData.stateData.selectedId) || {}
})

const mapDispatchToProps = {
    createSupplier: startCreatingSupplier
}

const connectFunction = connect(mapStateToProps, mapDispatchToProps)

export const SupplierDisplay = connectFunction (class extends Component {
    //constructor(props) {
    //    super(props)
    //    this.state = {
    //        showEditor: false,
    //        selected: null
    //    }
    //}

    //startEditing = (supplier) => {
    //    this.setState({ showEditor: true, selected: supplier })
    //}
    //createSupplier = () => {
    //    this.setState({ showEditor: true, selected: {} })
    //}

    //cancelEditing = () => {
    //    this.setState({ showEditor: false, selected: null })
    //}

    //saveSupplier = (Supplier) => {
    //    this.props.saveCallback(Supplier);
    //    this.setState({ showEditor: false, selected: null })
    //}

    render() {
        if (this.props.editing) {
            return <ConnectedEditor key={this.props.selected.id || -1} />
        } else {
            return <div className="m-2">
                <ConnectedTable />
                <div className="text-center">
                    <button className="btn btn-primary m-1" onClick={this.props.createSupplier}>
                        Create Supplier
                    </button>
                </div>
            </div>
        }
    }

    //render() {
    //    if (this.state.showEditor) {
    //        return <SupplierEditor key={this.state.selected.id || -1}
    //            supplier={this.state.selected} saveCallback={this.saveSupplier}
    //            cancelCallback={this.cancelEditing}
    //        />
    //    } else {
    //        return <div className="m-2">
    //            <SupplierTable suppliers={this.props.suppliers}
    //                editCallback={this.startEditing}
    //                deleteCallback={this.props.deleteCallback}
    //            />
    //            <div className="text-center">
    //                <button className="btn btn-primary m-1"
    //                    onClick={this.createSupplier}
    //                >
    //                    Create Supplier
    //                </button>
    //            </div>
    //        </div>
    //    }
    //}

})