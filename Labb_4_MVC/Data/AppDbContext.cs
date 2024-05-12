using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Labb_4_MVC.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Labb_4_MVC.Models.Customer> Customer { get; set; } = default!;

    public DbSet<Labb_4_MVC.Models.Book> Book { get; set; } = default!;

    public DbSet<Labb_4_MVC.Models.BorrowedBook> BorrowedBook { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = Guid.Parse("FB756FA6-AFCB-4163-940F-039877239B34"), FullName = "Adam Ask" , age = 23,Email = "adam@mail.com", PhoneNumber = "123456" },
            new Customer { Id = Guid.Parse("8C9A0FB0-274E-494E-BE52-7CC58DE22BBD"), FullName = "Bertil Bok", age = 32, Email = "Bertil@mail.com", PhoneNumber = "312453" },
            new Customer { Id = Guid.Parse("3D14E96D-5526-492B-8494-C0B7B65BA2B0"), FullName = "Berit Bok", age = 33, Email = "Berit@mail.com", PhoneNumber = "634523" }
            );

        modelBuilder.Entity<Book>().HasData(
            new Book { Id = Guid.Parse("359EF01E-5294-4773-A59A-5B2677BFDCC3"), Title = "Narnia", Description = "ett lejon och en häxa i garderoben",Author = "C.S.Lewis" },
            new Book { Id = Guid.Parse("5DBFFA4C-6956-4CD2-8606-86D59A0C666A"), Title = "Two Towers", Description = "två stora torn", Author= "Tolkien" },
            new Book { Id = Guid.Parse("BF55EF41-5174-44AD-AF48-CF6A7A03AA3F"), Title = "Lord of the rings", Description = "Magisk ring", Author = "Tolkien" }
            );

        modelBuilder.Entity<BorrowedBook>().HasData(
            new BorrowedBook { Id = Guid.Parse("FA737607-6F55-4608-A301-3D447422DE5B"), CustomerId =  Guid.Parse("FB756FA6-AFCB-4163-940F-039877239B34"), BookId = Guid.Parse("BF55EF41-5174-44AD-AF48-CF6A7A03AA3F"), BorrowedDate= new DateTime(2024-01-01), ReturnDate=new DateTime(2024 - 01 - 10), IsReturned=true },
            new BorrowedBook { Id = Guid.Parse("8C9A0FB0-274E-494E-BE52-7CC58DE22BBB"), CustomerId = Guid.Parse("8C9A0FB0-274E-494E-BE52-7CC58DE22BBD"), BookId = Guid.Parse("359EF01E-5294-4773-A59A-5B2677BFDCC3"), BorrowedDate = new DateTime(2024 - 01 - 01), ReturnDate = new DateTime(2024 - 01 - 11), IsReturned = false },
            new BorrowedBook { Id = Guid.Parse("E58F7808-F945-40B6-BEDE-D3E1DABA6B08"), CustomerId = Guid.Parse("FB756FA6-AFCB-4163-940F-039877239B34"), BookId = Guid.Parse("5DBFFA4C-6956-4CD2-8606-86D59A0C666A"), BorrowedDate = new DateTime(2024 - 05 - 03), ReturnDate = new DateTime(2024 - 05 - 20), IsReturned = false }
            );
    }
}
