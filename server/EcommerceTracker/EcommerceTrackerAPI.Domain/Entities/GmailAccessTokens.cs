using System;

namespace EcommerceTrackerAPI.Domain.Entities
{
    public class GmailAccessTokens
    {
        public int ID { get; set; }
        public string AccessToken { get; set; }
        /// <summary>
        /// Gets or sets the token type as specified in http://tools.ietf.org/html/rfc6749#section-7.1.
        /// 
        /// </summary>
        public string TokenType { get; set; }
        /// <summary>
        /// Gets or sets the lifetime in seconds of the access token.
        /// </summary>
        public long? ExpiresInSeconds { get; set; }
        /// <summary>
        /// Gets or sets the refresh token which can be used to obtain a new access token.
        ///             For example, the value "3600" denotes that the access token will expire in one hour from the time the
        ///             response was generated.
        /// 
        /// </summary>
        public string RefreshToken { get; set; }
        /// <summary>
        /// Gets or sets the scope of the access token as specified in http://tools.ietf.org/html/rfc6749#section-3.3.
        /// 
        /// </summary>
        public string Scope { get; set; }
        /// <summary>
        /// Gets or sets the id_token, which is a JSON Web Token (JWT) as specified in http://tools.ietf.org/html/draft-ietf-oauth-json-web-token
        /// 
        /// </summary>
        public string IdToken { get; set; }
        /// <summary>
        /// The date and time that this token was issued.
        /// <remarks>
        /// It should be set by the CLIENT after the token was received from the server.
        /// 
        /// </remarks>
        /// 
        /// </summary>
        public DateTime Issued { get; set; }
    }
}
