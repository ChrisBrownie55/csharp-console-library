using System;
using System.Collections.Generic;

namespace ConsoleLibrary.Models {
  public class Library {
    public string Name { get; private set; }
    private List<LibraryItem> LibraryItems = new List<LibraryItem>();

    public int ItemCount() {
      return LibraryItems.Count;
    }
    public void AddItem(LibraryItem item) {
      LibraryItems.Add(item);
    }
    public void ViewItems() {
      Console.WriteLine("Index\tTitle\t\t\tAvailable");
      Console.WriteLine("-----------------------------------------------------");

      for (int i = 0; i < LibraryItems.Count; i++) {
        LibraryItem item = LibraryItems[i];
        string available = item.Available ? "Available" : "Not available";
        Console.WriteLine($"{i + 1}:\t{item.Title}{(item.Title.Length < 16 ? "\t\t" : "\t")}{available}");
      }
    }

    private LibraryItem SelectItem() {
      Typer.TypeLine("What item would you like to select (use item's index)?");
      Console.Write("> ");

      if (Int32.TryParse(Console.ReadLine(), out int itemIndex) && itemIndex >= 1 && itemIndex <= LibraryItems.Count) {
        --itemIndex;
        return LibraryItems[itemIndex];
      }

      Typer.TypeLine("Invalid index, returning to main menu.");
      return null;
    }

    public void CheckoutItem() {
      LibraryItem item = SelectItem();
      if (item == null) { return; }

      if (item.Available) {
        item.Available = false;
        Typer.TypeLine($"You have checked out \"{item.Title}\".");
      } else {
        Typer.TypeLine($"This item is already checked out, sorry. Returning to main menu.");
      }
    }

    public void ReturnItem() {
      LibraryItem item = SelectItem();
      if (item == null) { return; }

      if (!item.Available) {
        item.Available = true;
        Typer.TypeLine($"You have returned \"{item.Title}\".");
      } else {
        Typer.TypeLine($"You can't return an item you didn't check out. Returning to main menu.");
      }
    }

    public Library(string name) {
      Name = name;
    }
  }
}