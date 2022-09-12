using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PorcinoRemoto.App.Frontend.Pages;

public class RegistrosModel : PageModel
{
    private readonly ILogger<RegistrosModel> _logger;

    public RegistrosModel(ILogger<RegistrosModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
