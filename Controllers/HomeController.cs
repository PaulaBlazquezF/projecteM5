using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PROJECTE_LLEGUATJE.ENTORNS.Models;
using Newtonsoft.Json;

namespace PROJECTE_LLEGUATJE.ENTORNS.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    // public IActionResult Index()
    // {
    //     return View();
    // }

    public IActionResult Facts()
    {

    
        const string apiUrl = "https://cat-fact.herokuapp.com/facts";

        var client = new HttpClient();
        var response = client.GetAsync(apiUrl).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        List<Root> model = JsonConvert.DeserializeObject<List<Root>>(content); 
  
        return View(model);
    
    }


    public IActionResult Index()
    {
        const string apiUrl = "https://api.thecatapi.com/v1/images/search?limit=4";

        var client = new HttpClient();
        var response = client.GetAsync(apiUrl).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        List<Root2> model = JsonConvert.DeserializeObject<List<Root2>>(content); 
  
       
        return View(model);
        
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

    
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
 
    }
    
}
