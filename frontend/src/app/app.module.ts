import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';  // Asegúrate de importar FormsModule
import { provideHttpClient, withInterceptorsFromDi, withFetch   } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';  // Asegúrate de importar el AppRoutingModule


import { AppComponent } from './app.component';
import { InfoComponent } from './info/info.component';
import { registerLocaleData } from '@angular/common';
import localeEs from '@angular/common/locales/es';  // We import the Spanish locale (Spain)

registerLocaleData(localeEs, 'es-ES');  // Registry locale

@NgModule({
  declarations: [
    AppComponent,
    InfoComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [
    provideHttpClient(withInterceptorsFromDi(), withFetch())
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
