using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Volta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        }
        int sayac = 0;
        string lora1;
        string lora2;
        string lora3;
        bool gonder3 = false;
        bool gonder1 = false;
        bool gonder2=false; 

        int check_sum = 0;
        public string adres;

        public static string[] aviyonik = new string[100];
        public static string[] gorev = new string[100];

        public static string[] yedek = new string[100];
        public byte takım_id = 0;

        public float irtifa = 0;
        public float gpsirtifa = 0;
        public float roket_enlem = 0;
        public float roket_boylam_irtifa = 0;

        public float gorev_yuku_gps_irtifa = 0;
        public float gorev_yuku_enlem = 0;
        public float gorev_yuku_boylam_irtifa = 0;

        public float jiroskop_x = 0;
        public float jiroskop_y = 0;
        public float jiroskop_z = 0;

        public float ivme_x = 0;
        public float ivme_y = 0;
        public float ivme_z = 0;
        public int parasut = 0;

        public float aci = 0;
        byte[] veriler = new byte[78];




        void Veri_Olustur()
        {
            check_sum = 0;
            veriler[0] = 0xFF;//sabit
            veriler[1] = 0xFF;
            veriler[2] = 0x54;
            veriler[3] = 0x52;
            veriler[4] = takım_id;

            veriler[5] = (byte)sayac;// sayac değeri her veri gönderildiğinde arttılıcak gönderilen paket sayısı


            byte[] irtifab = BitConverter.GetBytes(irtifa != 0 ? irtifa : 0f);
            veriler[6] = irtifab[0];
            veriler[7] = irtifab[1];
            veriler[8] = irtifab[2];
            veriler[9] = irtifab[3];

            byte[] gpsirtifab = BitConverter.GetBytes(gpsirtifa != 0 ? gpsirtifa : 0f);
            veriler[10] = gpsirtifab[0];
            veriler[11] = gpsirtifab[1];
            veriler[12] = gpsirtifab[2];
            veriler[13] = gpsirtifab[3];

            byte[] roketenlem = BitConverter.GetBytes(roket_enlem != 0 ? roket_enlem : 0f);
            veriler[14] = roketenlem[0];
            veriler[15] = roketenlem[1];
            veriler[16] = roketenlem[2];
            veriler[17] = roketenlem[3];

            byte[] roketboylam = BitConverter.GetBytes(roket_boylam_irtifa != 0 ? roket_boylam_irtifa : 0f);
            veriler[18] = roketboylam[0];
            veriler[19] = roketboylam[1];
            veriler[20] = roketboylam[2];
            veriler[21] = roketboylam[3];

            byte[] gorevyukugpsirtifa = BitConverter.GetBytes(gorev_yuku_gps_irtifa != 0 ? gorev_yuku_gps_irtifa : 0f);
            veriler[22] = gorevyukugpsirtifa[0];
            veriler[23] = gorevyukugpsirtifa[1];
            veriler[24] = gorevyukugpsirtifa[2];
            veriler[25] = gorevyukugpsirtifa[3];

            byte[] gorevyukuenlem = BitConverter.GetBytes(gorev_yuku_enlem != 0 ? gorev_yuku_enlem : 0f);
            veriler[26] = gorevyukuenlem[0];
            veriler[27] = gorevyukuenlem[1];
            veriler[28] = gorevyukuenlem[2];
            veriler[29] = gorevyukuenlem[3];

            byte[] gorevyukboylam = BitConverter.GetBytes(gorev_yuku_boylam_irtifa != 0 ? gorev_yuku_boylam_irtifa : 0f);
            veriler[30] = gorevyukboylam[0];
            veriler[31] = gorevyukboylam[1];
            veriler[32] = gorevyukboylam[2];
            veriler[33] = gorevyukboylam[3];

            veriler[34] = 0;
            veriler[35] = 0;
            veriler[36] = 0;
            veriler[37] = 0;

            veriler[38] = 0;
            veriler[39] = 0;
            veriler[40] = 0;
            veriler[41] = 0;

            veriler[42] = 0;
            veriler[43] = 0;
            veriler[44] = 0;
            veriler[45] = 0;

            byte[] jiroskopx = BitConverter.GetBytes(jiroskop_x != 0 ? jiroskop_x : 0f);
            veriler[46] = jiroskopx[0];
            veriler[47] = jiroskopx[1];
            veriler[48] = jiroskopx[2];
            veriler[49] = jiroskopx[3];

            byte[] jiroskopy = BitConverter.GetBytes(jiroskop_y != 0 ? jiroskop_y : 0f);
            veriler[50] = jiroskopy[0];
            veriler[51] = jiroskopy[1];
            veriler[52] = jiroskopy[2];
            veriler[53] = jiroskopy[3];

            byte[] jiroskopz = BitConverter.GetBytes(jiroskop_z != 0 ? jiroskop_z : 0f);
            veriler[54] = jiroskopz[0];
            veriler[55] = jiroskopz[1];
            veriler[56] = jiroskopz[2];
            veriler[57] = jiroskopz[3];

            byte[] ivmex = BitConverter.GetBytes(ivme_x != 0 ? ivme_x : 0f);
            veriler[58] = ivmex[0];
            veriler[59] = ivmex[1];
            veriler[60] = ivmex[2];
            veriler[61] = ivmex[3];

            byte[] ivmey = BitConverter.GetBytes(ivme_y != 0 ? ivme_y : 0f);
            veriler[62] = ivmey[0];
            veriler[63] = ivmey[1];
            veriler[64] = ivmey[2];
            veriler[65] = ivmey[3];

            byte[] ivmez = BitConverter.GetBytes(ivme_z != 0 ? ivme_z : 0f);
            veriler[66] = ivmez[0];
            veriler[67] = ivmez[1];
            veriler[68] = ivmez[2];
            veriler[69] = ivmez[3];

            byte[] acib = BitConverter.GetBytes(aci != 0 ? aci : 0f);
            veriler[70] = acib[0];
            veriler[71] = acib[1];
            veriler[72] = acib[2];
            veriler[73] = acib[3];

            veriler[74] = Convert.ToByte(parasut); 

            for (int i = 4; i < 75; i++)
            {
                check_sum += veriler[i];
            }
            check_sum %= 256;
            veriler[75] = (byte)check_sum;
            crc.Text = Convert.ToString(check_sum);

            veriler[76] = 0x0D;
            veriler[77] = 0x0A;
            try
            {
                if (gonder3 & gonder2 & gonder1)
                {
                    serialPort4.Write(veriler, 0, 78);
                    sayac++;
                    sayac %= 256;
                    label27.Text = sayac.ToString();
                    label42.Text = takım_id.ToString();
                    gonder1 = false;
                    gonder2=false;
                }

            }
            catch (Exception ex)
            {
                
            }




        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (Form2 form2 = new Form2())
            {
                serialPort3.Close();
                button2.Enabled = true;
                button1.Enabled = false;
                label4.Text = "Baglantı Kapalı";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort3.PortName = label5.Text;
                serialPort3.BaudRate = 9600;
                serialPort3.Open();
                button2.Enabled = false;
                button1.Enabled = true;
                label4.Text = "Baglantı Kuruldu";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Hata");

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = label7.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                label2.Text = "Baglantı Kuruldu";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Hata");
            }
            button3.Enabled = false;
            button4.Enabled = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort2.PortName = label12.Text;
                serialPort2.BaudRate = 9600;
                serialPort2.Open();
                button5.Enabled = false;
                button6.Enabled = true;
                label22.Text = "Baglantı Kuruldu";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Hata");

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            button3.Enabled = true;
            button4.Enabled = false;
            label2.Text = "Baglantı Kapalı";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            serialPort2.Close();
            button5.Enabled = true;
            button6.Enabled = false;
            label22.Text = "Baglantı Kapalı";
        }
        private void baslat_Click(object sender, EventArgs e)
        {

            try
            {
                serialPort4.PortName = label43.Text;
                serialPort4.BaudRate = int.Parse(label44.Text);
                serialPort4.Open();//Seri portu aç
                label42.Text = Convert.ToString(takım_id);
                label26.Text = "Bağlantı Kuruldu";
                durdur.Enabled = true;                  //Durdurma butonunu aktif hale getir
                baslat.Enabled = false;                 //Başlatma butonunu pasif hale getir
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata");    //Hata mesajı göster
            }
        }
        private void durdur_Click(object sender, EventArgs e)
        {
            serialPort4.Close();        //Seri Portu kapa
            durdur.Enabled = false;     //Durdurma butonunu pasif hale getir
            baslat.Enabled = true;      //Başlatma butonunu aktif hale getir
            label26.Text = "Bağlantı Kapatıldı";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
            label7.Text = "";
            label12.Text = "";
            label5.Text = "";
            label43.Text = "";
            label2.Text = "";
            label22.Text = "";
            label4.Text = "";
            label26.Text = "";
            label8.Text = Convert.ToString(9600);
            label13.Text = Convert.ToString(9600);
            label6.Text = Convert.ToString(9600);
            label44.Text = "";


            serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort1_DataReceived);
            serialPort2.DataReceived += new SerialDataReceivedEventHandler(SerialPort2_DataReceived);
            serialPort3.DataReceived += new SerialDataReceivedEventHandler(SerialPort3_DataReceived);

        }
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                lora1 = serialPort1.ReadLine();
                aviyonik = lora1.Split(';');
            }
            catch
            {

            }


            if (aviyonik.Length >= 12)
            {
                try
                {
                    irtifa = float.Parse(aviyonik[0], CultureInfo.InvariantCulture.NumberFormat);

                    ivme_x = float.Parse(aviyonik[1], CultureInfo.InvariantCulture.NumberFormat);
                    ivme_y = float.Parse(aviyonik[2], CultureInfo.InvariantCulture.NumberFormat);
                    ivme_z = float.Parse(aviyonik[3], CultureInfo.InvariantCulture.NumberFormat);
                    jiroskop_x = float.Parse(aviyonik[4], CultureInfo.InvariantCulture.NumberFormat);
                    jiroskop_y = float.Parse(aviyonik[5], CultureInfo.InvariantCulture.NumberFormat);
                    jiroskop_z = float.Parse(aviyonik[6], CultureInfo.InvariantCulture.NumberFormat);

                    roket_enlem = float.Parse(aviyonik[7], CultureInfo.InvariantCulture.NumberFormat);
                    roket_boylam_irtifa = float.Parse(aviyonik[8], CultureInfo.InvariantCulture.NumberFormat);

                    gpsirtifa = float.Parse(aviyonik[9], CultureInfo.InvariantCulture.NumberFormat);


                    parasut = Convert.ToInt32(aviyonik[10]);
                    label17.Text = Convert.ToString(parasut);

                    aci = float.Parse(aviyonik[11], CultureInfo.InvariantCulture.NumberFormat);

                    irtifa1.Text = Convert.ToString(irtifa);
                    label40.Text = Convert.ToString(gpsirtifa);

                    roket1.Text = Convert.ToString(roket_enlem);
                    roket2.Text = Convert.ToString(roket_boylam_irtifa);

                    jiiroskopx.Text = Convert.ToString(jiroskop_x);
                    jiiroskopy.Text = Convert.ToString(jiroskop_y);
                    jiiroskopz.Text = Convert.ToString(jiroskop_z);

                    iavmex.Text = Convert.ToString(ivme_x);
                    iavmey.Text = Convert.ToString(ivme_y);
                    iavmez.Text = Convert.ToString(ivme_z);
                    acı.Text = Convert.ToString(aci);
                    gonder1 = true;
                    Veri_Olustur();

                }
                catch (Exception ex)
                {
                 
                }

                if (parasut == 2)
                    button10.BackColor = Color.Green;
                else if (parasut == 3)
                    button11.BackColor = Color.Green;
                else if (parasut == 4)
                {
                    button10.BackColor = Color.Green;
                    button11.BackColor = Color.Green;
                }
                else
                {
                    button10.BackColor = Color.Red;
                    button11.BackColor = Color.Red;
                }
            }

        }
        private void SerialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                lora2 = serialPort2.ReadLine();
                gorev = lora2.Split(';');
            }
            catch
            {


            }

            if (gorev.Length >= 3)
            {
                try
                {
                    gorev_yuku_gps_irtifa = float.Parse(gorev[0], CultureInfo.InvariantCulture.NumberFormat);
                    gorev_yuku_enlem = float.Parse(gorev[1], CultureInfo.InvariantCulture.NumberFormat);
                    gorev_yuku_boylam_irtifa = float.Parse(gorev[2], CultureInfo.InvariantCulture.NumberFormat);

                    görev1.Text = Convert.ToString(gorev_yuku_gps_irtifa);
                    görev2.Text = Convert.ToString(gorev_yuku_enlem);
                    görev3.Text = Convert.ToString(gorev_yuku_boylam_irtifa);
                    gonder2 = true;
                    Veri_Olustur();
                }

                catch (Exception ex)
                {
                 

                }
            }

        }
        private void SerialPort3_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                lora3 = serialPort3.ReadLine();
                yedek = lora3.Split(';');
            }
            catch
            {
            }

            try
            {
                if (yedek.Length > 3)
                {
                    yedek1.Text = yedek[0];
                    yedek2.Text = yedek[1];
                    yedek3.Text = yedek[2];
                }


            }
            catch (Exception ex)
            {
               
            }

        }
        private void button7_Click(object sender, EventArgs e)
        {
            using (Form2 form2 = new Form2())
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    if (form2.anaport != null)
                        label7.Text = form2.anaport;
                    if (form2.gorevport != null)
                        label12.Text = form2.gorevport;
                    if (form2.yedekport != null)
                        label5.Text = form2.yedekport;
                    try
                    {
                        takım_id = Convert.ToByte(form2.ta);
                    }
                    catch
                    {
                        MessageBox.Show("Sayı 256 dan büyük olamaz");
                    }

                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            adres = "https://www.google.com/maps/place/" + roket_enlem + "," + roket_boylam_irtifa;
            webBrowser1.Navigate(adres.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (Form3 form3 = new Form3())
            {
                if (form3.ShowDialog() == DialogResult.OK)
                {
                    label43.Text = form3.ver;
                    label44.Text = Convert.ToString(form3.baud);

                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                Veri_Olustur();
                serialPort4.Write(veriler, 0, veriler.Length);
                sayac++;
                sayac %= 256;
                label27.Text = sayac.ToString();
                label42.Text = takım_id.ToString();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata");

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            gonder3 = true;
            button13.Enabled = false;
            button14.Enabled = true;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            gonder3 = false;

            button13.Enabled = true;

            button14.Enabled = false;

        }

    }
}

