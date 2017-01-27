using MagicSquares.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquares.BL
{
    public class MagicSquareService : IMagicSquareService
    {
        ISquareProviderFactory _providerFactory;
        IMagicConstantProvider _constantProvide;
        public MagicSquareService(ISquareProviderFactory providerFactory, IMagicConstantProvider constantProvide)
        {
            _providerFactory = providerFactory;
            _constantProvide = constantProvide;
        }

        public int[,] GetSquare(int squareSize)
        {
            ISquareProvider provider;
            if (squareSize % 4 == 0)
            {
                provider = _providerFactory.GetProvider<DoublyEvenMagicSquareProvider>();
            }
            else if (squareSize % 2 == 0)
            {
                provider = _providerFactory.GetProvider<EvenMagicSquareProvider>();
            }
            else
            {
                provider = _providerFactory.GetProvider<OddMagicSquareProvider>();
            }

            try
            {
                return provider.GenerateMagicSquare(squareSize);
            }
            catch (OutOfMemoryException)
            {
                throw new Exception("You are really aiming big! Unfortunately you ran out of memory :(");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public long GetSquareConstant(int squareSize)
        {
            return _constantProvide.CalculateMagicConstant(squareSize);
        }
    }
}
