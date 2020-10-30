using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplast
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TcpListener _Listen;
        TcpClient _Sock;
        private void btnStart_Click(object sender, EventArgs e)
        {
            if(_Listen == null)
            _Listen = new TcpListener(int.Parse(tbPort.Text));
            _Listen.Start();

            _Sock = _Listen.AcceptTcpClient();

            NetworkStream ns = _Sock.GetStream();

        }
    }
}
