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

        public override void Add(Reservation model)
        {
            var publications = context.Set<Book>();
            var publication = publications.Find(model.BookId);
            if (publication.NoOfCopies > 0)
            {
                publication.NoOfCopies--;
            }
            else
            {
                throw new Exception("Publication is unavailable");
            }

            publications.Update(publication);

            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now.AddDays(14);
            base.Add(model);
        }

        public IEnumerable<Reservation> GetReservationsForUser(string username)
        {
            return entities.Where(r => r.Username == username);
        }

        public IEnumerable<Reservation> GetExpiredReservations()
        {
            return entities.Where(r => r.EndDate <= DateTime.Now);
        }

        public IEnumerable<Reservation> GetExpiredReservationsForUser(string username)
        {
            return entities.Where(r => r.EndDate <= DateTime.Now && r.Username == username);
        }

        public void EndReservation(Guid id)
        {
            var entity = entities.Find(id);
            if (entity.EndDate < DateTime.Now)
            {
                base.Delete(id);
                throw new Exception("Reservation has expired. Customer needs to pay a fee");
            }
            else
            {
                base.Delete(id);
            }
        }
    }
}
