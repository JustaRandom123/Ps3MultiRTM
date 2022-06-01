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
using MetroFramework;



namespace RTM_Tool
{

  
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        public static uint hostID;
        public static string hostName;
        public static Form2 mainForm;
        public static bool loadedStats = false;
        public static System.Timers.Timer tt = new System.Timers.Timer(5000);
        public static Thread t;
        public static Thread nameChangerThread;



        public Form2()
        {
            InitializeComponent();
            mainForm = this;
        }

        private void Form2_Load(object sender, EventArgs e)
        {          
            metroLabel7.Text = Form1.PS3.Extension.ReadString(0x02000934);
            hostName = metroLabel7.Text;
            hostID = Convert.ToUInt32(bo1Classes.GetHost());
            metroLabel2.Text = "Host number: " + hostID.ToString();
            RPC.Enable_RPC();        
            t = new Thread(new ThreadStart(startTimer));
            t.Start(); 
        }

        //private void clientsAndPlayers_Click(object sender, EventArgs e)
        //{

        //}

        //private void unlockTrophies_Click(object sender, EventArgs e)
        //{
        //    Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.INFO, "Unlocking Trophies...");
        //    bo1Classes.TrophyUnlocks_MP(hostID);
        //    Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.INFO, "Unlocking Trophies successfully done!");
        //}


        private void startTimer()
        {
            while (true)
            {
                try
                {                  
                    metroLabel2.Text = "Host number: " + bo1Classes.GetHost().ToString();
                    hostID = Convert.ToUInt32(bo1Classes.GetHost());
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                  //  Console.WriteLin
                }
            }
        }


        bool recoilEnabled = false;
        bool wallhackEnabled = false;
        bool uavEnabled = false;   
        bool supersteadyaimEnabled = false;

     

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (recoilEnabled)
            {           
                Form1.PS3.SetMemory(0x19B244, new byte[] { 0x4B, 0xF1, 0x84, 0xCD });
                recoilEnabled = false;
                metroButton2.BackColor = Color.Transparent;
            }
            else
            {
                Form1.PS3.SetMemory(0x19B244, new byte[] { 0x60, 0x00, 0x00, 0x00 });
                recoilEnabled = true;
                metroButton2.BackColor = Color.Green;
            }             
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (wallhackEnabled)
            {
                Form1.PS3.SetMemory(0x131144, new byte[] { 0xFC, 0xC0, 0xF8, 0x90 });
                wallhackEnabled = false;
                metroButton3.BackColor = Color.Transparent;
            }
            else
            {
                Form1.PS3.SetMemory(0x131144, new byte[] { 0x38, 0xC0, 0xF0, 0x03 });
                wallhackEnabled = true;
                metroButton3.BackColor = Color.Green;
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (uavEnabled)
            {
            
                Form1.PS3.SetMemory(0x00EBDF4, new byte[] { 0x41, 0x9A, 0x00, 0xC4 });
                uavEnabled = false;
                metroButton4.BackColor = Color.Transparent;
            }
            else
            {
                Form1.PS3.SetMemory(0x00EBDF4, new byte[] { 0x40, 0x9A, 0x00, 0xC4 });
                uavEnabled = true;
                metroButton4.BackColor = Color.Green;
            }
        }


      

