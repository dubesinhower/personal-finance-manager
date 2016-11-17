import { ActionReducer, Action } from '@ngrx/store';

import { Token } from '../../user-account';

export const userTokenReducer: ActionReducer<Token> = (state: Token = null, action: Action) => {
    switch (action.type) {
        case 'SET_USER_TOKEN':
            return action.payload;
        case 'CLEAR_USER_TOKEN':
            return null;
        default:
            return state;
    }
};
