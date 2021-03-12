import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IOrder } from 'src/app/shared/models/order';
import { OrdersService } from '../orders.service';

@Component({
  selector: 'app-oreder-detailed',
  templateUrl: './oreder-detailed.component.html',
  styleUrls: ['./oreder-detailed.component.scss']
})
export class OrederDetailedComponent implements OnInit {

  order:IOrder;
  constructor(private route:ActivatedRoute,private ordersService:OrdersService) { }

  ngOnInit(): void {
    this.ordersService.getOrderDetailed(+this.route.snapshot.paramMap.get('id'))
    .subscribe((order:IOrder)=>{
      this.order=order;
      console.log(order);
    },error=>{
      console.log(error);
    });
  }

}
