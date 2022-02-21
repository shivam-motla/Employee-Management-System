using Microsoft.AspNetCore.Mvc;

using FirstMVCApplication1.Data;
using FirstMVCApplication1.Models;

namespace FirstMVCApplication1.Controllers
{
    public class FormController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FormController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();

        }
        public IActionResult ShowData() 
        {
            IEnumerable<AddAddress> obj_addressinfo_list = _db.AddAddresses;
            return View(obj_addressinfo_list);
        }
    }
}
