using Microsoft.Extensions.Logging;
using Printify;
using Printify.Models.Products;
using Printify.Models.Shops;

using System;
using System.Net.Mail;
using System.Text.Json;
using System.Text.Json.Serialization;

using static System.Net.WebRequestMethods;

namespace PrintifyManager
{

	internal class Program
	{
		// See doc: https://developers.printify.com/#create-a-personal-access-token
		public string API_KEY = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIzN2Q0YmQzMDM1ZmUxMWU5YTgwM2FiN2VlYjNjY2M5NyIsImp0aSI6IjViZWY5NjFkNTcwYmNhYTFhNjQ2NDE0NjZlNGQ5NTM4YTVlMDkzNDVhY2I4MGQyNGE4ZjY4ZjRmODcwYmQ0ODRjNzE5NTU2YTk1NDJkZTJjIiwiaWF0IjoxNzE4NzQyNjU2LjQ5NDg4OSwibmJmIjoxNzE4NzQyNjU2LjQ5NDg5MiwiZXhwIjoxNzUwMjc4NjU2LjQ4NTkxOCwic3ViIjoiMTU4NTEyMzAiLCJzY29wZXMiOlsic2hvcHMubWFuYWdlIiwic2hvcHMucmVhZCIsImNhdGFsb2cucmVhZCIsIm9yZGVycy5yZWFkIiwib3JkZXJzLndyaXRlIiwicHJvZHVjdHMucmVhZCIsInByb2R1Y3RzLndyaXRlIiwid2ViaG9va3MucmVhZCIsIndlYmhvb2tzLndyaXRlIiwidXBsb2Fkcy5yZWFkIiwidXBsb2Fkcy53cml0ZSIsInByaW50X3Byb3ZpZGVycy5yZWFkIl19.AhkmHNOJ7cRrH19E7nRr7Cp3YhIM5D7UK-mPuXrdYhZZDN4vdXXo5jjO3utSJxYnVm86q-ETZnWovr_1Pi4";

		public HttpClient SingleHttpClient { get; private set; }

		private ILogger _logger;

		static async Task Main(string[] args)
		{
			Console.WriteLine("Hello, World!");

			Program program = new Program();
			await program.Run();
		}

		private async Task Run()
		{
			using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
			_logger = factory.CreateLogger("Program");
			var printifyApiClientLogger = factory.CreateLogger<Printify.ApiClient>();
			SingleHttpClient = new HttpClient();

			IApiClient apiClient = new ApiClient(SingleHttpClient, printifyApiClientLogger);
			apiClient.AuthenticationToken = API_KEY;

			var cancelSource = new CancellationTokenSource();
			var token = cancelSource.Token;

			IShopClient shopClient = ((IShopClient)apiClient);

			List<Shop>? shops = await shopClient.GetShops(token);

			if (shops == null || shops.Count == 0)
			{
				_logger.LogDebug("No shop found.");
				return;
			}
			Shop shop = shops[0];

			int shopId = shop.Id;

			IProductClient productClient = (IProductClient)apiClient;

			List<Product> products = await productClient.GetProducts(shopId, 50);

			foreach(var product in products)
			{
				var productString = JsonSerializer.Serialize(product);
				_logger.LogInformation($"Product:\r\n {productString}");
			}

		}



	}
}
