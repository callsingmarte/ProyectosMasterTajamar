import { Component } from "react";
import { Selector } from "./Selector";
import { ProductDisplay } from "./product/ProductDisplay";
import { SupplierDisplay } from "./supplier/SupplierDisplay";

export default class ProductsAndSuppliers extends Component {

    constructor(props) {
        super(props)
        this.state = {
            products: [
                { id: 1, name: "Kayak",category: "Watersports", price: 275 },
                { id: 2, name: "Lifejacket", category: "Watersports", price: 48.95 },
                { id: 3, name: "Soccer Ball", category: "Soccer", price: 19.50 }
            ],
            suppliers: [
                { id: 1, name: "Surf Dudes", city: "San Jose", products: ["Kayak", "Lifejacket"] },
                { id: 2, name: "Field Supplies", city: "New York", products: ["Soccer Ball"] },
            ]
        }
        this.idContador = 100
    }
    saveData = (collection, item) => {
        if (item.id === "") {
            item.id = this.idContador++
            this.setState(prevState => ({
                [collection]: [...prevState[collection], item]
            }))
        } else {
            this.setState(state => state[collection] = state[collection]
                .map(stored => stored.id === item.id ? item : stored))
        }
    }

    deleteData = (collection, item) => {
        this.setState(state => state[collection] = state[collection].filter(stored => stored.id !== item.id))
    }

    render() {
        return <div>
            <Selector>
                <ProductDisplay name="Products"
                    saveCallback={p => this.saveData("products", p)}
                    deleteCallback={p => this.deleteData("products", p)}
                    products={ this.state.products }
                />
                <SupplierDisplay
                    name="Suppliers"
                    saveCallback={s => this.saveData("suppliers", s)}
                    deleteCallback={s => this.deleteData("suppliers", s)}
                    suppliers={this.state.suppliers}
                />
            </Selector>
        </div>
    }

}