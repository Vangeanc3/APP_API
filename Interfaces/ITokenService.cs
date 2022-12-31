using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP_API.Models;

namespace APP_API.Interfaces
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
    }
}