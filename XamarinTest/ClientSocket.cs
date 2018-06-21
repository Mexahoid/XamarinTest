using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinTest
{
    class ClientSocket
    {
        private string addr;
        private int port;
        private TcpClient tcpClient;
        private NetworkStream networkStream;

        private static ClientSocket instance;

        private ClientSocket(string addr, int port)
        {
            this.addr = addr;
            this.port = port;
        }

        public static ClientSocket GetInstance(string addr, int port)
        {
            return instance ?? (instance = new ClientSocket(addr, port));
        }
        
        

        public async Task Connect()
        {
            tcpClient = new TcpClient();
            //Console.WriteLine("[Client] Connecting to server");
            await tcpClient.ConnectAsync(addr, port);
            //Console.WriteLine("[Client] Connected to server");
            networkStream = tcpClient.GetStream();
        }

        public async Task<string> ClientWork(string text)
        {
            string res = await SendMessage(text);
            return $"Server response was {res}";
            //Console.WriteLine("[Client] Server response was {0}", res);
            //}
        }

        private async Task<string> SendMessage(string message)
        {
            //Console.WriteLine($"[Client] Writing request {message}");
            var bytes = Encoding.UTF8.GetBytes(message);
            await networkStream.WriteAsync(bytes, 0, bytes.Length);

            var buffer = new byte[4096];
            var byteCount = await networkStream.ReadAsync(buffer, 0, buffer.Length);
            //networkStream.Flush();
            return Encoding.UTF8.GetString(buffer, 0, byteCount);
        }

        public void Disconnect()
        {
            if (networkStream != null)
            {
                networkStream.Flush();
                networkStream.Close();
            }

            if (tcpClient != null && tcpClient.Connected)
                tcpClient.Close();
        }
    }
}