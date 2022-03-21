using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace front.docker.demo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {

            ViewData["Message"] = "Hello from webfrontend";

            using (var client = new HttpClient())
            {

                try
                {
                    var request = new HttpRequestMessage();
                    request.RequestUri = new Uri("http://api.docker.dem/WeatherForecast");
                    var response = await client.SendAsync(request);
                    ViewData["Message"] += " and " + await response.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    ViewData["Message"] = "Ops! algo deu errado ;/ "; 
                }
        
            }

        }
    }
}
