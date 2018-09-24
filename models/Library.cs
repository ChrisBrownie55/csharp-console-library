using System.Collections.Generic;

namespace ConsoleLibrary.Models {
  public class Library {
    public string Name { get; private set; }

    private List<Book> Books { get; set; } = new List<Book>();

    public Library(string name) {
      Name = name;
    }
  }
}