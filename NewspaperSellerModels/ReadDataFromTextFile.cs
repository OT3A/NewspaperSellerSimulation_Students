using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace NewspaperSellerModels
{
    public class ReadDataFromTextFile
    {
        public ReadDataFromTextFile()
        {
        }
        public ReadDataFromTextFile(String pathData , SimulationSystem sys)
        {
            lines = File.ReadAllLines(pathData);
            int size = lines.Count();
            for (int i = 0; i < size; i++)
            {
                if (lines[i] == null || lines[i].Length == 0 || lines[i] == "")
                {
                    continue;
                }
                if (lines[i] == "NumOfNewspapers")
                {
                    sys.NumOfNewspapers = int.Parse(lines[i + 1]);
                }
                else if (lines[i] == "NumOfRecords")
                {
                    sys.NumOfRecords = int.Parse(lines[i + 1]);
                }
                else if (lines[i] == "PurchasePrice")
                {
                    sys.PurchasePrice = decimal.Parse(lines[i + 1]);
                }
                else if (lines[i] == "SellingPrice")
                {
                    sys.SellingPrice = decimal.Parse(lines[i + 1]);
                }
                else if(lines[i]== "ScrapPrice")
                {
                    sys.ScrapPrice = decimal.Parse(lines[i + 1]);
                }
                else if (lines[i] == "DayTypeDistributions")
                {
                    decimal p1 = decimal.Parse(lines[i + 1].Split(',')[0]);
                    decimal p2 = decimal.Parse(lines[i + 1].Split(',')[1]);
                    decimal p3 = decimal.Parse(lines[i + 1].Split(',')[2]);
                    sys.DayTypeDistributions.Add(new DayTypeDistribution(Enums.DayType.Good, p1));
                    sys.DayTypeDistributions.Add(new DayTypeDistribution(Enums.DayType.Fair, p2));
                    sys.DayTypeDistributions.Add(new DayTypeDistribution(Enums.DayType.Poor, p3));
                }
                else if (lines[i] == "DemandDistributions") 
                {
                    for(int j = i + 1; j < size; j++)
                    {
                        if (lines[j] == null || lines[j].Length == 0 || lines[j] == "")
                            break;
                        int demand = int.Parse(lines[j].Split(',')[0]);
                        decimal p1 = decimal.Parse(lines[j].Split(',')[1]);
                        decimal p2 = decimal.Parse(lines[j].Split(',')[2]);
                        decimal p3 = decimal.Parse(lines[j].Split(',')[3]);
                        DemandDistribution obj = new DemandDistribution();
                        obj.Demand = demand;
                        obj.DayTypeDistributions.Add(new DayTypeDistribution(Enums.DayType.Good, p1));
                        obj.DayTypeDistributions.Add(new DayTypeDistribution(Enums.DayType.Fair, p2));
                        obj.DayTypeDistributions.Add(new DayTypeDistribution(Enums.DayType.Poor, p3));
                        sys.DemandDistributions.Add(obj);
                    }
                }
            }
            DayTypeDistribution.FillTaballDayTypeDistributions(sys.DayTypeDistributions);
            DemandDistribution.FillTableDemandDistribution(sys.DemandDistributions);

        }
        public String[] lines { get; set; }
    }


}
