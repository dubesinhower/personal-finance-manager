import { ActionReducer, Action } from '@ngrx/store';

export const googleOAuthSecurityTokenReducer: ActionReducer<string> = (state: string = null, action: Action) => {
    switch (action.type) {
        case 'SET_GOOGLE_OAUTH_SECURITY_TOKEN':
            return action.payload;
        case 'CLEAR_GOOGLE_OAUTH_SECURITY_TOKEN':
            return null;
        default:
            return state;
    }
};
