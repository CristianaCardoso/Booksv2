using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Books.Models;

namespace Books.Models
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext (DbContextOptions<BooksDbContext> options)
            : base(options)
        {
        }

        public DbSet<Books.Models.Author> Author { get; set; }

        public DbSet<Books.Models.Book> Book { get; set; }

        public DbSet<Books.Models.Category> Category { get; set; }

        public DbSet<Books.Models.BookCategory> BookCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // alternate way of specifying a key with two fields:
            // https://stackoverflow.com/questions/5962557/multiple-primary-key-with-asp-net-mvc-3
            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            // No need for doing this
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.CategoriesBook)
                .HasForeignKey(bc => bc.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            // No need for doing this
            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BooksCategory)
                .HasForeignKey(bc => bc.Category)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
