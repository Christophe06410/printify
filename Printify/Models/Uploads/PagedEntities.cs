// <copyright file="Images.cs" company="improvGroup, LLC">
//     Copyright © 2021 improvGroup, LLC. All Rights Reserved.
// </copyright>

namespace Printify.Models.Uploads
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// The paged images record.
    /// </summary>
    public abstract record PagedEntities
    {
        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>The current page.</value>
        [JsonPropertyName("current_page")]
        public int CurrentPage { get; init; }

        /// <summary>
        /// Gets or sets the first page URL.
        /// </summary>
        /// <value>The first page URL.</value>
        [JsonPropertyName("first_page_url")]
        public string FirstPageUrl { get; init; } = "/?page=1";

        /// <summary>
        /// Gets or sets from.
        /// </summary>
        /// <value>From.</value>
        public int From { get; init; } = 1;

        /// <summary>
        /// Gets or sets the last page.
        /// </summary>
        /// <value>The last page.</value>
        [JsonPropertyName("last_page")]
        public int LastPage { get; init; } = 2;

        /// <summary>
        /// Gets or sets the last page URL.
        /// </summary>
        /// <value>The last page URL.</value>
        [JsonPropertyName("last_page_url")]
        public string LastPageUrl { get; init; } = "/?page=2";

        /// <summary>
        /// Gets or sets the next page URL.
        /// </summary>
        /// <value>The next page URL.</value>
        [JsonPropertyName("next_page_url")]
        public string? NextPageUrl { get; init; } = "/?page=2";

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path { get; init; } = "/";

        /// <summary>
        /// Gets or sets the per page.
        /// </summary>
        /// <value>The per page.</value>
        [JsonPropertyName("per_page")]
        public int PerPage { get; init; } = 1;

        /// <summary>
        /// Gets or sets the previous page URL.
        /// </summary>
        /// <value>The previous page URL.</value>
        [JsonPropertyName("prev_page_url")]
        public string? PreviousPageUrl { get; init; }

        /// <summary>
        /// Gets or sets to.
        /// </summary>
        /// <value>To.</value>
        public int To { get; init; } = 2;

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        public int Total { get; init; } = 2;
    }
}
