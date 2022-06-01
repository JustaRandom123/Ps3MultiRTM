using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PS3Lib;
using RTM_Tool;

namespace RTM_Tool
{
    public partial class bf3Form : MetroFramework.Forms.MetroForm
    {
        public bf3Form()
        {
            InitializeComponent();
        }

        private void bf3Form_Load(object sender, EventArgs e)
        {

        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "RTM Tool by JustaRandom disconnected!");
            Form1.PS3.DisconnectTarget();
            Form1.CCAPI.DisconnectTarget();           
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void metroCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox8.Checked)
            {
                Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "1 Hit kill on");
                Form1.PS3.SetMemory(4325220u, new byte[] { 0x60, 0xA0, 0x63, 0x80 });
              
            }
            else
            {
                Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "1 Hit kill off");
                Form1.PS3.SetMemory(4325220u, new byte[] { 0x60, 0xA0, 0x68, 0x7A });
            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked)
            {
                Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Wallhack on");
                Form1.PS3.Extension.WriteBytes(4458436u, new byte[] { 0x7C, 0x08, 0x02, 0xA6 });

            }
            else
            {
                Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Wallhack off");
                Form1.PS3.Extension.WriteBytes(4458436u, new byte[] { 0x78, 0x80, 0x00, 0x32 });
            }
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked)
            {
                Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "UAV on");
                Form1.PS3.SetMemory(1626204u, new byte[] { 0x56, 0x96, 0x00, 0x00 });
            }
            else
            {
                Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "UAV off");
                Form1.PS3.SetMemory(1626204u, new byte[] { 0x56, 0x96, 0x00, 0x01 });
            }
        }

        private void metroCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox7.Checked)
            {
                Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "No Recoil on");
                Form1.PS3.SetMemory(8997476u, new byte[] { 63, 128, 0, 0 });
            }
            else
            {
                Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "No Recoil off");
                Form1.PS3.SetMemory(8997476u, new byte[] { 60, 0, 0, 0});
            }
        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox3.Checked)
            {
                Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Vehicle Wallhack on");
                Form1.PS3.SetMemory(5094400u, new byte[] { 44,3,0,0 });
            }
            else
            {
                Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Vehicle Wallhack off");
                Form1.PS3.SetMemory(5094400u, new byte[] { 44, 3, 0, 1 });
            }
        }

        private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox4.Checked)
            {
                Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Sniper Breath on");
                Form1.PS3.SetMemory(4788080u, new byte[] { 65, 130, 0, 28 });
            }
            else
            {
                Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Sniper Breath off");
                Form1.PS3.SetMemory(4788080u, new byte[] { 64, 130, 0, 28 });
            }
        }

        private void metroCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox5.Checked)
            {
                Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "3 Hits kill on");
                Form1.PS3.SetMemory(4325220u, new byte[] { 60, 160, 63, 128 });
            }
            else
            {
                Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "3 Hits kill off");
                Form1.PS3.SetMemory(4325220u, new byte[] { 60, 160, 66, 160 });
            }
        }

        private void metroCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox6.Checked)
            {
                Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Nametags on");
                Form1.PS3.SetMemory(1653200u, new byte[] { 64, 130, 22, 156 });
            }
            else
            {
                Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Nametags off");
                Form1.PS3.SetMemory(1653200u, new byte[] { 96, 0, 0, 0 });
            }
        }
    }
}
