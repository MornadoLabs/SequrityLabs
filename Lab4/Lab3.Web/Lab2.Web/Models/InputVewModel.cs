using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab4.Web.Models
{
    public class InputVewModel
    {
        [Display(Name = "RC5 key word")]
        public string RC5Key { get; set; }

        [Display(Name = "Choose file for RSA")]
        public string RSAFileInput { get; set; }    

        [Display(Name = "Choose file for RC5")]
        public string RC5FileInput { get; set; }    
    }
}