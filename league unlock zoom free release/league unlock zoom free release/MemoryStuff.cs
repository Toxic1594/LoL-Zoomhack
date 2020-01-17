using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace league_unlock_zoom_free_release
{
    class MemoryStuff
    {
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        public VAMemory PUBMEMORY { get => pubmemory; set => pubmemory = value; }
        public IntPtr PVTZOOMMIN { get => pvtzoommin; set => pvtzoommin = value; }//just a placeholder to use later anywhere
        public IntPtr PVTZOOMMAX { get => pvtzoommax; set => pvtzoommax = value; }//just a placeholder to use later anywhere
        private VAMemory pubmemory;
        private IntPtr pvtzoommin;
        private IntPtr pvtzoommax;
        public void start()
        {
            this.pubmemory = new VAMemory("League of Legends");//init VAMemory class with argument processname = League of Legends
            Process p = Process.GetProcessesByName("League of Legends")[0];
            int gamebase = (int)p.MainModule.BaseAddress;
            Console.WriteLine("Game Base Address: " + gamebase.ToString("x")); // x -> converts the value to hex
            #region read zoom base
            byte[] buff = new byte[4];
            int intPtr = 0;
            ReadProcessMemory(p.Handle, gamebase + offs.Zoombase, buff, 4, ref intPtr);
            int zoombase = BitConverter.ToInt32(buff, 0);
            #endregion//we use this because VAMemory is detected if you try to read base+stuff

            Console.WriteLine("Zoom Base Address: " + zoombase.ToString("x"));
            IntPtr zoommin = (IntPtr)zoombase + offs.zoommin;
            this.pvtzoommin = zoommin;//fill our private variables to use they in the unlockzoom methode
            Console.WriteLine("Zoom Min Address:" + zoommin.ToString("x"));
            IntPtr zoommax = (IntPtr)zoombase + offs.zoommax;
            this.pvtzoommax = zoommax;//fill our private variables to use they in the unlockzoom methode
            Console.WriteLine("Zoom Max Address: " + zoommax.ToString("x"));
            Console.WriteLine("Zoom Min Value:{0}", pubmemory.ReadFloat(zoommin));// you can use '+' instead of {0} result is the same
            Console.WriteLine("Zoom Max Value:{0}", pubmemory.ReadFloat(zoommax));
            unlockzoom();
        }

        void unlockzoom()
        {
            float setminzoom = 1000;
            float setmaxzoom= 20000;
            Console.WriteLine("Press any key to unlock zoom");
            Console.ReadKey();
            pubmemory.WriteFloat(PVTZOOMMIN, setminzoom);
            pubmemory.WriteFloat(PVTZOOMMAX, setmaxzoom);
            Console.WriteLine("Zoom Unlocked , min set to {0} | max set to {1}", setminzoom, setmaxzoom);
            Console.ReadKey();
        }

    }
}
