using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace MkTrainSchedule.Controllers
{
    public class TrainsController : ApiController
    {
        // GET: api/Trains
        public IList<Models.Train> Get()
        {
            var trains = (IList<Models.Train>) HttpContext.Current.Application["TrainData"];
            return trains;
        }

        /*
        // GET: api/Trains/5
        public IHttpActionResult Get(int id)
        {
            var trains = (IList<Models.Train>) HttpContext.Current.Application["TrainData"];
            var train = trains.FirstOrDefault((p) => p.Id == id);
            if (train == null)
            {
                return NotFound();
            }
            return Ok(train);
        }*/

    }
}
