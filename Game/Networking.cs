using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SchiffeFicken
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

        public static State HostMode { get; private set; }

        public static bool connected = false;
        public static bool error = false;

        public static void Setup(State state)
        {
            error = false;
            HostMode = state;
        }

        public static void Close()
        {
            connected = false;
        }

        public static void SendMessage(string msg)
        {
            //...
        }

        public static void SendInt(int value)
        {
            //...
        }

        public static string GetMessage()
        {
            //...
            return "";
        }

        public static int GetInt()
        {
            //...
            return 0;
        }

        public static void SendBool(bool value)
        {
            //...
        }

        public static bool GetBool()
        {
            //...
            return true;
        }
    }
}
