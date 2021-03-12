import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Basket, IBasket, IBasketItem, IBasketTotals } from '../shared/models/basket';
import { IMenu } from '../shared/models/menu';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  baseUrl=environment.apiUrl;
  private basketSource=new BehaviorSubject<IBasket>(null);
  basket$=this.basketSource.asObservable();
  private basketTotalSource=new BehaviorSubject<IBasketTotals>(null);
  basketTotal$=this.basketTotalSource.asObservable();

  constructor(private http:HttpClient,private toastr:ToastrService) { }

  createPaymentIntent(){
    return this.http.post(this.baseUrl + 'payment/'+ this.getCurrentBasketValue().id,{})
    .pipe(
      map((basket:IBasket)=> {
        this.basketSource.next(basket);
        console.log( this.getCurrentBasketValue().id);
      })
    );
  }

  getCurrentBasketValue(){
    return this.basketSource.value;
  }

  getBasket(id:string){
    return this.http.get(this.baseUrl+'basket?id='+id)
    .pipe(
      map((basket:IBasket)=>{
        this.basketSource.next(basket);
        this.calculateTotals();
      })
    );
  }

  private calculateTotals(){
    const basket=this.getCurrentBasketValue();
    const subtotal=basket.items.reduce((a,b)=> b.price + a,0);
    this.basketTotalSource.next({subtotal});
  }

  setBasket(basket:IBasket){
    return this.http.post(this.baseUrl+ 'basket',basket).subscribe((res:IBasket)=>{
      this.basketSource.next(res);
      this.calculateTotals();

    },error=>{console.log(error)});
  }

  addItemToBasket(item:IMenu){
    const itemToAdd:IBasketItem=this.mapProductItemToBasketItem(item);
    let basket=this.getCurrentBasketValue();
    if (basket===null) {
      basket=this.createBasket();
    }
    basket.items=this.addOrUpdateItem(basket.items,itemToAdd);
    this.setBasket(basket);
    basket.items.forEach(element => {
      if (element!==itemToAdd) {
        this.toastr.error("Menü'yü zaten eklediniz.");
      }else{
        this.toastr.success("Günün Menüsü Başarı ile Eklendi.");
      }
    });

  }

  private mapProductItemToBasketItem(item: IMenu): IBasketItem {
    return {
      id: item.id,
      schoolName: item.schoolName,
      price: item.price,
      day:item.day,
      month:item.month,
      year:item.year,
      dinnerTime:item.dinnerTime
    };
  }

  private createBasket(){
    const basket=new Basket();
    localStorage.setItem('basket_id',basket.id);
    return basket;
  }

  private addOrUpdateItem(items:IBasketItem[],itemtoAdd:IBasketItem){
    const index =items.findIndex(i=>i.id===itemtoAdd.id);
    if (index===-1) {
      items.push(itemtoAdd);
    }
    return items;
  }

  removeItemFromBasket(item:IBasketItem){
    const basket=this.getCurrentBasketValue();
    if (basket.items.some(x=>x.id===item.id)) {
      basket.items=basket.items.filter(i=>i.id!==item.id);
      if (basket.items.length > 0) {
        this.setBasket(basket);
      }else{
        this.deleteBasket(basket);
      }
    }
  }

  deleteBasket(basket:IBasket){
    return this.http.delete(this.baseUrl + 'basket?id=' + basket.id).subscribe(()=>{
      this.basketSource.next(null);
      this.basketTotalSource.next(null);
      localStorage.removeItem('basket_id');
    },error=>{console.log(error);});
  }

  deleteLocalBasket(id:string){
    this.basketSource.next(null);
    this.basketTotalSource.next(null);
    localStorage.removeItem('basket_id');
  }
}
