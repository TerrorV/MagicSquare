using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicSquares.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCalculateMagicConstant()
        {
            int squareSize = 3;
            int magicConstant = CalculateMagicConstant(squareSize);
            var magicSquare = new int[squareSize];

            Assert.AreEqual(magicConstant, 15);
            Assert.AreEqual(CalculateMagicConstant(2), 5);
            Assert.AreEqual(CalculateMagicConstant(4), 34);
            Assert.AreEqual(CalculateMagicConstant(4), 34);
            Assert.AreEqual(CalculateMagicConstant(122001), 977287841);
            Assert.AreEqual(CalculateMagicConstant(122001), 977287841);

        }

        [TestMethod]
        public void TestGenerateSquare()
        {
            int squareSize = 3;
            int[] magicSquare = TestGenerateSquare(squareSize);

        }

        private int[] TestGenerateSquare(int squareSize)
        {
            var squareArray = new int[squareSize];
            var magicConstant = CalculateMagicConstant(squareSize);
            for (int i = 0; i < magicConstant; i++)
            {

            }

            throw new NotImplementedException();
        }

        private int CalculateMagicConstant(int squareSize)
        {
            return squareSize * (squareSize * squareSize + 1) / 2;
        }
    }
}
