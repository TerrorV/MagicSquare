using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicSquares.BL;
using System.Diagnostics;

namespace MagicSquares.BL.Tests
{
    [TestClass]
    public class When_generating_Even_Square
    {
        [TestMethod]
        public void Should_generate_magic_square()
        {
            int squareSize = 10014;
            var magicConstantProvider = new MagicConstantProvider();
            long magicConstant = new MagicConstantProvider().CalculateMagicConstant(squareSize);
            Assert.IsTrue(magicConstant > 0);
            int[,] magicSquare = new EvenMagicSquareProvider(new OddMagicSquareProvider()).GenerateMagicSquare(squareSize);

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
    //private void PrintSquare(int[,] magicSquare)
    //{
    //    var squareSize = magicSquare.GetLength(0);
    //    for (int i = 0; i < squareSize; i++)
    //    {
    //        for (int j = 0; j < squareSize; j++)
    //        {
    //            Debug.Write($"{magicSquare[i, j]} \t");
    //        }

    //        Debug.WriteLine(string.Empty);
    //    }
    //}

    [TestClass]
    public class When_generating_Doubly_Even_Square
    {
        [TestMethod]
        public void Should_generate_magic_square()
        {

            int squareSize = 10000;
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

    [TestClass]
    public class When_generating_Odd_Square
    {
        [TestMethod]
        public void Should_generate_magic_square()
        {

            int squareSize = 10001;
            long magicConstant = new MagicConstantProvider().CalculateMagicConstant(squareSize);
            Assert.IsTrue(magicConstant > 0);
            int[,] magicSquare = new OddMagicSquareProvider().GenerateMagicSquare(squareSize);

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
