using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeFicken
{
    class Networking
    {
        public enum State
        {
            Host,
            Client
        }

        public static bool connected = false;

        public static void Setup(State state, IPAddress Hostname, int Port)
        {
            // ......
        }

        public static void SendMessage(string msg)
        {
            // ....
        }

        public static string GetMessage()
        {
            return "";
        }

        public static bool GetBool()
        {
            return true;
        }
    }
}
