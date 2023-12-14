using Newtonsoft.Json;
using Poweroff.Models;
using Poweroff.Services;
using Serilog;
using System.Net;
using System.Net.Sockets;

namespace Poweroff.Controllers
{
    public class NetworkListener(int port)
    {
        private readonly TcpListener _listener = new(IPAddress.Any, port);

        public void StartAsync()
        {
            _listener.Start();
            _listener.BeginAcceptTcpClient(AcceptCommand, null);
        }

        private void AcceptCommand(IAsyncResult asyncResult)
        {
            TcpClient client = _listener.EndAcceptTcpClient(asyncResult);

            Log.Debug($"Client {client.Client.LocalEndPoint} connected");

            BinaryReader reader = new(client.GetStream());

            string enumString = reader.ReadString();

            if (Enum.TryParse(enumString, out PowerOffCommands command))
            {
                PoweroffResult result = ExecuteCommand(command);

                BinaryWriter writer = new(client.GetStream());
                string jsonData = JsonConvert.SerializeObject(result);
                writer.Write(jsonData);
            }

            client.Close();

            _listener.BeginAcceptTcpClient(AcceptCommand, null);
        }

        private PoweroffResult ExecuteCommand(PowerOffCommands command)
        {
            PowerController controller = new(new WidowsController());

            PoweroffResult result = command switch
            {
                PowerOffCommands.Exit => controller.Exit(),
                _ => throw new InvalidOperationException("Not available command")
            };

            string resultMessage = result.Successful ? "executed successful" : "failed";
            Log.Debug($"Command {command} {resultMessage}");

            return result;
        }
    }


    public enum PowerOffCommands
    {
        PowerOff,
        Exit,
        Hibernate,
        Seep
    }
}
