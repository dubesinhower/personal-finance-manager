import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { Socket, ImapSettings } from '../shared';
import { Login } from '../../shared';

@Component ({
    selector: 'pfm-imap-settings-form',
    templateUrl: 'app/email-accounts/imap-settings-form/imap-settings-form.component.html'
})
export class ImapSettingsFormComponent implements OnInit {
    @Input() selectedAccount: number;
    @Input() errorMessage: string;
    @Output() submitSettings = new EventEmitter<ImapSettings>();
    private imapSettings: ImapSettings;

    constructor() { }

    ngOnInit() {
        this.imapSettings = new ImapSettings(this.selectedAccount, new Socket('', null), new Login('', null));
    }
}
