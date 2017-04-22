using System;
using System.Linq;

namespace FileMover
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");

      if (args.Any())
      {
        var filename = args.First();
        Console.WriteLine(filename);
      }
    }
  }
}
