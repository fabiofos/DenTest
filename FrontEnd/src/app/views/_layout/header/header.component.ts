import { Component, OnInit } from '@angular/core';
import { NotificationService } from 'src/app/services/notification.service';
import { HeaderService } from './header.service';
import * as signalR from '@microsoft/signalr';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  public newNotifications: number = 0;
  errorMessage: string = "";
  constructor(private headerService: HeaderService,
    private notificationService: NotificationService) { }

    ngOnInit() {  
      this.getNotifications();  
      const connection = new signalR.HubConnectionBuilder()  
        .configureLogging(signalR.LogLevel.Information)  
        .withUrl(environment.baseUrl + 'notify')  
        .build();  
    
      connection.start().then(function () {  
      }).catch(function (err) {  
        return console.error(err.toString());  
      });  
    
      connection.on("BroadcastMessage", () => {  
        this.getNotifications();  
      });  
    }  
  

  get title(): string {
    return this.headerService.headerData.title
  }


  get icon(): string {
    return this.headerService.headerData.icon
  }


  get routeUrl(): string {
    return this.headerService.headerData.routeUrl
  }

  getNotifications(){
    this.notificationService.getNotificationCount().subscribe(
      nots => {
        console.log('notifications', nots)
        this.newNotifications = nots;
      },
      error => this.errorMessage = <any>error
    );
  }

}
