using System.Security.Claims;

namespace ISAProject.Modules.Stakeholders.Infrastructure.Security
{
    public static class ClaimsPrincipalExtensions
    {
        public static int PersonId(this ClaimsPrincipal user)
            => int.Parse(user.Claims.First(i => i.Type == "personId").Value);
    }
}
