using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApplication1.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
