// <copyright file="PrintArea.cs" company="improvGroup, LLC">
//     Copyright © 2021 improvGroup, LLC. All Rights Reserved.
// </copyright>

namespace Printify.Models.Products
{
    using System;
	using System.Collections.Generic;
	using System.Text.Json.Serialization;

	/// <summary>
	/// The print area record.
	/// </summary>
    public record PrintArea
    {
		[JsonPropertyName("variant_ids")]
		public List<int> VariantIds { get; set; }

		public List<Placeholder> Placeholders { get; set; }

		[JsonPropertyName("font_color")]
		public string FontColor { get; set; }

		[JsonPropertyName("font_family")]
		public string FontFamily { get; set; }
		public string Background { get; set; }
	}
}
