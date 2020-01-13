import { Routes } from '@angular/router';
import { SectionSaleComponent } from './app/sections/section-sale/section-sale.component';
import { SectionOrdersComponent } from './app/sections/section-orders/section-orders.component';
import { SectionHealthComponent } from './app/sections/section-health/section-health.component';

export const appRoutes: Routes = [
    {path: 'sales', component: SectionSaleComponent},
    {path: 'orders', component: SectionOrdersComponent},
    {path: 'health', component: SectionHealthComponent},

    {path: '', redirectTo: '/sales', pathMatch: 'full'}
];