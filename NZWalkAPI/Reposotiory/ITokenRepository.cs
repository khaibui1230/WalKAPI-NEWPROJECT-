using Microsoft.AspNetCore.Identity;

namespace NZWalkAPI.Reposotiory
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
