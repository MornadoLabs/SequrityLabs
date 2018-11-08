using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Web.Models
{
    public class EncryptingResultModel
    {
        public byte[] IV { get; set; }
        public byte[] EncryptedData { get; set; }
    }
}