// <copyright file="Option.cs" company="improvGroup, LLC">
//     Copyright © 2021 improvGroup, LLC. All Rights Reserved.
// </copyright>

namespace Printify.Models.Products
{
	using System.Collections.Generic;
	using System.Text.Json.Serialization;

	/// <summary>
	/// The product option class.
	/// </summary>
	public class ProductOption
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; init; } = string.Empty;

		public List<ProductOptionValue> Values { get; set; }

        [JsonPropertyName("display_in_preview")]
		public bool DisplayInPreview { get; set; }
	}

	public class ProductOptionValue
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public List<string> Colors { get; set; }
	}
}
