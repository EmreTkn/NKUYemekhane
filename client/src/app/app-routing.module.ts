import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { AdminComponent } from './admin/admin.component';
import { AppComponent } from './app.component';
import { AuthGuard } from './core/guard/auth.guard';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { StudentComponent } from './student/student.component';


const routes: Routes = [
  {
    path: 'account',
    loadChildren: () => import('./account/account.module')
      .then(mod => mod.AccountModule)
  },
  {
    path: 'orders',
    canActivate:[AuthGuard],
    loadChildren: () => import('./orders/orders.module')
      .then(mod => mod.OrdersModule)
  },
  {
    path: 'checkout',
    canActivate:[AuthGuard],
    loadChildren: () => import('./checkout/checkout.module')
      .then(mod => mod.CheckoutModule)
  },
  {
    path: 'basket',
    canActivate:[AuthGuard],
    loadChildren: () => import('./basket/basket.module')
      .then(mod => mod.BasketModule)
  },
  {
    path: 'admin',
    canActivate:[AuthGuard],
    loadChildren: () => import('./admin/admin.module')
      .then(mod => mod.AdminModule)
  },
  {path:'student',canActivate:[AuthGuard] ,component:StudentComponent},
  {path:'not-found',component:NotFoundComponent},
  {path:'server-error',component:ServerErrorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
