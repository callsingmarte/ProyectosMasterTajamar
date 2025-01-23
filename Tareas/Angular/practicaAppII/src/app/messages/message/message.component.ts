import { Component } from '@angular/core';
import { Message } from '../message.model';
import { MessageService } from '../message.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-message',
  imports: [CommonModule],
  templateUrl: './message.component.html',
  styleUrl: './message.component.css'
})
export class MessageComponent {
  lastMessage?: Message;

  constructor(messageService: MessageService) {
    messageService.messages.subscribe(msg => this.lastMessage = msg);
  }
}
