import { GenerarComponent } from './components/generar/generar.component';
import { CanjeComponent } from './components/canje/canje.component';
import { Routes } from '@angular/router';

export const APP_ROUTES: Routes = [
    { path: 'generar', component: GenerarComponent },
    { path: 'canjear', component: CanjeComponent },
    { path: '', pathMatch: 'full' , redirectTo: 'generar' },
    { path: '**', pathMatch: 'full' , redirectTo: 'generar'}
  ];
