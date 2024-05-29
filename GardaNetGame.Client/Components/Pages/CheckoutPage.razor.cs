using GardaNetGame.Shared.DTOs.Klarna;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using GardaNetGame.Shared.DTOs.Orders.Responses;
using GardaNetGame.Shared.Entities;

namespace GardaNetGame.Client.Components.Pages
{
    public partial class CheckoutPage
    {
        //Momsen måste stämma Althea

        protected override async Task OnInitializedAsync()
        {
            //await LoadKlarnaSnippetAsync();
            currentEvent = await EventService.GetEventById(Id);
            currentGame = await GameService.GetGameById(Id);
        }

        private async Task LoadKlarnaSnippetAsync()
        {
			// Denna tar in en Order just nu som exempel. 
			// Skicka in en orderDTO frÃ¥n kundvagnen.
			//Guid guid = Guid.NewGuid();
			//var order = await OrderService.GetOrderById(guid);

			OrdersResponse order = new()
	        {
		        Events = new(),
		        Games = new()
		        {
			        new Game()
			        {
				        AgeRestriction = 18,
				        BackgroundImageUrl = null,
				        Description = "Text",
				        GameDeveloper = "Cool Man",
				        Genre = null,
				        Grade = null,
				        Id = Guid.NewGuid(),
				        Name = "Helldivers 2",
				        NumberOfPlayers = "Multiplayer",
				        OnlineFuntionality = "Online Multiplayer",
				        Price = 200,
				        PublicationDate = DateTime.Now,
				        Platform = "Steam",
				        SystemRequirement = "Stuff",
				        ProductImageUrl = null,
				        VideoTrailer = null,
			        },
					new Game()
					{
						AgeRestriction = 18,
						BackgroundImageUrl = null,
						Description = "Text",
						GameDeveloper = "Cool Man",
						Genre = null,
						Grade = null,
						Id = Guid.NewGuid(),
						Name = "Minecraft",
						NumberOfPlayers = "Multiplayer",
						OnlineFuntionality = "Online Multiplayer",
						Price = 200,
						PublicationDate = DateTime.Now,
						Platform = "Steam",
						SystemRequirement = "Stuff",
						ProductImageUrl = null,
						VideoTrailer = null,
					},
                    new Game()
                    {
                        AgeRestriction = 18,
                        BackgroundImageUrl = null,
                        Description = "Text",
                        GameDeveloper = "Cool Man",
                        Genre = null,
                        Grade = null,
                        Id = Guid.NewGuid(),
                        Name = "Towerfall Ascension",
                        NumberOfPlayers = "Multiplayer",
                        OnlineFuntionality = "Online Multiplayer",
                        Price = 100,
                        PublicationDate = DateTime.Now,
                        Platform = "Steam",
                        SystemRequirement = "Stuff",
                        ProductImageUrl = null,
                        VideoTrailer = null,
                    }
                },
		        Id = Guid.NewGuid(),
		        IsActive = true
	        };
	        var klarnaList = new List<OrderKlarnaDTO>();


	        Dictionary<string, string> urls = new Dictionary<string, string>
	        {
		        { "terms", "https://www.example.com/terms.html" },
		        { "checkout", "https://teamgardanetgame-development.azurewebsites.net/checkout" },
		        { "confirmation", "https://teamgardanetgame-development.azurewebsites.net/" },
		        { "push", "https://www.example.com/api/push" }
	        };


			foreach (var product in order.Games)
            {
                if (product != null)
                {
                    var klarnaItem = new OrderKlarnaDTO()
                    {
                        name = product.Name,
                        quantity = 1, //orderItem.Quantity is replaced with 1
						tax_rate = 2500,
                        unit_price = product.Price * 100,
                        total_amount = (int)Math.Round((product.Price) * 1 * 100),
                        total_tax_amount = (int)Math.Round((product.Price) * 1 * 0.20 * 100)

                    };
					order.TotalValue += klarnaItem.total_amount;
					klarnaList.Add(klarnaItem);
                }
            }

			//Tax amount always need to be 20%
			var orderDto = new KlarnaDTO()
			{
				purchase_country = "SE",
				purchase_currency = "SEK",
				locale = "sv-SV",
				order_amount = (int)Math.Round(order.TotalValue),
				//order_amount = 13900,
				order_tax_amount = (int)Math.Round(order.TotalValue * 0.20),
				//order_tax_amount = 2780,
				order_lines = klarnaList,
				merchant_urls = urls
			};

			//klarnaList.Add(orderKlarna);


            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"PK254382_cf8896f6edf1:A2vOPOtBsjQYp2oN"))
            );

            var response = await httpClient.PostAsJsonAsync("https://api.playground.klarna.com/checkout/v3/orders", orderDto);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                dynamic responseObject = JsonConvert.DeserializeObject(jsonResponse);
                string orderDtoJson = JsonConvert.SerializeObject(orderDto);
                string htmlSnippet = responseObject["html_snippet"];
                await JSRuntime.InvokeVoidAsync("renderSnippet", htmlSnippet);
            }
            else
            {
                string orderDtoJson = JsonConvert.SerializeObject(orderDto);
                Console.WriteLine(orderDtoJson);
            }
        }
    }
}