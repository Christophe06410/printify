// <copyright file="Variant.cs" company="improvGroup, LLC">
//     Copyright © 2021 improvGroup, LLC. All Rights Reserved.
// </copyright>

namespace Printify.Models.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    /// <summary>
    /// The product variant class.
    /// </summary>
    public class Variant
    {
        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>The cost.</value>
        /// <remarks>Product variant's fulfillment cost in cents, integer value.</remarks>
        public int Cost { get; set; }

        /// <summary>
        /// Gets or sets the weight in grams for a product variant.
        /// </summary>
        /// <value>The weight in grams for a product variant.</value>
        public int Grams { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        /// <remarks>
        /// A unique int identifier for the product variant from the blueprint. Each id is unique
        /// across the Printify system. See catalog for instructions on how to get variant ids.
        /// </remarks>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is available.
        /// </summary>
        /// <value><c>true</c> if this instance is available; otherwise, <c>false</c>.</value>
        /// <remarks>
        /// Actual stock status of the variant, if false, the variant is out of stock and vice versa.
        /// </remarks>
        [JsonPropertyName("is_available")]
        public bool IsAvailable { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <c>null</c> if [is default] contains no value, <c>true</c> if [is default]; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Only one variant can be default. Used when publishing to sales channel. Default
        /// variant's image will be the title image of the product.
        /// </remarks>
        [JsonPropertyName("is_default")]
        public bool? IsDefault { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value>
        /// <c>null</c> if [is enabled] contains no value, <c>true</c> if [is enabled]; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// Used for publishing, the value is true if one has the variant in question selected as an
        /// offering and wants it published.
        /// </remarks>
        [JsonPropertyName("is_enabled")]
        public bool? IsEnabled { get; set; }


        [JsonPropertyName("is_printify_express_eligible")]
		public bool IsPrintifyExpressEligible { get; set; }

		/// <summary>
		/// Gets the options.
		/// </summary>
		/// <value>The options.</value>
		/// <remarks>Reference to options by id.</remarks>
		public List<int> Options { get; } = new List<int>();

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        /// <remarks>Price in cents, integer value.</remarks>
        public int Price { get; set; }

		public int Quantity { get; set; }

		/// <summary>
		/// Gets or sets the SKU.
		/// </summary>
		/// <value>The SKU.</value>
		/// <remarks>
		/// Optional unique string identifier for the product variant. If one is not provided, one
		/// will be generated by Printify.
		/// </remarks>
		public string? Sku { get; set; }

        /// <summary>
        /// Gets or sets the variant title.
        /// </summary>
        /// <value>The variant title.</value>
        public string Title { get; set; } = string.Empty;
    }
}
