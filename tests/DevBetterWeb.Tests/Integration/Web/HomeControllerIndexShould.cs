﻿using DevBetterWeb.Web;
using Stripe;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DevBetterWeb.Tests.Integration.Web
{
  public class HomeControllerIndex : IClassFixture<CustomWebApplicationFactory<Startup>>
  {
    private readonly HttpClient _client;

    public HomeControllerIndex(CustomWebApplicationFactory<Startup> factory)
    {
      _client = factory.CreateClient();
    }

    //[Fact] Doesn't run on build server
    public async Task ReturnsViewWithCorrectMessage()
    {
      HttpResponseMessage response = await _client.GetAsync("/");
      response.EnsureSuccessStatusCode();
      string stringResponse = await response.Content.ReadAsStringAsync();

      Assert.Contains("Developer Career Coaching", stringResponse);
    }
  }

}
