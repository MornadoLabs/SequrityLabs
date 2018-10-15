using Lab3.Web.Models;
using Lab3.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Lab3.Web.Controllers
{
    public class HomeController : Controller
    {
        private HashService _hashService;
        public HashService HashService {
            get
            {
                if (_hashService == null)
                {
                    _hashService = new HashService();
                }

                return _hashService;
            }
        }

        private FileService _fileService;
        public FileService FileService
        {
            get
            {
                if (_fileService == null)
                {
                    _fileService = new FileService();
                }

                return _fileService;
            }
        }

        public ActionResult Index()
        {
            var model = new InputVewModel { IsManualInput = true };
            return View(model);
        }

        public JsonResult GetHash(InputVewModel input)
        {
            string result;
            if (input.IsManualInput)
            {
                result = HashService.GetHash(Encoding.ASCII.GetBytes(input.InputText ?? string.Empty));
            }
            else
            {
                result = FileService.GetFileHash(input.FileInputPath);
            }
            
            return Json(new { Result = result }, JsonRequestBehavior.AllowGet);
        }
    }
}