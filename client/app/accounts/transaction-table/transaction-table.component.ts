import { Component, Input } from '@angular/core';
import { Transaction } from '../shared';

@Component ({
    selector: 'pfm-transaction-table',
    templateUrl: 'app/accounts/transaction-table/transaction-table.component.html'
})
export class TransactionTableComponent {
    @Input() transactions: Transaction[];
}