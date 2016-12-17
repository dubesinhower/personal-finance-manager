"use strict";
exports.userTokenReducer = function (state, action) {
    if (state === void 0) { state = null; }
    switch (action.type) {
        case 'SET_USER_TOKEN':
            return action.payload;
        case 'CLEAR_USER_TOKEN':
            return null;
        default:
            return state;
    }
};
//# sourceMappingURL=user-token.reducer.js.map