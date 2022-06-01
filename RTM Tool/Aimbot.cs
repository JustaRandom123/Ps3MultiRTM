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
    public class Aimbot
    {     

        public static uint G_Entity(uint client)

        {

            return 0x012ab290 + (client * 0x2F8);

        }

        public static byte[] ReverseBytes(byte[] toReverse)
        {
            Array.Reverse(toReverse);
            return toReverse;
        }

        public static float[] ReadSingle(uint address, int length)
        {
            byte[] memory = Form1.PS3.Extension.ReadBytes(address, length * 4);
            ReverseBytes(memory);
            float[] numArray = new float[length];
            for (int index = 0; index < length; ++index)
                numArray[index] = BitConverter.ToSingle(memory, (length - 1 - index) * 4);
            return numArray;
        }



        public static float[] getOrigin(uint Client)
        {
            float[] Position = ReadSingle(0x013950c8 + ((uint)Client * 0x2A38), 3);
            return Position;
        }

        //public static float[] getOrigin(uint clientNum)

        //{

        //    float[] origin = new float[3];

        //    origin[0] = ReadSingle(0x013950c8 + 0x2A38 * clientNum + 0x24);

        //    origin[1] = Lib.ReadSingle(0x013950c8 + 0x2A38 * clientNum + 0x24 + 0x4);

        //    origin[2] = Lib.ReadSingle(0x013950c8 + 0x2A38 * clientNum + 0x24 + 0x8);

        //    return origin;

        //}


        public static UInt32 G_Entity(Int32 ClientIndex)

        {

            return 0x16B7920 + ((UInt32)ClientIndex * 0x31C);

        }



        public static int GetHost()

        {

            string str = Form1.PS3.Extension.ReadString(0x172a588);

            for (int i = 0; i < 0x12; i++)

            {

                string str2 = Form1.PS3.Extension.ReadString((uint)(0xf1651c + (i * 0x3600)));

                if (str == str2)

                {

                    return i;

                }

            }

            return -1;

        }

        public static Boolean Exists(Int32 clientIndex)

        {

            return Form1.PS3.Extension.ReadString(0x013978d0 + ((uint)clientIndex * 0x2A38)) != "";

        }



        public static Boolean IsAlive(Int32 clientIndex)

        {

            return (Form1.PS3.Extension.ReadByte(0x0139793b + ((uint)clientIndex * 0x2A38)) == 0);

        }



        public static Boolean isSameTeam(Int32 Owner, Int32 Victim)

        {

            return Form1.PS3.Extension.ReadInt32(0x01397894 + ((uint)Owner * 0x2A38)) == Form1.PS3.Extension.ReadInt32(0x01397894 + ((uint)Victim * 0x2A38));

        }

        public static Single GetDistance3D(Single[] p1, Single[] p2)

        {

            float[] numArray3 = new float[] { p2[0] - p1[0], p2[1] - p1[1], p2[2] - p1[2] };

            return ((numArray3[0] * numArray3[0]) + (numArray3[1] * numArray3[1])) + (numArray3[2] * numArray3[2]);

        }

        public static int GetNearestClientFromAttacker(int You)

        {

            int CIndex = -1;

            double Closest = 1E+08f;

            for (int i = 0; i < 12; i++)

            {

                if (((Exists(i) && IsAlive(i) && !isSameTeam(You, i))))

                {

                    double Bla = GetDistance3D(getOrigin((uint)You), getOrigin((uint)i));

                    if (Bla < Closest)

                    {

                        CIndex = i;

                        Closest = Bla;

                    }

                }

            }

            return CIndex;

        }





        //The Real Aimbot Code-----



        //function to convert a vector to angles

        public static Single[] vectoangles(Int32 clientIndex, Int32 secondPlayer)

        {

            Single[] numArray1 = getOrigin((uint)clientIndex);

            Single[] numArray2 = getOrigin((uint)secondPlayer);

            Single[] Angles = { (numArray2[0] - numArray1[0]), (numArray2[1] - numArray1[1]), (numArray2[2] - numArray1[2]) };

            Single num2;

            Single num3;

            Single[] numArray = new Single[3];

            if ((Angles[1] == 0f) && (Angles[0] == 0f))

            {

                num2 = 0f;

                if (Angles[2] > 0f)

                    num3 = 90f;

                else

                    num3 = 270f;

            }

            else

            {

                if (Angles[0] != -1f)

                    num2 = (Single)((Math.Atan2((Double)Angles[1], (Double)Angles[0]) * 180.0) / 3.1415926535897931);

                else if (Angles[1] > 0f)

                    num2 = 90f;

                else

                    num2 = 270f;

                if (num2 < 0f)

                    num2 += 360f;

                Single num = (Single)Math.Sqrt((Double)((Angles[0] * Angles[0]) + (Angles[1] * Angles[1])));

                num3 = (Single)((Math.Atan2((Double)Angles[2], (Double)num) * 180.0) / 3.1415926535897931);

                if (num3 < 0f)

                    num3 += 360f;

            }

            numArray[0] = -num3;

            numArray[1] = num2;

            return numArray;

        }

        //Set Set the clients angles

        public static void SetClientViewAngles(Int32 clientIndex, Int32 Victim)

        {

            float[] angles = vectoangles(clientIndex, Victim);

            WriteSingle(0x10040000, angles);

            RPC.Call(0x2C1E38, new Object[] { G_Entity((uint)clientIndex), 0x10040000 });

        }


        public static void WriteSingle(uint address, float[] input)
        {
            int length = input.Length;
            byte[] array = new byte[length * 4];
            for (int i = 0; i < length; i++)
            {
                ReverseBytes(BitConverter.GetBytes(Convert.ToInt64(input))).CopyTo(array, (int)(i * 4));
            }
            Form1.PS3.SetMemory(address, array);
        }


        public static void WriteSingleFloat(uint address, float input)
        {
            byte[] array = new byte[4];
            BitConverter.GetBytes(input).CopyTo(array, 0);
            Array.Reverse(array, 0, 4);
            Form1.PS3.SetMemory(address, array);
        }



        //Just Aimbot Threads and Bools

        public static bool[] AimbotStatus = new bool[12];

        public static Thread[] AimbotThread = new Thread[12];

        public static bool[] UnfairAimbot = new bool[12];



        //This is what starts the Aimbot

        public static void StartAimbot(int clientIndex)

        {

            ThreadStart start = null;

            if (!AimbotStatus[clientIndex])

            {

                Thread.Sleep(100);

                AimbotStatus[clientIndex] = true;

                if (start == null)

                {

                    start = () => InitializeAimbot(clientIndex);

                }

                AimbotThread[clientIndex] = new Thread(start);

                AimbotThread[clientIndex].IsBackground = true;

                AimbotThread[clientIndex].Start();

            }

            else

            {

                AimbotStatus[clientIndex] = false;

                AimbotThread[clientIndex].Abort();

            }

        }

        //Main Aimbot Code

        private static void InitializeAimbot(int client)

        {
            //  Form1.PS3.Extension.Reconnect();


            while (AimbotThread[client].IsAlive)

            {

                int nearestPlayer = GetNearestClientFromAttacker(client);

                if (nearestPlayer != client)

                {

                    if (Buttons.ButtonPressed(client, 03) || Buttons.ButtonPressed(client, 04))

                    {

                        SetClientViewAngles(client, nearestPlayer);

                    }

                }

            }
        }
    }
}
