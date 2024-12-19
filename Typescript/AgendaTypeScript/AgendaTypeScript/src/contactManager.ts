import { Contact } from './Contact';

export class ContactManager {
    private contacts: Contact[] = [];

    //Agregar un contacto

    addContact(contact: Contact): void {
        this.contacts.push(contact);
        console.log(`Contacto agregado ${ contact.name }`)
    }

    //Listar todos los contactos

    listContacts(): void {
        if (this.contacts.length == 0) {
            console.log("No hay contactos en la agenda");
            return
        }

        console.log("Lista de contactos");

        this.contacts.forEach((contact, index) => {
            console.log(`${index + 1}.${contact.name} - ${contact.phone} - ${contact.email}`)
        })
    }

    //Buscar un contacto por su nombre

    searchContactName(name: string): void {

        const found = this.contacts.filter(contact => contact.name.toLowerCase().includes(name.toLowerCase()));

        if (found.length == 0) {
            console.log(`No se han encontrado coincidencias para este nombre ${name}`);
            return;
        }

        console.log("Contacto encontrado");
        found.forEach(contact => {
            console.log(`${contact.name} - ${contact.phone} - ${contact.email}`)
        })
    }

    //Eliminar un contacto

    deleteContact(name: string): void {
        const initialLength = this.contacts.length;
        this.contacts = this.contacts.filter(contact => contact.name.toLowerCase() !== name.toLowerCase());

        if (this.contacts.length < initialLength) {
            console.log(`Contacto(s) con el nombre ${name} eliminados`)
        } else {
            console.log(`No se ha encontrado ningun registro con ese nombre ${name}`)
        }
    }

}