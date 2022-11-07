using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewspaperSellerTesting;
using NewspaperSellerModels;

namespace NewspaperSellerSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            String path = "D:\\PDF\\4th year\\first term\\Symister 1\\Modeling and Simulations\\Labs\\PDF\\Lab 3_Task 2\\NewspaperSellerSimulation_Students\\NewspaperSellerSimulation\\TestCases\\TestCase3.txt";
            SimulationSystem system = new SimulationSystem();
            ReadDataFromTextFile data = new ReadDataFromTextFile(path, system);
            Calculations.FillTabel(system);
            Calculations.FillPerformanceMeasures(system);
            String testingResult = TestingManager.Test(system, Constants.FileNames.TestCase3);
            MessageBox.Show(testingResult);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
