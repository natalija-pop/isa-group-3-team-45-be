using ISAProject.Modules.Stakeholders.Core.UseCases;

namespace ISAProject.Modules.Stakeholders.Infrastructure.Security
{
    internal class GuidPasswordGenerator: IPasswordGenerator
    {
        public string GeneratePassword()
        {
            return Guid.NewGuid()
                .ToString();
        }
    }
}
