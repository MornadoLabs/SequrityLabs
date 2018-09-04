using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1.Web.Models
{
    public class InputModel
    {
        [Display(Name="a")]
        public long A { get; set; }

        [Display(Name="c")]
        public long C { get; set; }

        [Display(Name="m")]
        public long M { get; set; }

        [Display(Name="X₀")]
        public long X0 { get; set; }
    }

    public class VariantModel : InputModel
    {
        public string Caption { get; set; }
    }
}