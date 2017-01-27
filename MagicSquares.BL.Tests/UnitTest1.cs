using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicSquares.BL;
using System.Diagnostics;

namespace MagicSquares.BL.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGenerateEvenSquare()
        {
            int squareSize = 314;
            var magicConstantProvider = new MagicConstantProvider();
            long magicConstant = new MagicConstantProvider().CalculateMagicConstant(squareSize);
            Assert.IsTrue(magicConstant > 0);
            int[,] magicSquare = new EvenMagicSquareProvider(new OddMagicSquareProvider()).GenerateMagicSquare(squareSize);

            PrintSquare(magicSquare);
            long diagSum1 = 0;
            long diagSum2 = 0;
            for (int i = 0; i < squareSize; i++)
            {
                long rowSum = 0;
                long colSum = 0;
                diagSum1 += magicSquare[i, i];
                diagSum2 += magicSquare[i, squareSize - i - 1];

                for (int j = 0; j < squareSize; j++)
                {
                    rowSum += magicSquare[i, j];
                    colSum += magicSquare[j, i];
                }

                Assert.AreEqual(magicConstant, rowSum);
                Assert.AreEqual(magicConstant, colSum);
            }

            Assert.AreEqual(magicConstant, diagSum1);
            Assert.AreEqual(magicConstant, diagSum2);


        }

        private void PrintSquare(int[,] magicSquare)
        {
            var squareSize = magicSquare.GetLength(0);
            for (int i = 0; i < squareSize; i++)
            {
                for (int j = 0; j < squareSize; j++)
                {
                    Debug.Write($"{magicSquare[i, j]} \t");
                }

                Debug.WriteLine(string.Empty);
            }
        }

        [TestMethod]
        public void TestGenerateDoublyEvenSquare()
        {
            int squareSize = 1000;
            var magicConstantProvider = new MagicConstantProvider();
            long magicConstant = new MagicConstantProvider().CalculateMagicConstant(squareSize);
            Assert.IsTrue(magicConstant > 0);
            int[,] magicSquare = new DoublyEvenMagicSquareProvider().GenerateMagicSquare(squareSize);

            long diagSum1 = 0;
            long diagSum2 = 0;
            for (int i = 0; i < squareSize; i++)
            {
                long rowSum = 0;
                long colSum = 0;
                diagSum1 += magicSquare[i, i];
                diagSum2 += magicSquare[i, squareSize - i - 1];

                for (int j = 0; j < squareSize; j++)
                {
                    rowSum += magicSquare[i, j];
                    colSum += magicSquare[j, i];
                }

                Assert.AreEqual(magicConstant, rowSum);
                Assert.AreEqual(magicConstant, colSum);
            }

            Assert.AreEqual(magicConstant, diagSum1);
            Assert.AreEqual(magicConstant, diagSum2);

        }

    }
}
