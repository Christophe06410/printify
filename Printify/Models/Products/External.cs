// <copyright file="External.cs" company="improvGroup, LLC">
//     Copyright © 2021 improvGroup, LLC. All Rights Reserved.
// </copyright>

namespace Printify.Models.Products
{
	using System.Text.Json.Serialization;

	/// <summary>
	/// The External class.
	/// </summary>
	public class External
    {
		public string Id { get; set; }
		public string Handle { get; set; }

        [JsonPropertyName("shipping_template_id")]
		public string ShippingTemplateId { get; set; }
	}
}
