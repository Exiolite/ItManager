using Models.External;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace DataServer
{
    public class ServerSocket
    {
        private const string Ip = "192.168.116.73";
        private const int port = 8080;
        private const int listeners = 5;

        public ServerSocket(string password)
        {
            if(File.Exists("DataBase.im"))
                Program.DataContext = JsonSerializer.Deserialize<DataContext>(Encryption.Decrypt(File.ReadAllBytes("DataBase.im"), password));
            else
            {
                Program.DataContext = new DataContext();
                File.WriteAllBytes("DataBase.im", Encryption.Encrypt(JsonSerializer.Serialize(Program.DataContext), password));
            }

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

                Program.Merge(JsonSerializer.Deserialize<DataContext>(stringBuilder.ToString()));

                listener.Send(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(Program.DataContext)));

                listener.Shutdown(SocketShutdown.Both);
                listener.Close();

                File.WriteAllBytes("DataBase.im", Encryption.Encrypt(JsonSerializer.Serialize(Program.DataContext), password));
            }
        }
    }
}
