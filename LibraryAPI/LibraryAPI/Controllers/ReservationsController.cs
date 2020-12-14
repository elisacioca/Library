using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        ReservationRepository repo;

        public ReservationsController(LibraryContext context)
        {
            repo = new ReservationRepository(context);
        }

        [HttpPost]
        public ActionResult AddReservation([FromBody] Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            repo.Add(reservation);
            return Accepted(reservation);
        }

        [HttpGet]
        public ActionResult GetReservations()
        {
            var reservations = repo.GetAll();
            if (reservations != null)
            {
                return Ok(reservations);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult GetReservation(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var reservation = repo.GetById(id);
            if (reservation != null)
            {
                return Ok(reservation);
            }
            return NotFound();
        }

        [HttpGet("user/{username}")]
        public ActionResult GetReservationsForUser(string username)
        {
            if (username == null)
            {
                return BadRequest();
            }
            var reservations = repo.GetReservationsForUser(username);
            if (reservations != null)
            {
                return Ok(reservations);
            }
            return NotFound();
        }

        [HttpGet("user/{username}/expired")]
        public ActionResult GetExpiredReservationsForUser(string username)
        {
            if (username == null)
            {
                return BadRequest();
            }
            var reservations = repo.GetExpiredReservationsForUser(username);
            if (reservations != null)
            {
                return Ok(reservations);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReservation(Guid id, [FromBody] Reservation reservation)
        {
            if (id != reservation.ReservationId)
            {
                return BadRequest();
            }

            repo.Update(reservation);

            if (repo.GetById(id) == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult EndReservation(Guid id)
        {
            var reservation = repo.GetById(id);
            if (reservation == null)
            {
                return NotFound();
            }

            try
            {
                repo.EndReservation(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

            return NoContent();
        }
    }
}
