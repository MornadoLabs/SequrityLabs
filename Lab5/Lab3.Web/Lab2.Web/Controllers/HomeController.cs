using Lab5.Web.Models;
using Lab5.Web.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using FileInfo = System.IO.FileInfo;

namespace Lab5.Web.Controllers
{
    public class HomeController : Controller
    {
        public FileService FileService { get; set; } = new FileService();
        public DSAService DSAService { get; set; } = new DSAService();

        public ActionResult Index()
        {
            var rsaKeys = DSAService.GenerateKeys();
            FileService.SaveFile(DSAService.PublicKeyFile, rsaKeys.PublicKey);
            FileService.SaveFile(DSAService.PrivateKeyFile, rsaKeys.PrivateKey);

            var model = new InputVewModel { IsManualInput = true };            
            return View(model);
        }

        [HttpPost]
        public JsonResult SignData(InputVewModel input)
        {
            try
            {
                var inputData = input.IsManualInput 
                                    ? Encoding.Unicode.GetBytes(input.InputText)
                                    : FileService.LoadFile(input.FileInput);
                
                var signature = DSAService.SignData(inputData);
                var successMessage = $"Signature created successfully.";

                return Json(new {
                    Success = true,
                    SuccessMessage = successMessage,
                    Result = Encoding.Unicode.GetString(signature)  
                }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { Success = false, ErrorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult SaveSign(InputVewModel input)
        {
            try
            {
                if (input.IsManualInput)
                {
                    var inputData = Encoding.Unicode.GetBytes(input.InputText);
                    var signature = DSAService.SignData(inputData);
                    FileService.SaveFileWithSuffix("ManualInput.txt", "_signature", signature);
                }
                else
                {
                    var inputData = FileService.LoadFile(input.FileInput);
                    var signature = DSAService.SignData(inputData);
                    FileService.SaveFileWithSuffix(input.FileInput, "_signature", signature);
                }                

                var successMessage = $"Signature saved successfully.";
                return Json(new
                {
                    Success = true,
                    SuccessMessage = successMessage,
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, ErrorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult CheckSign(InputVewModel input)
        {
            try
            {
                var inputData = input.IsManualInput
                                    ? Encoding.Unicode.GetBytes(input.InputText)
                                    : FileService.LoadFile(input.FileInput);
                var inputDataSignature = FileService.LoadFile(input.FileInputSignature);

                if (DSAService.CheckSign(inputData, inputDataSignature))
                {
                    var successMessage = $"Signature is correct!";
                    return Json(new { Success = true, SuccessMessage = successMessage }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var errorMessage = $"Signature is incorrect!";
                    return Json(new { Success = false, ErrorMessage = errorMessage }, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception ex)
            {
                return Json(new { Success = false, ErrorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
               
    }
}