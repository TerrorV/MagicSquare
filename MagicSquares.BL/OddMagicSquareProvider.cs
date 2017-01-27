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

                // Advance one step
                x = isRightMost ? 0 : x + 1;
                y = isTopMost ? 0 : y + 1;

                var isBusy = squareArray[x, y] > 0;
                if(isBusy)
                {
                    // Back one step
                    x = isRightMost ? squareSize - 1 : x-1;
                    y = isTopMost ? squareSize - 1 : y-1;

                    // Change track
                    x--;
                }
            }

            return squareArray;
        }

    }
}
