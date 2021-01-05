using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFuxion.Custom
{
    public interface IToken
    {
        string CreateToken(string name);
    }
}
