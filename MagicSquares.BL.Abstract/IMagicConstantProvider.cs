﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquares.BL.Abstract
{
    public interface IMagicConstantProvider
    {
        long CalculateMagicConstant(long squareSize);
    }
}
