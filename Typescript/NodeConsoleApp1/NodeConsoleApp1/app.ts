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
let list: Array<number> = [1, 2, 3, 4]

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

const persona: [string, number] = ["Javier", 45];
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
function saludar(): void {
    console.log("Hola Master");
}

saludar();

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

console.log();