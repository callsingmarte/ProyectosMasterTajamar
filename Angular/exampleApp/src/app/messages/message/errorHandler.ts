import { ErrorHandler, Injectable, NgZone } from "@angular/core";
import { MessageService } from "../message.service";
import { Message } from "../message.model";

@Injectable({
  providedIn: 'root'
})

export class MessageErrorHandler implements ErrorHandler {

  constructor(private messageService: MessageService, private ngZone: NgZone) {

  }

  handleError(error: any) {
    let msg = error instanceof Error ? error.message : error.toString();
    this.ngZone.run(() => this.messageService.reportMessage(new Message(msg, true)), 0)
    //El 0 hace referencia al delay en milisegundos que indica cuando ejecutar la funcion
  }
}
