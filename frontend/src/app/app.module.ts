import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; 
import { provideHttpClient, withInterceptorsFromDi, withFetch   } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module'; 
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';

import { registerLocaleData } from '@angular/common';
import localeEs from '@angular/common/locales/es'; // We import the Spanish locale (Spain)

import { AppComponent } from './app.component'
import { ShowMasterInfoComponent } from './show-master-info/show-master-info.component';  
import { InformationDialogComponent } from './modals/information-dialog/information-dialog.component';
import { ShowInfoAnthemsComponent } from './show-info-anthems/show-info-anthems.component';
import { ShowInfoCoatOfArmsComponent } from './show-info-coat-of-arms/show-info-coat-of-arms.component';
import { ShowInfoFlagComponent } from './show-info-flag/show-info-flag.component';
import { ShowInfoCountryComponent } from './show-info-country/show-info-country.component';
import { ShowInfoMapComponent } from './show-info-map/show-info-map.component';

registerLocaleData(localeEs, 'es-ES');  // Registry locale

@NgModule({
  declarations: [
    AppComponent,
    ShowMasterInfoComponent,
    InformationDialogComponent,
    ShowInfoAnthemsComponent,
    ShowInfoCoatOfArmsComponent,
    ShowInfoFlagComponent,
    ShowInfoCountryComponent,
    ShowInfoMapComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    MatButtonModule,
    MatCardModule,
    MatInputModule,
    MatSnackBarModule,
    BrowserAnimationsModule,
    MatDialogModule
  ],
  providers: [
    provideHttpClient(withInterceptorsFromDi(), withFetch())
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
