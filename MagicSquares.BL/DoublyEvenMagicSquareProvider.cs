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
        IMagicConstantProvider _magicConstantProvider;
        public DoublyEvenMagicSquareProvider(IMagicConstantProvider magicConstantProvider)
        {
            _magicConstantProvider = magicConstantProvider;
        }

        public int[,] GenerateMagicSquare(int squareSize)
        {
            var squareArray = new int[squareSize, squareSize];
            var magicConstant = _magicConstantProvider.CalculateMagicConstant(squareSize);
            int shift = squareSize / 4;

            for (int x = 0; x < squareSize; x++)
            {
                for (int y = 0; y < squareSize; y++)
                {
                    var coordX = (x + 1);
                    var coordY = (y + 1);
                    bool reverse = (coordX <= shift && coordY <= shift) ||                                                                  //upper left corner
                                    (coordX > squareSize - shift && coordY <= shift) ||                                                     //upper right corner
                                    (coordX > squareSize - shift && coordY > squareSize - shift) ||                                         //lower right corner
                                    (coordY > squareSize - shift && coordX <= shift) ||                                                     //lower left corner
                                    (coordX > shift && coordX <= squareSize - shift && coordY > shift && coordY <= squareSize - shift);     //center

                    squareArray[x, y] = reverse ? squareSize * x + coordY : squareSize * squareSize - (squareSize * x + coordY) + 1;
                }
            }


            return squareArray;
        }
    }
}
