using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public class MagazineRepository: Repository<Magazine, Guid>
    {
        public MagazineRepository(LibraryContext context) : base(context) { }
    }
}
