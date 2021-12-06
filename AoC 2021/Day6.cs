using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2021
{
    class Day6
    {
        public void Part1()
        {
            var fish = lines[0].Split(",").Select(x => Convert.ToByte(x)).ToList();
            int currentDay = 0;
            int maxDay = 80;
            for(; currentDay < maxDay; currentDay++)
            {
                int numberOfFishToAdd = 0;
                for(int i = 0; i < fish.Count; i++)
                {
                    if(fish[i] == 0)
                    {
                        fish[i] = 6;
                        numberOfFishToAdd++;
                    }
                    else
                        fish[i]--;
                }
                for(; numberOfFishToAdd > 0; numberOfFishToAdd--)
                {
                    fish.Add(8);
                }
            }
            Console.WriteLine(fish.Count);
        }

        public void Part2()
        {
            var fishToProcess = lines[0].Split(",").Select(x => Convert.ToInt32(x)).ToList();
            long[] fish = new long[10];
            foreach(int f in fishToProcess)
            {
                fish[f + 1]++;
            }

            int currentIndex = 0;

            for(int i = 0; i <= 256; i++)
            {
                //has to be 1 above the actual amount since that's when it will actually activate
                var ind = currentIndex + 9;
                if(ind >= fish.Length)
                    ind -= fish.Length;
                fish[ind] += fish[currentIndex];

                //has to be 1 above the actual amount since that's when it will actually activate
                ind = currentIndex + 7;
                if(ind >= fish.Length)
                    ind -= fish.Length;
                fish[ind] += fish[currentIndex];
                fish[currentIndex] = 0;

                currentIndex++;
                if(currentIndex >= fish.Length)
                    currentIndex = 0;
            }
            Console.WriteLine(fish.Sum());
        }



        public Day6(string[] input)
        {
            this.lines = input;
        }

        //input gets changed in main from the constructor
        string[] lines = new string[]
        {
            "don't you dare use this"
        };
    }
}

