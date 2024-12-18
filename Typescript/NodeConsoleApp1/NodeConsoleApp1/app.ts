//Tipos primitivos
//Boolean

const booleano: boolean = true;
let isDone: boolean = false;

//Number

const entero: number = 10;
const decimal: number = 10.5;

let decimal2: number = 6;

//Entero largos
const bigInt: bigint = 10n;
const bigInt1: bigint = 99440949449494949n;

console.log(bigInt1);
//string

const str: string = 'Hola Master';
let color: string = "blue";

color = 'red';

let fullname: string = 'Javier Vazquez';
let age: number = 45;

let sentence: string = `Hello my name is ${fullname} I'll be ${age + 1} years old next month.`;

console.log(sentence);

//Tipos personalizados

type CustomType = string | number;

let variable: CustomType = 'hola';

//let variable1: CustomType = true; //esto da error por que no admite ese tipo
//variable = null //esto da error por que no admite ese tipo

//Arrays Tipados
const numberArray: number[] = [1, 2, 3, 4]
// let list: Array<number> = [1, 2, 3, 4]

const stringArray: string[] = ['a', 'b', 'c']
const booleanArray: boolean[] = [true, false, false, true];

const nullAndNumberArray: (null | number)[] = [1, null, 2, null, 3, null]

//const errorNumArray: number[] = [1, 2, 3, 4, 'hola'];

type arrayCustomType = string | number;

const valueArray: arrayCustomType[] = [1, 'hola', 2, 'adios'];

//Tuplas 
let x: [string, number?];
x = ["Texto"];
x = ["Texto", 5];

//spread operator

let tuplaOpcional : [string, ...number[]]
tuplaOpcional = ["a", 1, 2, 3, 4, 5]

// const persona: [string, number] = ["Javier", 45];
/*
const [nombre, edad] = persona;
console.log(nombre);
console.log(edad);
*/
function getUsuario(): [string, number] {
    return ['Alicia', 30];
}

const [nombre, edad] = getUsuario();

//Any
let notSure: any = 4;
notSure = "a lo mejor es un string";
notSure = false;

notSure = [1, 'hola', 2, 'adios'];

//Never
type Colores = "rojo" | "azul"

function procesarColor(color: Colores): string {
    switch (color) {
        case "rojo":
            return "Es rojo";
        case "azul":
            return "Es azul";
        default:
            const nunca: never = color;
            throw new Error(`Color inesperado ${nunca}`);
    }
}

//Enum
enum Direccion {
    Norte,
    Sur,
    Este,
    Oeste
}

enum Rol {
    Admin = "ADMIN",
    Usuario = "USUARIO",
    Invitado = "INVITADO"
}
console.log(Direccion[2]);
//No admite valores inversos esto daria error
console.log(Rol["Usuario"]);

enum Modo {
    Manual = "MANUAL",
    Automatico = "AUTOMATICO"
}

function configurarModo(modo: Modo): void
{
    console.log(`Modo seleccionado ${modo}`)
}

configurarModo(Modo["Manual"]);

//void
/*
function saludar(): void {
    console.log("Hola Master");
}
saludar();
*/

function procesar(callback: () => void): void {
    console.log("Procesando...");

}

procesar(() => {
    console.log("Procesando...")
})

//Null y Undefined
const nulo: null = null;
const indefinido: undefined = undefined;

//Object
let obj: object;
obj = { clave: "valor" }
obj = [1, 2, 3];
//obj = "cadena" //da error porque es un tipo primitivo;
//obj = 42 //da error porque es un tipo primitivo;

let obj1 = { clave: "valor" };

console.log(Object.keys(obj1));//-->["clave"]
console.log(Object.values(obj1));//-->["valor"]
console.log(Object.entries(obj1))//-->[["clave"],["valor"]]

//Objetos tipados
//Utilizando type

type UserType = {
    name: string,
    organisation: string,
    email: string
}

type ExtendedUserType = UserType & {
    age:number
}

const userType: UserType = {
    name: 'Pepe Alvarez',
    organisation: 'Tajamar',
    email: 'pepe@tajamar.com'
}

console.log(userType.name);

//Utilizando interface
interface UserInterface {
    name: string,
    organisation: string,
    email: string
}

interface ExtendedUserInterface extends UserInterface {
    age: number
}

const userInterface: UserInterface = {
    name: 'Pepe Alvarez',
    organisation: 'Tajamar',
    email: 'pepe@tajamar.com'
}

console.log(userInterface.email);
/*
interface User {
    name: string
    organisation: string
    email: string
}
interface UserWithId extends User {
    id: string
}

const addUserId = ({ name, organisation, email }: User): UserWithId => {
    const id: string = crypto.randomUUID()
    return {id, name, organisation, email}
}

const userWithoutId: User = {
    name: "Pepe",
    organisation: "Tajamar",
    email: "pepe@tajamar.com"
}

const userWithId = addUserId(userWithoutId);
*/

//funciones
function sumar(a: number, b: number): number {
    return a + b;
}

//funcion anonima
const multiplicar = function (a: number, b: number): number {
    return a * b;
}

//funciones flecha
const dividir = (a: number, b: number): number => {
    return a / b;
}

