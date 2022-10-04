import {IClient} from "../clients.model";

export interface clientCreateDto extends Omit<IClient,'id'>{}
