using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using Lab1.Web.Helpers;
using Lab1.Web.Models;
using Lab1.Web.Services;

namespace Lab1.Web.Controllers
{
    public class HomeController : Controller
    {
        private static int PageSize;
        private static InputModel Data { get; set; }
        private static GeneratingResultModel GeneratingResults { get; set; }

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
                OutputSize = 190
            };

            return View(model);
        }        
                
        public JsonResult InputData(InputViewModel model)
        {
            if (model.InputType)
            {
                var variant = EnumValuesParser.GetVariantModel(model.Variant);
                Data = new InputModel
                {
                    A = variant.A,
                    C = variant.C,
                    M = variant.M,
                    X0 = variant.X0
                };
            }
            else
            {
                if (model.ManualInput.A >= model.ManualInput.M ||
                    model.ManualInput.C >= model.ManualInput.M ||
                    model.ManualInput.X0 >= model.ManualInput.M)
                {
                    return Json(new
                    {
                        Success = false,
                        ErrorMessage = "Incorrect input data."
                    }, JsonRequestBehavior.AllowGet);
                }

                Data = new InputModel
                {
                    A = model.ManualInput.A,
                    C = model.ManualInput.C,
                    M = model.ManualInput.M,
                    X0 = model.ManualInput.X0
                };
            }

            PageSize = model.OutputSize;
            GeneratingResults = GeneratorService.GenerateSequence(Data);

            return Json(new
            {
                Success = true,
                Period = GeneratingResults.Period,
                PagesCount = (GeneratingResults.Period + 1) % PageSize == 0 ?
                    (GeneratingResults.Period + 1) / PageSize :
                    (GeneratingResults.Period + 1) / PageSize + 1
            }, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult LoadPage(int number)
        {
            var firstElemId = number * PageSize;
            var tuchPointId = firstElemId / RandomSequenceGenerator.PartSize;
            var skipCount = firstElemId - tuchPointId * RandomSequenceGenerator.PartSize;
            var takeCount = GeneratingResults.Period - firstElemId < PageSize ? 
                                (int)(GeneratingResults.Period - firstElemId + 1) : 
                                PageSize;

            var generator = new RandomSequenceGenerator(Data.A, Data.C, Data.M, GeneratingResults.TuchPoints[tuchPointId]);
            var pageContent = new StringBuilder();
            var sequence = generator.GetNextSequencePart().Skip(skipCount).Take(takeCount).ToList();
            if (sequence.Count < PageSize && GeneratingResults.Period - firstElemId > PageSize)
            {
                sequence.AddRange(generator.GetNextSequencePart().Skip(sequence.Count).Take(PageSize - sequence.Count).ToList());
            }
            sequence.ForEach(num => pageContent.Append(num).Append(" "));
            
            return Json(new { PageContent = pageContent.ToString() }, JsonRequestBehavior.AllowGet);
        }
    }
}