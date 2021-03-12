import { Component, OnInit, Output,EventEmitter, Input } from '@angular/core';
import { IBasketItem } from '../../models/basket';
import { IOrderItem } from '../../models/order';

@Component({
  selector: 'app-basket-summary',
  templateUrl: './basket-summary.component.html',
  styleUrls: ['./basket-summary.component.scss']
})
export class BasketSummaryComponent implements OnInit {

  @Output() remove:EventEmitter<IBasketItem> =new EventEmitter<IBasketItem>();
  @Input() isBasket=true;
  @Input() items:IBasketItem[] | IOrderItem[]=[];
  @Input() isOrder=false;

  constructor() { }

  ngOnInit(): void {
  }

  removeBasketItem(item:IBasketItem){
    this.remove.emit(item);
  }
}
