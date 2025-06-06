import { connect } from "react-redux"
import { PRODUCTS, SUPPLIERS } from "./dataTypes"
import { saveProduct, saveSupplier } from "./modelActionCreators"
import { endEditing } from "./stateActions"

export const EditorConnector = (dataType, presentationComponent) => {
    const mapStateToProps = (storeData) => ({
        editing: storeData.stateData.editing && storeData.stateData.selectedType === dataType,
        product: (storeData.modelData[PRODUCTS].find(p => p.id === storeData.stateData.selectedId)) || {},
        supplier: (storeData.modelData[SUPPLIERS].find(s => s.id === storeData.stateData.selectedId)) || {},
    })

    const mapDispatchToProps = dispatch => ({
        cancelCallback: () => dispatch(endEditing()), 
        saveCallback: (data) => {
            dispatch((dataType === PRODUCTS ? saveProduct : saveSupplier)(data))
            dispatch(endEditing())
        }
    })

    return connect(mapStateToProps, mapDispatchToProps)(presentationComponent)

}