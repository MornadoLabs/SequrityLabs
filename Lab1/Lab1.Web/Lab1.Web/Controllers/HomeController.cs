using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab1.Web.Helpers;
using Lab1.Web.Models;

namespace Lab1.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var variants = new List<SelectListItem>();

            for (int i = 1; i < 26; i++)
            {
                variants.Add(new SelectListItem
                {
                    Text = EnumValuesParser.GetVariantModel(i).Caption,
                    Value = i.ToString()
                });
            }

            ViewBag.Variants = variants;

            var model = new InputViewModel
            {
                Variant = 1,
                InputType = true,
                ManualInput = new InputModel(),
                OutputSize = 100000
            };

            return View(model);
        }        

        public JsonResult InputData(InputViewModel model)
        {
            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}