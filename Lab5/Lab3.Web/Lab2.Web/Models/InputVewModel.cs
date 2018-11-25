using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab5.Web.Models
{
    public class InputVewModel
    {
        [Display(Name = "Choose file")]
        public string FileInput { get; set; }    

        [Display(Name = "Choose file with signature")]
        public string FileInputSignature { get; set; }    

        [Display(Name = "Input text")]
        public string InputText { get; set; }
        
        public bool IsManualInput { get; set; }
    }
}