using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSellerModels
{
   public class Funcations
   {
        public static Enums.DayType SelectDayType(int rand,SimulationSystem sys)
        {
            int size = sys.DayTypeDistributions.Count();
            for(int i = 0; i < size; i++)
            {
                if(sys.DayTypeDistributions[i].MinRange <= rand && rand<= sys.DayTypeDistributions[i].MaxRange)
                {
                    return sys.DayTypeDistributions[i].DayType;
                }
            }
            return 0;

        }
        public static int SelectDemand(int rand, SimulationSystem sys , Enums.DayType dayType)
        {
            int size = sys.DemandDistributions.Count();
            int size2 = sys.DemandDistributions[0].DayTypeDistributions.Count();
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size2; j++)
                {
                    if(sys.DemandDistributions[i].DayTypeDistributions[j].DayType== dayType)
                    {
                        if(sys.DemandDistributions[i].DayTypeDistributions[j].MinRange <=rand &&rand <= sys.DemandDistributions[i].DayTypeDistributions[j].MaxRange)
                        {
                            return sys.DemandDistributions[i].Demand;
                        }
                    }
                }
            }
            return 0;
        }
        public static decimal CalculateSalesProfit(decimal sell ,int demand, int numberOfPapers)
        {
            if (demand <= numberOfPapers)
            {
                return sell * demand;
            }
            else
            {
                return numberOfPapers * sell;
            }
        }
        public static decimal CalculateLostProfit(int demand, int numberOfPapers,decimal sell,decimal buy)
        {
            if (demand <= numberOfPapers)
            {
                return 0;
            }
            else
            {
                return (demand - numberOfPapers) * (sell-buy);
            }
        }
        public static decimal CalculateScrapProfit(int demand, int numberOfPapers, decimal sell)
        {
            if (demand < numberOfPapers)
            {
                return (numberOfPapers - demand) * sell;
            }
            return 0;
        }
        public static decimal CalculateDailyNetProfit(decimal SalesProfit,decimal ScrapProfit,decimal LostProfit,decimal DailyCost)
        {
            return (SalesProfit - DailyCost - LostProfit + ScrapProfit);
        }
   }
}
