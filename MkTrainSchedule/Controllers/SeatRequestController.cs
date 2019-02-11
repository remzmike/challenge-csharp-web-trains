using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace MkTrainSchedule.Controllers
{
    public class SeatRequestController : ApiController
    {                
        // POST: api/SeatRequest
        public IHttpActionResult Post([FromUri]int trainId, [FromUri]int seatType)
        {
            var trains = (IList<Models.Train>) HttpContext.Current.Application["TrainData"];

            if (trainId >= trains.Count)
            {
                return BadRequest("Invalid train id.");
            }

            if (seatType != 0 && seatType != 1)
            {
                return BadRequest("Invalid seat type.");
            }

            var train = trains[trainId];
            var success = train.TryReserveSeat(seatType);

            return Ok(success);
        }
    }
}
