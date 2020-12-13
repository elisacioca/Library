using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public class ReservationRepository: Repository<Reservation, Guid>
    {
        public ReservationRepository(LibraryContext context) : base(context) { }
    }
}
