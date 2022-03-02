using Microsoft.AspNetCore.Mvc;

using FirstMVCApplication1.Data;
using FirstMVCApplication1.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

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
        public IActionResult Index(UploadData objfc)
        {
            AddAddress addAddress1 = new AddAddress();
            if (objfc.Name == objfc.Address)
            {
                ModelState.AddModelError("CustomError", "Give name different from address.");
            }
            addAddress1.Id = objfc.Id;
            addAddress1.Name = objfc.Name;
            addAddress1.Address = objfc.Address;
            addAddress1.Country = objfc.Country;
            addAddress1.State=objfc.State;

            if (ModelState.IsValid)
            {

                if (objfc.Imagem != null)
                {

                    //var filePath = Path.Combine("\\UploadedFiles", Path.GetRandomFileName());
                    //filePath = filePath + ".jpg";

                
                    var fileName = Path.GetRandomFileName();
                    fileName = fileName + ".jpg";
                    
                    //filePath = filePath + ".jpg";

                    
                    addAddress1.imgpath = fileName;


                    //string _FileName = objfc.Imagem.FileName;
                    ////string imgpath_s= Path.Combine(, "images");
                    //string _path = Path.Combine(Microsoft.AspNetCore.Server.MapPath("~/UploadedFiles"), _FileName);
                    //objfc.Imagem.SaveAs(_path);
                }

                _db.AddAddresses.Add(addAddress1);
                _db.SaveChanges();
                int addAddress1id = addAddress1.Id;
                Directory.CreateDirectory("D:\\web_development\\FirstMVCApplication1\\FirstMVCApplication1\\wwwroot\\StoredData\\UploadedImages\\" + addAddress1id.ToString());
                string destpath = "D:\\web_development\\FirstMVCApplication1\\FirstMVCApplication1\\wwwroot\\StoredData\\UploadedImages\\" + addAddress1id.ToString() + "\\defaultpotraitimage.jpg";
                System.IO.File.Copy("D:\\web_development\\FirstMVCApplication1\\FirstMVCApplication1\\wwwroot\\StoredData\\UploadedImages\\defaultpotraitimage.jpg", destpath);

                if (objfc.Imagem != null)
                {
                    var filePath = "D:\\web_development\\FirstMVCApplication1\\FirstMVCApplication1\\wwwroot\\StoredData\\UploadedImages\\" + addAddress1id.ToString();
                    filePath = Path.Combine(filePath, addAddress1.imgpath);
                    objfc.Imagem.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                return RedirectToAction("ShowData");
            }
            return View(objfc);
        }




        //for editing
        //GET
        public IActionResult Edit(int? id)
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

            //UploadData ud = new UploadData();
            //ud.Id = addressfromDB.Id;
            //ud.Address = addressfromDB.Address;
            //ud.Country = addressfromDB.Country;
            //ud.State = addressfromDB.State;
            
            return View(addressfromDB);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UploadData objfc)
        {
            AddAddress addAddress1 = new AddAddress();
            if (objfc.Name == objfc.Address)
            {
                ModelState.AddModelError("CustomError", "Give name different from address.");
            }
            addAddress1.Id = objfc.Id;
            addAddress1.Name = objfc.Name;
            addAddress1.Address = objfc.Address;
            addAddress1.Country = objfc.Country;
            addAddress1.State = objfc.State;

            if (ModelState.IsValid)
            {

                if (objfc.Imagem != null)
                {

                    //var filePath = Path.Combine("\\UploadedFiles", Path.GetRandomFileName());
                    //filePath = filePath + ".jpg";


                    var fileName = Path.GetRandomFileName();
                    fileName = fileName + ".jpg";

                    //filePath = filePath + ".jpg";


                    addAddress1.imgpath = fileName;


                    //string _FileName = objfc.Imagem.FileName;
                    ////string imgpath_s= Path.Combine(, "images");
                    //string _path = Path.Combine(Microsoft.AspNetCore.Server.MapPath("~/UploadedFiles"), _FileName);
                    //objfc.Imagem.SaveAs(_path);
                }

                _db.AddAddresses.Update(addAddress1);
                _db.SaveChanges();
                int addAddress1id = addAddress1.Id;


                if (objfc.Imagem != null)
                {
                    var filePath = "D:\\web_development\\FirstMVCApplication1\\FirstMVCApplication1\\wwwroot\\StoredData\\UploadedImages\\" + addAddress1id.ToString();
                    filePath = Path.Combine(filePath, addAddress1.imgpath);
                    objfc.Imagem.CopyTo(new FileStream(filePath, FileMode.Create));
                }

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

           
            Directory.Delete("D:\\web_development\\FirstMVCApplication1\\FirstMVCApplication1\\wwwroot\\StoredData\\UploadedImages\\" + addressfromDB.Id.ToString(),true);
            _db.AddAddresses.Remove(addressfromDB);
            _db.SaveChanges();
            return RedirectToAction("ShowData");

        }



        public IActionResult ShowData()
        {
            IEnumerable<AddAddress> obj_addressinfo_list = _db.AddAddresses;
            return View(obj_addressinfo_list);
        }
    }
}
