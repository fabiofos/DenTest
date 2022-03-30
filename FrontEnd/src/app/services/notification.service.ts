import { HttpClient, HttpHeaders } from '@angular/common/http';  
import { Injectable } from '@angular/core';  
import { Observable, throwError } from 'rxjs';  
import { catchError } from 'rxjs/operators';  
import { environment } from 'src/environments/environment';  
  
@Injectable({  
  providedIn: 'root'  
})  
export class NotificationService {  
  
  private notificationsUrl = environment.baseUrl +'signalr/webapi/v1/SignalR';  
  
  constructor(private http: HttpClient) { }  
  
  getNotificationCount(): Observable<number> {  
    const url = `${this.notificationsUrl}/GetNotificationCount`;  
    return this.http.get<number>(url)  
      .pipe(  
        catchError(this.handleError)  
      );  
  }  
  
  getNotificationMessage(): Observable<Array<Notification>> {  
    const url = `${this.notificationsUrl}/GetNotificationMessage`;  
    return this.http.get<Array<Notification>>(url)  
      .pipe(  
        catchError(this.handleError)  
      );  
  }  

  private handleError(err: any) {  
    let errorMessage: string;  
    if (err.error instanceof ErrorEvent) {  
      errorMessage = `An error occurred: ${err.error.message}`;  
    } else {  
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;  
    }  
    console.error(err);  
    return throwError(errorMessage);  
  }  
} 