        private void metroButton6_Click(object sender, EventArgs e)
        {
            if (supersteadyaimEnabled)
            {
                Form1.PS3.SetMemory(0xAB8EC, new byte[] { 0x2F, 0x80, 0x00, 0x02 });
                supersteadyaimEnabled = false;
                metroButton6.BackColor = Color.Transparent;
            }
            else
            {
                Form1.PS3.SetMemory(0xAB8EC, new byte[] { 0x60, 0x00, 0x00, 0x00 });
                supersteadyaimEnabled = true;
                metroButton6.BackColor = Color.Green;
            }
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "RTM Tool by JustaRandom disconnected!");
            Form1.PS3.DisconnectTarget();
            Form1.CCAPI.DisconnectTarget();         
            t.Abort();
            this.Hide();           
            Form1 frm1 = new Form1();
            frm1.Show();
        }


        bool redboxEnabled = false;

        private void metroButton5_Click(object sender, EventArgs e)
        {
            if (redboxEnabled)
            {
                Form1.PS3.SetMemory(0x001205C0, new byte[] { 0x41, 0x86, 0x02, 0x78 });
                redboxEnabled = false;
                metroButton5.BackColor = Color.Transparent;
            }
            else
            {
                Form1.PS3.SetMemory(0x001205C0, new byte[] { 0x60, 0x00, 0x00, 0x00 });
                redboxEnabled = true;
                metroButton5.BackColor = Color.Green;
            }
        }


        bool superSlightOfHandEnabled = false;
        private void metroButton8_Click(object sender, EventArgs e)
        {
            if (superSlightOfHandEnabled)
            {
                Form1.PS3.SetMemory(0xBBC2E8, new byte[] { 0x01 });
                superSlightOfHandEnabled = false;
                metroButton8.BackColor = Color.Transparent;
            }
            else
            {
                Form1.PS3.SetMemory(0xBBC2E8, new byte[] { 0x02 });
                superSlightOfHandEnabled = true;
                metroButton8.BackColor = Color.Green;
            }
        }

 

     
        private void metroButton10_Click(object sender, EventArgs e)
        {
            bo1Classes.giveLevel(hostID);
        }


     

        private void metroButton11_Click(object sender, EventArgs e)
        {
            bo1Classes.givePrestige(hostID, metroTextBox2.Text);        
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            bo1Classes.giveMoney(hostID);            
        }


        bool rapidFireEnabled = false;

        private void metroButton13_Click(object sender, EventArgs e)
        {
            if (rapidFireEnabled)
            {
                Form1.PS3.SetMemory(0xBBC2EC, new byte[] { 0x01 });
                rapidFireEnabled = false;
                metroButton27.BackColor = Color.Transparent;
            }
            else
            {
                Form1.PS3.SetMemory(0xBBC2EC, new byte[] { 0x02 });
                rapidFireEnabled = true;
                metroButton27.BackColor = Color.Green;               
            }
        }

     

        private void metroButton14_Click(object sender, EventArgs e)
        {
            bo1Classes.Godmode(Convert.ToUInt32(hostID));
            Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.INFO, "Godmode activated for yourself");
        }

      
     


        bool chromePlayerEnabled = false;
        private void metroButton16_Click(object sender, EventArgs e)
        {
            if (chromePlayerEnabled)
            {
                Form1.PS3.SetMemory(0x131144, new byte[] { 0xFC, 0xC0, 0xF8, 0x90 });
                chromePlayerEnabled = false;
                metroButton16.BackColor = Color.Transparent;
            }
            else
            {
                Form1.PS3.SetMemory(0x131144, new byte[] { 0x38, 0xC0, 0xFF, 0xFF });
                chromePlayerEnabled = true;
                metroButton16.BackColor = Color.Green;
            }
        }

        private void metroButton17_Click(object sender, EventArgs e)
        {
            for (uint i = 0; i < 18; i++)
            {
               // if (i != hostID)
              //  {
                    Form1.PS3.SetMemory((0x20946dd + (i * 0x2A38)), new byte[] { 0x0F });
               // }                             
            }
        }

    

        private void metroButton18_Click(object sender, EventArgs e)
        {
            for (uint i = 0; i < 18; i++)
            {           
                    Form1.PS3.SetMemory((0x20942d1 + (i * 0x2A38)), new byte[] { 0xFF, 0xFF, 0xFF, 0x7F });
            }
        }


        //Form1.PS3.Extension.WriteString(9554016u, newName);  //schreibt oben auf den screen

        string[] colors = { "^1", "^4", "^2", "^0" };

        bool randomColorTimer = false;

        private void metroButton19_Click(object sender, EventArgs e)  //change name
        {
            string newName = metroTextBox1.Text;      

            if (metroRadioButton4.Checked)  //rot
            {
                Form1.PS3.Extension.WriteString(0x02000934, "^1" + newName);

                for (uint i = 0; i < 18; i++)
                {
                    Form1.PS3.Extension.WriteString((0x139784C + (i * 0x2A38)), "^1" + newName); //ingame name
                }                     
            }
            else if (metroRadioButton8.Checked)  //flashing text
            {
                Form1.PS3.Extension.WriteString(0x02000934, "^F" + newName);
                for (uint i = 0; i < 18; i++)
                {
                    Form1.PS3.Extension.WriteString((0x139784C + (i * 0x2A38)), "^F" + newName); //ingame name
                }
            }
            else if (metroRadioButton5.Checked)  //blau
            {
                Form1.PS3.Extension.WriteString(0x02000934, "^4" + newName);
                for (uint i = 0; i < 18; i++)
                {
                    Form1.PS3.Extension.WriteString((0x139784C + (i * 0x2A38)), "^4" + newName); //ingame name
                }
            }
            else if (metroRadioButton6.Checked) //grün
            {
                Form1.PS3.Extension.WriteString(0x02000934, "^2" + newName);
                for (uint i = 0; i < 18; i++)
                {
                    Form1.PS3.Extension.WriteString((0x139784C + (i * 0x2A38)), "^2" + newName); //ingame name
                }
            }
            else if (metroRadioButton7.Checked) //schwarz
            {
                Form1.PS3.Extension.WriteString(0x02000934, "^0" + newName);
                for (uint i = 0; i < 18; i++)
                {
                    Form1.PS3.Extension.WriteString((0x139784C + (i * 0x2A38)), "^0" + newName); //ingame name
                }
            }  
            else
            {
                Form1.PS3.Extension.WriteString(0x02000934, newName);
                for (uint i = 0; i < 18; i++)
                {
                    Form1.PS3.Extension.WriteString((0x139784C + (i * 0x2A38)), newName); //ingame name
                }
            }
        }

        private readonly Random _random = new Random();
        
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

     


        private void metroButton21_Click(object sender, EventArgs e)
        {
           
            Console.WriteLine("clicked");
        }

       

        private void metroButton22_Click(object sender, EventArgs e)  //refreh playerlist
        {
            bo1Classes.getIngameNames();             
        }








        /// <summary>
        /// Menu Drop down logic
        /// </summary>

        string selectedPlayerIDFromList = "";

        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var rows = metroGrid2.SelectedRows;
            foreach (DataGridViewRow selection in rows)
            {
                selectedPlayerIDFromList = selection.Cells[1].Value.ToString();
                Console.WriteLine("You selected " + selection.Cells[0].Value + ".");

                MenuItem[] menuItems = new MenuItem[]{
                     new MenuItem("Godmode"),
                     new MenuItem("Max Money"),
                     new MenuItem("Unlimited Ammo"),
                     new MenuItem("Unlock all"),
                     new MenuItem("Unlock Trophies"),
                     new MenuItem("Max Prestige"),
                     new MenuItem("Max Level"),
                     new MenuItem("Check Played Games"),
                     new MenuItem("Give Aimbot")
                };

                ContextMenu buttonMenu = new ContextMenu(menuItems);
                buttonMenu.Show(metroGrid2, new System.Drawing.Point(20, 20));

                foreach (MenuItem mItem in menuItems)
                {
                    mItem.Click += clickedMenuItem;
                }
            }
        }


        private void clickedMenuItem(object sender, EventArgs e)
        {
            MenuItem clickedItem = sender as MenuItem;
            Console.WriteLine(clickedItem.Text + " / pID: " + selectedPlayerIDFromList);

            if (clickedItem.Text == "Godmode")
            {
                bo1Classes.Godmode(Convert.ToUInt32(selectedPlayerIDFromList));
            }
            else if (clickedItem.Text == "Unlimited Ammo")
            {
                bo1Classes.unlimitedAmmo(Convert.ToUInt32(selectedPlayerIDFromList));
            }
            else if (clickedItem.Text == "Max Money")
            {
                bo1Classes.giveMoney(Convert.ToUInt32(selectedPlayerIDFromList));
            }
            else if (clickedItem.Text == "Max Prestige")
            {
                bo1Classes.givePrestige(Convert.ToUInt32(selectedPlayerIDFromList), "15");
            }
            else if (clickedItem.Text == "Max Level")
            {
                bo1Classes.giveLevel(Convert.ToUInt32(selectedPlayerIDFromList));
            }
            else if (clickedItem.Text == "Unlock all")
            {
                bo1Classes.giveUnlockAll(Convert.ToUInt32(selectedPlayerIDFromList));
            }
            else if (clickedItem.Text == "Unlock Trophies")
            {
                bo1Classes.TrophyUnlocks_MP(Convert.ToUInt32(selectedPlayerIDFromList));
            }

            else if (clickedItem.Text == "Give Aimbot")
            {
                Aimbot.StartAimbot(Convert.ToInt32(selectedPlayerIDFromList));              
            }


            else if (clickedItem.Text == "Check Played Games")
            {
                byte playedGames = Form1.PS3.Extension.ReadByte(0x209475d);
                Console.WriteLine("Played games: " + playedGames.ToString());
            }

            selectedPlayerIDFromList = "";
        }


        /// <summary>
        /// END
        /// </summary>
    




        private void metroButton23_Click(object sender, EventArgs e) //max money for all
        {
            for (uint i = 0; i < 18; i++)
            {
                Form1.PS3.SetMemory((0x20942d1 + (i * 10808)), new byte[] { 0xFF, 0xFF, 0xFF, 0x7F });              
            }
        }

        private void metroButton24_Click(object sender, EventArgs e)  //max prestige for all
        {
            for (uint i = 0; i < 18; i++)
            {
                //    Form1.PS3.SetMemory((0x20946dd + (i * 0x2a38)), new byte[] { 0x0F });           

                 Form1.PS3.SetMemory(20543739 + i * 10808, new byte[1]
                 {
                      15
                 });

                Form1.PS3.SetMemory(20543735 + i * 10808, new byte[1]
                {
                         49
                });


            }
        }

        private void metroButton25_Click(object sender, EventArgs e) //unlimited ammo for host
        {
            bo1Classes.unlimitedAmmo(hostID);
        }



        bool noclipEnabled = false;
        private void metroButton21_Click_1(object sender, EventArgs e)  //noclip
        {
            if (noclipEnabled)
            {
                Form1.PS3.SetMemory((0x13979BF + (hostID * 0x2a38)), new byte[] { 0x00 });
                noclipEnabled = false;
                metroButton21.BackColor = Color.Transparent;
                Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.INFO, "No Clip deactivated!");
            }
            else
            {
                Form1.PS3.SetMemory((0x13979BF + (hostID * 0x2a38)), new byte[] { 0x01 });
                noclipEnabled = true;
                metroButton21.BackColor = Color.Green;
                Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.INFO, "No Clip activated!");
            }
        }



        private void metroButton26_Click(object sender, EventArgs e) //godmode for host
        {
            bo1Classes.Godmode(hostID);
        }

        private void metroButton28_Click(object sender, EventArgs e) //unlock all
        {
            bo1Classes.giveUnlockAll(hostID);      
        }

        private void metroButton29_Click(object sender, EventArgs e)  //unlock trophies
        {
            Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.INFO, "Unlocking Trophies...");
            bo1Classes.TrophyUnlocks_MP(hostID);
            Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.INFO, "Unlocking Trophies successfully done!");
        }








        /// <summary>
        /// Speed logic that dosent work for now maybe wrong offset
        /// </summary>
   
        private void metroRadioButton12_CheckedChanged(object sender, EventArgs e)
        {
            for (uint i = 0; i < 18; i++)
            {
                Form1.PS3.SetMemory((0x1397880 + (i * 0x2a38)), new byte[] { 0x3F, 0x80 });
            }
        }

        private void metroRadioButton11_CheckedChanged(object sender, EventArgs e)
        {
            for (uint i = 0; i < 18; i++)
            {
                Form1.PS3.SetMemory((0x1397880 + (i * 0x2a38)), new byte[] { 0x00, 0x00 });
            }      
        }

        private void metroRadioButton10_CheckedChanged(object sender, EventArgs e)
        {          
            for (uint i = 0; i < 18; i++)
            {             
                Form1.PS3.SetMemory((0x1397880 + (i * 0x2a38)), new byte[] { 0x40, 0x40 });
            }
        }




        //load stats
        private void metroButton1_Click(object sender, EventArgs e)
        {
            bo1Classes.loadStats(hostID);
        }





        /// <summary>
        /// save new stats
        /// </summary>
       
        private void metroButton9_Click(object sender, EventArgs e)
        {
            if (loadedStats)
            {
                DataGridViewRowCollection theRows = metroGrid1.Rows;
                foreach (DataGridViewRow row in theRows)
                {
                    string rowname = row.Cells[0].Value.ToString();
                    string value = row.Cells[1].Value.ToString();

                    if (rowname == "Wins")
                    {
                        byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(value.ToString()));
                        Form1.PS3.SetMemory(0x209475d, bytes);
                    }
                    else if (rowname == "Loss")
                    {
                        byte[] array = BitConverter.GetBytes(Convert.ToInt32(value.ToString()));
                        Form1.PS3.SetMemory(0x20944dd, array);
                    }
                    else if (rowname == "Played Games")
                    {
                        byte[] array = BitConverter.GetBytes(Convert.ToInt32(value.ToString()));
                        Form1.PS3.SetMemory(0x20938b1, array);
                    }
                    else if (rowname == "Purchased Contract")
                    {
                        byte[] array = BitConverter.GetBytes(Convert.ToInt32(value.ToString()));
                        Form1.PS3.SetMemory(0x20942e1, array);

                    }
                    else if (rowname == "Paid Contract")
                    {                     
                        byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(value.ToString()));
                        Form1.PS3.SetMemory(0x20942d5, bytes);

                    }
                    else if (rowname == "Lifetime earning")
                    {
                        byte[] array = BitConverter.GetBytes(Convert.ToInt32(value.ToString()));
                        Form1.PS3.SetMemory(0x20942f1, array);

                    }
                    else if (rowname == "Deaths")
                    {
                        byte[] array = BitConverter.GetBytes(Convert.ToInt32(value.ToString()));
                        Form1.PS3.SetMemory(0x20942f5, array);

                    }
                    else if (rowname == "Money")
                    {
                        byte[] array = BitConverter.GetBytes(Convert.ToInt32(value.ToString()));
                        Form1.PS3.SetMemory(0x20942d1, array);

                    }
                    else if (rowname == "Assists")
                    {
                        byte[] array = BitConverter.GetBytes(Convert.ToInt32(value.ToString()));
                        Form1.PS3.SetMemory(0x2094291, array);

                    }
                    else if (rowname == "Headshots")
                    {
                        byte[] array = BitConverter.GetBytes(Convert.ToInt32(value.ToString()));
                        Form1.PS3.SetMemory(0x209440d, array);

                    }
                }
            }
        }


        private void nameChangerTick()
        {
            while (true)
            {
                int randomColorInt = RandomNumber(0, 3);
                Form1.PS3.Extension.WriteString(0x02000934, colors[randomColorInt] + metroTextBox1.Text);  //lobby name            
                Form1.PS3.Extension.WriteString(0x139784C + (hostID * 0x2A38), colors[randomColorInt] + metroTextBox1.Text); //ingame name
            }
        }
    


    private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool state = metroCheckBox1.Checked;
            //hier
            if (state)
            {
                nameChangerThread = new Thread(new ThreadStart(nameChangerTick));
                nameChangerThread.Start();
            }
            else
            {
                nameChangerThread.Abort();
            }

            metroRadioButton4.Checked = false;
            metroRadioButton5.Checked = false;
            metroRadioButton6.Checked = false;
            metroRadioButton7.Checked = false;
            metroRadioButton8.Checked = false;

        }

        private void metroButton13_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Hostname: " + Form1.PS3.Extension.ReadString(0x37703450));        
        }

      

        private void metroButton15_Click(object sender, EventArgs e)
        {

        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Not working in this version!");
            //if (metroCheckBox2.Checked)
            //{
            //    // Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Super force host activated!");
            //    //  RPC.cBuf_AddText((int)hostID, "ds_serverConnectTimeout 1000");
            //    //  RPC.cBuf_AddText((int)hostID, "ds_serverConnectTimeout 1");
            //    //  RPC.cBuf_AddText((int)hostID, "party_minplayers 1");
            //    //  RPC.cBuf_AddText((int)hostID, "party_maxplayers 12");

            //  //    RPC.cBuf_AddText((int)hostID, bo1Classes.forceHostCommand);
            //    //timer3.Enabled = true;
            //    //timer3.Start();
            //}
            //else
            //{
            //   // Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Super force host disabled!");
            //   // timer3.Enabled = false;
            //   // timer3.Stop();
            //   // timer3.Dispose();
            //}
        }



        private void timer3_Tick(object sender, EventArgs e)
        {
            //RPC.cBuf_AddText((int)hostID, bo1Classes.forceHostCommand);

            //RPC.cBuf_AddText((int)hostID, "ds_serverConnectTimeout 1000");
            //RPC.cBuf_AddText((int)hostID, "ds_serverConnectTimeout 1");
            //RPC.cBuf_AddText((int)hostID, "party_minplayers 1");
            //RPC.cBuf_AddText((int)hostID, "party_maxplayers 12");
        }

        private void metroButton14_Click_1(object sender, EventArgs e)
        {
            bo1Classes.setGodModeClass(0);
        }

      

        private void metroButton17_Click_1(object sender, EventArgs e)
        {
            bo1Classes.setGodModeClass(1);
        }

        private void metroButton18_Click_1(object sender, EventArgs e)
        {
            bo1Classes.setGodModeClass(2);
        }

        private void metroButton20_Click(object sender, EventArgs e)
        {
            bo1Classes.setGodModeClass(3);
        }

        private void metroButton30_Click(object sender, EventArgs e)
        {
            bo1Classes.setGodModeClass(4);
        }

        private void metroButton31_Click(object sender, EventArgs e)
        {
            bo1Classes.setGodModeClass(5);
        }

        private void metroButton32_Click(object sender, EventArgs e)
        {
            bo1Classes.setGodModeClass(6);
        }

        private void metroButton33_Click(object sender, EventArgs e)
        {
            bo1Classes.setGodModeClass(7);
        }

        private void metroButton34_Click(object sender, EventArgs e)
        {
            bo1Classes.setGodModeClass(8);
        }

        private void metroButton35_Click(object sender, EventArgs e)
        {
            bo1Classes.setGodModeClass(9);
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton36_Click(object sender, EventArgs e)
        {
            string text = metroTextBox4.Text;
            for (uint i = 0; i < 18; i++)
            {
                RPC.iPrintlnBold((int)i, text);
            }        
        }


        private static byte[] SendServer(string text)
        {
            ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
            return aSCIIEncoding.GetBytes(text);
        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Not working in this version!");
          //  Form1.smethod((int)numFov.Value, fovON.Text);
        }

        private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            Form1.PS3.SetMemory(20543739 + hostID * 10808, new byte[1]
            {
                     14
            });

            Form1.PS3.SetMemory(20543735 + hostID * 10808, new byte[1]
            {
                     49
            });
        }


   

        private void metroButton37_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not working in this version!");
            //RPC.iPrintlnBold((int)Form2.hostID, "^1W^7elcome! ^1P^7ress [{+melee}] + [{+speed_throw}] ^1T^7o ^1O^7pen");       
            //Buttons.CurrentMenu[hostID] = "Main";

            //while (true)
            //{                             
            //    Buttons.ButtonsMonitoring((int)hostID);              
            //}
        }

        private void metroButton38_Click(object sender, EventArgs e)
        {
            bo1Classes.TrophyUnlocks_MP(hostID);
        }

        /////////////
        ///
        //
        //  0x1397893 //invisible 0x00 0x01
    }
}
