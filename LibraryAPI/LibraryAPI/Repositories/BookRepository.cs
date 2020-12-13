using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public class BookRepository: Repository<Book, Guid>
    {
        public BookRepository(LibraryContext context) : base(context) { }
    }
}
