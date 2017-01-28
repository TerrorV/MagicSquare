using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicSquares.BL;
using System.Diagnostics;

namespace MagicSquares.BL.Tests
{
    [TestClass]
    public class When_generating_Magic_Square_constant
    {
        [TestMethod]
        public void Should_generate_a_positive_constant()
        {

            var constantProvider = new MagicConstantProvider();
            long magicConstant = constantProvider.CalculateMagicConstant(3);
            Assert.IsTrue(magicConstant > 0);
            Assert.AreEqual(magicConstant, 15);

            magicConstant = constantProvider.CalculateMagicConstant(2);
            Assert.IsTrue(magicConstant > 0);
            Assert.AreEqual(magicConstant, 5);


            magicConstant = constantProvider.CalculateMagicConstant(4);
            Assert.IsTrue(magicConstant > 0);
            Assert.AreEqual(magicConstant, 34);


            magicConstant = constantProvider.CalculateMagicConstant(122001);
            Assert.IsTrue(magicConstant > 0);
            Assert.AreEqual(magicConstant, 907946326244001);
        }

    }
}
