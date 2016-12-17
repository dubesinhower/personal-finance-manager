"use strict";
exports.googleOAuthSecurityTokenReducer = function (state, action) {
    if (state === void 0) { state = null; }
    switch (action.type) {
        case 'SET_GOOGLE_OAUTH_SECURITY_TOKEN':
            return action.payload;
        case 'CLEAR_GOOGLE_OAUTH_SECURITY_TOKEN':
            return null;
        default:
            return state;
    }
};
//# sourceMappingURL=google-oauth-security-token.reducer.js.map