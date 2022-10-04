import {IProduct} from "../products.model";

export interface ICreateProductDTO extends Omit<IProduct,'id'>{}
export interface IUpdateProductDTO extends Omit<IProduct,'id'>{}
