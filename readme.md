# Stack & Heap Memory Demo C#
![](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white) ![](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)

All the code is contained in the **Program.cs** file

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
## Strucs

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

