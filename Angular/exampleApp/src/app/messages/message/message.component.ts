import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Message } from '../message.model';
import { MessageService } from '../message.service';
import { NavigationCancel, NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-message',
  imports: [CommonModule],
  standalone: true,
  templateUrl: './message.component.html',
  styleUrl: './message.component.css'
})
export class MessageComponent {
  lastMessage?: Message;

  constructor(messageService: MessageService, router: Router) {
    messageService.messages.subscribe(msg => this.lastMessage = msg);
    router.events.subscribe(e => {
      if (e instanceof NavigationEnd || e instanceof NavigationCancel) {
        this.lastMessage = undefined;
      }
    })
  }
}
