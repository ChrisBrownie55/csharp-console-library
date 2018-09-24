using System;

namespace ConsoleLibrary.Models {
  public class Book : LibraryItem
  {
    public string ISBN { get; set; }
    public Book(string title, string author, string isbn, string published, bool available = true)
    : base(title, author, published, available) {
      ISBN = isbn;
    }
  }
}