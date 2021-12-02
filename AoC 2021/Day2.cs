using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2021
{
    class Day2
    {
        public void Part1()
        {
            int x = 0;
            int y = 0;
            foreach (string line in lines)
            {
                var p = line.Split(' ');
                x += int.Parse(p[1]) * (p[0] == "forward" ? 1 : 0);
                y += int.Parse(p[1]) * (p[0] == "down" ? 1 : p[0] == "up" ? -1 : 0);
            }
            Console.WriteLine(x * y);
        }

        public void Part2()
        {
            int x = 0;
            int y = 0;
            int aim = 0;
            foreach (string line in lines)
            {
                var p = line.Split(' ');
                int temp = int.Parse(p[1]) * (p[0] == "forward" ? 1 : 0);
                x += temp;
                y += aim * temp;
                temp = int.Parse(p[1]) * (p[0] == "down" ? 1 : p[0] == "up" ? -1 : 0);
                aim += temp;
            }
            Console.WriteLine(x * y);
        }

        public Day2(string[] input)
        {
            this.lines = input;
        }

        //input gets changed in main
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

