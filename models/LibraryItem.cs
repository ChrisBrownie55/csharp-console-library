namespace ConsoleLibrary.Models {
  public abstract class LibraryItem {
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string Published { get; set; }
    public bool Available { get; set; }

    public LibraryItem(string title, string author, string published, bool available=true) {
      Title = title;
      Author = author;
      Published = published;
      Available = available;
    }
  }
}