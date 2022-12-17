using System.Security.Claims;

namespace RentACarPlatform.Extensions
{
    /// <summary>
    /// Convert claim to string
    /// </summary>
    public static class ClaimsPrincipleExtension
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
