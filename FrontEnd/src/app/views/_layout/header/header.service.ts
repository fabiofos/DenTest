import { HeaderData } from './header-data.model';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HeaderService {
  notification: number = 0;
  errorMessage: string = "";

  private _headerData = new BehaviorSubject<HeaderData>({
    title: 'Login',
    icon: 'person',
    routeUrl: ''
  })

  constructor() { }

  get headerData(): HeaderData {
    return this._headerData.value
  }

  set headerData(headerdata: HeaderData) {
   this._headerData.next(headerdata)
  }
}
