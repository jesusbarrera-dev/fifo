using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FCFS
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public class ThreadWork
        {
            public static void DoWork()
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Working thread..."); Thread.Sleep(100);
                }
            }
        }
    class ThreadTest
    {
        public static void Main()
        {
            Thread thread1 = new Thread(ThreadWork.DoWork); thread1.Start();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("In main.");
                Thread.Sleep(100);
            }
        }
    }
}
