using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CleanArchitectureTemplate.Shared.Utilities
{
    public static class Global
    {
        public static void CreateResxFileFromCSV()
        {
            var csvFilePath = "filepath to csv file";
            var resxFilePath = "filepath to EMPTY resource file";

            //see https://joshclose.github.io/CsvHelper/getting-started/#reading-a-csv-file
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader,
                  CultureInfo.InvariantCulture))
            {
                //var records = csv.GetRecords<CsvInputOfResx>();
                ////see https://learn.microsoft.com/en-us/dotnet/core/extensions/work-with-resx-files-programmatically#create-a-resx-fil

                //using (ResXResourceWriter writer =
                //     new ResXResourceWriter(@resxFilePath))
                //{
                //    foreach (var entry in records)
                //    {
                //        writer.AddResource(entry.Name, entry.Value);
                //    }
                //}


            }
        }
    }
}
