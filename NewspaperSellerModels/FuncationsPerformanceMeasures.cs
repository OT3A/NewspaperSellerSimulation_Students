using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSellerModels
{
    public class FuncationsPerformanceMeasures
    {
        public static decimal CalculateTotalSalesProfit(SimulationSystem sys)
        {
            int size = sys.SimulationTable.Count();
            decimal sum = 0;
            for(int i = 0; i < size; i++)
            {
                sum += sys.SimulationTable[i].SalesProfit;
            }
            return sum;
        }
        public static decimal CalculateTotalLostProfit(SimulationSystem sys)
        {
            int size = sys.SimulationTable.Count();
            decimal sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += sys.SimulationTable[i].LostProfit;
            }
            return sum;
        }
        public static decimal CalculateTotalScrapProfit(SimulationSystem sys)
        {
            int size = sys.SimulationTable.Count();
            decimal sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += sys.SimulationTable[i].ScrapProfit;
            }
            return sum;
        }
        public static decimal CalculateTotalNetProfit(SimulationSystem sys)
        {
            int size = sys.SimulationTable.Count();
            decimal sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += sys.SimulationTable[i].DailyNetProfit;
            }
            return sum;
        }
        public static int CalculateDaysWithMoreDemand(SimulationSystem sys)
        {
            int size = sys.SimulationTable.Count();
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                if (sys.SimulationTable[i].LostProfit != 0)
                {
                    sum += 1;
                }
            }
            return sum;
        }
        public static int CalculateDaysWithUnsoldPapers(SimulationSystem sys)
        {
            int size = sys.SimulationTable.Count();
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                if (sys.SimulationTable[i].ScrapProfit != 0)
                {
                    sum += 1;
                }
            }
            return sum;
        }
    }
}
