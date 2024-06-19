// <copyright file="Image.cs" company="improvGroup, LLC">
//     Copyright © 2021 improvGroup, LLC. All Rights Reserved.
// </copyright>

namespace Printify.Models.Products
{
	using System.Collections.Generic;
	using System.Text.Json.Serialization;

	/// <summary>
	/// The image record.
	/// </summary>
	public record Image
	{
		/// <summary>
		/// Gets or sets the angle used to rotate the image.
		/// </summary>
		/// <value>The angle used to rotate the image.</value>
		/// <remarks>See image positioning for reference on how to position images.</remarks>
        public int Angle { get; init; }

        /// <summary>
        /// Gets or sets the image height in pixels.
        /// </summary>
        /// <value>The image height in pixels.</value>
        /// <remarks>
        /// See upload images for reference on how to upload images and get all needed properties.
        /// </remarks>
        public float Height { get; init; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        /// <remarks>
        /// See upload images for reference on how to upload images and get all needed properties.
        /// </remarks>
        public int Id { get; init; }

        /// <summary>
        /// Gets or sets the name of the image file.
        /// </summary>
        /// <value>The image filename.</value>
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// Gets or sets the value used to scale the image up or down.
        /// </summary>
        /// <value>The value used to scale the image up or down.</value>
        /// <remarks>See image positioning for reference on how to position images.</remarks>
        public float Scale { get; init; }

        /// <summary>
        /// Gets or sets the type of the image.
        /// </summary>
        /// <value>The type.</value>
        /// <remarks>Valid image types are image/png, image/jpg, image/jpeg.</remarks>
        public string Type { get; init; } = string.Empty;

        /// <summary>
        /// Gets or sets the width of the image in pixels.
        /// </summary>
        /// <value>The width of the image in pixels.</value>
        /// <remarks>
        /// See upload images for reference on how to upload images and get all needed properties.
        /// </remarks>
        public float Width { get; init; }

        /// <summary>
        /// Gets or sets the position of the image on the X axis.
        /// </summary>
        /// <value>The position of the image on the X axis.</value>
        /// <remarks>See image positioning for reference on how to position images.</remarks>
        public float X { get; init; }

        /// <summary>
        /// Gets or sets the position of the image on the Y axis.
        /// </summary>
        /// <value>The position of the image on the Y axis.</value>
        /// <remarks>See image positioning for reference on how to position images.</remarks>
        public float Y { get; init; }

		public string Src { get; set; }

        [JsonPropertyName("variant_ids")]
		public List<int> VariantIds { get; set; }
		public string Position { get; set; }

        [JsonPropertyName("is_default")]
		public bool IsDefault { get; set; }

        [JsonPropertyName("is_selected_for_publishing")]
		public bool IsSelectedForPublishing { get; set; }
		public object Order { get; set; }
	}
}
