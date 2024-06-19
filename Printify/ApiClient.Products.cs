namespace Printify
{
    using Microsoft.Extensions.Logging;

    using Printify.Models.Products;
	using Printify.Models.Uploads;

	using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class ApiClient : IProductClient
    {
        /// <inheritdoc />
        [SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "Uri is not user input.")]
        public async Task CreateProduct(int shopId, Product product, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("POST: /v1/shops/{shopId}/products.json", shopId);
            var content = JsonContent.Create(product, new MediaTypeHeaderValue(ContentType), jsonSerializerOptions);
            var response = await httpClient.PostAsync($"shops/{shopId}/products.json", content, cancellationToken).ConfigureAwait(false);
            logger.LogTrace(response.ReasonPhrase);
            response.EnsureSuccessStatusCode();
        }

        /// <inheritdoc />
        [SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "Uri is not user input.")]
        public async Task DeleteProduct(int shopId, int productId, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("DELETE: /v1/shops/{shopId}/products/{productId}.json", shopId, productId);
            var response = await httpClient.DeleteAsync($"shops/{shopId}/products.json", cancellationToken).ConfigureAwait(false);
            logger.LogTrace(response.ReasonPhrase);
            response.EnsureSuccessStatusCode();
        }

        /// <inheritdoc />
        [SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "Uri is not user input.")]
        public async Task<Product?> GetProduct(int shopId, int productId, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("GET: /v1/shops/{shopId}/products/{productId}.json", shopId, productId);
            var json = await httpClient.GetStringAsync($"shops/{shopId}/products/{productId}.json", cancellationToken).ConfigureAwait(false);
            logger.LogTrace(json);
            return JsonSerializer.Deserialize<Product>(json, jsonSerializerOptions);
        }

        /// <inheritdoc />
        [SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "Uri is not user input.")]
        public async Task<List<Product>> GetProducts(int shopId, int limit = 10, int? page = null,
			CancellationToken cancellationToken = default)
        {
            if (limit > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(limit), "limit cannot be more than 100.");
            }

            logger.LogInformation("GET: /v1/shops/{shopId}/products.json?limit={limit}&page={page}", shopId, limit, page);

            var url = $"shops/{shopId}/products.json";
            if (limit != 10)
            {
                url += $"?limit={limit}";
                if (page != null)
                {
                    url += $"&page={page}";
                }
            }
            else
            {
                if (page != null)
                {
                    url += $"?page={page}";
                }
            }

			var json = await httpClient.GetStringAsync(url, cancellationToken).ConfigureAwait(false);
			logger.LogTrace(json);

			PagedProducts pagedProducts = JsonSerializer.Deserialize<PagedProducts>(json, jsonSerializerOptions) ?? new PagedProducts();
			return pagedProducts.Data;
        }

        /// <inheritdoc />
        [SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "Uri is not user input.")]
        public async Task PublishProduct(int shopId, int productId, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("POST: /v1/shops/{shopId}/products/{productId}/publish.json", shopId, productId);
            var response = await httpClient.PostAsync($"shops/{shopId}/products/{productId}/publish.json", new StringContent(string.Empty), cancellationToken).ConfigureAwait(false);
            logger.LogTrace(response.ReasonPhrase);
            response.EnsureSuccessStatusCode();
        }

        /// <inheritdoc />
        [SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "Uri is not user input.")]
        public async Task SetProductPublishStatusFailure(int shopId, int productId, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("POST: /v1/shops/{shopId}/products/{productId}/publishing_failed.json", shopId, productId);
            var response = await httpClient.PostAsync($"shops/{shopId}/products/{productId}/publishing_failed.json", new StringContent(string.Empty), cancellationToken).ConfigureAwait(false);
            logger.LogTrace(response.ReasonPhrase);
            response.EnsureSuccessStatusCode();
        }

        /// <inheritdoc />
        [SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "Uri is not user input.")]
        public async Task SetProductPublishStatusSuccess(int shopId, int productId, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("POST: /v1/shops/{shopId}/products/{productId}/publishing_succeeded.json", shopId, productId);
            var response = await httpClient.PostAsync($"shops/{shopId}/products/{productId}/publishing_succeeded.json", new StringContent(string.Empty), cancellationToken).ConfigureAwait(false);
            logger.LogTrace(response.ReasonPhrase);
            response.EnsureSuccessStatusCode();
        }

        /// <inheritdoc />
        [SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "Uri is not user input.")]
        public async Task Unpublish(int shopId, int productId, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("POST: /v1/shops/{shopId}/products/{productId}/unpublish.json", shopId, productId);
            var response = await httpClient.PostAsync($"shops/{shopId}/products/{productId}/unpublish.json", new StringContent(string.Empty), cancellationToken).ConfigureAwait(false);
            logger.LogTrace(response.ReasonPhrase);
            response.EnsureSuccessStatusCode();
        }

        /// <inheritdoc />
        [SuppressMessage("Usage", "SecurityIntelliSenseCS:MS Security rules violation", Justification = "Uri is not user input.")]
        public async Task UpdateProduct(int shopId, Product product, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("PUT: /v1/shops/{shopId}/products/{productId}.json", shopId, product.Id);
            var content = JsonContent.Create(product, new MediaTypeHeaderValue(ContentType), jsonSerializerOptions);
            var response = await httpClient.PutAsync($"shops/{shopId}/products/{product.Id}.json", content, cancellationToken).ConfigureAwait(false);
            logger.LogTrace(response.ReasonPhrase);
            response.EnsureSuccessStatusCode();
        }
    }
}
