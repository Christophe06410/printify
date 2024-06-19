// <copyright file="ApiClient.cs" company="improvGroup, LLC">
//     Copyright © 2021 improvGroup, LLC. All Rights Reserved.
// </copyright>

namespace Printify
{
	using Microsoft.Extensions.Logging;
	using Printify.Models;

	using System;
	using System.Diagnostics.CodeAnalysis;
	using System.Net.Http;
	using System.Net.Http.Headers;
	using System.Text.Json;

	/// <summary>
	/// The API client class.
	/// </summary>
	public partial class ApiClient : IApiClient
	{
		/// <summary>
		/// The base URL
		/// </summary>
		private const string BaseURL = "https://api.printify.com/v1/";

		/// <summary>
		/// The content type
		/// </summary>
		private const string ContentType = "application/json;charset=utf-8";

		/// <summary>
		/// The JSON serializer options
		/// </summary>
		private static readonly JsonSerializerOptions jsonSerializerOptions = new(JsonSerializerDefaults.Web)
		{
			AllowTrailingCommas = true,
			PropertyNameCaseInsensitive = true,
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			ReadCommentHandling = JsonCommentHandling.Skip,
		};

		/// <summary>
		/// The HTTP client
		/// </summary>
		private readonly HttpClient httpClient;

		/// <summary>
		/// The logger
		/// </summary>
		private readonly ILogger<ApiClient> logger;

		/// <summary>
		/// The authentication token
		/// </summary>
		private string authenticationToken = string.Empty;

		/// <summary>
		/// Initializes a new instance of the <see cref="ApiClient" /> class.
		/// </summary>
		/// <param name="httpClient">The HTTP client.</param>
		/// <param name="logger">The logger.</param>
		/// <exception cref="ArgumentNullException">httpClient or logger</exception>
		[SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "BaseAddress is a constant.")]
		public ApiClient(HttpClient httpClient, ILogger<ApiClient> logger)
		{
			this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
			this.httpClient.BaseAddress = new Uri(BaseURL);
			this.httpClient.DefaultRequestHeaders.Accept.ParseAdd(ContentType);
			this.httpClient.DefaultRequestHeaders.Add("User-Agent", "PrintifyManager");
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

			jsonSerializerOptions.Converters.Add(new CustomDateTimeConverter());
		}

		/// <inheritdoc />
		public string AuthenticationToken
		{
			set
			{
				authenticationToken = string.IsNullOrWhiteSpace(value) ? throw new ArgumentNullException(nameof(value)) : value;
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationToken);
			}
		}
	}
}
