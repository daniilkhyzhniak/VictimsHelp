using System.Security.Claims;

namespace VictimsHelp.BLL.Enums
{
    public static class ClaimType
    {
        public const string Id = "Id";
        public const string Email = ClaimsIdentity.DefaultNameClaimType;
        public const string Role = ClaimTypes.Role;
    }
}
