using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace MIHS2017
{
    [TestClass]
    public class UndergroundMazeTest
    {
        [TestMethod]
        public void TestUndergroundMaze()
        {
            Assert.AreEqual(
@"########
#      #
###### #
##S### #
## #.. #
## ### #
#.     #
########
", UndergroundMaze(new string[]
            {
                "########",
                "#S.....#",
                "######.#",
                "##X###.#",
                "##.#...#",
                "##.###.#",
                "#......#",
                "########",
            }));

            Assert.AreEqual(
@"########
#..    #
### ####
#   #..#
# ##   #
# #. # #
#    #S#
########
", UndergroundMaze(new string[]
            {
                "########",
                "#.....S#",
                "###.####",
                "#...#..#",
                "#.##...#",
                "#.#..#.#",
                "#....#X#",
                "########",
            }));
        }

        private static int[] deltas = new int[] { 0, 1, 0, -1 };

        public static string UndergroundMaze(string[] input)
        {
            int startX = 0;
            int startY = 0;

            char[,] maze = new char[8, 8];
            for(int i = 0; i < input.Length; i++)
            {
                for(int j = 0; j < input[i].Length; j++)
                {
                    maze[i, j] = input[i][j];
                    if (maze[i, j] == 'S')
                    {
                        startX = i;
                        startY = j;
                    }
                }
            }

            Search(maze, startX, startY);

            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < maze.GetLength(0); i++)
            {
                for(int j = 0; j < maze.GetLength(1); j++)
                    sb.Append(maze[i, j]);

                sb.AppendLine();
            }

            return sb.ToString();
        }

        private static bool Search(char[,] maze, int x, int y)
        {
            char current = maze[x, y];
            if (current == 'X')
            {
                maze[x, y] = 'S';
                return true;
            }

            if (current == '#' || current == ' ')
                return false;

            maze[x, y] = ' ';
            for (int i = 0; i < deltas.Length; i++)
            {
                if (Search(maze, x + deltas[i], y + deltas[(i + 1) % deltas.Length]))
                    return true;
            }

            maze[x, y] = '.';

            return false;
        }
    }
}
