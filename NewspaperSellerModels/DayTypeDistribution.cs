using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSellerModels
{
    public class DayTypeDistribution
    {
        public DayTypeDistribution() { }
        public DayTypeDistribution(Enums.DayType type , decimal prop) {
            DayType = type;
            Probability = prop;
        }
        public Enums.DayType DayType { get; set; }
        public decimal Probability { get; set; }
        public decimal CummProbability { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }

        public static void FillTaballDayTypeDistributions(List<DayTypeDistribution> dayTypeDis)
        {
            int coun = dayTypeDis.Count();
            for (int i = 0; i < coun; i++)
            {
                if (i == 0)
                {
                    dayTypeDis[i].CummProbability = dayTypeDis[i].Probability;
                    dayTypeDis[i].MinRange = 1;
                    int tmp = (int)((dayTypeDis[i].CummProbability * 100));
                    dayTypeDis[i].MaxRange = tmp;
                }
                else
                {
                    dayTypeDis[i].CummProbability = dayTypeDis[i].Probability + dayTypeDis[i - 1].CummProbability;
                    dayTypeDis[i].MinRange = dayTypeDis[i - 1].MaxRange + 1;
                    int tmp = (int)((dayTypeDis[i].CummProbability * 100));
                    dayTypeDis[i].MaxRange = tmp;
                }
            }
        }
    }
}
