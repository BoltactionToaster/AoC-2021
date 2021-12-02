using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AoC_2021
{
    class Day1
    {
        public void Part1()
        {
            int count = 0;
            int prev = input[0];
            foreach (int i in input)
            {
                if (i > prev)
                {
                    count++;
                }
                prev = i;
            }
            Console.WriteLine(count);
        }

        public void Part2()
        {
            Console.WriteLine(input.Where((n, index) => input.Length > index + 3 && input[index] < input[index + 3]).Count());
        }

        public void Part2Improved()
        {
            Console.WriteLine(input.Skip(3).Where((n, index) => n > input[index]).Count());
        }

        public Day1(int[] input)
        {
            this.input = input;
        }

        //input gets changed in main
        int[] input = new int[]
        {
            199,
            200,
            208,
            210,
            200,
            207,
            240,
            269,
            260,
            263
        };
    }
}

