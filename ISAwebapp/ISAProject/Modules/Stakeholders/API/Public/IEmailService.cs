using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProject.Modules.Stakeholders.API.Public
{
    public interface IEmailService
    {
        public void SendActivationEmail(string recipientEmail, string activationLink);

    }
}
