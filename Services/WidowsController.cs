using Poweroff.Models;
using System.Diagnostics;

namespace Poweroff.Services
{
    public class WidowsController : ISystemController
    {
        private const string _command = "shutdown";

        public PoweroffResult Hibernate(int delay = 0)
        {
            throw new NotImplementedException();
        }

        public PoweroffResult Leave(bool forse = false, int delay = 0)
        {
            string commandParams = "/l";
            commandParams += forse ? "/f" : string.Empty;
            commandParams += $"/t {delay}";

            Process.Start(_command, commandParams);

            return new PoweroffResult(true);
        }

        public PoweroffResult ShutDown(bool forse = false, int delay = 0)
        {
            throw new NotImplementedException();
        }

        public PoweroffResult Sleep(int delay = 0)
        {
            throw new NotImplementedException();
        }
    }
}
