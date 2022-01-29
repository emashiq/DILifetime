using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DILifetime.Models;
using DILifetime.Services;

namespace DILifetime.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Dictionary<string,IService> _services = new Dictionary<string, IService>();
    public HomeController(ILogger<HomeController> logger, IScopedService scopedService,IScopedService scopedService2,
    ITransientService transientService,
    ITransientService transientService2,
    ISingletonService singletonService)
    {
        _logger = logger;
        _services.Add(nameof(scopedService),scopedService);
        _services.Add(nameof(scopedService2),scopedService2);
        _services.Add(nameof(transientService),transientService);
        _services.Add(nameof(transientService2),transientService2);
        _services.Add(nameof(singletonService),singletonService);
    }

    public IActionResult Index()
    {
        Dictionary<string,string> serviceResultDictionary = new Dictionary<string, string>();
        foreach (var item in _services)
        {
            serviceResultDictionary.Add(item.Key,$"Id: {item.Value.InstanceId.ToString()} :Created: {item.Value.InstanceCreationTime.ToString("hh:mm:ss.s")}");
        }
        
        return Json(serviceResultDictionary);
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
