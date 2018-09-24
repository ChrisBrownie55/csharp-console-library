using System;
using System.Threading;

namespace ConsoleLibrary.Models {
  public class Typer {
    public static void Type(string output, int delay=25) {
      foreach (char c in output) {
        Thread.Sleep(delay);
        Console.Write(c);
      }
    }

    public static void TypeLine(string output) {
      Type(output);
      Console.Write('\n');
    }
  }
}