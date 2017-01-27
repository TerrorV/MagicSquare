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
        IMagicConstantProvider _magicConstantProvider;
        public EvenMagicSquareProvider(IMagicConstantProvider magicConstantProvider)
        {
            _magicConstantProvider = magicConstantProvider;
        }

        public int[,] GenerateMagicSquare(int squareSize)
        {
            throw new NotImplementedException();
        }
    }
}
