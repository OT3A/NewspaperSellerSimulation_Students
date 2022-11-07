using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSellerModels
{
   public class Calculations
    {
        public Calculations() { }
        public static void FillTabel(SimulationSystem sys)
        {
            Random rd = new Random();
            int size = sys.NumOfRecords;
            int numberOfPapers = sys.NumOfNewspapers;
            decimal buy = sys.PurchasePrice;
            decimal sell = sys.SellingPrice;
            decimal sellScrap = sys.ScrapPrice;
            for (int i = 0; i < size; i++)
            {
                SimulationCase row = new SimulationCase();
                row.DayNo = i + 1;
                row.RandomNewsDayType = rd.Next(1, 100);
                row.NewsDayType = Funcations.SelectDayType(row.RandomNewsDayType,sys);
                row.RandomDemand = rd.Next(1, 100);
                row.Demand = Funcations.SelectDemand(row.RandomDemand, sys, row.NewsDayType);
                row.DailyCost = numberOfPapers * buy;
                row.SalesProfit = Funcations.CalculateSalesProfit(sell, row.Demand, numberOfPapers);
                row.LostProfit = Funcations.CalculateLostProfit(row.Demand, numberOfPapers, sell,buy);
                row.ScrapProfit = Funcations.CalculateScrapProfit(row.Demand, numberOfPapers, sellScrap);
                row.DailyNetProfit = Funcations.CalculateDailyNetProfit(row.SalesProfit, row.ScrapProfit, row.LostProfit, row.DailyCost);
                sys.SimulationTable.Add(row);
            }
        }
        public static void FillPerformanceMeasures(SimulationSystem sys)
        {
            sys.PerformanceMeasures.TotalSalesProfit = FuncationsPerformanceMeasures.CalculateTotalSalesProfit(sys);
            sys.PerformanceMeasures.TotalCost = sys.SimulationTable[0].DailyCost * sys.NumOfRecords;
            sys.PerformanceMeasures.TotalLostProfit = FuncationsPerformanceMeasures.CalculateTotalLostProfit(sys);
            sys.PerformanceMeasures.TotalScrapProfit = FuncationsPerformanceMeasures.CalculateTotalScrapProfit(sys);
            sys.PerformanceMeasures.TotalNetProfit = FuncationsPerformanceMeasures.CalculateTotalNetProfit(sys);
            sys.PerformanceMeasures.DaysWithMoreDemand = FuncationsPerformanceMeasures.CalculateDaysWithMoreDemand(sys);
            sys.PerformanceMeasures.DaysWithUnsoldPapers = FuncationsPerformanceMeasures.CalculateDaysWithUnsoldPapers(sys);
        }
    }
}
