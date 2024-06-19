// <copyright file="Product.cs" company="improvGroup, LLC">
//     Copyright © 2021 improvGroup, LLC. All Rights Reserved.
// </copyright>

namespace Printify.Models.Products
{
	using Printify.Models.Catalog;

	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Text.Json.Serialization;

	/// <summary>
	/// The product class.
	/// </summary>
	public class Product
	{
		/// <summary>
		/// Gets the blueprint identifier.
		/// </summary>
		/// <value>The blueprint identifier.</value>
		/// <remarks>
		/// Required when creating a product, but is read only after. See catalog for how to get blueprint_id.
		/// </remarks>
		[JsonPropertyName("blueprint_id")]
		public int BlueprintId { get; set; }

		/// <summary>
		/// Gets or sets the date and time when a product was created.
		/// </summary>
		/// <value>The date and time when a product was created.</value>
		[JsonPropertyName("created_at")]
		public DateTime? CreatedAt { get; set; }

		/// <summary>
		/// Gets or sets the description of the product. Supports HTML formatting.
		/// </summary>
		/// <value>The description of the product. Supports HTML formatting.</value>
		[Required]
		public string Description { get; set; } = string.Empty;

		/// <summary>
		/// Gets the external.
		/// </summary>
		/// <value>The external.</value>
		/// <remarks>
		/// Updated by sales channel with publishing succeeded endpoint. Id and handle are external
		/// references in the sales channel. See publishing succeeded endpoint for more reference.
		/// </remarks>
		public List<External> External { get; } = new List<External>();

		/// <summary>
		/// Gets or sets a unique string identifier for the product. Each id is unique across the
		/// Printify system.
		/// </summary>
		/// <value>The unique string identifier for the product.</value>
		[Key]
		[Required]
		public string Id { get; set; } = string.Empty;

		/// <summary>
		/// Gets the mock-up images are read only values. The mock-up images are grouped by variants
		/// and position. See mock-up image properties for reference.
		/// </summary>
		/// <value>The mock-up images.</value>
		public List<Image> Images { get; } = new List<Image>();

		/// <summary>
		/// Gets or sets a value indicating whether the product is locked.
		/// </summary>
		/// <value>A value indicating whether the product is locked.</value>
		/// <remarks>
		/// A product is locked during publishing. Locked products can't be updated until unlocked.
		/// </remarks>
		[JsonPropertyName("is_locked")]
		public bool IsLocked { get; set; }

		/// <summary>
		/// Gets the options. Options are read only values and describe product options. There can
		/// be up to 3 options for a product.
		/// </summary>
		/// <value>The options.</value>
		public List<ProductOption> Options { get; } = new List<ProductOption>();

		/// <summary>
		/// Gets the print areas.
		/// </summary>
		/// <value>The print areas.</value>
		/// <remarks>
		/// All print area values are required. Each variant has a print area attached to it. Each
		/// print area has placeholders which represent printable areas on a product. For example
		/// the front of the t-shirt, back of the t-shirt etc. Each placeholder has images and their
		/// positions, where they need to be printed in the printable area. See placeholder
		/// properties for reference.
		/// </remarks>
		[JsonPropertyName("print_areas")]
		public List<PrintArea> PrintAreas { get; } = new List<PrintArea>();

		/// <summary>
		/// Gets or sets the print details.
		/// </summary>
		/// <value>The print details.</value>
		[JsonPropertyName("print_details")]
		public List<PrintDetails> PrintDetails { get; set; }

		/// <summary>
		/// Gets or sets the print provider identifier.
		/// </summary>
		/// <value>The print provider identifier.</value>
		/// <remarks>
		/// Required when creating a product, but is read only after. See catalog for how to get print_provider_id.
		/// </remarks>
		[JsonPropertyName("print_provider_id")]
		public int PrintProviderId { get; set; }

		/// <summary>
		/// Gets the product properties specific to the sales channel associated with the product.
		/// </summary>
		/// <value>The sales channel properties.</value>
		/// <remarks>
		/// If the sales channel has such custom properties, the attributes are listed in the array
		/// and may be actionable, but for all custom integrations, it will either be null or an
		/// empty array.
		/// </remarks>
		[JsonPropertyName("sales_channel_properties")]
		public List<SalesChannelProperty> SalesChannelProperties { get; } = new List<SalesChannelProperty>();

		/// <summary>
		/// Gets or sets the shop identifier that a product belongs to.
		/// </summary>
		/// <value>The shop identifier that a product belongs to.</value>
		[JsonPropertyName("shop_id")]
		public int ShopId { get; set; }

		/// <summary>
		/// Gets the tags, which are also published to sales channel.
		/// </summary>
		/// <value>The tags.</value>
		public List<string>? Tags { get; } = new List<string>();

		/// <summary>
		/// Gets or sets the name of the product.
		/// </summary>
		/// <value>The name of the product.</value>
		[Required]
		public string Title { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the date and time when a product was last updated.
		/// </summary>
		/// <value>The date and time when a product was last updated.</value>
		[JsonPropertyName("update_at")]
		public DateTime? UpdateAt { get; set; }

		/// <summary>
		/// Gets or sets the user identifier that a product belongs to.
		/// </summary>
		/// <value>The user identifier that a product belongs to.</value>
		[JsonPropertyName("user_id")]
		public int UserId { get; set; }

		/// <summary>
		/// Gets the list of all product variants, each representing a different version of the
		/// product. But during product creation, only the variant id and price are necessary. See
		/// variant properties for reference.
		/// </summary>
		/// <value>The product variants.</value>
		public List<Variant> Variants { get; } = new List<Variant>();

		/// <summary>
		/// Gets or sets the visibility in sales channel. Can be true or false, defaults to true.
		/// Used for publishing.
		/// </summary>
		/// <value>The visibility in sales channel.</value>
		public bool Visible { get; set; } = true;

		[JsonPropertyName("is_printify_express_eligible")]
		public bool IsPrintifyExpressEligible { get; set; }

		[JsonPropertyName("is_printify_express_enabled")]
		public bool IsPrintifyExpressEnabled { get; set; }

		[JsonPropertyName("is_economy_shipping_eligible")]
		public bool IsEconomyShippingEligible { get; set; }

		[JsonPropertyName("is_economy_shipping_enabled")]
		public bool IsEconomyShippingEnabled { get; set; }

	}
}
