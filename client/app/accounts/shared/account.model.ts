import { Transaction } from './transaction.model';  

export class Account {
    id: number;
    name: string;
    userId: string;
    importTypeId: number;
    transactions: Transaction[];
}