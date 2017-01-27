using MagicSquares.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquares.BL
{
    public class DoublyEvenMagicSquareProvider : ISquareProvider
    {
        public int[,] GenerateMagicSquare(int squareSize)
        {
            var squareArray = new int[squareSize, squareSize];
            int shift = squareSize / 4;

            for (int x = 0; x < squareSize; x++)
            {
                for (int y = 0; y < squareSize; y++)
                {
                    var coordX = (x + 1);
                    var coordY = (y + 1);
                    bool isUpperLeft = (coordX <= shift && coordY <= shift);
                    bool isUpperRight = (coordX > squareSize - shift && coordY <= shift);
                    bool isLowerRight = (coordX > squareSize - shift && coordY > squareSize - shift);
                    bool isLowerLeft = (coordY > squareSize - shift && coordX <= shift);
                    bool isCenter = (coordX > shift && coordX <= squareSize - shift && coordY > shift && coordY <= squareSize - shift);
                    bool reverse = isUpperLeft || isUpperRight || isLowerLeft || isLowerRight || isCenter;

                    squareArray[x, y] = reverse ? squareSize * x + coordY : squareSize * squareSize - (squareSize * x + coordY) + 1;
                }
            }


            return squareArray;
        }
    }
}
