import { Component } from "react";
import { Provider } from "react-redux";
import { Selector } from "./Selector"
import dataStore from "./store";
import { ProductDisplay } from "./product/ProductDisplay";
import { SupplierDisplay } from "./supplier/SupplierDisplay";

export default class App extends Component {
    render() {
        return(
            <Provider store={dataStore}>        
                <Selector>
                    <ProductDisplay name="Products" />
                    <SupplierDisplay name="Suppliers" />
                </Selector>
            </Provider>
        )           
    }
}