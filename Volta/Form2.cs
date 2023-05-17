using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Volta
{
    public partial class Form2 : Form
    {
        public string anaport;
        public string gorevport;
        public string yedekport;
        public int ta;
        public Form2()
        {
            InitializeComponent();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
                comboBox2.Items.Add(port);
                comboBox3.Items.Add(port);

            }


        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            anaport = comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            gorevport = comboBox2.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            yedekport = comboBox3.Text;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ta = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Hata");
            }
            
        }
    }
}
