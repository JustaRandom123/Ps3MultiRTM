using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS3Lib;
using System.Threading;
using MetroFramework;

namespace RTM_Tool
{
    public class bo1Classes
    {
        public static string forceHostCommand = "set party_host 1;onlinegame 1;onlinegameandhost 1;onlineunrankedgameandhost 0;migration_msgtimeout 0;migration_timeBetween 999999;migrationPingTime 0;party_minplayers 1;party_matchedPlayerCount 0;party_connectTimeout 1000;party_connectTimeout 1";


        public static void Godmode(uint client)
        {
            Form1.PS3.SetMemory((0x12ab290 + (client * 760)) + 0x194, new byte[4]);
            Thread.Sleep(50);
            Form1.PS3.SetMemory((0x12ab290 + (client * 760)) + 0x194, new byte[] { 15, 0xff, 0xff, 0xff });
        }

        public static void unlimitedAmmo(uint i)
        {
            Form1.PS3.SetMemory((0x13950c8 + (i * 0x2A38)) + 0x388, new byte[] { 15, 0xff, 0xff, 0xff });
            Form1.PS3.SetMemory((0x13950c8 + (i * 0x2A38)) + 0x400, new byte[] { 15, 0xff, 0xff, 0xff });
            Form1.PS3.SetMemory((0x13950c8 + (i * 0x2A38)) + 0x380, new byte[] { 15, 0xff, 0xff, 0xff });
            Form1.PS3.SetMemory((0x13950c8 + (i * 0x2A38)) + 0x3f8, new byte[] { 15, 0xff, 0xff, 0xff });
            Form1.PS3.SetMemory((0x13950c8 + (i * 0x2A38)) + 0x410, new byte[] { 15, 0xff, 0xff, 0xff });
            Form1.PS3.SetMemory((0x13950c8 + (i * 0x2A38)) + 0x408, new byte[] { 15, 0xff, 0xff, 0xff });
        }

        public static Int32 G_Client(Int32 clientIndex)
        {
            return (Int32)0x13950C8 + 0x2A38 * clientIndex;
        }


        public static void getIngameNames()
        {
            Form2.mainForm.metroGrid2.Rows.Clear();

            for (uint i = 0; i < 18; i++)
            {
                string name = Form1.PS3.Extension.ReadString((0x139784C + (i * 0x2A38)));
                if (name != "")
                {
                    Form2.mainForm.metroGrid2.Rows.Add(name, i.ToString());                    
                    Console.WriteLine("name gefunden! " + name);
                }
            }
        }


