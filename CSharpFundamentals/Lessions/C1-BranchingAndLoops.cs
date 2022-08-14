using System;

internal class BranchesAndLoops
{
    internal void LearnBranching()
    {
        //if-else
        // var isHuman = false;
        // if(2 + 2 == 4 && isHuman) //&& : logical AND, & : bitwise AND
        // {
        //     Console.WriteLine("I am human and can calculate 2 + 2.");
        // }
        // else
        // {
        //     Console.WriteLine("I am robot and don't know what 2 + 2 is.");
        // }

        //if-elseif-else
        // Console.Write("Enter number:");
        // var text = Console.ReadLine();
        // var number = short.Parse(text);

        // if(number == 0)
        // {
        //     Console.WriteLine("You entered ZERO.");
        // }
        // else if(number < 0)
        // {            
        //     Console.WriteLine("You entered -VE number");
        // }
        // else
        // {
        //     Console.WriteLine("You entered +VE number");
        // }

        //switch (Descrete values)
        var today = DateTime.Now.DayOfWeek;
        switch(today)
        {
            case DayOfWeek.Sunday: 
            Console.WriteLine("Today is Sunday");
            break;
            case DayOfWeek.Monday: 
            Console.WriteLine("Today is Monday");
            break;
            case DayOfWeek.Tuesday: 
            Console.WriteLine("Today is Tuesday");
            break;
            case DayOfWeek.Wednesday: 
            Console.WriteLine("Today is Wednesday");
            break;
            case DayOfWeek.Thursday: 
            Console.WriteLine("Today is Thursday");
            break;
            case DayOfWeek.Friday: 
            Console.WriteLine("Today is Friday");
            break;
            case DayOfWeek.Saturday: 
            Console.WriteLine("Today is Saturday");
            break;
        }
    }    
    internal void LearnLooping()
    {
        //for
        // for(int i = 1; i <= 500; i++)
        // {
        //     //check for primality
        //     Console.WriteLine(i);
        // }

        //while
        ConsoleKeyInfo keyInfo = new();
        while(keyInfo.Key != ConsoleKey.Escape)
        {
            Console.WriteLine("Hello");
            keyInfo = Console.ReadKey();
        }

        //do-while
        //foreach
        byte[] ages = {34, 56, 23, 12, 21, 98, 54};

        for(int x = 0; x < ages.Length; x++)
        {
            Console.WriteLine(ages[x]);
        }  

        foreach(var age in ages)
        {
            Console.WriteLine(age);
        }   
    }
}