import { Component, Input, Output, EventEmitter } from '@angular/core';

import { ImapSettings } from '../shared';

@Component ({
    selector: 'pfm-imap-settings-form',
    templateUrl: 'app/email-accounts/imap-settings-form/imap-settings-form.component.html'
})
export class ImapSettingsFormComponent {
    @Input() errorMessage: string;
    @Output() onSubmit = new EventEmitter<ImapSettings>();

    model = new ImapSettings('', null, '', '');
}
