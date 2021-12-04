using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2021
{
    class Day3
    {
        public void Part1()
        {
            List<int> numberOfOnes = new List<int>();
            List<int> totalNumber = new List<int>();
            foreach(string line in lines)
            {
                
                for(int i = 0; i < line.Length; i++)
                {
                    if (totalNumber.Count < line.Length)
                    {
                        totalNumber.Add(1);
                    }
                    else
                    {
                        totalNumber[i]++;
                    }
                    if (line[i] == '1')
                    {
                        if (numberOfOnes.Count < line.Length)
                        {
                            numberOfOnes.Add(1);
                        }
                        else
                        {
                            numberOfOnes[i]++;
                        }
                    }
                    else if (numberOfOnes.Count < line.Length)
                    {
                        numberOfOnes.Add(0);
                    }
                    
                }
            }

            string gammaRate = "";
            string epsilonRate = "";
            int index = 0;
            foreach (int n in totalNumber)
            {
                if(Math.Floor((decimal)n * 0.5m) < numberOfOnes[index])
                {
                    gammaRate += "1";
                    epsilonRate += "0";
                }
                else
                {
                    gammaRate += "0";
                    epsilonRate += "1";
                }
                index++;
            }


            Console.WriteLine($"{Convert.ToInt64(gammaRate, 2)}, {Convert.ToInt64(epsilonRate, 2)}, {Convert.ToInt64(gammaRate, 2) * Convert.ToInt64(epsilonRate, 2)}");
        }


        public void Part2()
        {
            string oxygen = "";
            
            List<string> tempo = lines.ToList();
            for(int i = 0; i < tempo[0].Length; i++)
            {
                int oneCount = 0;
                int zeroCount = 0;
                foreach(string line in tempo)
                {
                    if(line[i] == '1')
                    {
                        oneCount++;
                    }
                    else
                    {
                        zeroCount++;
                    }
                }
                if(oneCount >= zeroCount)
                {
                    oxygen += "1";
                    tempo.RemoveAll(x => x[i] == '0');
                }
                else
                {
                    oxygen += "0";
                    tempo.RemoveAll(x => x[i] == '1');
                }

            }

            string co2 = "";

            tempo = lines.ToList();
            for(int i = 0; i < tempo[0].Length; i++)
            {
                if(tempo.Count == 1)
                {
                    for(int x = co2.Length; x < tempo[0].Length; x++)
                    {
                        co2 += tempo[0][x];
                    }
                    break;
                }
                int oneCount = 0;
                int zeroCount = 0;
                foreach (string line in tempo)
                {
                    if (line[i] == '1')
                    {
                        oneCount++;
                    }
                    else
                    {
                        zeroCount++;
                    }
                }
                if (oneCount >= zeroCount)
                {
                    co2 += "0";
                    tempo.RemoveAll(x => x[i] == '1');
                }
                else
                {
                    co2 += "1";
                    tempo.RemoveAll(x => x[i] == '0');
                }

            }
            Console.WriteLine($"oxy: {oxygen}, co2: {co2}");
            Console.WriteLine($"oxy: {Convert.ToInt64(oxygen, 2)}, co2: {Convert.ToInt64(co2, 2)}, multi: {Convert.ToInt64(oxygen, 2) * Convert.ToInt64(co2, 2)}");
        }

        public Day3(string[] input)
        {
            this.lines = input;
        }

        //input gets changed in main through constructor
        string[] lines = new string[]
        {
            "forward 5",
            "down 5",
            "forward 8",
            "up 3",
            "down 8",
            "forward 2"
        };
    }
}

