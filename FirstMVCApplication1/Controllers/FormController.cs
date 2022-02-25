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

        //GET
        public IActionResult Index()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(AddAddress objfc)
        {
            if (objfc.Name == objfc.Address) {
                ModelState.AddModelError("CustomError", "Give name different from address.");
            }
            if (ModelState.IsValid) { 
                _db.AddAddresses.Add(objfc);
                _db.SaveChanges();
                return RedirectToAction("ShowData");
            }
            return View(objfc);
        }


        //for editing
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) {
                return NotFound();
            }
            var addressfromDB = _db.AddAddresses.Find(id);

            if (addressfromDB == null) {
                return NotFound();
            }

            return View(addressfromDB);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AddAddress objfc)
        {
            if (objfc.Name == objfc.Address)
            {
                ModelState.AddModelError("CustomError", "Give name different from address.");
            }
            if (ModelState.IsValid)
            {
                //_db.AddAddresses.Add(objfc);
                _db.AddAddresses.Update(objfc);
                _db.SaveChanges();
                return RedirectToAction("ShowData");
            }
            return View(objfc);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var addressfromDB = _db.AddAddresses.Find(id);

            if (addressfromDB == null)
            {
                return NotFound();
            }

            _db.AddAddresses.Remove(addressfromDB);
            _db.SaveChanges();
            return RedirectToAction("ShowData");

            //return View(addressfromDB);
        }



        public IActionResult ShowData() 
        {
            IEnumerable<AddAddress> obj_addressinfo_list = _db.AddAddresses;
            return View(obj_addressinfo_list);
        }
    }
}
