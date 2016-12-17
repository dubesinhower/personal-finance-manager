import { ActionReducer, Action } from '@ngrx/store';

import { EmailAccount } from '../../email-accounts';

export const emailAccountsReducer: ActionReducer<EmailAccount[]> = (state: EmailAccount[] = [], action: Action) => {
    switch (action.type) {
        case 'LOAD_EMAIL_ACCOUNTS':
            return action.payload;
        case 'ADD_EMAIL_ACCOUNT':
            return [ ...state, action.payload ];
        case 'UPDATE_EMAIL_ACCOUNT':
            return state.map(emailAccount => {
                return emailAccount.id === action.payload.id ? Object.assign({}, emailAccount, action.payload) : emailAccount;
            });
        case 'DELETE_EMAIL_ACCOUNT':
            return state.filter(emailAccount => {
                return emailAccount.id !== action.payload.id;
            });
        default:
            return state;
    }
};
