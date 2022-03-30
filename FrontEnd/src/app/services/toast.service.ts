import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ToastService {
  private title = 'Signal R / NPOI testss'
  constructor(private toastr: ToastrService) { }

  showErrorMessage(infoMessage: string) {
    this.toastr.error(
      infoMessage,
      this.title
    );
  }

  showSuccessMessage(infoMessage: string) {
    this.toastr.success(
      infoMessage,
      this.title
    );
  }

  showInfoMessage(infoMessage: string) {
    this.toastr.info(
      infoMessage,
      this.title
    );
  }
}