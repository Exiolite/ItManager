using Models.External;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace DataServer
{
    public class ServerSocket
    {
        private const string Ip = "127.0.0.1";
        private const int port = 8080;
        private const int listeners = 5;

        private DataContext _dataContext = new DataContext();

        public ServerSocket()
        {
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(Ip), port);
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(listeners);

            while (true)
            {
                var listener = tcpSocket.Accept();
                var buffer = new byte[listener.ReceiveBufferSize];
                var size = 0;
                var stringBuilder = new StringBuilder();

                do
                {
                    size = listener.Receive(buffer);
                    stringBuilder.Append(Encoding.UTF8.GetString(buffer, 0, size));
                } while (listener.Available > 0);

                _dataContext.Merge(JsonSerializer.Deserialize<DataContext>(stringBuilder.ToString()));

                listener.Send(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(_dataContext)));

                listener.Shutdown(SocketShutdown.Both);
                listener.Close();

                File.WriteAllText("Save.dat", JsonSerializer.Serialize(_dataContext));
            }
        }
    }
}
