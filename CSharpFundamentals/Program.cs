//using System;

//Console.Write("Enter Your Full Name: ");
//string name = Console.ReadLine();
//var fullName = Console.ReadLine();
//var len = fullName.IndexOf(" ");
//var firstName = fullName.Substring(0,len);
//Console.WriteLine($"Hello, {firstName}");
/*
// Class Work-1
Console.Write("Enter Your a word: ");
string word = Console.ReadLine();
string uword = word.ToUpper();
Console.WriteLine($"Given word in upper case:, {uword}");
*/

// ======
/*
// Class Work-2
Console.Write("Enter meter to convert ot feet");
var length = Console.ReadLine();
var lenNumber = double.Parse(length);
var feets = lenNumber * 3.2808;
Console.WriteLine($"{lenNumber} metres = {feets} feet");


// Datatype: Numbers, Strings, booleans, characters, derived types
// Numbers: Integer(e.g. 34, 56), Floating point (23.56, 111.0111)
byte a = 255; // 1 byte  = 8 bit = 11111111 = 255) // for storing age of man
short b = 32767; // 2 byte: 
int c = int.MaxValue; // 4 byte:
long d = long.MaxValue; // 
float e = 334.4545f; //4 byte / after decimal 8 digit only accurate
double f =23422.34535; //16 byte / after . 16 digit accurately hold
decimal g = 234243242.234252424242m; // for more it is usefull

char h = 'r';
string i = "nepal";
bool j = true;

// Declaring and initialise varialbes
byte age = 45; // Explicit type
var age1 = 45; // Implicit type

// nullable variable
float? radius = 56.78f; //nullable variable is radius?
radius = null;

// Array
// One dimensional
byte[] scores = new byte[1000];
scores[0] = 45;
scores[1] = 15;
scores[2] = 75;
scores[3] = 42;
scores[4] = 45;
scores[5] = 40;

var x = scores[49];

byte[] scores1 = {45, 15, 75};

// Multi dimensional
double[,] matrix = new double[2,3];
matrix[0,0] =34.5;
matrix[1,2] = 67.1;

double[,] table = {{2, 3}, {5,6}};

//Jagged array
short[][] data = new short[3][];

short[] dp1 = {2,3,4,5,6};
data[0] = dp1;

//2,3,4,5,6
// 3,4,5
//1,2
//3,4,5,6,7,8,9

*/

/*
// Assignment QNo. 1
// Program to calculate area of circle.
using System;
class Circle
{
    static void Main(string[] args)
    {
        Console.Write("Enter Radius: ");
        double Radious = Convert.ToDouble(Console.ReadLine());
        double Area = Math.PI * Radious * Radious;
        Console.WriteLine("Area of circle: " + Area);
        Console.ReadKey();
    }
}
*/

// Assignment QNo. 2
// Program to convert entered days into years, weeks, and days.

using System;

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