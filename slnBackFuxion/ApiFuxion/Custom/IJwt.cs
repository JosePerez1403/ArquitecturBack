using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFuxion.Custom
{
    interface IJwt
    {
        string Authenticate(string user, string pass);
    }
}
