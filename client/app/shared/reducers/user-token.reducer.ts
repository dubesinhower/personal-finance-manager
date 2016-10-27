import { ActionReducer, Action } from '@ngrx/store';

import { Token } from '../../user-accounts';

export const userTokenReducer: ActionReducer<Token> = (state: Token = null, action: Action) => {
    switch (action.type) {
        case 'SET_USER_TOKEN':
            return action.payload;
        case 'CLEAR_USER_TOKEN':
            return null;
        default:
            return state;
            // Hi chris! This is a commment maybe!?   idk im not good at coding like you are, look at all this code its pretty neat eh?
    }
}
