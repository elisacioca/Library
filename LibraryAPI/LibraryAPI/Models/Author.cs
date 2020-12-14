using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }   
        public List<Book> Books { get; set; }

        public List<Magazine> Magazines { get; set; }
    }
}
