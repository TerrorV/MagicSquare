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

                if (x + 1 < squareSize && y + 1 < squareSize)
                {
                    if (squareArray[x + 1, y + 1] > 0)
                    {
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
            }

            return squareArray;
        }

    }
}
