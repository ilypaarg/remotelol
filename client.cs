using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Windows.Forms;

namespace client
{
    class Program
    {
        static NetworkStream stream { get; set; }
        
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("<target ip>", <target port in integer not string>);
            
            stream = client.GetStream();
            
            while (true)
            {
                string[] input = Recieve();
                
                switch (input[0])
                {
                    case "msgbox":
                        {
                            ShowMsgBox(input[1], input[2]);
                            break;
                        }
                }
          }
     }
     
     private static void ShowMsgBox(string message, string title)
     {
        MessageBox.Show(message, title);
     }
     
     private static string[] Recieve()
     {
        byte[] bytes = new byte[1024];  // 1024 is recommended
        
        stream.Read(bytes, 0, bytes.Length);
        
        stream.Flush();
        
        return Encoding.ASCII.GetString(bytes).Split('|');
      }
   }
}
