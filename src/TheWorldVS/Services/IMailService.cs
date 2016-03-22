namespace TheWorldVS.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IMailService
    {
        Boolean SendMail(String to, String from, String subject, String body);
    }
}
