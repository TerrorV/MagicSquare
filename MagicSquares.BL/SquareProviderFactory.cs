using MagicSquares.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquares.BL
{
    public class SquareProviderFactory : ISquareProviderFactory
    {
        IEnumerable<ISquareProvider> _providerList;
        public SquareProviderFactory(IEnumerable<ISquareProvider> providerList)
        {
            _providerList = providerList;
        }

        public ISquareProvider GetProvider<T>() where T: ISquareProvider
        {
            return _providerList.First(p => p.GetType() == typeof(T));
        }
    }
}
