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
            var publications = context.Set<IPublication>();
            var publication = publications.Find(model.PublicationId);
            if (publication.NoOfCopies > 0)
            {
                publication.NoOfCopies--;
            }
            else
            {
                throw new Exception("Publication is unavailable");
            }

            publications.Update(publication);
            base.Add(model);
        }
    }
}
