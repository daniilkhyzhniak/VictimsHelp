using System.Collections.Generic;
using System.Security.Claims;

namespace VictimsHelp.PL.Authorization
{
    public interface ITokenFactory
    {
        string CreateToken(ICollection<Claim> claims);
    }
}
