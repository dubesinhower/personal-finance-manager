"use strict";
exports.emailAccountsReducer = function (state, action) {
    if (state === void 0) { state = []; }
    switch (action.type) {
        case 'LOAD_EMAIL_ACCOUNTS':
            return action.payload;
        case 'ADD_EMAIL_ACCOUNT':
            return state.concat([action.payload]);
        case 'UPDATE_EMAIL_ACCOUNT':
            return state.map(function (emailAccount) {
                return emailAccount.id === action.payload.id ? Object.assign({}, emailAccount, action.payload) : emailAccount;
            });
        case 'DELETE_EMAIL_ACCOUNT':
            return state.filter(function (emailAccount) {
                return emailAccount.id !== action.payload.id;
            });
        default:
            return state;
    }
};
//# sourceMappingURL=email-accounts.reducer.js.map