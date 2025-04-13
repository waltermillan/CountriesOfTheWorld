import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShowMasterInfoComponent } from './show-master-info/show-master-info.component';  

const routes: Routes = [
  { path: '', component: ShowMasterInfoComponent },
  { path: 'show-info-country/:id', component: ShowMasterInfoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
