import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrderComponent } from './order.component';
import { OrederDetailedComponent } from './oreder-detailed/oreder-detailed.component';


const routes: Routes = [
  {path: '', component: OrderComponent},
  {path: ':id', component: OrederDetailedComponent}
];


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports:[RouterModule]
})
export class OrdersRoutingModule { }
