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
            var model = new InputVewModel { W = 64, R = 16, B = 32 };
            var ListW = new List<SelectListItem>
            {
                new SelectListItem { Text = "16", Value = "16" },
                new SelectListItem { Text = "32", Value = "32" },
                new SelectListItem { Text = "64", Value = "64" }
            };

            ViewBag.ListW = ListW;

            return View(model);
        }

        [HttpPost]
        public JsonResult EncryptData(InputVewModel input)
        {
            try
            {
                if (input.R < 0 || input.R > 255)
                {
                    return Json(new
                    {
                        Success = false,
                        ErrorMessage = "R must be greater or equal 0 and less or equal than 255"
                    }, JsonRequestBehavior.AllowGet);
                }

                if (input.B < 0 || input.B > 255)
                {
                    return Json(new
                    {
                        Success = false,
                        ErrorMessage = "B must be greater or equal 0 and less or equal than 255"
                    }, JsonRequestBehavior.AllowGet);
                }

                var file = new FileInfo(FileService.BaseDirectory + input.FileInput);
                var encryptingResults =
                    RC5Service.Encrypt(
                        FileService.LoadFile(file.FullName),
                        Encoding.Unicode.GetBytes(input.Key), input.W, input.R, input.B);
                FileService.SaveEncriptingResut(encryptingResults, file);
            }
            catch(Exception ex)
            {
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DecryptData(InputVewModel input)
        {
            try
            {
                if (input.R < 0 || input.R > 255)
                {
                    return Json(new
                    {
                        Success = false,
                        ErrorMessage = "R must be greater or equal 0 and less or equal than 255"
                    }, JsonRequestBehavior.AllowGet);
                }

                if (input.B < 0 || input.B > 255)
                {
                    return Json(new
                    {
                        Success = false,
                        ErrorMessage = "B must be greater or equal 0 and less or equal than 255"
                    }, JsonRequestBehavior.AllowGet);
                }

                var file = new FileInfo(FileService.BaseDirectory + input.FileInput);
                var decryptingResults =
                    RC5Service.Decrypt(
                        FileService.LoadFile(file.FullName),
                        Encoding.Unicode.GetBytes(input.Key), input.W, input.R, input.B);

                FileService.SaveDecriptingResut(decryptingResults, file);
            }
            catch(Exception ex)
            {
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}