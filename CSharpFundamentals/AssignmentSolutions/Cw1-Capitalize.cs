using System;
// Class Work-1
Console.Write("Enter Your a word: ");
string word = Console.ReadLine();
string uword = word.ToUpper();
Console.WriteLine($"Given word in upper case:, {uword}");

// Class Work-2
Console.Write("Enter meter to convert ot feet");
var length = Console.ReadLine();
var lenNumber = double.Parse(length);
var feets = lenNumber * 3.2808;
Console.WriteLine($"{lenNumber} metres = {feets} feet");