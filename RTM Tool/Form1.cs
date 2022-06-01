using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using PS3Lib;

namespace RTM_Tool
{
    public partial class Form1 : MetroFramework.Forms.MetroForm 
    {
        bool connected = false;
        public static PS3API PS3 = new PS3API();
        public static CCAPI CCAPI = new CCAPI();
        public static WebClient wclient = new WebClient();
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string version = wclient.DownloadString("http://jonas.thd1.de/RTM%20Tool/version.ini");
            //if (Form1..Default.version != version)
            //{
            //    MessageBox.Show("New RTM tool update available! [" + version + "]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    Application.Exit();
            //    Process.Start(Application.StartupPath + "\\rtmUpdater.exe");
            //}
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false)
            {
                MessageBox.Show("You have to select CCAPI first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            try
            {
                if (PS3.ConnectTarget())
                {
                    connectButton.Enabled = false;
                    connected = true;                   
                    MessageBox.Show("Connected to ps3 via CCAPI!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Check Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Check Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void attachButton_Click(object sender, EventArgs e)
        {
            if (connected == false)
            {
                MessageBox.Show("Press Connect first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (PS3.AttachProcess())
                {
                    PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "RTM Tool by JustaRandom attached!");
                    metroLabel1.Text = "Welcome " + PS3.Extension.ReadString(0x02000934);
                    attachButton.Enabled = false;
                    CCAPI.RingBuzzer(CCAPI.BuzzerMode.Double);
                    RPC.Enable_RPC();
                    // MessageBox.Show("Attached!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);                  
                    this.Hide();
                    Form2 frmMain = new Form2();
                    frmMain.Show();                   
                }
                else
                {
                    MessageBox.Show("Check Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Check Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {          
            PS3.ChangeAPI(SelectAPI.ControlConsole);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frmMain = new Form2();
            frmMain.Show();
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            if (connected == false)
            {
                MessageBox.Show("Press Connect first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (PS3.AttachProcess())
                {
                    PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "RTM Tool by JustaRandom attached!");            
                    attachButton.Enabled = false;
                    CCAPI.RingBuzzer(CCAPI.BuzzerMode.Double);                  
                    this.Hide();
                    bf3Form frmMain = new bf3Form();
                    frmMain.Show();
                }
                else
                {
                    MessageBox.Show("Check Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Check Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == false)
            {
                MessageBox.Show("You have to select CCAPI first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            try
            {
                if (PS3.ConnectTarget())
                {
                    connectButton.Enabled = false;
                    connected = true;
                    MessageBox.Show("Connected to ps3 via CCAPI!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Check Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Check Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.ControlConsole);
        }
    }


    public static class RPC
        {
            public static UInt32 function_address = 0x7A21E0; //MP = 0x7A21E0  ||  ZM = 0x6E34E0

            public static void Enable_RPC()
            {
                Form1.PS3.SetMemory(function_address, new byte[] { 0x4e, 0x80, 0, 0x20 });
                System.Threading.Thread.Sleep(20);
                byte[] memory = new byte[] {
            0x7c, 8, 2, 0xa6, 0xf8, 1, 0, 0x80, 60, 0x60, 0x10, 5, 0x81, 0x83, 0, 0x4c,
            0x2c, 12, 0, 0, 0x41, 130, 0, 100, 0x80, 0x83, 0, 4, 0x80, 0xa3, 0, 8,
            0x80, 0xc3, 0, 12, 0x80, 0xe3, 0, 0x10, 0x81, 3, 0, 20, 0x81, 0x23, 0, 0x18,
            0x81, 0x43, 0, 0x1c, 0x81, 0x63, 0, 0x20, 0xc0, 0x23, 0, 0x24, 0xc0, 0x43, 0, 40,
            0xc0, 0x63, 0, 0x2c, 0xc0, 0x83, 0, 0x30, 0xc0, 0xa3, 0, 0x34, 0xc0, 0xc3, 0, 0x38,
            0xc0, 0xe3, 0, 60, 0xc1, 3, 0, 0x40, 0xc1, 0x23, 0, 0x48, 0x80, 0x63, 0, 0,
            0x7d, 0x89, 3, 0xa6, 0x4e, 0x80, 4, 0x21, 60, 0x80, 0x10, 5, 0x38, 160, 0, 0,
            0x90, 0xa4, 0, 0x4c, 0x90, 100, 0, 80, 0xe8, 1, 0, 0x80, 0x7c, 8, 3, 0xa6,
            0x38, 0x21, 0, 0x70, 0x4e, 0x80, 0, 0x20
         };
                Form1.PS3.SetMemory(function_address + 4, memory);
                Form1.PS3.SetMemory(0x10050000, new byte[0x2854]);
                Form1.PS3.SetMemory(function_address, new byte[] { 0xf8, 0x21, 0xff, 0x91 });
            }

            public static uint Call(uint func_address, params object[] parameters)
            {
                int length = parameters.Length;
                uint num2 = 0;
                for (uint i = 0; i < length; i++)
                {
                    if (parameters[i] is int)
                    {
                        byte[] array = BitConverter.GetBytes((int)parameters[i]);
                        Array.Reverse(array);
                        Form1.PS3.SetMemory(0x10050000 + ((i + num2) * 4), array);
                    }
                    else if (parameters[i] is uint)
                    {
                        byte[] buffer2 = BitConverter.GetBytes((uint)parameters[i]);
                        Array.Reverse(buffer2);
                        Form1.PS3.SetMemory(0x10050000 + ((i + num2) * 4), buffer2);
                    }
                    else if (parameters[i] is string)
                    {
                        byte[] buffer3 = Encoding.UTF8.GetBytes(Convert.ToString(parameters[i]) + "\0");
                        Form1.PS3.SetMemory(0x10050054 + (i * 0x400), buffer3);
                        uint num4 = 0x10050054 + (i * 0x400);
                        byte[] buffer4 = BitConverter.GetBytes(num4);
                        Array.Reverse(buffer4);
                        Form1.PS3.SetMemory(0x10050000 + ((i + num2) * 4), buffer4);
                    }
                    else if (parameters[i] is float)
                    {
                        num2++;
                        byte[] buffer5 = BitConverter.GetBytes((float)parameters[i]);
                        Array.Reverse(buffer5);
                        Form1.PS3.SetMemory(0x10050024 + ((num2 - 1) * 4), buffer5);
                    }
                }
                byte[] bytes = BitConverter.GetBytes(func_address);
                Array.Reverse(bytes);
                Form1.PS3.SetMemory(0x1005004c, bytes);
                System.Threading.Thread.Sleep(20);
                byte[] memory = new byte[4];
                Form1.PS3.GetMemory(0x10050050, memory);
                Array.Reverse(memory);
                return BitConverter.ToUInt32(memory, 0);
            }

            public static void SV_GameSendServerCommad(Int32 client, Int32 Type, String command)
            {
                RPC.Call(0x003E95F0, new Object[] { client, Type, command }); //MP = 0x003E95F0  ||  ZM = 0x003C33A8
            }

            public static void iPrintln(Int32 ClientNum, String Message)
            {
                SV_GameSendServerCommad(ClientNum, 0, "f \"" + Message + "\"");
            }

            public static void iPrintlnBold(Int32 ClientNum, String Message)
            {
                SV_GameSendServerCommad(ClientNum, 0, "c \"" + Message + "\"");
            }
        }
        public class Funcs
        {
            public static byte[] ReverseBytes(byte[] inArray)
            {
                Array.Reverse(inArray);
                return inArray;
            }
            public static void WriteSingle(uint address, float[] input)
            {
                int length = input.Length;
                byte[] array = new byte[length * 4];
                for (int i = 0; i < length; i++)
                {
                    ReverseBytes(BitConverter.GetBytes(input[i])).CopyTo(array, (int)(i * 4));
                }
                Form1.PS3.SetMemory(address, array);
            }
            public static void WriteSingle(uint address, float input)
            {
                byte[] numArray = new byte[4];
                BitConverter.GetBytes(input).CopyTo(numArray, 0);
                Array.Reverse(numArray, 0, 4);
                Form1.PS3.SetMemory(address, numArray);
            }
            public static float[] ReadSingle(uint address, int length)
            {
                byte[] memory = Form1.PS3.Extension.ReadBytes(address, length * 4);
                ReverseBytes(memory);
                float[] numArray = new float[length];
                for (int inPS3 = 0; inPS3 < length; ++inPS3)
                    numArray[inPS3] = BitConverter.ToSingle(memory, (length - 1 - inPS3) * 4);
                return numArray;
            }
            public static float ReadSingle(uint address)
            {
                byte[] memory = Form1.PS3.Extension.ReadBytes(address, 4);
                Array.Reverse(memory, 0, 4);
                return BitConverter.ToSingle(memory, 0);
            }
        }
        public class Huds
        {
            public class HElems
            {
                public static uint
                    x = 0x0,
                    y = 0x4,
                    z = 0x8,
                    fontScale = 0xC,
                    color = 0x10,
                    sort = 0x38,
                    glowColor = 0x3C,
                    targetEntNum = 0x70,
                    label = 0x48,
                    width = 0x4A,
                    height = 0x4C,
                    text = 0x56,
                    type = 0x64,
                    font = 0x65,
                    materialIndex = 0x68,
                    ui3dWindow = 0x6D;
            }
            public static short G_LocalizedStringIndex(string Text)
            {
                return (short)RPC.Call(0x00370638, Text);
            }
            public static UInt32 SetShader(uint Element, Int32 clientIndex, SByte Material, Int16 Width, Int16 Height, Single X, Single Y, Byte R = 255, Byte G = 255, Byte B = 255, Byte A = 255, float Sort = 0)
            {
                Form1.PS3.Extension.WriteSByte(Element + HElems.type, 8);
                Form1.PS3.Extension.WriteInt16(Element + HElems.width, Width);
                Form1.PS3.Extension.WriteInt16(Element + HElems.height, Height);
                Form1.PS3.Extension.WriteFloat(Element + HElems.x, X);
                Form1.PS3.Extension.WriteFloat(Element + HElems.y, Y);
                Form1.PS3.Extension.WriteFloat(Element + HElems.sort, Sort);
                Form1.PS3.Extension.WriteInt32(Element + HElems.targetEntNum, clientIndex);
                Form1.PS3.Extension.WriteSByte(Element + HElems.materialIndex, Material);
                Form1.PS3.Extension.WriteBytes(Element + HElems.color, new Byte[] { R, G, B, A });
                Form1.PS3.Extension.WriteBytes(Element + HElems.ui3dWindow, new Byte[] { 0xFF });
                return Element;
            }
            public static UInt32 SetText(uint Element, Int32 clientIndex, String Text, Single X, Single Y, Single FontScale, Byte Font, float Sort = 0, Byte R = 255, Byte G = 255, Byte B = 255, Byte A = 255, Byte GlowR = 0, Byte GlowG = 0, Byte GlowB = 0, Byte GlowA = 0)
            {
                Form1.PS3.Extension.WriteSByte(Element + HElems.type, 1);
                Form1.PS3.Extension.WriteInt32(Element + HElems.targetEntNum, clientIndex);
                Form1.PS3.Extension.WriteInt16(Element + HElems.text, G_LocalizedStringIndex(Text));
                Form1.PS3.Extension.WriteFloat(Element + HElems.x, X);
                Form1.PS3.Extension.WriteFloat(Element + HElems.y, Y);
                Form1.PS3.Extension.WriteFloat(Element + HElems.sort, Sort);
                Form1.PS3.Extension.WriteFloat(Element + HElems.fontScale, FontScale);
                Form1.PS3.Extension.WriteBytes(Element + HElems.font, new Byte[] { Font });
                Form1.PS3.Extension.WriteBytes(Element + HElems.color, new Byte[] { R, G, B, A });
                Form1.PS3.Extension.WriteBytes(Element + HElems.glowColor, new Byte[] { GlowR, GlowG, GlowB, GlowA });
                Form1.PS3.Extension.WriteBytes(Element + HElems.ui3dWindow, new Byte[] { 0xFF });
                return Element;
            }

            public static byte[] GetMemory(uint address, int length)
            {
                byte[] buffer = new byte[length];
                Form1.PS3.GetMemory(address, buffer);
                return buffer;
            }

            public static UInt32 HudElem_Alloc()
            {
                for (Int32 i = 0; i < 1024; i++)
                {
                    UInt32 address = (0x11F26D4 + ((UInt32)i * 0x7C));
                    Byte[] Buffer = GetMemory(address, 4);
                    if (Buffer[0] == 0x00)
                    {
                        Form1.PS3.SetMemory(address + HElems.type, new Byte[0x7C]);
                        return address;
                    }
                }
                return 0;
            }
            public static void ChangeAlpha(uint elem, byte A)
            {
                Form1.PS3.Extension.WriteBytes(elem + HElems.color + 3, new Byte[] { A });
            }
            public static void ChangeText(uint elem, string Text)
            {
                Form1.PS3.Extension.WriteInt16(elem + HElems.text, G_LocalizedStringIndex(Text));
            }
            public static void DestroyElement(UInt32 Element)
            {
                Form1.PS3.Extension.WriteBytes(Element, new Byte[0x7C]);
            }
            public static void ChangeY(uint elem, float Y)
            {
                Form1.PS3.Extension.WriteFloat(elem + HElems.y, Y);
            }
        }

        public static class Buttons
        {
            public static UInt32
            X = 2104320,
            O = 512,
            Square = 67108864,
            Triangle = 8,
            L3 = 1074003968,
            R3 = 536870912,
            L2 = 72704,
            R2 = 131072,
            L1 = 1048704,
            R1 = 2147483648,
            Crouch = 4194304,
            Prone = 8388608,
            StartButton = 4;



            public static Boolean ButtonPressed(Int32 clientIndex, UInt32 Button)
            {
                if (Form1.PS3.Extension.ReadUInt32((UInt32)G_Client(clientIndex) + 0x2718) == Button)
                    return true;
                else return false;
            }
            public static Int32 G_Client(Int32 clientIndex)
            {
                return (Int32)0x13950C8 + 0x2A38 * clientIndex;
            }
            public static UInt32 ReadUInt32(uint offset)
            {
                Byte[] YoLo = GetMemory(offset, 4);
                Array.Reverse(YoLo, 0, 4);
                return BitConverter.ToUInt32(YoLo, 0);
            }
            public static byte[] GetMemory(uint address, int length)
            {
                byte[] buffer = new byte[length];
                Form1.PS3.GetMemory(address, buffer);
                return buffer;
            }
            public static string GetPlayerNameForMenu(Int32 clientIndex)
            {
                String Name = Form1.PS3.Extension.ReadString(0x139784C + ((uint)clientIndex * 0x2A38));
                if (Name == "")
                    return "Not Connected";
                else
                    return Name;
            }
            public static string GetNames(int client)
            {
                return Form1.PS3.Extension.ReadString(0x139784C + ((uint)client * 0x2A38));
            }
            public static int GetHost()
            {
                int str = 0;
                string host = Form1.PS3.Extension.ReadString(0x02000934);
                if (host == "")
                {
                    str = 0;
                }
                else
                {
                    for (int i = 0; i < 18; i++)
                    {
                        if (host == GetNames(i))
                        {
                            str = i;
                        }
                    }
                }
                return str;
            }


        public static int[] client_id = new int[18];
        public static bool[] MenuIsDrawed = new bool[18];
        public static bool[] MenuIsAllowed = new bool[18];
        public static string[] CurrentMenu = new string[18];
        public static int[] Scroll = new int[18];
        public static uint[] Shader_Middle = new uint[18];
        public static uint[] Shader_Left = new uint[18];
        public static uint[] Shader_Right = new uint[18];
        public  static uint[] Menu_Title = new uint[18];
        public static uint[] Menu_Text = new uint[18];
        public static uint[] Menu_Scrollbar = new uint[18];
        public static uint[] Menu_Seperator = new uint[18];



            public static void DrawMenu(int client)
            {
                if (MenuIsDrawed[client] == false)
                {
                    Shader_Middle[client] = Huds.HudElem_Alloc();
                    Huds.SetShader(Shader_Middle[client], client, 6, 250, 470, 200, 10);
                    Shader_Left[client] = Huds.HudElem_Alloc();
                    Huds.SetShader(Shader_Left[client], client, 5, 5, 470, 200, 10, 255, 0, 0, 150);
                    Shader_Right[client] = Huds.HudElem_Alloc();
                    Huds.SetShader(Shader_Right[client], client, 5, 5, 470, 448, 10, 255, 0, 0, 150);
                    Menu_Title[client] = Huds.HudElem_Alloc();
                    Huds.SetText(Menu_Title[client], client, "Main Menu", 250, 50, 3, 5);
                    Menu_Text[client] = Huds.HudElem_Alloc();
                    Huds.SetText(Menu_Text[client], client, "Submenu 1\nSubmenu 2\nSubmenu 3\nSubmenu 4\nSubmenu 5\nSubmenu 6\nSubmenu 7\nSubmenu 8\nSubmenu 9\nPlayers Menu", 270, 100, 2, 4);
                    Menu_Scrollbar[client] = Huds.HudElem_Alloc();
                    Huds.SetShader(Menu_Scrollbar[client], client, 5, 250, 20, 200, 102, 255, 0, 0, 150);
                    Menu_Seperator[client] = Huds.HudElem_Alloc();
                    Huds.SetShader(Menu_Seperator[client], client, 5, 250, 5, 200, 90, 255, 0, 0, 150);
                    MenuIsDrawed[client] = true;
                }
                else
                {
                    Huds.ChangeAlpha(Shader_Middle[client], 255);
                    Huds.ChangeAlpha(Shader_Left[client], 150);
                    Huds.ChangeAlpha(Shader_Right[client], 150);
                    Huds.ChangeAlpha(Menu_Text[client], 255);
                    Huds.ChangeAlpha(Menu_Title[client], 255);
                    Huds.ChangeAlpha(Menu_Scrollbar[client], 150);
                    Huds.ChangeAlpha(Menu_Seperator[client], 150);
                }
            }


            public static void LoadMenu(int client)
            {
                if (CurrentMenu[client] == "Main")
                {
                    Huds.ChangeText(Menu_Title[client], "Main Menu");
                    Huds.ChangeText(Menu_Text[client], "Submenu 1\nSubmenu 2\nSubmenu 3\nSubmenu 4\nSubmenu 5\nSubmenu 6\nSubmenu 7\nSubmenu 8\nSubmenu 9\nPlayers Menu");
                }
                if (CurrentMenu[client] == "Sub1")
                {
                    Huds.ChangeText(Menu_Title[client], "Submenu 1");
                    Huds.ChangeText(Menu_Text[client], "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8\nOption 9\nOption 10");
                }
                if (CurrentMenu[client] == "Sub2")
                {
                    Huds.ChangeText(Menu_Title[client], "Submenu 2");
                    Huds.ChangeText(Menu_Text[client], "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8\nOption 9\nOption 10");
                }
                if (CurrentMenu[client] == "Sub3")
                {
                    Huds.ChangeText(Menu_Title[client], "Submenu 3");
                    Huds.ChangeText(Menu_Text[client], "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8\nOption 9\nOption 10");
                }
                if (CurrentMenu[client] == "Sub4")
                {
                    Huds.ChangeText(Menu_Title[client], "Submenu 4");
                    Huds.ChangeText(Menu_Text[client], "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8\nOption 9\nOption 10");
                }
                if (CurrentMenu[client] == "Sub5")
                {
                    Huds.ChangeText(Menu_Title[client], "Submenu 5");
                    Huds.ChangeText(Menu_Text[client], "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8\nOption 9\nOption 10");
                }
                if (CurrentMenu[client] == "Sub6")
                {
                    Huds.ChangeText(Menu_Title[client], "Submenu 6");
                    Huds.ChangeText(Menu_Text[client], "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8\nOption 9\nOption 10");
                }
                if (CurrentMenu[client] == "Sub7")
                {
                    Huds.ChangeText(Menu_Title[client], "Submenu 7");
                    Huds.ChangeText(Menu_Text[client], "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8\nOption 9\nOption 10");
                }
                if (CurrentMenu[client] == "Sub8")
                {
                    Huds.ChangeText(Menu_Title[client], "Submenu 8");
                    Huds.ChangeText(Menu_Text[client], "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8\nOption 9\nOption 10");
                }
                if (CurrentMenu[client] == "Sub9")
                {
                    Huds.ChangeText(Menu_Title[client], "Submenu 9");
                    Huds.ChangeText(Menu_Text[client], "Option 1\nOption 2\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8\nOption 9\nOption 10");
                }
                if (CurrentMenu[client] == "Sub10")
                {
                    Huds.ChangeText(Menu_Title[client], "Players Menu");
                    Huds.ChangeText(Menu_Text[client], GetPlayerNameForMenu(0) + "\n" + GetPlayerNameForMenu(1) + "\n" + GetPlayerNameForMenu(2) + "\n" + GetPlayerNameForMenu(3) + "\n" + GetPlayerNameForMenu(4) + "\n" + GetPlayerNameForMenu(5) + "\n" + GetPlayerNameForMenu(6) + "\n" + GetPlayerNameForMenu(7) + "\n" + GetPlayerNameForMenu(8) + "\nPage 2");
                }
                if (CurrentMenu[client] == "Sub11")
                {
                    Huds.ChangeText(Menu_Title[client], "Players Menu");
                    Huds.ChangeText(Menu_Text[client], GetPlayerNameForMenu(9) + "\n" + GetPlayerNameForMenu(10) + "\n" + GetPlayerNameForMenu(11) + "\n" + GetPlayerNameForMenu(12) + "\n" + GetPlayerNameForMenu(13) + "\n" + GetPlayerNameForMenu(14) + "\n" + GetPlayerNameForMenu(15) + "\n" + GetPlayerNameForMenu(16) + "\n" + GetPlayerNameForMenu(17) + "\nPage 1");
                }
                if (CurrentMenu[client] == "Options")
                {
                    Huds.ChangeText(Menu_Title[client], GetPlayerNameForMenu(client_id[client]));
                    Huds.ChangeText(Menu_Text[client], "Verify\nRemove Access\nOption 3\nOption 4\nOption 5\nOption 6\nOption 7\nOption 8\nOption 9\nOption 10");
                }
            }


             public static  void HideMenu(int client)
             {
                Huds.ChangeAlpha(Shader_Middle[client], 0);
                Huds.ChangeAlpha(Shader_Left[client], 0);
                Huds.ChangeAlpha(Shader_Right[client], 0);
                Huds.ChangeAlpha(Menu_Text[client], 0);
                Huds.ChangeAlpha(Menu_Title[client], 0);
                Huds.ChangeAlpha(Menu_Scrollbar[client], 0);
                Huds.ChangeAlpha(Menu_Seperator[client], 0);
             }



            public static void Scrollbar(int client)
            {
                if (Scroll[client] == 1)
                {
                    Huds.ChangeY(Menu_Scrollbar[client], 102);
                }
                if (Scroll[client] == 2)
                {
                    Huds.ChangeY(Menu_Scrollbar[client], 126);
                }
                if (Scroll[client] == 3)
                {
                    Huds.ChangeY(Menu_Scrollbar[client], 151);
                }
                if (Scroll[client] == 4)
                {
                    Huds.ChangeY(Menu_Scrollbar[client], 174);
                }
                if (Scroll[client] == 5)
                {
                    Huds.ChangeY(Menu_Scrollbar[client], 198);
                }
                if (Scroll[client] == 6)
                {
                    Huds.ChangeY(Menu_Scrollbar[client], 222);
                }
                if (Scroll[client] == 7)
                {
                    Huds.ChangeY(Menu_Scrollbar[client], 246);
                }
                if (Scroll[client] == 8)
                {
                    Huds.ChangeY(Menu_Scrollbar[client], 271);
                }
                if (Scroll[client] == 9)
                {
                    Huds.ChangeY(Menu_Scrollbar[client], 294);
                }
                if (Scroll[client] == 10)
                {
                    Huds.ChangeY(Menu_Scrollbar[client], 318);
                }
            }
            public static void TestFunction(int client)
            {
                RPC.iPrintln(client, "Option " + Scroll[client]);
            }




            public static void SelectOption(int client) // Add mods here
            {
                if (CurrentMenu[client] == "Sub1")
                {
                    if (Scroll[client] == 1)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 2)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 3)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 4)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 5)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 6)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 7)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 8)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 9)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 10)
                    {
                        TestFunction(client);
                    }
                }
                if (CurrentMenu[client] == "Sub2")
                {
                    if (Scroll[client] == 1)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 2)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 3)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 4)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 5)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 6)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 7)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 8)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 9)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 10)
                    {
                        TestFunction(client);
                    }
                }
                if (CurrentMenu[client] == "Sub3")
                {
                    if (Scroll[client] == 1)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 2)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 3)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 4)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 5)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 6)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 7)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 8)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 9)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 10)
                    {
                        TestFunction(client);
                    }
                }
                if (CurrentMenu[client] == "Sub4")
                {
                    if (Scroll[client] == 1)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 2)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 3)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 4)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 5)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 6)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 7)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 8)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 9)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 10)
                    {
                        TestFunction(client);
                    }
                }
                if (CurrentMenu[client] == "Sub5")
                {
                    if (Scroll[client] == 1)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 2)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 3)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 4)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 5)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 6)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 7)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 8)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 9)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 10)
                    {
                        TestFunction(client);
                    }
                }
                if (CurrentMenu[client] == "Sub6")
                {
                    if (Scroll[client] == 1)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 2)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 3)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 4)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 5)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 6)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 7)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 8)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 9)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 10)
                    {
                        TestFunction(client);
                    }
                }
                if (CurrentMenu[client] == "Sub7")
                {
                    if (Scroll[client] == 1)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 2)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 3)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 4)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 5)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 6)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 7)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 8)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 9)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 10)
                    {
                        TestFunction(client);
                    }
                }
                if (CurrentMenu[client] == "Sub8")
                {
                    if (Scroll[client] == 1)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 2)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 3)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 4)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 5)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 6)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 7)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 8)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 9)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 10)
                    {
                        TestFunction(client);
                    }
                }
                if (CurrentMenu[client] == "Sub9")
                {
                    if (Scroll[client] == 1)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 2)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 3)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 4)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 5)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 6)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 7)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 8)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 9)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 10)
                    {
                        TestFunction(client);
                    }
                }
                if (CurrentMenu[client] == "Sub10")
                {
                    if (Scroll[client] == 1)
                    {
                        client_id[client] = 0;
                    }
                    if (Scroll[client] == 2)
                    {
                        client_id[client] = 1;
                    }
                    if (Scroll[client] == 3)
                    {
                        client_id[client] = 2;
                    }
                    if (Scroll[client] == 4)
                    {
                        client_id[client] = 3;
                    }
                    if (Scroll[client] == 5)
                    {
                        client_id[client] = 4;
                    }
                    if (Scroll[client] == 6)
                    {
                        client_id[client] = 5;
                    }
                    if (Scroll[client] == 7)
                    {
                        client_id[client] = 6;
                    }
                    if (Scroll[client] == 8)
                    {
                        client_id[client] = 7;
                    }
                    if (Scroll[client] == 9)
                    {
                        client_id[client] = 8;
                    }
                    CurrentMenu[client] = "Options";
                    LoadMenu(client);
                }
                if (CurrentMenu[client] == "Sub11")
                {
                    if (Scroll[client] == 1)
                    {
                        client_id[client] = 9;
                    }
                    if (Scroll[client] == 2)
                    {
                        client_id[client] = 10;
                    }
                    if (Scroll[client] == 3)
                    {
                        client_id[client] = 11;
                    }
                    if (Scroll[client] == 4)
                    {
                        client_id[client] = 12;
                    }
                    if (Scroll[client] == 5)
                    {
                        client_id[client] = 13;
                    }
                    if (Scroll[client] == 6)
                    {
                        client_id[client] = 14;
                    }
                    if (Scroll[client] == 7)
                    {
                        client_id[client] = 15;
                    }
                    if (Scroll[client] == 8)
                    {
                        client_id[client] = 16;
                    }
                    if (Scroll[client] == 9)
                    {
                        client_id[client] = 17;
                    }
                    CurrentMenu[client] = "Options";
                    LoadMenu(client);
                }
                if (CurrentMenu[client] == "Options")
                {
                    if (Scroll[client] == 1)
                    {
                        if (client_id[client] == 0)
                        {
                            RPC.iPrintln(0, "You have been ^2Verified");
                            RPC.iPrintlnBold(0, "^1P^7ress [{+speed_throw}] + [{+melee}] ^1T^7o ^1O^7pen ^1M^7enu!");
                          //  timer1.Start();
                        }
                        if (client_id[client] == 1)
                        {
                            RPC.iPrintln(1, "You have been ^2Verified");
                            RPC.iPrintlnBold(1, "^1P^7ress [{+speed_throw}] + [{+melee}] ^1T^7o ^1O^7pen ^1M^7enu!");
                          //  timer2.Start();
                        }
                        if (client_id[client] == 2)
                        {
                            RPC.iPrintln(2, "You have been ^2Verified");
                            RPC.iPrintlnBold(2, "^1P^7ress [{+speed_throw}] + [{+melee}] ^1T^7o ^1O^7pen ^1M^7enu!");
                          // timer3.Start();
                        }
                        if (client_id[client] == 3)
                        {
                            RPC.iPrintln(3, "You have been ^2Verified");
                            RPC.iPrintlnBold(3, "^1P^7ress [{+speed_throw}] + [{+melee}] ^1T^7o ^1O^7pen ^1M^7enu!");
                          //  timer4.Start();
                        }
                        if (client_id[client] == 4)
                        {
                            RPC.iPrintln(4, "You have been ^2Verified");
                            RPC.iPrintlnBold(4, "^1P^7ress [{+speed_throw}] + [{+melee}] ^1T^7o ^1O^7pen ^1M^7enu!");
                        //    timer5.Start();
                        }
                        if (client_id[client] == 5)
                        {
                            RPC.iPrintln(5, "You have been ^2Verified");
                            RPC.iPrintlnBold(5, "^1P^7ress [{+speed_throw}] + [{+melee}] ^1T^7o ^1O^7pen ^1M^7enu!");
                          //  timer6.Start();
                        }
                        if (client_id[client] == 6)
                        {
                            RPC.iPrintln(6, "You have been ^2Verified");
                            RPC.iPrintlnBold(6, "^1P^7ress [{+speed_throw}] + [{+melee}] ^1T^7o ^1O^7pen ^1M^7enu!");
                          //  timer7.Start();
                        }
                        if (client_id[client] == 7)
                        {
                            RPC.iPrintln(7, "You have been ^2Verified");
                            RPC.iPrintlnBold(7, "^1P^7ress [{+speed_throw}] + [{+melee}] ^1T^7o ^1O^7pen ^1M^7enu!");
                          //  timer8.Start();
                        }
                        if (client_id[client] == 8)
                        {
                            RPC.iPrintln(8, "You have been ^2Verified");
                            RPC.iPrintlnBold(8, "^1P^7ress [{+speed_throw}] + [{+melee}] ^1T^7o ^1O^7pen ^1M^7enu!");
                          //  timer9.Start();
                        }
                        if (client_id[client] == 9)
                        {
                            RPC.iPrintln(9, "You have been ^2Verified");
                            RPC.iPrintlnBold(9, "^1P^7ress [{+speed_throw}] + [{+melee}] ^1T^7o ^1O^7pen ^1M^7enu!");
                          //  timer10.Start();
                        }
                        if (client_id[client] == 10)
                        {
                            RPC.iPrintln(10, "You have been ^2Verified");
                            RPC.iPrintlnBold(10, "^1P^7ress [{+speed_throw}] + [{+melee}] ^1T^7o ^1O^7pen ^1M^7enu!");
                         //   timer11.Start();
                        }
                        if (client_id[client] == 11)
                        {
                            RPC.iPrintln(11, "You have been ^2Verified");
                            RPC.iPrintlnBold(11, "^1P^7ress [{+speed_throw}] + [{+melee}] ^1T^7o ^1O^7pen ^1M^7enu!");
                          //  timer12.Start();
                        }
                        if (client_id[client] == 12)
                        {
                            RPC.iPrintln(12, "You have been ^2Verified");
                            RPC.iPrintlnBold(12, "^1P^7ress [{+speed_throw}] + [{+melee}] ^1T^7o ^1O^7pen ^1M^7enu!");
                        //    timer13.Start();
                        }
                        if (client_id[client] == 13)
                        {
                            RPC.iPrintln(13, "You have been ^2Verified");
                            RPC.iPrintlnBold(13, "^1P^7ress [{+speed_throw}] + [{+melee}] ^1T^7o ^1O^7pen ^1M^7enu!");
                         //   timer14.Start();
                        }
                        if (client_id[client] == 14)
                        {
                            RPC.iPrintln(14, "You have been ^2Verified");
                            RPC.iPrintlnBold(14, "^1P^7ress [{+speed_throw}] + [{+melee}] ^1T^7o ^1O^7pen ^1M^7enu!");
                         //   timer15.Start();
                        }
                        if (client_id[client] == 15)
                        {
                            RPC.iPrintln(15, "You have been ^2Verified");
                            RPC.iPrintlnBold(15, "^1P^7ress [{+speed_throw}] + [{+melee}] ^1T^7o ^1O^7pen ^1M^7enu!");
                         //   timer16.Start();
                        }
                        if (client_id[client] == 16)
                        {
                            RPC.iPrintln(16, "You have been ^2Verified");
                            RPC.iPrintlnBold(16, "^1P^7ress [{+speed_throw}] + [{+melee}] ^1T^7o ^1O^7pen ^1M^7enu!");
                         //   timer17.Start();
                        }
                        if (client_id[client] == 17)
                        {
                            RPC.iPrintln(16, "You have been ^2Verified");
                            RPC.iPrintlnBold(16, "^1P^7ress [{+speed_throw}] + [{+melee}] ^1T^7o ^1O^7pen ^1M^7enu!");
                         //   timer18.Start();
                        }
                    }
                    if (Scroll[client] == 2)
                    {
                        if (client_id[client] == 0)
                        {
                            RPC.iPrintln(0, "Your access has been ^1Removed");
                           // timer1.Stop();
                            HideMenu(0);
                        }
                        if (client_id[client] == 1)
                        {
                            RPC.iPrintln(1, "Your access has been ^1Removed");
                           // timer2.Stop();
                            HideMenu(1);
                        }
                        if (client_id[client] == 2)
                        {
                            RPC.iPrintln(2, "Your access has been ^1Removed");
                           // timer3.Stop();
                            HideMenu(2);
                        }
                        if (client_id[client] == 3)
                        {
                            RPC.iPrintln(3, "Your access has been ^1Removed");
                           // timer4.Stop();
                            HideMenu(3);
                        }
                        if (client_id[client] == 4)
                        {
                            RPC.iPrintln(4, "Your access has been ^1Removed");
                          //  timer5.Stop();
                            HideMenu(4);
                        }
                        if (client_id[client] == 5)
                        {
                            RPC.iPrintln(5, "Your access has been ^1Removed");
                           // timer6.Stop();
                            HideMenu(5);
                        }
                        if (client_id[client] == 6)
                        {
                            RPC.iPrintln(6, "Your access has been ^1Removed");
                         //   timer7.Stop();
                            HideMenu(6);
                        }
                        if (client_id[client] == 7)
                        {
                            RPC.iPrintln(7, "Your access has been ^1Removed");
                          //  timer8.Stop();
                            HideMenu(7);
                        }
                        if (client_id[client] == 8)
                        {
                            RPC.iPrintln(8, "Your access has been ^1Removed");
                         //   timer9.Stop();
                            HideMenu(8);
                        }
                        if (client_id[client] == 9)
                        {
                            RPC.iPrintln(9, "Your access has been ^1Removed");
                         //   timer10.Stop();
                            HideMenu(9);
                        }
                        if (client_id[client] == 10)
                        {
                            RPC.iPrintln(10, "Your access has been ^1Removed");
                          //  timer11.Stop();
                            HideMenu(10);
                        }
                        if (client_id[client] == 11)
                        {
                            RPC.iPrintln(11, "Your access has been ^1Removed");
                          //  timer12.Stop();
                            HideMenu(11);
                        }
                        if (client_id[client] == 12)
                        {
                            RPC.iPrintln(12, "Your access has been ^1Removed");
                         //   timer13.Stop();
                            HideMenu(12);
                        }
                        if (client_id[client] == 13)
                        {
                            RPC.iPrintln(13, "Your access has been ^1Removed");
                         //   timer14.Stop();
                            HideMenu(13);
                        }
                        if (client_id[client] == 14)
                        {
                            RPC.iPrintln(14, "Your access has been ^1Removed");
                         //   timer15.Stop();
                            HideMenu(14);
                        }
                        if (client_id[client] == 15)
                        {
                            RPC.iPrintln(15, "Your access has been ^1Removed");
                       //     timer16.Stop();
                            HideMenu(15);
                        }
                        if (client_id[client] == 16)
                        {
                            RPC.iPrintln(16, "Your access has been ^1Removed");
                         //   timer17.Stop();
                            HideMenu(16);
                        }
                        if (client_id[client] == 17)
                        {
                            RPC.iPrintln(17, "Your access has been ^1Removed");
                         //   timer18.Stop();
                            HideMenu(17);
                        }
                    }
                    if (Scroll[client] == 3)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 4)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 5)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 6)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 7)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 8)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 9)
                    {
                        TestFunction(client);
                    }
                    if (Scroll[client] == 10)
                    {
                        TestFunction(client);
                    
                    }
                }
            }



            public static void ButtonsMonitoring(int client)
            {
                if (MenuIsAllowed[client] == true)
                {
                    if (ButtonPressed(client, Buttons.R1))
                    {
                        Scroll[client]++;
                        if (Scroll[client] == 11)
                        {
                            Scroll[client] = 1;
                        }
                        Scrollbar(client);
                    }
                    if (ButtonPressed(client, Buttons.L1))
                    {
                        Scroll[client]--;
                        if (Scroll[client] == 0)
                        {
                            Scroll[client] = 10;
                        }
                        Scrollbar(client);
                    }
                    if (ButtonPressed(client, Buttons.R3))
                    {
                        if (CurrentMenu[client] == "Main")
                        {
                            MenuIsAllowed[client] = false;
                            HideMenu(client);
                        }
                        else
                        {
                            CurrentMenu[client] = "Main";
                            LoadMenu(client);
                        }
                    }
                    if (ButtonPressed(client, Buttons.Square))
                    {
                        if (CurrentMenu[client] == "Main")
                        {
                            if (Scroll[client] == 1)
                            {
                                CurrentMenu[client] = "Sub1";
                            }
                            if (Scroll[client] == 2)
                            {
                                CurrentMenu[client] = "Sub2";
                            }
                            if (Scroll[client] == 3)
                            {
                                CurrentMenu[client] = "Sub3";
                            }
                            if (Scroll[client] == 4)
                            {
                                CurrentMenu[client] = "Sub4";
                            }
                            if (Scroll[client] == 5)
                            {
                                CurrentMenu[client] = "Sub5";
                            }
                            if (Scroll[client] == 6)
                            {
                                CurrentMenu[client] = "Sub6";
                            }
                            if (Scroll[client] == 7)
                            {
                                CurrentMenu[client] = "Sub7";
                            }
                            if (Scroll[client] == 8)
                            {
                                CurrentMenu[client] = "Sub8";
                            }
                            if (Scroll[client] == 9)
                            {
                                CurrentMenu[client] = "Sub9";
                            }
                            if (Scroll[client] == 10)
                            {
                                CurrentMenu[client] = "Sub10";
                            }
                            LoadMenu(client);
                        }
                        else if (CurrentMenu[client] == "Sub10")
                        {
                            if (Scroll[client] == 1)
                            {
                                client_id[client] = 0;
                                CurrentMenu[client] = "Options";
                            }
                            if (Scroll[client] == 2)
                            {
                                client_id[client] = 1;
                                CurrentMenu[client] = "Options";
                            }
                            if (Scroll[client] == 3)
                            {
                                client_id[client] = 2;
                                CurrentMenu[client] = "Options";
                            }
                            if (Scroll[client] == 4)
                            {
                                client_id[client] = 3;
                                CurrentMenu[client] = "Options";
                            }
                            if (Scroll[client] == 5)
                            {
                                client_id[client] = 4;
                                CurrentMenu[client] = "Options";
                            }
                            if (Scroll[client] == 6)
                            {
                                client_id[client] = 5;
                                CurrentMenu[client] = "Options";
                            }
                            if (Scroll[client] == 7)
                            {
                                client_id[client] = 6;
                                CurrentMenu[client] = "Options";
                            }
                            if (Scroll[client] == 8)
                            {
                                client_id[client] = 7;
                                CurrentMenu[client] = "Options";
                            }
                            if (Scroll[client] == 9)
                            {
                                client_id[client] = 8;
                                CurrentMenu[client] = "Options";
                            }
                            if (Scroll[client] == 10)
                            {
                                CurrentMenu[client] = "Sub11";
                            }
                            LoadMenu(client);
                        }
                        else if (CurrentMenu[client] == "Sub11")
                        {
                            if (Scroll[client] == 1)
                            {
                                client_id[client] = 9;
                                CurrentMenu[client] = "Options";
                            }
                            if (Scroll[client] == 2)
                            {
                                client_id[client] = 10;
                                CurrentMenu[client] = "Options";
                            }
                            if (Scroll[client] == 3)
                            {
                                client_id[client] = 11;
                                CurrentMenu[client] = "Options";
                            }
                            if (Scroll[client] == 4)
                            {
                                client_id[client] = 12;
                                CurrentMenu[client] = "Options";
                            }
                            if (Scroll[client] == 5)
                            {
                                client_id[client] = 13;
                                CurrentMenu[client] = "Options";
                            }
                            if (Scroll[client] == 6)
                            {
                                client_id[client] = 14;
                                CurrentMenu[client] = "Options";
                            }
                            if (Scroll[client] == 7)
                            {
                                client_id[client] = 15;
                                CurrentMenu[client] = "Options";
                            }
                            if (Scroll[client] == 8)
                            {
                                client_id[client] = 16;
                                CurrentMenu[client] = "Options";
                            }
                            if (Scroll[client] == 9)
                            {
                                client_id[client] = 17;
                                CurrentMenu[client] = "Options";
                            }
                            if (Scroll[client] == 10)
                            {
                                CurrentMenu[client] = "Sub10";
                            }
                            LoadMenu(client);
                        }
                        else
                        {
                            SelectOption(client);
                        }
                    }
                }
                else
                {
                    if (ButtonPressed(client, Buttons.L1 + Buttons.R3))
                    {
                        MenuIsAllowed[client] = true;
                        DrawMenu(client);
                        CurrentMenu[client] = "Main";
                    }
                }
            }
        }

        //private void button3_Click(object sender, EventArgs e) // Start Menu
        //{
        //    //Host = GetHost();
        //    //Host_Menu.Start();
        //    //CurrentMenu[Host] = "Main";
        //    RPC.iPrintlnBold((int)Form2.hostID, "^1W^7elcome! ^1P^7ress [{+melee}] + [{+speed_throw}] ^1T^7o ^1O^7pen");
        //}
    }

