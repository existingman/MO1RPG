using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using MO1.Content;

namespace MO1.Editor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Data.Initialise();
            BaseStats.Init();
            Data.Load();
            Map.Load();
            PlayerFile.Load();
            ImageData.Initialise();
            ImageData.LoadImages();


            Application.Run(new Main());
        }
    }
}
