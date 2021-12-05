using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2021
{
    class Day4
    {
        public void Part1()
        {
            var lotteryNums = lines[0].Split(",");
            int lotteryIndex = -1;
            int bingoYIndex = 0;
            List<BingoNumber[,]> bingoNumbers = new List<BingoNumber[,]>();
            for (int i = 1; i < lines.Length; i++)
            {
                if(lines[i] == "")
                {
                    bingoNumbers.Add(new BingoNumber[5, 5]);
                    lotteryIndex++;
                    bingoYIndex = 0;
                }
                else
                {
                    var len = lines[i].Split(" ");
                    int x = 0;
                    for(int z = 0; z < len.Length; z++)
                    {
                        if(len[z] != "")
                        {
                            bingoNumbers[lotteryIndex][x, bingoYIndex] = new BingoNumber(len[z], false);
                            x++;
                        }
                    }
                    bingoYIndex++;
                }
            }
            foreach(string lot in lotteryNums)
            {
                for(lotteryIndex = 0; lotteryIndex < bingoNumbers.Count; lotteryIndex++)
                {
                    int[] xRows = new int[5];
                    int[] yRows = new int[5];
                    for(int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            if (bingoNumbers[lotteryIndex][x, y].num == lot || bingoNumbers[lotteryIndex][x,y].activated)
                            {
                                bingoNumbers[lotteryIndex][x, y].activated = true;
                                xRows[x]++;
                                yRows[y]++;
                            }
                        }
                    }
                    if(xRows.Where(x => x == 5).Count() >= 1)
                    {
                        //bingoNumbers[lotteryIndex].Select(n => Convert.ToInt64(n))
                        var select = from BingoNumber item in bingoNumbers[lotteryIndex]
                        where !item.activated
                        select item;
                        Console.WriteLine($"Sum: {select.Select(n => Convert.ToInt64(n.num)).Sum()}, Last drawn lot {Convert.ToInt64(lot)}");
                        Console.WriteLine(select.Select(n => Convert.ToInt64(n.num)).Sum() * Convert.ToInt64(lot));
                        return;
                    }
                    else if(yRows.Where(x => x == 5).Count() >= 1)
                    {
                        var select = from BingoNumber item in bingoNumbers[lotteryIndex]
                                     where !item.activated
                                     select item;
                        Console.WriteLine($"Sum: {select.Select(n => Convert.ToInt64(n.num)).Sum()}, Last drawn lot {Convert.ToInt64(lot)}");
                        Console.WriteLine(select.Select(n => Convert.ToInt64(n.num)).Sum() * Convert.ToInt64(lot));
                        return;
                    }
                }
            }
        }

        public void Part2()
        {
            var lotteryNums = lines[0].Split(",");
            int lotteryIndex = -1;
            int bingoYIndex = 0;
            List<BingoBoard> bingoNumbers = new List<BingoBoard>();
            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i] == "")
                {
                    bingoNumbers.Add(new BingoBoard(false, new BingoNumber[5, 5]));
                    lotteryIndex++;
                    bingoYIndex = 0;
                }
                else
                {
                    var len = lines[i].Split(" ");
                    int x = 0;
                    for (int z = 0; z < len.Length; z++)
                    {
                        if (len[z] != "")
                        {
                            bingoNumbers[lotteryIndex].bingoNumbers[x, bingoYIndex] = new BingoNumber(len[z], false);
                            x++;
                        }
                    }
                    bingoYIndex++;
                }
            }

            int wonBoards = 0;
            foreach (string lot in lotteryNums)
            {
                for (lotteryIndex = 0; lotteryIndex < bingoNumbers.Count; lotteryIndex++)
                {
                    int[] xRows = new int[5];
                    int[] yRows = new int[5];

                    for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            if (bingoNumbers[lotteryIndex].bingoNumbers[x, y].num == lot || bingoNumbers[lotteryIndex].bingoNumbers[x, y].activated)
                            {
                                bingoNumbers[lotteryIndex].bingoNumbers[x, y].activated = true;
                                xRows[x]++;
                                yRows[y]++;
                            }
                        }
                    }

                    if (xRows.Where(x => x == 5).Count() >= 1 && !bingoNumbers[lotteryIndex].boardWon)
                    {
                        wonBoards++;
                        bingoNumbers[lotteryIndex] = new BingoBoard(true, bingoNumbers[lotteryIndex].bingoNumbers);
                    }
                    else if (yRows.Where(x => x == 5).Count() >= 1 && !bingoNumbers[lotteryIndex].boardWon)
                    {
                        wonBoards++;
                        bingoNumbers[lotteryIndex] = new BingoBoard(true ,bingoNumbers[lotteryIndex].bingoNumbers);
                    }

                    if (bingoNumbers.Count - wonBoards == 0)
                    {

                        var select = from BingoNumber item in bingoNumbers[lotteryIndex].bingoNumbers
                                     where !item.activated
                                     select item;
                        Console.WriteLine($"Sum: {select.Select(n => Convert.ToInt64(n.num)).Sum()}, Last drawn lot {Convert.ToInt64(lot)}");
                        Console.WriteLine(select.Select(n => Convert.ToInt64(n.num)).Sum() * Convert.ToInt64(lot));
                        return;
                    }
                }
            }
            
        }

        public Day4(string[] input)
        {
            this.lines = input;
        }

        public struct BingoBoard
        {
            public bool boardWon;
            public BingoNumber[,] bingoNumbers;

            public BingoBoard(bool won, BingoNumber[,] nums)
            {
                boardWon = won;
                bingoNumbers = nums;
            }
        }

        public struct BingoNumber
        {
            public string num;
            public bool activated;

            public BingoNumber(string num, bool acti)
            {
                this.num = num;
                activated = acti;
            }
        }

        //input gets changed in main
        string[] lines = new string[]
        {
            "don't you dare use this"
        };
    }
}

