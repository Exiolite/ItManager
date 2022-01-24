using Models.External;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace ViewModels
{
    public class ClientSocket
    {
        private const string Ip = "127.0.0.1";
        private const int port = 8080;

        public static DataContext SendToServer(DataContext dataContext)
        {
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(Ip), port);
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var jsonDataContext = JsonSerializer.Serialize(dataContext);

            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(Encoding.UTF8.GetBytes(jsonDataContext));

            var buffer = new byte[tcpSocket.ReceiveBufferSize];
            var size = 0;
            var stringBuilder = new StringBuilder();

            do
            {
                size = tcpSocket.Receive(buffer);
                stringBuilder.Append(Encoding.UTF8.GetString(buffer,0, size));
            } while (tcpSocket.Available > 0);

            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();

            return JsonSerializer.Deserialize<DataContext>(stringBuilder.ToString());
        }
    }
}
