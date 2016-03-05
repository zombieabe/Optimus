﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Core
{
    public interface IPrimeGenerator
    {
        uint[] GeneratePrimesArray(uint arrayLength);
    }
}
