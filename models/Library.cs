using System;
using System.Collections.Generic;

namespace ConsoleLibrary.Models {
  public class Library {
    public string Name { get; private set; }
    private List<Book> Books = new List<Book>();

    public int BookCount() {
      return Books.Count;
    }
    public void AddBook(Book book) {
      Books.Add(book);
    }
    public void ViewBooks() {
      Console.WriteLine("Index\tTitle\t\t\tAvailable");
      Console.WriteLine("-----------------------------------------------------");

      for (int i = 0; i < Books.Count; i++) {
        Book book = Books[i];
        string available = book.Available ? "Available" : "Not available";
        Console.WriteLine($"{i + 1}:\t{book.Title}\t{(book.Title.Length < 16 ? "\t" : "")}{available}");
      }
    }

    private Book SelectBook() {
      Typer.TypeLine("What book would you like to select(use book's index)?");
      Console.Write("> ");
      if (Int32.TryParse(Console.ReadLine(), out int bookIndex) && bookIndex >= 1 && bookIndex <= Books.Count) {
        --bookIndex;
        Book book = Books[bookIndex];
        return book;
      } else {
        Typer.TypeLine("Invalid index, returning to main menu.");
      }
      return null;
    }

    public void CheckoutBook() {
      Book book = SelectBook();
      if (book == null) { return; }

      if (book.Available) {
        book.Available = false;
        Typer.TypeLine($"You have checked out \"{book.Title}\".");
      } else {
        Typer.TypeLine($"This book is already checked out, sorry. Returning to main menu.");
      }
    }

    public void ReturnBook() {
      Book book = SelectBook();
      if (book == null) { return; }

      if (!book.Available) {
        book.Available = true;
        Typer.TypeLine($"You have returned \"{book.Title}\".");
      } else {
        Typer.TypeLine($"You can't return a book you didn't check out. Returning to main menu.");
      }
    }

    public Library(string name) {
      Name = name;
    }
  }
}