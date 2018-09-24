using System;
using ConsoleLibrary.Models;

namespace ConsoleLibrary {
  class Program {
    static void Main(string[] args) {
      Library library = new Library("Nampa Public Library");
      Typer.TypeLine(library.Name);
    }
  }
}
