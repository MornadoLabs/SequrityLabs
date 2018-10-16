using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab3.Web.Models
{
    public class InputVewModel
    {
        [Display(Name = "Key word")]
        public string Key { get; set; }

        [Display(Name = "Choose file")]
        public string FileInput { get; set; }        
    }
}