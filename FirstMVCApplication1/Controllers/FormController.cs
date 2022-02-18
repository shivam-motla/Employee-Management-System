using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApplication1.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewData() 
        { 
            return View();
        }
    }
}
