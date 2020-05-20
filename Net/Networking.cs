using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Battleships.Net
{
    class Networking
    {
        public static int Port;
        public static IPAddress Address;

        public enum State
        {
            Host,
            Client
        }
        
        private static TcpListener server;
        private static TcpClient client;
        private static Thread thServer;
        private static Thread thClient;
        public static State HostMode { get; private set; }

        public static bool connected = false;
        public static bool error = false;

        public static void Setup(State state)
        {
            error = false;
            HostMode = state;
            if(state == State.Host)
            {
                thServer = new Thread(Server);
                thServer.Start();
            }
            else
            {
                thClient = new Thread(Client);
                thClient.Start();
            }
        }

        public static void Close()
        {
            if (HostMode == State.Host)
                server.Stop();
            client.Close();
            connected = false;
        }

        private static void Client()
        {
            try
            {
                client = new TcpClient(Address.ToString(), Port);
                connected = true;
            }
            catch (Exception) {
                error = true;
            }
            connected = false;
        }

        private static void Server()
        {
            try
            {
                server = new TcpListener(Address, Port);

                server.Start();

                client = server.AcceptTcpClient();
                connected = true;
            }
            catch(Exception) {
                error = true;
            }
}

        public static void SendMessage(string msg)
        {
            byte[] buffer = UnicodeEncoding.Unicode.GetBytes(msg);
            SendInt(buffer.Length);

            try
            {
                client.GetStream().Write(buffer, 0, buffer.Length);
            }
            catch (Exception) {
                error = true;
            }
        }

        public static void SendInt(int value)
        {
            byte[] buffer = BitConverter.GetBytes(value);

            try
            {
                client.GetStream().Write(buffer, 0, buffer.Length);
            }
            catch (Exception) {
                error = true;
            }
        }

        public static string GetMessage()
        {
            int len = GetInt();
            byte[] buffer = new byte[len];
            
            try
            {
                client.GetStream().Read(buffer, 0, buffer.Length);
                return UnicodeEncoding.Unicode.GetString(buffer);
            }
            catch (Exception) {
                error = true;
                return "";
            }
        }

        public static int GetInt()
        {
            byte[] buffer = new byte[4];
            try
            {
                client.GetStream().Read(buffer, 0, buffer.Length);
                return BitConverter.ToInt32(buffer, 0);
            } catch (Exception) {
                error = true;
                return 0;
            }
        }

        public static void SendBool(bool value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            try
            {
                client.GetStream().Write(buffer, 0, buffer.Length);
            }
            catch (Exception) {
                error = true;
            }
        }

        public static bool GetBool()
        {
            byte[] buffer = new byte[1];
            try
            {
                client.GetStream().Read(buffer, 0, 1);
                return BitConverter.ToBoolean(buffer, 0);
            }
            catch (Exception) {
                error = true;
                return false;
            }
        }
    }
}
