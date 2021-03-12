export interface IOrderToCreate {
  basketId: string;
}

export interface IOrder {
  id: number;
  buyerEmail: string;
  orderDate: string;
  menus: IOrderItem[];
  subtotal: number;
  orderStatus: string;
}

export interface IOrderItem {
  menuId: number;
  schoolName: string;
  price: number;
}
