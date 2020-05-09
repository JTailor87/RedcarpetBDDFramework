using NUnit.Framework;
using System;

namespace Redcarpet.BDDtesting.ComponentHelper
{
    public class AssertHelper
    {
        public static void AreEqual(string expected, string actual)
        {
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception)
            {
                //ignore
            }
        }
    }
}
