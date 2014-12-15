using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrapping;

namespace TestUnitaire
{
    [TestClass]
    public class UnitWrapper
    {
        [TestMethod]
        public void GameInit()
        {
            Wrapper w = new Wrapper();
            Assert.IsNotNull(w);
        }
    }
}