        public static void giveUnlockAll(uint client)
        {
            Form1.PS3.SetMemory((0x208cfc1 + (client * 0x2A38)), new byte[] { 0x90, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0, 0x92, 4, 0x49, 0x92, 0x24, 9, 0x90,
0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24,
0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x12, 0x24, 0x49, 0x92, 0x24, 0x49,
0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0, 0x24, 0x41, 0x92, 0x24, 0x41, 0x92,
0x24, 0x49, 130, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x12 });

            Form1.PS3.SetMemory((0x208d021 + (client * 0x2A38)), new byte[] {0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92,
0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24,
0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49,
0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92,
0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24,
0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49,
0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92,
0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24,
0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49,
0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92,
0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24,
0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92, 0x24, 0x49, 0x92 });



            Form1.PS3.SetMemory((0x20909a0 + (client * 0x2A38)), new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
0xff, 0xff });



            Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.INFO, "Unlock all successfully done!");
        }



        public static void TrophyUnlocks_MP(uint client)
        {
            string[] Achievements = new string[75];

            Achievements[0] = "8 SP_WIN_CUBA";

            Achievements[1] = "8 SP_WIN_VORKUTA";

            Achievements[2] = "8 SP_WIN_PENTAGON";

            Achievements[3] = "8 SP_WIN_FLASHPOINT";

            Achievements[4] = "8 SP_WIN_KHE_SANH";

            Achievements[5] = "8 SP_WIN_HUE_CITY";

            Achievements[6] = "8 SP_WIN_KOWLOON";

            Achievements[7] = "8 SP_WIN_RIVER";

            Achievements[8] = "8 SP_WIN_FULLAHEAD";

            Achievements[9] = "8 SP_WIN_INTERROGATION_ESCAPE";

            Achievements[10] = "8 SP_WIN_UNDERWATERBASE";

            Achievements[11] = "8 SP_VWIN_FLASHPOINT";

            Achievements[12] = "8 SP_VWIN_HUE_CITY";

            Achievements[13] = "8 SP_VWIN_RIVER";

            Achievements[14] = "8 SP_VWIN_FULLAHEAD";

            Achievements[15] = "8 SP_VWIN_UNDERWATERBASE";

            Achievements[16] = "8 SP_LVL_CUBA_CASTRO_ONESHOT";

            Achievements[17] = "8 SP_LVL_VORKUTA_VEHICULAR";

            Achievements[18] = "8 SP_LVL_VORKUTA_SLINGSHOT";

            Achievements[19] = "8 SP_LVL_KHESANH_MISSILES";

            Achievements[20] = "8 SP_LVL_HUECITY_AIRSUPPORT";

            Achievements[21] = "8 SP_LVL_HUECITY_DRAGON";

            Achievements[22] = "8 SP_LVL_CREEK1_DESTROY_MG";

            Achievements[23] = "8 SP_LVL_CREEK1_KNIFING";

            Achievements[24] = "8 SP_LVL_KOWLOON_DUAL";

            Achievements[25] = "8 SP_LVL_RIVER_TARGETS";

            Achievements[26] = "8 SP_LVL_WMD_RSO";

            Achievements[27] = "8 SP_LVL_WMD_RELAY";

            Achievements[28] = "8 SP_LVL_POW_HIND";

            Achievements[29] = "8 SP_LVL_POW_FLAMETHROWER";

            Achievements[30] = "8 SP_LVL_FULLAHEAD_2MIN";

            Achievements[31] = "8 SP_LVL_REBIRTH_MONKEYS";

            Achievements[32] = "8 SP_LVL_REBIRTH_NOLEAKS";

            Achievements[33] = "8 SP_LVL_UNDERWATERBASE_MINI";

            Achievements[34] = "8 SP_LVL_FRONTEND_CHAIR";

            Achievements[35] = "8 SP_LVL_FRONTEND_ZORK";

            Achievements[36] = "8 SP_GEN_MASTER";

            Achievements[37] = "8 SP_GEN_FRAGMASTER";

            Achievements[38] = "8 SP_GEN_ROUGH_ECO";

            Achievements[39] = "8 SP_GEN_CROSSBOW";

            Achievements[40] = "8 SP_GEN_FOUNDFILMS";

            Achievements[41] = "8 SP_ZOM_COLLECTOR";

            Achievements[42] = "8 SP_ZOM_NODAMAGE";

            Achievements[43] = "8 SP_ZOM_TRAPS";

            Achievements[44] = "8 SP_ZOM_SILVERBACK";

            Achievements[45] = "8 SP_ZOM_CHICKENS";

            Achievements[46] = "8 SP_ZOM_FLAMINGBULL";

            Achievements[47] = "8 MP_FILM_CREATED";

            Achievements[48] = "8 MP_WAGER_MATCH";

            Achievements[49] = "8 MP_PLAY";

            Achievements[50] = "8 DLC1_ZOM_OLDTIMER";

            Achievements[51] = "8 DLC1_ZOM_HARDWAY";

            Achievements[52] = "8 DLC1_ZOM_PISTOLERO";

            Achievements[53] = "8 DLC1_ZOM_BIGBADDABOOM";

            Achievements[54] = "8 DLC1_ZOM_NOLEGS";

            Achievements[55] = "8 DLC2_ZOM_PROTECTEQUIP";

            Achievements[56] = "8 DLC2_ZOM_LUNARLANDERS";

            Achievements[57] = "8 DLC2_ZOM_FIREMONKEY";

            Achievements[58] = "8 DLC2_ZOM_BLACKHOLE";

            Achievements[59] = "8 DLC2_ZOM_PACKAPUNCH";

            Achievements[60] = "8 DLC3_ZOM_STUNTMAN";

            Achievements[61] = "8 DLC3_ZOM_SHOOTING_ON_LOCATION";

            Achievements[62] = "8 DLC3_ZOM_QUIET_ON_THE_SET";

            Achievements[63] = "8 DLC4_ZOM_TEMPLE_SIDEQUEST";

            Achievements[64] = "8 DLC5_ZOM_CRYOGENIC_PARTY";

            Achievements[65] = "8 DLC5_ZOM_BIG_BANG_THEORY";

            Achievements[66] = "8 DLC5_ZOM_GROUND_CONTROL";

            Achievements[67] = "8 DLC5_ZOM_ONE_SMALL_HACK";

            Achievements[68] = "8 DLC5_ZOM_ONE_GIANT_LEAP";

            Achievements[69] = "8 DLC5_ZOM_PERKS_IN_SPACE";

            Achievements[70] = "8 DLC5_ZOM_FULLY_ARMED";

            Achievements[71] = "8 DLC4_ZOM_ZOMB_DISPOSAL";

            Achievements[72] = "8 DLC4_ZOM_MONKEY_SEE_MONKEY_DONT";

            Achievements[73] = "8 DLC4_ZOM_BLINDED_BY_THE_FRIGHT";

            Achievements[74] = "8 DLC4_ZOM_SMALL_CONSOLATION";


            for (int i = 0; i < 75; i++)
            {       
                Form1.PS3.SetMemory((0x2005000 + (client * 0x2a38)), Encoding.ASCII.GetBytes(Achievements + "\0"));

                Form1.PS3.SetMemory((0x466298 + (client * 0x2a38)), new byte[] { 0x41 });

                Form1.PS3.SetMemory((0x4667B4 + (client * 0x2a38)), new byte[] { 0x38, 0x60, 0xFF, 0xFF, 0x38, 0x80, 0x00, 0x00, 0x3C, 0xA0, 0x02, 0x00, 0x30, 0xA5, 0x50, 0x00, 0x4B, 0xF8, 0x2E, 0x2D, 0x4B, 0xFF, 0xFB, 0x78 });

                System.Threading.Thread.Sleep(20);

                Form1.PS3.SetMemory((0x466298 + (client * 0x2a38)), new byte[] { 0x40 });

                Form1.PS3.SetMemory((0x4667B4 + (client * 0x2a38)), new byte[] { 0x82, 0xB9, 0x00, 0x00, 0x3C, 0xE0, 0x00, 0xD7, 0x3D, 0x80, 0x00, 0x92, 0x56, 0xA4, 0x38, 0x30, 0x56, 0xBB, 0x18, 0x38, 0x3B, 0x87, 0x9D, 0x04 });
            }


            Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.INFO, "Unlocked all Trophies successfully done!");
        }



        public static int GetHost()
        {
            string str = Form1.PS3.Extension.ReadString(0x172a588);
            for (int i = 0; i < 0x12; i++)
            {               
                string str2 = Form1.PS3.Extension.ReadString((uint)(0xf1651c + (i * 0x3600)));

               // string name = Form1.PS3.Extension.ReadString((uint)(0x02000934 + (i * 0x2A38)));
              //  Console.WriteLine("Player: " + name);
                if (str == str2)
                {
                    return i;
                }
            }
            return -1;
        }


        public static void givePrestige(uint i, string prestige)
        {          
            byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(prestige.ToString()));
            Form1.PS3.SetMemory(0x20946dd, bytes);
        }

        public static void giveMoney(uint i)
        {
           Form1.PS3.SetMemory((0x20946dd + (i * 0x2A38)), new byte[] { 0xFF, 0xFF, 0xFF, 0x7F });

           // Form1.PS3.SetMemory(0x20946dd , new byte[] { 0xFF, 0xFF, 0xFF, 0x7F });
        }


        //public static string ToHex(int value)
        //{
        //    return String.Format("0x{0:X}", value);
        //}


        //public static byte[] prestiges = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10 };

        //public static byte getHexByInt(string hex)
        //{
        //    byte toreturn = new byte();
        //    for (int i = 0; i < prestiges.Length; i++)
        //    {

        //        if ("0x" + prestiges[i].ToString("X") == hex)
        //        {
        //            Console.WriteLine("hex: " + hex + " / 0x" + prestiges[i].ToString("X"));
        //            toreturn = prestiges[i];
        //        }
        //    }
        //    return toreturn;
        //}


        //public static string getHexByString(int value)
        //{           
        //  //  int toBase = 16;

        //   // string hex = Convert.ToString(value, toBase);

        //    string hex = value;
        //    Console.WriteLine(hex);

        //    return hex;
        //}


        public static byte[] StringToByteArray(string str)
        {
            Dictionary<string, byte> hexindex = new Dictionary<string, byte>();
            for (int i = 0; i <= 255; i++)
            {
                hexindex.Add(i.ToString("X2"), (byte)i);
            }               

            List<byte> hexres = new List<byte>();
            for (int i = 0; i < str.Length; i += 2)
            {
                hexres.Add(hexindex[str.Substring(i, 2)]);
            }
            
            return hexres.ToArray();
        }

        //public static byte[] StringToByteArray(string hex)
        //{
        //    return Enumerable.Range(0, hex.Length)
        //                     .Where(x => x % 2 == 0)
        //                     .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
        //                     .ToArray();
        //}

        //public static byte[] StrToByteArray(string str)
        //{
        //    Dictionary<string, byte> hexindex = new Dictionary<string, byte>();
        //    for (int i = 0; i <= 255; i++)
        //    {
        //        hexindex.Add(i.ToString("X2"), (byte)i);
        //    }


        //    List<byte> hexres = new List<byte>();
        //    for (int i = 0; i < str.Length; i += 2)
        //    {
        //        hexres.Add(hexindex[str.Substring(i, 2)]);


        //        Console.WriteLine(hexindex[str.Substring(i, 2)].ToString());
        //    }

        //    return hexres.ToArray();
        //}

        public static void giveLevel(uint i)  //for now it sets max level 50
        {
                 
            Form1.PS3.SetMemory(0x20946e1, new byte[] { 0x31 });
            byte[] buffer7 = new byte[4];
            buffer7[1] = 0x43;
            buffer7[2] = 0x13;
            byte[] buffer2 = buffer7;
            Form1.PS3.SetMemory(0x20946e5, buffer2);
        }


        public void SV_GameSendServerCommand(int client, string command)
        {
            RPC.Call(0x003E95F0, client, 1, command);
        }

        public static void Cbuf_AddText(int localClient, string command)
        {
            RPC.Call(0x00399CC8, localClient, command);
        }


        public static void setGodModeClass(int klasse)
        {
            Form1.PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Godmode class set to #" + klasse.ToString());
            if (klasse <= 4)
            {
                uint Offset = 0x0208B8F2 + ((uint)klasse * 0x23); //Classes 0-4
                byte[] GByte = new byte[] { 0xE7 };
                Form1.PS3.SetMemory(Offset, GByte);
            }
            else
            {
                uint Offset = 0x0208B9A5 + ((uint)klasse * 0x23); //Classes 5-9
                byte[] GByte = new byte[] { 0xCE };
                Form1.PS3.SetMemory(Offset, GByte);
            }
        }

        public static void loadStats(uint client)
        {
            
            //byte currentWins = Form1.PS3.Extension.ReadByte(0x209475d);
            //byte currentLoss = Form1.PS3.Extension.ReadByte(0x20944dd);
            //byte playedGames = Form1.PS3.Extension.ReadByte(0x20938b1);
            //byte purchasedContract = Form1.PS3.Extension.ReadByte(0x20942e1);
            //byte paidContract = Form1.PS3.Extension.ReadByte(0x20942d5);
            //byte lifetimeearning = Form1.PS3.Extension.ReadByte(0x20942f1);          
            //byte deaths = Form1.PS3.Extension.ReadByte(0x20942f5);
            //byte currentMoney = Form1.PS3.Extension.ReadByte(0x20942d1);


            //Console.WriteLine(currentMoney);
            //byte[] moneyBytes = BitConverter.GetBytes(Convert.ToInt32(currentMoney));
        



          //  byte assists = Form1.PS3.Extension.ReadByte(0x2094291);
          //  byte headshots = Form1.PS3.Extension.ReadByte(0x209440d);

            Form2.mainForm.metroGrid1.Rows.Clear();
            Form2.mainForm.metroGrid1.Rows.Add("Wins", "0");
            Form2.mainForm.metroGrid1.Rows.Add("Loss", "0");
            Form2.mainForm.metroGrid1.Rows.Add("Played Games", "0");
            Form2.mainForm.metroGrid1.Rows.Add("Purchased Contract", "0");
            Form2.mainForm.metroGrid1.Rows.Add("Paid Contract", "0");
            Form2.mainForm.metroGrid1.Rows.Add("Lifetime earning", "0");
            Form2.mainForm.metroGrid1.Rows.Add("Deaths", "0");
            Form2.mainForm.metroGrid1.Rows.Add("Money", "0");
            Form2.mainForm.metroGrid1.Rows.Add("Assists", "0");
            Form2.mainForm.metroGrid1.Rows.Add("Headshots", "0");


            Form2.loadedStats = true;
        }


      

        public static bool Dvar_GetBool(string DVAR)
        {
            bool State;
            uint Value = (uint)RPC.Call(0x4C7BF0, DVAR);
            if (Value == 1)
                State = true;
            else
                State = false;
            return State;
        }

        public static Boolean cl_inGame()
        {
            bool es;
            if (Dvar_GetBool("cl_ingame") == true)
            {
                es = true;
            }
            else
            {
                es = false;
            }
            return es;
        }
    }
}