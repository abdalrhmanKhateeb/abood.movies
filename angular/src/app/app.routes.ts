import { Routes } from '@angular/router';
import { CustomerComponent } from './customer/customer.component';
import { HomeComponent } from './home/home.component';
import { MovieComponent } from './movie/movie.component';
import { DirectorComponent } from './director/director.component';
import { RentalComponent } from './rental/rental.component';

export const appRoutes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.routes').then(m => m.homeRoutes),
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(m => m.createRoutes()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(m => m.createRoutes()),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management').then(m => m.createRoutes()),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.createRoutes()),
  },
  {
  
  path: 'customers',
    component: CustomerComponent,
  },
  {
    path: 'movies',
    component: MovieComponent,
  },
   {
    path: 'directors',
    component: DirectorComponent,
  },
  {
  path: 'rentals',
  component: RentalComponent,
},
    {
    path: '',
    component: HomeComponent,
  },
 
];






