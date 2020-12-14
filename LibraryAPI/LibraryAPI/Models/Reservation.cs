using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class Reservation
    {
        public Guid ReservationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid PublicationId { get; set; }
        public string Username { get; set; }
        [ForeignKey("Username")]
        public User User { get; set; }

        [ForeignKey("PublicationId")]
        public IPublication Publication { get; set; }
    }
}
