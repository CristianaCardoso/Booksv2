using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Books.Models {
    public class Book {
        public int BookId { get; set; }

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public ICollection<BookCategory> CategoriesBook { get; set; }
    }
}
