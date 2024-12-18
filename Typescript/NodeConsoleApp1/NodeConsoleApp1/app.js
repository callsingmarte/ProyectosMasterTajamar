"use strict";
//Tipos primitivos
//Boolean
const booleano = true;
let isDone = false;
//Number
const entero = 10;
const decimal = 10.5;
let decimal2 = 6;
//Entero largos
const bigInt = 10n;
const bigInt1 = 99440949449494949n;
console.log(bigInt1);
//string
const str = 'Hola Master';
let color = "blue";
color = 'red';
let fullname = 'Javier Vazquez';
let age = 45;
let sentence = `Hello my name is ${fullname} I'll be ${age + 1} years old next month.`;
console.log(sentence);
let variable = 'hola';
//let variable1: CustomType = true; //esto da error por que no admite ese tipo
//variable = null //esto da error por que no admite ese tipo
//Arrays Tipados
const numberArray = [1, 2, 3, 4];
let list = [1, 2, 3, 4];
const stringArray = ['a', 'b', 'c'];
const booleanArray = [true, false, false, true];
const nullAndNumberArray = [1, null, 2, null, 3, null];
const valueArray = [1, 'hola', 2, 'adios'];
//Tuplas 
let x;
x = ["Texto"];
x = ["Texto", 5];
//spread operator
let tuplaOpcional;
tuplaOpcional = ["a", 1, 2, 3, 4, 5];
const persona = ["Javier", 45];
/*
const [nombre, edad] = persona;
console.log(nombre);
console.log(edad);
*/
function getUsuario() {
    return ['Alicia', 30];
}
const [nombre, edad] = getUsuario();
//Any
let notSure = 4;
notSure = "a lo mejor es un string";
notSure = false;
notSure = [1, 'hola', 2, 'adios'];
function procesarColor(color) {
    switch (color) {
        case "rojo":
            return "Es rojo";
        case "azul":
            return "Es azul";
        default:
            const nunca = color;
            throw new Error(`Color inesperado ${nunca}`);
    }
}
//Enum
var Direccion;
(function (Direccion) {
    Direccion[Direccion["Norte"] = 0] = "Norte";
    Direccion[Direccion["Sur"] = 1] = "Sur";
    Direccion[Direccion["Este"] = 2] = "Este";
    Direccion[Direccion["Oeste"] = 3] = "Oeste";
})(Direccion || (Direccion = {}));
var Rol;
(function (Rol) {
    Rol["Admin"] = "ADMIN";
    Rol["Usuario"] = "USUARIO";
    Rol["Invitado"] = "INVITADO";
})(Rol || (Rol = {}));
console.log(Direccion[2]);
//No admite valores inversos esto daria error
console.log(Rol["Usuario"]);
var Modo;
(function (Modo) {
    Modo["Manual"] = "MANUAL";
    Modo["Automatico"] = "AUTOMATICO";
})(Modo || (Modo = {}));
function configurarModo(modo) {
    console.log(`Modo seleccionado ${modo}`);
}
configurarModo(Modo["Manual"]);
//void
/*
function saludar(): void {
    console.log("Hola Master");
}
saludar();
*/
function procesar(callback) {
    console.log("Procesando...");
}
procesar(() => {
    console.log("Procesando...");
});
//Null y Undefined
const nulo = null;
const indefinido = undefined;
//Object
let obj;
obj = { clave: "valor" };
obj = [1, 2, 3];
//obj = "cadena" //da error porque es un tipo primitivo;
//obj = 42 //da error porque es un tipo primitivo;
let obj1 = { clave: "valor" };
console.log(Object.keys(obj1)); //-->["clave"]
console.log(Object.values(obj1)); //-->["valor"]
console.log(Object.entries(obj1)); //-->[["clave"],["valor"]]
const userType = {
    name: 'Pepe Alvarez',
    organisation: 'Tajamar',
    email: 'pepe@tajamar.com'
};
console.log(userType.name);
const userInterface = {
    name: 'Pepe Alvarez',
    organisation: 'Tajamar',
    email: 'pepe@tajamar.com'
};
console.log(userInterface.email);
const addUserId = ({ name, organisation, email }) => {
    const id = crypto.randomUUID();
    return { id, name, organisation, email };
};
const userWithoutId = {
    name: "Pepe",
    organisation: "Tajamar",
    email: "pepe@tajamar.com"
};
const userWithId = addUserId(userWithoutId);
//funciones
function sumar(a, b) {
    return a + b;
}
//funcion anonima
const multiplicar = function (a, b) {
    return a * b;
};
//funciones flecha
const dividir = (a, b) => {
    return a / b;
};
//Parametros opcionales
function saludar(nombre, edad) {
    if (edad != undefined) {
        return `Hola ${nombre}, tienes ${edad} a�os`;
    }
    return `Hola ${nombre}`;
}
console.log(saludar("Alicia"));
console.log(saludar("Alicia", 30));
//Parametos predeterminados
function calcularDescuentos(precio, descuento = 10) {
    return precio - (precio * descuento) / 100;
}
console.log(calcularDescuentos(100, 20));
console.log(sumar(3, 4));
//Parametros Rest
function sumarTodo(...numeros) {
    return numeros.reduce((total, num) => total + num, 0);
}
console.log(sumarTodo(1, 2, 3, 4));
const restar = (a, b) => a + b;
console.log(restar(3, 6));
//Funciones Genericas
function identidad(valor) {
    return valor;
}
console.log(identidad(123));
//Funciones Asincronas: valor retornado es una Promise
async function obtenerDatos() {
    return "Datos obtenidos";
}
obtenerDatos().then((datos) => console.log(datos));
console.log(identidad("123"));
async function fetchUser() {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve({
                id: 1,
                name: "Juan Perez",
                email: "juan@example.com"
            });
        }, 1000);
    });
}
console.log();
//# sourceMappingURL=app.js.map