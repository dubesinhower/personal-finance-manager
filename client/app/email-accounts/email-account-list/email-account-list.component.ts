import { Component, Input, Output, EventEmitter } from '@angular/core';

import { ImapAccount } from '../shared';

@Component ({
    selector: 'pfm-email-account-list',
    templateUrl: 'app/email-accounts/email-account-list/email-account-list.component.html'
})
export class EmailAccountListComponent {
    @Input() emailAccounts: ImapAccount[];
    // @Output() authorizeGmail = new EventEmitter<number>();
}
