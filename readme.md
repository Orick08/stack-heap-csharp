# Stack & Heap Memory Demo C#
![](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white) ![](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)

All the code is contained in the [**Program.cs**](https://github.com/Orick08/stack-heap-csharp/blob/master/Program.cs) file

---
## Stack Memory

First, in declares two ints (primitive type value) with the same value.

    int score = 95;
    int score2 = score;

Then, change the second value and all seems to be normal

    score2 = 70;
    Console.WriteLine($"score = {score}, score2 = {score2}");
    //score = 95, score2 = 70

Both score and score2 variables are stored in the **stack** memory.

---
## Heap Memory

Now, we made two report objects from the report class (line 84)

    Report report = new Report
      {
        Title = "Hello world!",
        Description = "This is my description",
        Pages = 11,
      };

    Report report2 = report;

Everything seems normal, lets change the value of *report2*

    report2.Pages = 69;

    //report pages = 69
    //report2 pages = 69

Change one property in report 2, but the object is on **heap memory**, so both change :o

When ```report2 = report``` it only copy the pointer on the **stack memory**.

---
## Structs

The instances of the classes (objects) are stored in the heap memory, but structs are directly saved in the stack memory.

Let's make the same experiment as before but with the *document* struct (line 97):

    Document file = new Document
      {
        Title = "This is a document",
        Description = "Total normal document",
        Pages = 40
      };
    Document file2 = file;

Now let's change the value of pages:

    file2.Pages = 100;

    //file.Pages = 40
    //file2.Pages = 100

Just the value of the file2 changes unlike the objects.

---
## Params by Value & Reference

To end, is important to notice that the paramets of a function can be by value (passing the value in the **stack** memory), and by reference (passing just the pointer to the **heap** memory).

As we see, primitive type values (floats, ints, chars, struts) are stored directly in the **stack memory** this means that they are just passing the value to the function.

In the other hand, objects only have a reference to the heap memory, this means that **when you change a value inside a function, the values would change at the end of the function**.

To be more clear, notice the function in the line 68:

    static void ValueReference(int s, Report r)
      {
        s = 400;
        r.Description = "I'm a reference";
      }

Now let's call the function:

    ValueReference(score, report);

And check the values of score and report after the call:

    score = 95; // This don't change
    report.Description = I'm s reference // This value change

The propoerty of description change because it is stored in the **heap memory**.