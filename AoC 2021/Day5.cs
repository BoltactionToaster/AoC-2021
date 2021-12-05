using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2021
{
    class Day5
    {
        public void Part1()
        {
            HashSet<Vector2> vecsChecked = new HashSet<Vector2>();
            HashSet<Vector2> vecsUsed = new HashSet<Vector2>();

            foreach (string l in lines)
            {
                var fromtoVectors = l.Split(" -> ");
                var vecFrom = fromtoVectors[0].Split(",");
                Vector2 vecFromInt = new Vector2(Convert.ToInt32(vecFrom[0]), Convert.ToInt32(vecFrom[1]));
                var vecTo = fromtoVectors[1].Split(",");
                Vector2 vecToInt = new Vector2(Convert.ToInt32(vecTo[0]), Convert.ToInt32(vecTo[1]));


                Vector2 diff = new Vector2((int)vecToInt.x - (int)vecFromInt.x, (int)vecToInt.y - (int)vecFromInt.y);

                int ySign = Math.Sign(diff.y);
                int xSign = Math.Sign(diff.x);

                Vector2 absDiff = new Vector2(Math.Abs(diff.x) + 1, Math.Abs(diff.y) + 1);

                if (vecFromInt.x == vecToInt.x || vecFromInt.y == vecToInt.y)
                {
                    for (int x = 0; x < absDiff.x; x++)
                    {
                        for (int y = 0; y < absDiff.y; y++)
                        {
                            var vector = new Vector2(vecFromInt.x + x * xSign, vecFromInt.y + y * ySign);
                            if (vecsChecked.Contains(vector))
                            {
                                vecsUsed.Add(vector);
                            }
                            else
                            {
                                vecsChecked.Add(vector);
                            }
                        }
                    }
                }
            }
            Console.WriteLine(vecsUsed.Count());
        }

        public void Part2()
        {

            HashSet<Vector2> vecsChecked = new HashSet<Vector2>();
            HashSet<Vector2> vecsUsed = new HashSet<Vector2>();

            foreach (string l in lines)
            {
                var fromtoVectors = l.Split(" -> ");
                var vecFrom = fromtoVectors[0].Split(",");
                Vector2 vecFromInt = new Vector2(Convert.ToInt32(vecFrom[0]), Convert.ToInt32(vecFrom[1]));
                var vecTo = fromtoVectors[1].Split(",");
                Vector2 vecToInt = new Vector2(Convert.ToInt32(vecTo[0]), Convert.ToInt32(vecTo[1]));


                Vector2 diff = new Vector2((int)vecToInt.x - (int)vecFromInt.x, (int)vecToInt.y - (int)vecFromInt.y);

                int ySign = Math.Sign(diff.y);
                int xSign = Math.Sign(diff.x);

                Vector2 absDiff = new Vector2(Math.Abs(diff.x) + 1, Math.Abs(diff.y) + 1);

                if (vecFromInt.x == vecToInt.x || vecFromInt.y == vecToInt.y)
                {
                    for (int x = 0; x < absDiff.x; x++)
                    {
                        for (int y = 0; y < absDiff.y; y++)
                        {
                            var vector = new Vector2(vecFromInt.x + x * xSign, vecFromInt.y + y * ySign);
                            if (vecsChecked.Contains(vector))
                            {
                                vecsUsed.Add(vector);
                            }
                            else
                            {
                                vecsChecked.Add(vector);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < absDiff.x; i++)
                    {
                        //Console.WriteLine($"Position {(int)chosenVec.x + i},{chosenVec.y} is getting overlapped up");
                        var vector = new Vector2(((int)vecFromInt.x + i * xSign), ((int)vecFromInt.y + i * ySign));
                        if (vecsChecked.Contains(vector))
                        {
                            vecsUsed.Add(vector);
                        }
                        else
                        {
                            vecsChecked.Add(vector);
                        }
                    }
                }
            }
            Console.WriteLine(vecsUsed.Count());
        }

        public Day5(string[] input)
        {
            this.lines = input;
        }

        public struct UIntVector2
        {
            public uint x;
            public uint y;
            public UIntVector2(uint x, uint y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public struct Vector2
        {
            public int x;
            public int y;
            public Vector2(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        //input gets changed in main
        string[] lines = new string[]
        {
            "don't you dare use this"
        };
    }
}

