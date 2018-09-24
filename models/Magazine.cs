namespace ConsoleLibrary.Models {
  public class Magazine : LibraryItem {
    public Magazine(string title, string author, string published, bool available = true)
    : base(title, author, published, available) {
    }
  }
}