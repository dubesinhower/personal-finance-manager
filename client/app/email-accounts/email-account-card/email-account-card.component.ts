import { Component, Input } from '@angular/core';

import { AuthorizationUrl } from '../../shared';
import { EmailAccount } from '../shared';

@Component ({
    selector: 'pfm-email-account-card',
    templateUrl: 'app/email-accounts/email-account-card/email-account-card.component.html'
})
export class EmailAccountCardComponent {
    @Input() emailAccount: EmailAccount;
    @Input() gmailAuthorizationUrl: AuthorizationUrl;
}
