using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSellerModels
{
    public class DemandDistribution
    {
        public DemandDistribution()
        {
            DayTypeDistributions = new List<DayTypeDistribution>();
        }
        public int Demand { get; set; }
        public List<DayTypeDistribution> DayTypeDistributions { get; set; }
        public static void FillTableDemandDistribution(List<DemandDistribution> dayDi)
        {
            int count = dayDi.Count();
            int cou = dayDi[0].DayTypeDistributions.Count();
            for(int i = 0; i < count; i++)
            {
                if(i == 0)
                {
                    for(int j = 0; j < cou; j++)
                    {
                        dayDi[i].DayTypeDistributions[j].CummProbability = dayDi[i].DayTypeDistributions[j].Probability;
                        dayDi[i].DayTypeDistributions[j].MinRange = 1;
                        int tmp = (int)((dayDi[i].DayTypeDistributions[j].CummProbability * 100));
                        dayDi[i].DayTypeDistributions[j].MaxRange = tmp;
                    }
                }
                else
                {
                    for(int j = 0; j < cou; j++)
                    {
                        dayDi[i].DayTypeDistributions[j].CummProbability = dayDi[i].DayTypeDistributions[j].Probability + dayDi[i - 1].DayTypeDistributions[j].CummProbability;
                        dayDi[i].DayTypeDistributions[j].MinRange = dayDi[i - 1].DayTypeDistributions[j].MaxRange + 1;
                        int tmp = (int)((dayDi[i].DayTypeDistributions[j].CummProbability * 100));
                        dayDi[i].DayTypeDistributions[j].MaxRange = tmp;
                    }
                }
            }
        }
    }
}

