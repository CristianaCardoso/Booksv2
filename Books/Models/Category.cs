﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Models {
    public class Category {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public ICollection<BookCategory> BooksCategory { get; set; }
    }
}
