import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './views/_layout/header/header.component';
import { DashboardComponent } from './views/_layout/dashboard/dashboard.component';
import { LoadingPanelComponent } from './views/_layout/loading-panel/loading-panel.component';
import { MessagePopUpComponent } from './views/_layout/message-pop-up/message-pop-up.component';
import { MenuComponent } from './views/_layout/menu/menu.component';
import { FooterComponent } from './views/_layout/footer/footer.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatMenuModule} from '@angular/material/menu';
import { ToastrModule } from 'ngx-toastr';
import { MatIconModule } from '@angular/material/icon'
import {
  DxDataGridModule,
  DxPopupModule,
  DxLoadPanelModule,
  DxCalendarModule,
  DxTemplateModule,
  DxSelectBoxModule,
  DxPopoverModule,
  DxValidatorModule
} from 'devextreme-angular';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { DatePipe } from '@angular/common';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    DashboardComponent,
    LoadingPanelComponent,
    MessagePopUpComponent,
    MenuComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FontAwesomeModule,
    DxDataGridModule,
    DxPopupModule,
    DxLoadPanelModule,
    DxCalendarModule,
    DxTemplateModule,
    DxSelectBoxModule,
    DxPopoverModule,
    DxValidatorModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatCardModule,
    MatButtonModule,
    MatSnackBarModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatMenuModule,
    MatIconModule,
    ReactiveFormsModule,
    FormsModule,
    ToastrModule.forRoot(), // ToastrModule added
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
