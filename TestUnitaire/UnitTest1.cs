using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetPOO;
using Wrapping;

namespace TestUnitaire
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GameInit()
        {
            Wrapper w = new Wrapper();
            World w0 = new World(null);
            //Assert.IsNotNull(Player);
        }
    }
}
