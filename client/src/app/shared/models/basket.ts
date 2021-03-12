import uuid from 'uuid/v4';

export interface IBasket {
    id: string;
    items: IBasketItem[];
    clientSecret?: string;
    paymentIntentId?: string;
}

export interface IBasketItem {
    id: number;
    schoolName: string;
    price: number;
    day:number;
    month:number;
    year:number;
    dinnerTime:string;
}

export class Basket implements IBasket {
    id = uuid();
    items: IBasketItem[] = [];
}

export interface IBasketTotals {
    subtotal: number;
}
