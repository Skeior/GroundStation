using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Volta
{
    public partial class Form3 : Form
    {
        public string ver;
        public int baud;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            }
            comboBox2.Items.Add(4800);
            comboBox2.Items.Add(9600);
            comboBox2.Items.Add(19200);
            comboBox2.Items.Add(14400);
            comboBox2.Items.Add(38400);
            comboBox2.Items.Add(57600);
            comboBox2.Items.Add(115200);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

                ver = comboBox1.Text;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            baud=int.Parse(comboBox2.Text);
        }
    }
}
