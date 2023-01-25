using System;

namespace Day1
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var process = new ElvesAndCalories();
            process.ImportFile("/Users/leopaillard/RiderProjects/AOC2022/Day1/calories_list.txt");
            
            var elvesAndCaloriesSumDict = process.SumCalories();
            Console.WriteLine($"Il y a {elvesAndCaloriesSumDict.Count} Elfes");
            
            var biggerBag = process.FindBiggerBag();
            Console.WriteLine($"La plus grosse portion de calories est : {biggerBag} ");
            
            var secondBiggerBag = process.FindSecondBiggerBag(biggerBag);
            var thirdBiggerBag = process.FindThirdBiggerBag(biggerBag, secondBiggerBag);
            Console.WriteLine($"La 2ème est : {secondBiggerBag} ");
            Console.WriteLine($"La 3ème est : {thirdBiggerBag} ");
            
            Console.WriteLine($"La somme de ces trois portions de calories est égale à {biggerBag + secondBiggerBag + thirdBiggerBag}");
        }
    }
}