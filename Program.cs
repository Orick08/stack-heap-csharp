using System;
using System.Text;

namespace Program
{
  class Program
  {
    static void Main(string[] args)
    {
      //Declare 2 primitive variables and save them on the stack memory
      int score = 95;
      int score2 = score;
      Console.WriteLine($"score = {score}, score2 = {score2}");

      //Change the second value, all its fine :)
      score2 = 70;
      Console.WriteLine($"score = {score}, score2 = {score2}");

      Line();

      //Make a report object and then a copy of the object
      Report report = new Report
      {
        Title = "Hello world!",
        Description = "This is my description",
        Pages = 11,
      };
      Report report2 = report;

      Console.WriteLine(report.Display());
      Console.WriteLine(report2.Display());

      //Change one property, but is on heap memory, so both change :o
      //on the stack memory is the pointer, so C# only copy the pointer
      report2.Pages = 69;
      Console.WriteLine(report.Display());
      Console.WriteLine(report2.Display());

      Line();

      //Now, same experiment but with struct
      Document file = new Document
      {
        Title = "This is a document",
        Description = "Total normal document",
        Pages = 40
      };
      Document file2 = file;

      Console.WriteLine(file.Display());
      Console.WriteLine(file2.Display());

      //Now lets change a value, strucs are like primitive types
      //It means that they are save in the stack memory
      file2.Pages = 100;
      Console.WriteLine(file.Display());
      Console.WriteLine(file2.Display());

      Line();

      //Finally the experiment of values and references
      //The value is pass throw the function and don't change
      //But the pointer of the object (aka reference), so it change the value
      ValueReference(score, report);
      Console.WriteLine($"score = {score}");
      Console.WriteLine(report.Display());
    }
    static void ValueReference(int s, Report r)
    {
      s = 400;
      r.Description = "I'm a reference";
    }

    static void Line()
    {
      Console.WriteLine("-----------");
    }
  }
  interface IPapers
  {
    string Display();
  }

  class Report : IPapers
  {
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int Pages { get; set; }

    public string Display()
    {
      return string.Format("{0}, {1}. pp. {2}", Title, Description, Pages);
    }

  }

  struct Document : IPapers
  {
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int Pages { get; set; }

    public string Display()
    {
      return string.Format("{0}, {1}. pp. {2}", Title, Description, Pages);
    }

  }
}

