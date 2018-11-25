using System;
using Lab5.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Lab5.Tests
{
    [TestClass]
    public class MD5Tests
    {
        [TestMethod]
        public void TestHashEmpty()
        {
            var service = new HashService();
            Assert.AreEqual("D41D8CD98F00B204E9800998ECF8427E", service.GetHash(Encoding.ASCII.GetBytes(string.Empty)));
        }

        [TestMethod]
        public void TestHashA()
        {
            var service = new HashService();
            Assert.AreEqual("0CC175B9C0F1B6A831C399E269772661", service.GetHash(Encoding.ASCII.GetBytes("a")));
        }

        [TestMethod]
        public void TestHashABC()
        {
            var service = new HashService();
            Assert.AreEqual("900150983CD24FB0D6963F7D28E17F72", service.GetHash(Encoding.ASCII.GetBytes("abc")));
        }

        [TestMethod]
        public void TestHashMessageDigest()
        {
            var service = new HashService();
            Assert.AreEqual("F96B697D7CB7938D525A2F31AAF161D0", service.GetHash(Encoding.ASCII.GetBytes("message digest")));
        }

        [TestMethod]
        public void TestHashLongString()
        {
            var service = new HashService();
            Assert.AreEqual("C3FCD3D76192E4007DFB496CCA67E13B", 
                            service.GetHash(Encoding.ASCII.GetBytes("abcdefghijklmnopqrstuvwxyz")));
        }

        [TestMethod]
        public void TestHashVeryLongString()
        {
            var service = new HashService();
            Assert.AreEqual("D174AB98D277D9F5A5611C2C9F419D9F", 
                            service.GetHash(Encoding.ASCII.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789")));
        }

        [TestMethod]
        public void TestHashNumbersString()
        {
            var service = new HashService();
            Assert.AreEqual("57EDF4A22BE3C955AC49DA2E2107B67A", 
                            service.GetHash(Encoding.ASCII.GetBytes("12345678901234567890123456789012345678901234567890123456789012345678901234567890")));
        }
    }
}
