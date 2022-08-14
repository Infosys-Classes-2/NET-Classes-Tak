using System;
public class Assignment
{
//AgnQNo1 - Function to Calculate Area of Circle
public string GetAreaOfCircle(double radius)
{
   double area = (3.14) * radius * radius; 
   return ($"Area of Circle is {area}");
}


//AgnQNo2 - Function to convert days to years, months, weeks and days.
class Dayconversion
{
    static void Main(string[] args)
    {
        int num     =0;
        int years   =0;
        int weeks   =0;
        int days    =0;
                
        Console.Write("Enter number of days: ");
        num = Convert.ToInt32(Console.ReadLine());
        
        years = num / 365;
        weeks = (num % 365) / 7;
        days  = (num % 365) % 7;

        Console.WriteLine($"{num} is equal to => {years} Year/s, {weeks} Week/s & {days} Day/s");
    }
}
//function to print prime number <500

public void PrintPrimeNumber()
{
    Console.Write("Prime Numbers <500 are:");
   for(int num = 1;num<=500;num++)
       {
         int ctr = 0;

         for(int i =2;i<=num/2;i++)
            {
             if(num%i==0)
             {
                 ctr++;
                 break;
             }
            }
        
         if(ctr==0 && num!= 1)
             Console.Write($"{num},");
         }    
         Console.Write("\n\n");
}

 // Print pattens
    public void PrintPattern()
    {
        int rows = 10;
        for (int i = 1; i <= rows; i++)
        {
            for(int j = rows -1; j >= i; j--)
            {                
                Console.Write(" ");
            }

            for(int j = 1; j <= 2 * i - 1; j++)
            {                
                Console.Write("*");
            }
            Console.WriteLine();            
        }
    }

public void PrintData (string inputValue)
{
    Console.WriteLine(inputValue);
}
}