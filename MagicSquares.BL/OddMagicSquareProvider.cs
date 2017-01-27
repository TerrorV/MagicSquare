using MagicSquares.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquares.BL
{
    public class OddMagicSquareProvider : ISquareProvider
    {
        public int[,] GenerateMagicSquare(int squareSize)
        {
            var squareArray = new int[squareSize, squareSize];
            var x = squareSize - 1;
            var y = (squareSize - 1) / 2;
            for (int i = 1; i <= squareSize * squareSize; i++)
            {
                squareArray[x, y] = i;

                var isRightMost = x + 1 == squareSize;
                var isTopMost = y + 1 == squareSize;
                x = isRightMost ? 0 : x + 1;
                y = isTopMost ? 0 : y + 1;
                var isBusy = squareArray[x, y] > 0;
                if(isBusy)
                {
                    x = isRightMost ? squareSize - 2 : x-2;
                    y = isTopMost ? squareSize - 1 : y-1;
                }
            }

            return squareArray;
        }

    }
}
