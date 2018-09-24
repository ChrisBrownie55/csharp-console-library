using System;
using ConsoleLibrary.Models;

namespace ConsoleLibrary {
  class Program {
    static void Main(string[] args) {
      Console.Clear();
      Library library = new Library("Nampa Public Library");
      library.AddItem(new Book("Wocket In My Pocket", "Dr. Seuss", "1234", "1-1-2000"));
      library.AddItem(new Book("Moby Dick", "Herman Melville", "1", "1470"));
      library.AddItem(new Book("The Fellowship", "Grey Beard", "219123-21", "1954", false));
      library.AddItem(new Magazine("People Magazine", "Jess Cagle", "24/7"));
      library.AddItem(new Magazine("Time Magazine", "Edward Felsenthal", "24/7", false));

      // Typer.TypeLine(library.Name);
      // library.ViewBooks();

      bool inTheLibrary = true;
      Console.Clear();
      Typer.TypeLine($"Welcome to {library.Name}!");
      Typer.TypeLine("What would you look to do? (h for help)");
      while (inTheLibrary) {
        Console.Write("> ");
        string input = Console.ReadLine().ToLower();

        if (input.Length != 0 && input[0] == 'h') {
          Console.WriteLine(
            @"
            Things you can do at the library:
              checkout(c) - Checkout book
              return(r) - Return book
              view(v) - View books
              quit(q) - Quit
            "
          );
          continue;
        }

        switch (input) {
          case "c":
          case "checkout":
            library.CheckoutItem();
            break;
          case "r":
          case "return":
            library.ReturnItem();
            break;
          case "v":
          case "view":
            Console.Write('\n');
            library.ViewItems();
            Console.Write('\n');
            break;
          case "q":
          case "quit":
            inTheLibrary = false;
            Console.Clear();
            Console.WriteLine("Have a good day.");
            break;
          default:
            Typer.TypeLine("Invalid option");
            break;
        }
      }
    }
  }
}
