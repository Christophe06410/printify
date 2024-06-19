// <copyright file="Images.cs" company="improvGroup, LLC">
//     Copyright © 2021 improvGroup, LLC. All Rights Reserved.
// </copyright>

namespace Printify.Models.Uploads
{
	using Printify.Models.Products;

	using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// The paged images record.
    /// </summary>
    public record PagedProducts : PagedEntities
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>The data.</value>
        public List<Product> Data { get; set; } = new List<Product>();
    }
}
