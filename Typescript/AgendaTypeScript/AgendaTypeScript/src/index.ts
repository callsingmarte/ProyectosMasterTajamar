import { Contact } from './Contact';
import { ContactManager } from './ContactManager';
import readLineSync from 'readline-sync';

const manager = new ContactManager;

function showMenu(): void {
    console.log("\nGestion de contactos:");
    console.log("\n 1.Agregar contacto:");
    console.log("\n 2.Listar contacto:");
    console.log("\n 3.Buscar contacto:");
    console.log("\n 4.Eliminar contacto:");
    console.log("\n 5.Salir");
}

function main(): void {
    let exit = false;

    while (!exit) {
        showMenu();
        const choice = readLineSync.questionInt("\nseleccione una opcion: ");

        switch (choice) {
            case 1:
                const name = readLineSync.question("Nombre: ");
                const phone = readLineSync.question("Phone: ");
                const email = readLineSync.questionEMail("Email: ");

                const contact: Contact = { name, phone, email }
                manager.addContact(contact);
                break;
            case 2:
                manager.listContacts();
                break;
            case 3:
                const searchName = readLineSync.question("Nombre: ");
                manager.searchContactName(searchName);
                break;
            case 4:
                const deleteName = readLineSync.question("Nombre a borrar: ");
                manager.deleteContact(deleteName);
                break;
            case 5:
                exit = true;
                console.log("Saliendo del programa");
                break;
            default:
                console.log("Opcion no valida");
                break;
        }
    }
}

main();