using System;
using System.Windows.Forms;
using DarrenLee.Bluetooth;

namespace BlueConnectionClient
{
    public partial class Form1 : Form
    {
        Bluetooth_Client blueClient = new Bluetooth_Client("DESKTOP-1089RN9");
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "Not doing anything";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            blueClient.Start();
            textBox1.Text = "Trying to connect to server...";
            blueClient.IsConnected += BlueClient_IsConnected;

        }

        private void BlueClient_IsConnected(object sender, EventArgs e)
        {
            MessageBox.Show("Connection established!");
            if (InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    textBox1.Text = "Connected";
                }));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            blueClient.SyncMessage(richTextBox1.Text);
            richTextBox1.Text = null;
        }
    }
}
