import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: '::Movies',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44374/',
    redirectUri: baseUrl,
    clientId: 'Movies_App',
    responseType: 'code',
    scope: 'offline_access Movies',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44374',
      rootNamespace: 'Abood.Movies',
    },
  },
} as Environment;
