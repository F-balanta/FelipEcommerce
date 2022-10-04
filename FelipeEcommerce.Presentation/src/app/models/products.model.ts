export interface IProduct {
  id: number;
  name: string;
  urlImage: string;
  description: string;
  price: number;
}
export class Product {
  id: number = 0;
  name: string = '';
  urlImage: string = '';
  description: string = '';
  price: number = 0;
}
