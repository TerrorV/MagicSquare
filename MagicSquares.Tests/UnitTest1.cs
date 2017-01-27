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
            long magicConstant = CalculateMagicConstant(squareSize);
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
            int squareSize = 20001;
            long magicConstant = CalculateMagicConstant(squareSize);
            Assert.IsTrue(magicConstant > 0);
            int[,] magicSquare = GenerateOddSquare(squareSize);

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

        private int[,] GenerateOddSquare(int squareSize)
        {
            var squareArray = new int[squareSize, squareSize];
            var magicConstant = CalculateMagicConstant(squareSize);
            var x = squareSize - 1;
            var y = (squareSize - 1) / 2;
            ////var x = 3-squareSize;
            ////var y = (squareSize - 1) / 2;
            for (int i = 1; i <= squareSize * squareSize; i++)
            {
                squareArray[x, y] = i;

                //x++;
                //y++;
                if (x + 1 < squareSize && y + 1 < squareSize)
                {
                    if (squareArray[x + 1, y + 1] > 0)
                    {
                        //x--;
                        //y--;
                        x--;
                    }
                    else
                    {
                        x++;
                        y++;
                    }
                }
                else
                {
                    if (x + 1 == squareSize && y + 1 == squareSize)
                    {
                        if (squareArray[0, 0] > 0)
                        {
                            x--;
                        }
                        else
                        {
                            x = 0;
                            y = 0;
                        }
                    }
                    else if (x + 1 == squareSize)
                    {
                        if (squareArray[0, y + 1] > 0)
                        {
                            x--;
                        }
                        else
                        {
                            x = 0;
                            y++;
                        }
                    }
                    else if (y + 1 == squareSize)
                    {
                        if (squareArray[x + 1, 0] > 0)
                        {
                            x--;
                        }
                        else
                        {
                            y = 0;
                            x++;
                        }
                    }
                }





                ////int coordX = x;
                ////int coordY = y;
                ////if(coordX<0)
                ////{
                ////    coordX += squareSize;
                ////}

                ////if (coordY < 0)
                ////{
                ////    coordY += squareSize;
                ////}

                ////if (coordX >= squareSize )
                ////{
                ////    coordX -= squareSize;
                ////}

                ////if (coordY >= squareSize)
                ////{
                ////    coordY -= squareSize;
                ////}

                ////squareArray[coordX, coordY] = i;

                ////x++;
                ////y--;


                ////if (x < 0)
                ////{
                ////    x += squareSize;
                ////}

                ////if (coordY < 0)
                ////{
                ////    coordY += squareSize;
                ////}

                ////if (x >= squareSize)
                ////{
                ////    x -= squareSize;
                ////}

                ////if (coordY >= squareSize)
                ////{
                ////    coordY -= squareSize;
                ////}



            }

            return squareArray;
        }

        private long CalculateMagicConstant(long squareSize)
        {
            return squareSize * (squareSize * squareSize + 1) / 2;
        }
    }
}
