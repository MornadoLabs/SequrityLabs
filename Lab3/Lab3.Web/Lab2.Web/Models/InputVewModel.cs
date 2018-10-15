using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab3.Web.Models
{
    public class InputVewModel
    {
        [Display(Name = "Input text")]
        public string InputText { get; set; }

        [Display(Name = "Choose file")]
        public string FileInputPath { get; set; }

        public bool IsManualInput { get; set; }
    }
}