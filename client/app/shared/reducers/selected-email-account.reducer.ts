import { ActionReducer, Action } from '@ngrx/store';

export const selectedEmailAccountReducer: ActionReducer<number> = (state: number = null, action: Action) => {
    switch (action.type) {
        case 'SELECT_EMAIL_ACCOUNT':
            return action.payload;
        case 'DESELECT_EMAIL_ACCOUNT':
            return null;
        default:
            return state;
    }
};
