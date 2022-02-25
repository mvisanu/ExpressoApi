using ExpressoApi.Data;
using ExpressoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExpressoApi.Controllers
{
    public class ReservationsController : ApiController
    {
        private ExpressoDbContext _dbContext = new ExpressoDbContext();

        public IHttpActionResult Post(Reservation reservations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.Reservations.Add(reservations);
            _dbContext.SaveChangesAsync();
            return StatusCode(HttpStatusCode.Created);
        }

        public IHttpActionResult Get()
        {
            var reservations = _dbContext.Reservations;
            if (reservations == null) return BadRequest("No reservation");
            return Ok(reservations);
        }
    }
}
