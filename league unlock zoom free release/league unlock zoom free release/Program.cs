using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static league_unlock_zoom_free_release.offs;
namespace league_unlock_zoom_free_release
{
    public class Program

    {
        static void Main(string[] args)
        {
            string line2 = "Simple zoom unlock by Singleplayer";
            string line3 = "\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305\u0305";//overline symbol
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (line2.Length / 2)) + "}", line2));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (line3.Length / 2)) + "}", line3));
            MemoryStuff mstuff = new MemoryStuff();
            Thread t1 = new Thread(mstuff.start);
            t1.IsBackground = true; // this prevents the thread from staying alive after closing the console
            t1.Start();
            Console.ReadKey();
        }
        
    }
}
