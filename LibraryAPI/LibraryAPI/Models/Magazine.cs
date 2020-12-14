using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class Magazine : IPublication
    {
        public Guid MagazineId { get; set; }
        string IPublication.Name { get; set; }
        string IPublication.Description { get; set; }
        DateTime IPublication.PublicationDate { get; set; }
        List<string> IPublication.Tags { get; set; }
        int IPublication.NoOfCopies { get; set; }
    }
}
