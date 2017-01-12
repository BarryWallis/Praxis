using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SieveOfErasthones.Model;

namespace SieveOfEratosthenesUnitTests
{
    [TestClass]
    public class SieveOfErasthonesTests
    {
        [TestMethod]
        public void SieveOfErasthonesTest()
        {
            ICollection result = (ICollection)Sieve.Calculate(30);
            ICollection expected = (ICollection)new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, };
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
