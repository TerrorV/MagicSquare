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
        IMagicConstantProvider _magicConstantProvider;
        public OddMagicSquareProvider(IMagicConstantProvider magicConstantProvider)
        {
            _magicConstantProvider = magicConstantProvider;
        }

        public int[,] GenerateMagicSquare(int squareSize)
        {
            var squareArray = new int[squareSize, squareSize];
            var magicConstant = _magicConstantProvider.CalculateMagicConstant(squareSize);
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

    }
}
