using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam_PracticeSessions
{
    class Program
    {
        static void Main(string[] args)
        {
            var roadsAndRacers = new Dictionary<string, List<string>>();
            string input = string.Empty;
            while ((input = Console.ReadLine())!= "END")
            {
                string[] inputInLines = input.Split("->");
                string command = inputInLines[0];
                switch (command)
                {
//                    •	"Add->{road}->{racer}"
//o Add the road if it doesn't exist in your collection and add the racer to it.
                    case "Add":
                        string road = inputInLines[1];
                        string racer = inputInLines[2];
                        if (!roadsAndRacers.ContainsKey(road))
                        {
                            roadsAndRacers.Add(road, new List<string>());
                        }
                        roadsAndRacers[road].Add(racer);
                        break;
                        //"Move->{currentRoad}->{racer}->{nextRoad}"
                        //o Find the racer on the current road and move him to the next one, only
                        //if he exists in the current road.Both roads will always 
                           // be valid and will already exist.
                    case "Move":
                        string currentRoad = inputInLines[1];
                        string racerToMove = inputInLines[2];
                        string nextRoad= inputInLines[3];
                        if (roadsAndRacers.ContainsKey(currentRoad) && roadsAndRacers[currentRoad].Contains(racerToMove))
                        {
                            roadsAndRacers[currentRoad].Remove(racerToMove);
                            roadsAndRacers[nextRoad].Add(racerToMove);
                        }                  
                        break;
                    //•	"Close->{road}"
                    case "Close":                     
                        string roadToMove = inputInLines[1];
                        if (roadsAndRacers.ContainsKey(roadToMove))
                        {
                            roadsAndRacers.Remove(roadToMove);
                        }
                        break;
                            default:
                        break;
                }
            }
            Console.WriteLine("Practice sessions:");
            foreach (var kvp in roadsAndRacers.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                Console.WriteLine(kvp.Key);
                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"++{item}");
                }
            }
        }
    }
}
