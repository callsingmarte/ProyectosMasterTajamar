import { PRODUCTS, SUPPLIERS } from "./dataTypes"

export const initialData = {
    modelData: {
        [PRODUCTS]: [
            { id: 1, name: "Trail Shoes", category: "Running", price: 100 },
            { id: 2, name: "Thermal Hat", category: "Running", price: 12 },
            { id: 3, name: "Heated Gloves", category: "Running", price: 82.50 }
        ],
        [SUPPLIERS]: [
            { id: 1, name: "Zoom Shoes", city: "London", products: ["Trail Shoes"] },
            { id: 2, name: "Cosy Gear", city: "New York", products: ["Thermal Hat", "Heated Gloves"] }
        ],
        stateData: {
            editing: false,
            selectedId: -1,
            selectedType: PRODUCTS
        }
    }
}