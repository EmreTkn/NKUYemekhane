import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IBasket, IBasketItem, IBasketTotals } from '../shared/models/basket';
import { BasketService } from './basket.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {

  basket$:Observable<IBasket>;
  basketTotal$:Observable<IBasketTotals>;

  constructor(private basketService:BasketService) { }

  ngOnInit(): void {
    this.basket$=this.basketService.basket$;
    this.basketTotal$=this.basketService.basketTotal$;
  }

  removeBasketItem(item:IBasketItem){
    this.basketService.removeItemFromBasket(item);
  }
}
