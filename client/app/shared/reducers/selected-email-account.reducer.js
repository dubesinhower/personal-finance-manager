"use strict";
exports.selectedEmailAccountReducer = function (state, action) {
    if (state === void 0) { state = null; }
    switch (action.type) {
        case 'SELECT_EMAIL_ACCOUNT':
            return action.payload;
        case 'DESELECT_EMAIL_ACCOUNT':
            return null;
        default:
            return state;
    }
};
//# sourceMappingURL=selected-email-account.reducer.js.map