import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  {
    provide: APP_INITIALIZER,
    useFactory: configureRoutes,
    deps: [RoutesService],
    multi: true,
  },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/directors',
        name: 'Directors',
        iconClass: 'fas fa-user-tie',
        order: 2,
        layout: eLayoutType.application,
      },
      {
        path: '/movies',
        name: '::Movies',
        iconClass: 'fas fa-film',
        order: 3,
        layout: eLayoutType.application,
      },
      {
        path: '/customers',
        name: 'Customers',
        iconClass: 'fas fa-users',
        order: 4,
        layout: eLayoutType.application,
      },
      {
        path: '/rentals',
        name: 'Rentals',
        iconClass: 'fas fa-clipboard-list',
        order: 5,
        layout: eLayoutType.application,
      },
    ]);
  };
}