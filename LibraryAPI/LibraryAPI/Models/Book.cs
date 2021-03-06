﻿using LibraryAPI.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class Book : IPublication
    {
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public TypesOfBook BookType { get; set; }
        public List<string> Tags { get; set; }
        public int NoOfCopies { get; set; }
    }
}
