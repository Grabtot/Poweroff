using Poweroff.Models;
using Poweroff.Services;

namespace Poweroff.Controllers
{
    public class PowerController(ISystemController systemController)
    {
        private readonly ISystemController _systemController = systemController;
        public PoweroffResult Exit()
        {
            PoweroffResult result = _systemController.Leave();

            return result;
        }
    }
}
