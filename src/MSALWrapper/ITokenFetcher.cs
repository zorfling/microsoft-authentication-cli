// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Microsoft.Authentication.MSALWrapper
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Authentication.MSALWrapper.AuthFlow;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// An interface for acquiring an AAT Access Token.
    /// </summary>
    public interface ITokenFetcher
    {
        /// <summary>
        /// Run the authentication process using a global lock around the client, tenant, scopes trio to prevent multiple
        /// auth prompts for the same tokens.
        /// </summary>
        /// <param name="logger">A <see cref="ILogger"/> to use.</param>
        /// <param name="client">The client ID to authenticate as.</param>
        /// <param name="tenant">The Azure tenant containing the client.</param>
        /// <param name="scopes">The list of scopes to request access for.</param>
        /// <param name="mode">The <see cref="AuthMode"/>. Controls which <see cref="IAuthFlow"/>s should be used.</param>
        /// <param name="domain">The domain (account suffix) to filter cached accounts with.</param>
        /// <param name="prompt">A prompt hint to display to the user if needed.</param>
        /// <param name="timeout">The max <see cref="TimeSpan"/> we should spend attempting token acquisition for.</param>
        /// <returns>A <see cref="TokenFetcher.Result"/> representing the result of the asynchronous operation.</returns>
        TokenFetcher.Result AccessToken(
            ILogger logger,
            Guid client,
            Guid tenant,
            IEnumerable<string> scopes,
            AuthMode mode,
            string domain,
            string prompt,
            TimeSpan timeout);
    }
}
