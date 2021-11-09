using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Robotik_Kol___2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var ports = SerialPort.GetPortNames();
            combobox_comport.DataSource = ports;
            serialPort1.PortName = combobox_comport.SelectedItem.ToString();
            serialPort1.BaudRate = 9600;
        }

        private void btn_baglan_Click(object sender, EventArgs e)
        {
            timer1.Start();

            timer2.Start();

            try
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.Open();
                    btn_baglantidurumu.Visible = true;
                    btn_baglantidurumu.BackColor = Color.Green;
                    btn_baglantidurumu.Text = "BAĞLANDI";

                    bar_s1.Value = 90;
                    bar_s2.Value = 90;
                    bar_s3.Value = 90;
                    bar_s4.Value = 90;
                    bar_s5.Value = 90;
                    bar_s6.Value = 90;
                    bar_s7.Value = 90;
                }
            }
            catch (Exception exception)
            {
                btn_baglantidurumu.BackColor = Color.Red;
                btn_baglantidurumu.Text = "BAĞLANTI YOK";
                MessageBox.Show("BAĞLANTI GERÇEKLEŞTİRİLEMEDİ");
                //throw;
            }
        }

        private void btn_baglantikes_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            serialPort1.Close();
            btn_baglantidurumu.BackColor = Color.Red;
            btn_baglantidurumu.Text = "BAĞLANTI KESİLDİ";
            MessageBox.Show("BAĞLANTI SONLANDIRILDI");
        }

        private void btn_yenile_Click(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            combobox_comport.DataSource = ports;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*
            try
            {
                string result = serialPort1.ReadExisting();

                string[] value = result.Split('/');

                //string veri = "5/10/15/20/25/30/1/2/3/4";

                //string[] value = veri.Split('/'); 

                bar_s1.Value = Convert.ToInt32(value[0]);
                bar_s2.Value = Convert.ToInt32(value[1]);
                bar_s3.Value = Convert.ToInt32(value[2]);
                bar_s4.Value = Convert.ToInt32(value[3]);
                bar_s5.Value = Convert.ToInt32(value[4]);
                bar_s6.Value = Convert.ToInt32(value[5]);

                lbl_aci1.Text = value[0].ToString();
                lbl_aci2.Text = value[1].ToString();
                lbl_aci3.Text = value[2].ToString();
                lbl_aci4.Text = value[3].ToString();
                lbl_aci5.Text = value[4].ToString();
                lbl_aci6.Text = value[5].ToString();

                string organized_result = "Aci - 1 : " + value[0].ToString() + "Aci - 2 : " + value[1].ToString() +
                                          "Aci - 3 : " + value[2].ToString() +
                                          "Aci - 4 : " + value[3].ToString() + "Aci - 5 : " + value[4].ToString() +
                                          "Aci - 6 : " + value[5].ToString() +
                                          "Basinc - 1 : " + value[6].ToString() + "Basinc - 2 : " +
                                          value[7].ToString() + "Basinc - 3 : " + value[8].ToString() +
                                          "Basinc - 4 : " + value[9].ToString();

                listbox_veri.Items.Add(result);
                listbox_veri.SelectedIndex = listbox_veri.Items.Count - 1;
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
                //timer1.Stop();
            }*/
        }

        private void btn_kontrolubaslat_KeyDown(object sender, KeyEventArgs e)
        {
            btn_kontrolubaslat.BackColor = Color.Green;

            if (e.KeyCode == Keys.W)
            {
                btn_s1_sol.PerformClick();
            }
            else if (e.KeyCode == Keys.A)
            {
                btn_s1_sag.PerformClick();
            }
            else if(e.KeyCode == Keys.E)
            {
                btn_s2_sol.PerformClick();
            }
            else if (e.KeyCode == Keys.S)
            {
                btn_s2_sag.PerformClick();
            }
            else if (e.KeyCode == Keys.R)
            {
                btn_s3_sol.PerformClick();
            }
            else if (e.KeyCode == Keys.D)
            {
                btn_s3_sag.PerformClick();
            }
            else if (e.KeyCode == Keys.T)
            {
                btn_s4_sol.PerformClick();
            }
            else if (e.KeyCode == Keys.F)
            {
                btn_s4_sag.PerformClick();
            }
            else if (e.KeyCode == Keys.Y)
            {
                btn_s5_sol.PerformClick();
            }
            else if (e.KeyCode == Keys.G)
            {
                btn_s5_sag.PerformClick();
            }
            else if (e.KeyCode == Keys.U)
            {
                btn_s6_sol.PerformClick();
            }
            else if (e.KeyCode == Keys.H)
            {
                btn_s6_sag.PerformClick();
            }
            else if (e.KeyCode == Keys.I)
            {
                btn_s7_sol.PerformClick();
            }
            else if (e.KeyCode == Keys.J)
            {
                btn_s7_sag.PerformClick();
            }
        }

        private void btn_s1_sol_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("w");
            change_color(btn_s1_sol);
        }

        private void btn_s1_sag_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("a");
            change_color(btn_s1_sag);
        }

        private void btn_s2_sol_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("e");
            change_color(btn_s2_sol);
        }

        private void btn_s2_sag_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("s");
            change_color(btn_s2_sag);
        }

        private void btn_s3_sol_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("r");
            change_color(btn_s3_sol);
        }

        private void btn_s3_sag_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("d");
            change_color(btn_s3_sag);
        }

        private void btn_s4_sol_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("t");
            change_color(btn_s4_sol);
        }

        private void btn_s4_sag_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("f");
            change_color(btn_s4_sag);
        }

        private void btn_s5_sol_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("y");
            change_color(btn_s5_sol);
        }

        private void btn_s5_sag_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("g");
            change_color(btn_s5_sag);
        }

        private void btn_s6_sol_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("u");
            change_color(btn_s6_sol);
        }

        private void btn_s6_sag_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("h");
            change_color(btn_s6_sag);
        }
  
        private void btn_s7_sol_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("ı");
            change_color(btn_s7_sol);
        }

        private void btn_s7_sag_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("j");
            change_color(btn_s7_sag);
        }

        private void change_color(Button x)
        {
            x.BackColor = Color.Green;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            btn_s1_sol.BackColor = default(Color);
            btn_s1_sag.BackColor = default(Color);
            btn_s2_sol.BackColor = default(Color);
            btn_s2_sag.BackColor = default(Color);
            btn_s3_sol.BackColor = default(Color);
            btn_s3_sag.BackColor = default(Color);
            btn_s4_sol.BackColor = default(Color);
            btn_s4_sag.BackColor = default(Color);
            btn_s5_sol.BackColor = default(Color);
            btn_s5_sag.BackColor = default(Color);
            btn_s6_sol.BackColor = default(Color);
            btn_s6_sag.BackColor = default(Color);
            btn_s7_sol.BackColor = default(Color);
            btn_s7_sag.BackColor = default(Color);
        }

        private void btn_motor_yenile_Click(object sender, EventArgs e)
        {
            bar_s1.Value = 90;
            bar_s2.Value = 90;
            bar_s3.Value = 90;
            bar_s4.Value = 90;
            bar_s5.Value = 90;
            bar_s6.Value = 90;
            bar_s7.Value = 90;
        }
    }
}
