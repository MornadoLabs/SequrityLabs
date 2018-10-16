using Lab3.Web.Models;
using Lab3.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using FileInfo = System.IO.FileInfo;

namespace Lab3.Web.Controllers
{
    public class HomeController : Controller
    {
        public RC5Service RC5Service { get; set; } = new RC5Service();
        public FileService FileService { get; set; } = new FileService();

        public ActionResult Index()
        {
            var model = new InputVewModel();
            return View(model);
        }

        [HttpPost]
        public JsonResult EncryptData(InputVewModel input)
        {
            try
            {
                var file = new FileInfo(FileService.BaseDirectory + input.FileInput);
                var encryptingResults =
                    RC5Service.Encrypt(
                        FileService.LoadFile(file.FullName),
                        Encoding.Unicode.GetBytes(input.Key), 32, 12, 16);
                FileService.SaveEncriptingResut(encryptingResults, file);
            }
            catch(Exception ex)
            {
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}