using EfCodeFirst;

var context = new LibraryEntities();

//context.Books.Add(new Book
//{
//    Title = "Pan Tadeusz",
//    Author = new Author
//    {
//        FirstName = "Adam",
//        LastName= "Mickiewicz"
//    }
//});

//context.Authors.Add(new Author
//{
//    FirstName = "Ian",
//    LastName = "Flemming",
//    Books = new List<Book>
//    {
//        new() { Title = "Dr. No"},
//        new() { Title = "From Russia with love"},
//        new() { Title = "Goldfinger"}
//    }
//});

foreach (var book in context.Books)
{
    book.Price = 10;
}


context.SaveChanges();
Console.WriteLine("Done");
Console.ReadKey();