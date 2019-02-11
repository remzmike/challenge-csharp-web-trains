using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MkTrainSchedule.Models
{
    [DataContract]
    public class Train
    {
        private readonly object seatLock = new object();

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime DepartureTime { get; set;  }

        [DataMember]
        public String Destination { get; set; }

        private int SeatsTotal { get; }
        private int SeatsTaken { get; set; }
        private int[] SeatsTakenBySeatType { get; }

        public Train(int id, DateTime departureTime, String destination, int seatsTotal)
        {
            this.Id = id;
            this.DepartureTime = departureTime;
            this.Destination = destination;
            this.SeatsTotal = seatsTotal;
            this.SeatsTakenBySeatType = new int[2];
        }

        /*public bool HasSeatsAvailable()
        {
            return SeatsTaken < SeatsTotal;
        }*/

        public bool HasSeatsAvailable(int seatType)
        {
            return SeatsTakenBySeatType[seatType] < SeatsTotal / 2;
        }

        public bool TryReserveSeat(int seatType)
        {
            lock (seatLock)
            {
                if (HasSeatsAvailable(seatType))
                {
                    SeatsTakenBySeatType[seatType]++;
                    SeatsTaken++;
                    return true;
                }
                return false;
            }
        }

    }

}