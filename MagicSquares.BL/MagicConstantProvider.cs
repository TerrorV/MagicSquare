﻿using MagicSquares.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquares.BL
{
    public class MagicConstantProvider : IMagicConstantProvider
    {
        public long CalculateMagicConstant(long squareSize)
        {
            return squareSize * (squareSize * squareSize + 1) / 2;
        }
    }
}
