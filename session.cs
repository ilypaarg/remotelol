using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace session
{
    class Session
    {
        private NetworkStream stream { get; set; }

        public void Start(TcpClient client)
        {
            Task.Run(() =>
            {

                stream = client.GetStream();

                while (true)
                {
                    string[] input = Recieve();

                    switch (input[0])
                    {

                    }
                }

            });

        }

        public void Stop()
        {
            stream.Close();
        }

        public void Send(string data)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(data);

            stream.Write(bytes, 0, bytes.Length);
        }

        public string[] Recieve()
        {
            byte[] bytes = new byte[1024]; //once again 1024 is recommended

            stream.Read(bytes, 0, bytes.Length);

            stream.Flush();

            return Encoding.ASCII.GetString(bytes).Split('|');
        }
    }
}
