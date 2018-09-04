using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Web.Models
{
    public class InputViewModel
    {
        public int Variant { get; set; }
        public bool InputType { get; set; }
        public InputModel ManualInput { get; set; }

        [Display(Name="Output Size")]
        public long OutputSize { get; set; }
    }
}