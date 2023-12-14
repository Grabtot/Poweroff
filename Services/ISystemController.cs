using Poweroff.Models;

namespace Poweroff.Services
{
    public interface ISystemController
    {
        PoweroffResult Leave(bool forse = false, int delay = 0);
        PoweroffResult ShutDown(bool forse = false, int delay = 0);
        PoweroffResult Hibernate(int delay = 0);
        PoweroffResult Sleep(int delay = 0);
    }
}
