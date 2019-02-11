using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;

namespace MkTrainSchedule
{
    public class TrainData
    {
        public static IList<Models.Train> Load(string path)
        {
            var trains = new List<Models.Train>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var splits = reader.ReadLine().Split(',');
                    var departureTime = DateTime.ParseExact(splits[0], "HH.mm", CultureInfo.InvariantCulture); ;
                    var destination = splits[1];
                    var seatsTotal = Convert.ToInt32(splits[2]);
                    var train = new Models.Train(trains.Count, departureTime, destination, seatsTotal);
                    trains.Add(train);
                }
            }
            return trains;
        }
    }
}