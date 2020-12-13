using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<IPublication> BookedPublications { get; set; }
    }
}
