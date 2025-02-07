import { configureStore } from "@reduxjs/toolkit";
import modelReducer from "./modelReducer";
import { combineReducers } from "redux"
import stateReducer from "./stateReducer";

export default configureStore({
    reducer: combineReducers({
        modelData: modelReducer,
        stateData: stateReducer
    })
})

export { saveProduct, saveSupplier, deleteProduct, deleteSupplier } from "./modelActionCreators"