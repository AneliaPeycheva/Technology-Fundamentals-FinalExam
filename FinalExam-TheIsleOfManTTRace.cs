using System;
using System.Text;
using System.Text.RegularExpressions;

namespace FinalExam_TheIsleOfManTTRace
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<name>[#$%*&]([A-Za-z]+)[#$%*&])=(?<length>[0-9]+)!!(?<code>.+)$";
            var decripted = new StringBuilder();
            while (true)
            {
                string input = Console.ReadLine();
                var match = Regex.Match(input, pattern);
                if (!match.Success)
                {
                    Console.WriteLine("Nothing found!");
                    continue;
                }
                else
                {
                    string name = match.Groups[1].Value;
                    string nameWithSines = match.Groups[2].Value;
                    int length = int.Parse(match.Groups[3].Value);
                    string code = match.Groups[4].Value;
                    int lengthOfCode = code.Length;
                    char symbolBegining = nameWithSines[0];
                    char symbolEnding = nameWithSines[nameWithSines.Length - 1];
                    if (symbolBegining == symbolEnding && lengthOfCode == length)
                    {
                        //"Coordinates found! {nameOfRacer} -> {geohashcode}"
                        for (int i = 0; i < code.Length; i++)
                        {
                            char newSymbol = (char)(code[i] + length);
                            decripted.Append(newSymbol);
                        }                        
                        Console.WriteLine($"Coordinates found! {name} -> {decripted.ToString()}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                        continue;
                    }
                }
            }

        }
    }
}

