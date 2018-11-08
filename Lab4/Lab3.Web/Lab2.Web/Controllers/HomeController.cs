using Lab4.Web.Models;
using Lab4.Web.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using FileInfo = System.IO.FileInfo;

namespace Lab4.Web.Controllers
{
    public class HomeController : Controller
    {
        public RC5Service RC5Service { get; set; } = new RC5Service();
        public FileService FileService { get; set; } = new FileService();
        public RSAService RSAService { get; set; } = new RSAService();

        public ActionResult Index()
        {
            var model = new InputVewModel { RC5Key = "Key" };            
            return View(model);
        }

        [HttpPost]
        public JsonResult EncryptData(InputVewModel input)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                var inputRSAData = FileService.LoadFile(input.RSAFileInput);
                var inputRC5Data = FileService.LoadFile(input.RC5FileInput);

                stopwatch.Start();
                var rc5EncryptingResults =
                    RC5Service.Encrypt(inputRC5Data, Encoding.Unicode.GetBytes(input.RC5Key), 64, 16, 32);
                stopwatch.Stop();

                var rc5Time = stopwatch.ElapsedMilliseconds / 1000.0;
                FileService.SaveEncriptingResut(rc5EncryptingResults, input.RC5FileInput);

                stopwatch.Reset();

                var rsaKeys = RSAService.GenerateKeys(RSAService.DefaultKeySize);
                FileService.SaveFile(RSAService.PublicKeyFile, rsaKeys.PublicKey);
                FileService.SaveFile(RSAService.PrivateKeyFile, rsaKeys.PrivateKey);

                stopwatch.Start();
                var rsaEncryptingResults = RSAService.Encrypt(inputRSAData);
                stopwatch.Stop();

                var rsaTime = stopwatch.ElapsedMilliseconds / 1000.0;
                FileService.SaveFileWithSuffix(input.RSAFileInput, "_encryptedUsingRSA", rsaEncryptingResults);

                var successMessage = $"File encrypted successfully. {Environment.NewLine} " +
                    $"RC5 executing time: {rc5Time} s.{Environment.NewLine} RSA executing time: {rsaTime} s.";

                return Json(new { Success = true, SuccessMessage = successMessage }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { Success = false, ErrorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DecryptData(InputVewModel input)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                var inputRSAData = FileService.LoadFile(input.RSAFileInput);
                var inputRC5Data = FileService.LoadFile(input.RC5FileInput);

                stopwatch.Start();
                var rc5DecryptingResults =
                    RC5Service.Decrypt(inputRC5Data, Encoding.Unicode.GetBytes(input.RC5Key), 64, 16, 32);
                stopwatch.Stop();

                var rc5Time = stopwatch.ElapsedMilliseconds / 1000.0;
                FileService.SaveDecriptingResut(input.RC5FileInput, rc5DecryptingResults);

                stopwatch.Reset();

                RSAService.GenerateKeys(RSAService.DefaultKeySize);
                stopwatch.Start();
                var rsaDecryptingResults = RSAService.Decrypt(inputRSAData);
                stopwatch.Stop();

                var rsaTime = stopwatch.ElapsedMilliseconds / 1000.0;
                FileService.SaveFileWithSuffix(input.RSAFileInput, "_decryptedUsingRSA", rsaDecryptingResults);

                var successMessage = $"File decrypted successfully. {Environment.NewLine} " +
                    $"RC5 executing time: {rc5Time} s.{Environment.NewLine} RSA executing time: {rsaTime} s.";

                return Json(new { Success = true, SuccessMessage = successMessage }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { Success = false, ErrorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult EncryptDataUsingRSA(InputVewModel input)
        {
            try
            {
                var rsaKeys = RSAService.GenerateKeys(RSAService.DefaultKeySize);
                FileService.SaveFile(RSAService.PublicKeyFile, rsaKeys.PublicKey);
                FileService.SaveFile(RSAService.PrivateKeyFile, rsaKeys.PrivateKey);

                var encryptingResults = RSAService.Encrypt(FileService.LoadFile(input.RSAFileInput));
                FileService.SaveFileWithSuffix(input.RSAFileInput, "_encrypted", encryptingResults);

                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { Success = false, ErrorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DecryptDataUsingRSA(InputVewModel input)
        {
            try
            {
                var decryptingResults =
                    RSAService.Decrypt(FileService.LoadFile(input.RSAFileInput));
                FileService.SaveFileWithSuffix(input.RSAFileInput, "_decrypted", decryptingResults);

                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { Success = false, ErrorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult EncryptDataUsingRC5(InputVewModel input)
        {
            try
            {                
                var encryptingResults =
                    RC5Service.Encrypt(
                        FileService.LoadFile(input.RC5FileInput),
                        Encoding.Unicode.GetBytes(input.RC5Key), 64, 16, 32);
                FileService.SaveEncriptingResut(encryptingResults, input.RC5FileInput);

                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { Success = false, ErrorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DecryptDataUsingRC5(InputVewModel input)
        {
            try
            {
                var decryptingResults =
                    RC5Service.Decrypt(
                        FileService.LoadFile(input.RC5FileInput),
                        Encoding.Unicode.GetBytes(input.RC5Key), 64, 16, 32);

                FileService.SaveDecriptingResut(input.RC5FileInput, decryptingResults);

                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { Success = false, ErrorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        
    }
}