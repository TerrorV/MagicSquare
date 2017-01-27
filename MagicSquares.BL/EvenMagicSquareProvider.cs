using MagicSquares.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquares.BL
{
    public class EvenMagicSquareProvider : ISquareProvider
    {
        OddMagicSquareProvider _oddSquareProvider;
        public EvenMagicSquareProvider(OddMagicSquareProvider oddSquareProvider)
        {
            _oddSquareProvider = oddSquareProvider;
        }

        public int[,] GenerateMagicSquare(int squareSize)
        {
            var halfSize = squareSize / 2;
            var baseSquare = _oddSquareProvider.GenerateMagicSquare(halfSize);
            var squareArray = new int[squareSize, squareSize];
            for (int x = 0; x < halfSize; x++)
            {
                for (int y = 0; y < halfSize; y++)
                {
                    squareArray[x, y] = baseSquare[halfSize - x - 1, y];
                    squareArray[x + halfSize, y + halfSize] = baseSquare[halfSize - x - 1, y] + squareSize * squareSize / 4;
                    squareArray[x, y + halfSize] = baseSquare[halfSize - x - 1, y] + squareSize * squareSize / 2;
                    squareArray[x + halfSize, y] = baseSquare[halfSize - x - 1, y] + 3 * squareSize * squareSize / 4;

                }
            }

            TransformRawSquare(squareArray);

            return squareArray;
        }

        private void TransformRawSquare(int[,] squareArray)
        {
            var squareSize = squareArray.GetLength(0);
            var halfSize = squareSize / 2;
            var shiftSize = (halfSize - 1) / 2 - 1;

            for (int x = 0; x < halfSize; x++)
            {
                var addition = (x == ((halfSize - 1) / 2)) ? 1 : 0;
                for (int y = 0; y < shiftSize + 1; y++)
                {
                    var tempItem = squareArray[x, y + addition];
                    squareArray[x, y + addition] = squareArray[x + halfSize, y + addition];
                    squareArray[x + halfSize, y + addition] = tempItem;
                }

                for (int y = 0; y < shiftSize; y++)
                {
                    var tempItem = squareArray[x, squareSize - y - 1];
                    squareArray[x, squareSize - y - 1] = squareArray[x + halfSize, squareSize - y - 1];
                    squareArray[x + halfSize, squareSize - y - 1] = tempItem;
                }
            }
        }
    }
}
