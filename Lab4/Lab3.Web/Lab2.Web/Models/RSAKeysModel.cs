using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Web.Models
{
    public class RSAKeysModel
    {
        public byte[] PublicKey { get; set; }
        public byte[] PrivateKey { get; set; }
    }
}