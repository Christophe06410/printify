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
    public record PagedImages : PagedEntities
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>The data.</value>
        public List<Image> Data { get; } = new List<Image>();
    }
}
