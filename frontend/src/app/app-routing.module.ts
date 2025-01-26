import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InfoComponent } from './info/info.component';  // Importa tu componente

const routes: Routes = [
  { path: '', component: InfoComponent },
  { path: 'country-info/:id', component: InfoComponent }  // Definir una ruta para info con un parámetro
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
