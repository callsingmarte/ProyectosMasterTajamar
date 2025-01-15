import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Message } from '../message.model';
import { MessageService } from '../message.service';

@Component({
  selector: 'app-message',
  imports: [CommonModule],
  standalone: true,
  templateUrl: './message.component.html',
  styleUrl: './message.component.css'
})
export class MessageComponent {
  lastMessage?: Message;

  constructor(messageService: MessageService) {
    messageService.messages.subscribe(msg => this.lastMessage = msg);
  }
}
