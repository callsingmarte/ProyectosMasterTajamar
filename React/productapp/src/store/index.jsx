import { configureStore } from "@reduxjs/toolkit";
import modelReducer from "./modelReducer";


const store = configureStore({
    reducer: modelReducer
})

export default store

export { saveProduct, saveSupplier, deleteProduct, deleteSupplier } from "./modelActionCreators"