using System;
using System.Collections.Generic;
using System.IO;

namespace Day1
{
    public class ElvesAndCalories
    {
        private readonly Dictionary<int, List<string>> _elvesAndCalories = new Dictionary<int, List<string>>();
        private readonly Dictionary<int, int> _elvesAndCaloriesSum = new Dictionary<int, int>();
        private int _biggerBag;
        private int _secondBiggerBag;
        private int _thirdBiggerBag;

        public Dictionary<int, List<string>> ImportFile(string path)
        {
            var lines = File.ReadAllLines(path);

            var calorieBag = new List<string>();

            var index = 1;

            foreach (var line in lines)
                if (line != "")
                {
                    calorieBag.Add(line);
                }
                else
                {
                    _elvesAndCalories.Add(index, calorieBag);
                    calorieBag = new List<string>();
                    index++;
                }

            return _elvesAndCalories;
        }

        public Dictionary<int, int> SumCalories()
        {
            foreach (var item in _elvesAndCalories)
            {
                var calorieBagSum = 0;

                foreach (var i in item.Value) 
                    calorieBagSum += Convert.ToInt32(i);

                _elvesAndCaloriesSum.Add(item.Key, calorieBagSum);
            }

            return _elvesAndCaloriesSum;
        }

        public void DisplayElvesAndCalories(Dictionary<int, int> dictionary)
        {
            foreach (var item in dictionary) 
                Console.WriteLine($"L'elfe n°{item.Key} a {item.Value} calories");
        }

        public int FindBiggerBag()
        {
            foreach (var item in _elvesAndCaloriesSum)
                if (item.Value > _biggerBag)
                    _biggerBag = item.Value;
            return _biggerBag;
        }

        public int FindSecondBiggerBag(int biggerBag)
        {
            foreach (var item in _elvesAndCaloriesSum)
                if (item.Value != biggerBag && item.Value > _secondBiggerBag)
                    _secondBiggerBag = item.Value;
            return _secondBiggerBag;
        }

        public int FindThirdBiggerBag(int biggerBag, int secondBag)
        {
            foreach (var item in _elvesAndCaloriesSum)
                if (item.Value != biggerBag && item.Value != secondBag && item.Value > _thirdBiggerBag)
                    _thirdBiggerBag = item.Value;
            return _thirdBiggerBag;
        }
    }
}