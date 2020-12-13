using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public interface IPublication
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public DateTime PublicationDate { get; set; }
        public List<string> Tags { get; set; }
        public int NoOfCopies { get; set; }
    }
}
