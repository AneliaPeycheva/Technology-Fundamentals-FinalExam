using System;
using System.Text;
using System.Text.RegularExpressions;

namespace FinalExamGr1_ArrivingInKathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern =@"^(?<name>[A-Za-z0-9!@#$?]+)=(?<length>[0-9]+)<<(?<code>.+)$";
            string input = string.Empty;
            var nameOfMountain = new StringBuilder();
            while ((input=Console.ReadLine())!= "Last note")
            {
                
                var match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    int length=int.Parse(match.Groups["length"].Value);
                    string geohashcode = match.Groups["code"].Value;
                    int currentCodeLength = geohashcode.Length;
                    if (currentCodeLength == length)
                    {
                        for (int i = 0; i < name.Length; i++)  
                        {
                            if (name[i]!= '!' && name[i] != '@' && name[i] != '#' && name[i]!='$' && name[i] != '?')
                            {
                                nameOfMountain.Append(name[i]);
                            }
                        }
                        Console.WriteLine($"Coordinates found! {nameOfMountain} -> {geohashcode}");
                    }
                    else
                    {
                        Console.WriteLine($"Nothing found!");
                    }
                }
                else
                {
                    Console.WriteLine($"Nothing found!");
                }
            }
        }
    }
}