//Parametros opcionales
/*
function saludar(nombre: string, edad?: number) : string {
    if (edad != undefined) {
        return `Hola ${nombre}, tienes ${edad} años`;
    }
    return `Hola ${nombre}`;
}

console.log(saludar("Alicia"))
console.log(saludar("Alicia", 30))
*/

//Parametos predeterminados
function calcularDescuentos(precio: number, descuento: number = 10): number {
    return precio - (precio * descuento) / 100;
}

console.log(calcularDescuentos(100, 20))
console.log(sumar(3, 4))

//Parametros Rest
function sumarTodo(...numeros: number[]): number {
    return numeros.reduce((total, num) => total + num, 0);
}

console.log(sumarTodo(1, 2, 3, 4));

//Sobrecarga
/*
function combinar(a: string, b: string): string;
function combinar(a: number, b: number): number;
function combinar(a: any, b: any): any;

console.log(combinar(1, 2));
console.log(combinar("Hola", "Adios"));
*/

//Funciones typadas

type Operacion = (a: number, b: number) => number;

const restar: Operacion = (a, b) => a + b;

console.log(restar(3, 6));

//Funciones Genericas
function identidad<T>(valor: T): T {
    return valor;
}

console.log(identidad(123));

//Funciones Asincronas: valor retornado es una Promise
async function obtenerDatos(): Promise<string> {
    return "Datos obtenidos";
}

obtenerDatos().then((datos) => console.log(datos));

console.log(identidad("123"));

//Promise tipos
//Promise<void>
//Promise<T>
//Promise<unknown>

interface User {
    id: number;
    name: string;
    email: string;
}

async function fetchUser(): Promise<User> {
    return new Promise((resolve, rejects) => {
        setTimeout(() => {
            resolve({
                id: 1,
                name: "Juan Perez",
                email: "juan@example.com"
            });
        }, 1000);
        fetchUser().then(user => {
            console.log(user.name); //Imprime Juan Perez
        })
            .catch(error => {
                console.error("Error: ", error);
            });
    })
}

//Declare
/*
declare function saludar(nombre: string): void;
declare let mivariableGlobal: number;
*/

//Cast
let cualquierValor: any = "Hola master";
let longitud: number = (cualquierValor as string).length;

interface Persona {
    nombre: string;
    edad: number;
}

let cualquierObjeto: any = { nombre: "Alicia", edad: 30 };
let persona = cualquierObjeto as Persona;

console.log(persona.nombre);

//Iterativas
//for...In for...of
let list = [4, 5, 6];
for (let i in list) {
    console.log(i); //"0", "1", "2"
}

for (let i of list) {
    console.log(i); //"4","5","6"
}

//Modulos
export type RankingTuple = [number, string, boolean];
export function printRankings(rankings: Array<RankingTuple>): void {
    for (let ranking of rankings) {
        console.log(ranking)
    }
}

export const PI = 3.14;

export function sumardos(a: number, b: number): number {
    return a + b;
}

//Clases
class Employee {
    public name: string;
    protected age: number;
    private mobile: string;

    constructor(name: string, age: number, mobile: string) {
        this.name = name;
        this.age = age;
        this.mobile = mobile;
    }

    get Name() {
        return this.name;
    }
    set Name(name: string) {
        this.name = name;
    }

}

class Actor {
    private _name: string;
    constructor(name: string){
        this._name = name
    }
    set name(value: string){
        this._name = value;
    }
    get name(){
        return this._name;
    }
}

let actor = new Actor("Marlon Brandon");
console.log(actor.name);
actor.name = "Jane Doe"
console.log(actor.name);

//Herencia
class Manager extends Employee {
    constructor(name: string, age: number, mobile: string) {
        super(name, age, mobile);
        this.age = 25;
    }
}

let manager = new Manager("Javier", 23, "0321s6s984");

console.log(manager.Name);

//Clases Abstractas
abstract class Product {
    productName: string = "Default";
    price: number = 1000;

    abstract changeName(name: string): void;

    calcPrice() {
        return this.price
    }
}
class Mobile extends Product {
    changeName(name: string): void {
        this.productName = name;
    }
}

let mobProduct = new Mobile();
console.log(mobProduct);
mobProduct.changeName("Super mobile");
console.log(mobProduct);

//Interfaces

interface Vehiculo {
    marca: string;
    encender(): void;
    apagar(): void;
}

class Coche implements Vehiculo {
    marca: string;
    constructor(marca: string) {
        this.marca = marca;
    }
    encender() {
        console.log(`${this.marca} esta encendiendose`)
    }
    apagar() {
        console.log(`${this.marca} esta apagandose`)
    }
}

const miCoche = new Coche("Skoda");
miCoche.encender();
miCoche.apagar();

//Decoradores : @midecorador

//De clase, de Metodo, de Propiedad, de Parametro

//De clase: funcion que recibe y devuelve el constructor de la clase que decora

function Logger(constructor: Function) {
    console.log(`Clase Registrada: ${constructor.name}`)
}

@Logger
class Persona {
    constructor(public nombre: string) { }
}

const personaNueva = new Persona("Juan");


function log<T extends { new(...args: any[]): {} }>(originalConstructor: T) {
    return class extends originalConstructor {
        constructor(...args: any[]) {
            console.log("Argumentos: ", args.join(", "));
            super(...args); // Llama al constructor original
        }
    };
}

@log
class Person {
    constructor(name: string, age: number) {

    }
}

new Person("Miguel", 33)


console.log();