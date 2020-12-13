using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public class AuthorRepository: Repository<Author, Guid>
    {
        public AuthorRepository(LibraryContext context) : base(context) { }
    }
}
