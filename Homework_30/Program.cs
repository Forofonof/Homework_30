using System;
using System.Xml.Serialization;

internal class Program
{
    static void Main(string[] args)
    {
        string[,] map =
            { {"#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"},
              {"#","@"," "," "," "," ","#"," "," "," ","#"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","#"," "," "," "," "," "," ","#","#","#"},
              {"#"," "," "," "," "," "," "," "," ","#","#"," ","#","#","#","#"," ","#","#","#"," ","#","#","#"," "," "," "," "," "," ","#"," ","#"," ","#","#","#","#","#","#"},
              {"#"," "," "," "," "," ","#"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","#"},
              {"#","#"," "," ","#","#","#"," ","#","#","#","#","#"," ","#"," ","#","#"," "," "," ","#"," ","#","#","#","#","#","#"," ","#","#","#"," ","#","#"," ","#"," ","#"},
              {"#"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","#"},
              {"#"," "," "," ","#"," ","#","#","#","#","#"," "," "," ","#"," "," ","#"," ","#","#","#"," ","#","#","#"," ","#"," "," ","#","#","#"," ","#"," ","#","#"," ","#"},
              {"#"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","#"},
              {"#"," "," ","#","#"," ","#","#","#"," ","#"," ","#"," "," "," "," "," "," ","#","#"," "," ","#"," "," "," ","#","#","#","#","#","#","#","#","#","#","#"," ","#"},
              {"#"," "," ","#"," "," "," "," "," ","#"," "," ","#"," ","#","#","#","#","#","#","#"," ","#","#","#","#"," ","#"," ","#","#"," ","#","#"," ","#"," ","#"," ","#"},
              {"#"," "," ","#"," "," "," ","#"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","#"},
              {"#"," "," ","#"," ","#","#","#"," ","#","#","#","#","#","#","#","#","#","#","#","#"," ","#"," "," ","#","#","#"," ","#","#"," ","#","#"," ","#","#"," "," ","#"},
              {"#"," "," "," "," "," "," "," "," ","#"," "," "," "," "," "," "," "," "," ","#"," "," ","#"," ","#","#"," ","#"," ","#","#"," ","#"," "," "," ","#"," "," ","#"},
              {"#"," "," "," "," ","#","#","#"," ","#"," "," "," "," ","#","#","#","#","#"," "," ","#","#"," "," "," "," "," "," "," "," "," ","#","#","#"," ","#"," "," ","#"},
              {"#"," "," ","#"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","#"," ","#"," ","#","#","#","#","#"," ","#","#"," "," "," ","#"," ","#"," "," ","#"},
              {"#"," "," ","#"," "," "," ","#"," "," ","#","#","#","#","#","#","#","#"," ","#"," ","#"," ","#","#","#","#","#"," ","#","#"," ","#"," ","#"," ","#"," "," ","#"},
              {"#"," ","#","#","#","#","#","#","#","#","#"," "," "," "," "," "," ","#"," "," "," "," "," ","#","#","#","#","#"," "," ","#"," ","#"," "," "," "," ","#"," ","#"},
              {"#"," "," "," "," "," ","#"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","#"," ","#"},
              {"#","#","#","#"," "," ","#","#"," ","#","#","#"," ","#","#","#"," ","#","#","#"," ","#","#","#"," ","#","#","#","#"," ","#"," ","#"," ","#","#"," ","#","#","#"},
              {"#","#","#","#"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","#","#","#"},
              {"#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#","#"}
            };

        int pacmanPositionX;
        int pacmanPositionY;
        int pacmanDirectionX = 0;
        int pacmanDirectionY = 0;
        bool isPlaying = true;

        Console.CursorVisible = false;

        RenderMap(map);

        FindPlayer(map, out pacmanPositionX, out pacmanPositionY);

        while (isPlaying)
        {
            if (Console.KeyAvailable)
            {
                Console.CursorVisible = false;

                SelectDirectionPlayer(ref pacmanDirectionX, ref pacmanDirectionY);

                MovePacman(map, ref pacmanPositionY, ref pacmanPositionX, pacmanDirectionX, pacmanDirectionY);
            }
        }
    }

    static void RenderMap(string[,] map)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Console.Write(map[i, j]);
            }
            Console.WriteLine();
        }
    }

    static void FindPlayer(string[,] map, out int pacmanPositionX, out int pacmanPositionY)
    {
        string symbolPlayerid = "@";
        pacmanPositionX = 0;
        pacmanPositionY = 0;

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j] == symbolPlayerid)
                {
                    pacmanPositionX = j;
                    pacmanPositionY = i;
                }
            }
        }
        DrawSetCursorPosition(pacmanPositionX, pacmanPositionY);
    }

    static void SelectDirectionPlayer(ref int pacmanDirectionX, ref int pacmanDirectionY)
    {
        pacmanDirectionX = 0;
        pacmanDirectionY = 0;

        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                pacmanDirectionX = -1;
                break;
            case ConsoleKey.DownArrow:
                pacmanDirectionX = 1;
                break;
            case ConsoleKey.LeftArrow:
                pacmanDirectionY = -1;
                break;
            case ConsoleKey.RightArrow:
                pacmanDirectionY = 1;
                break;
        }
    }

    static void MovePacman(string[,] map, ref int pacmanPositionY, ref int pacmanPositionX, int pacmanDirectionX, int pacmanDirectionY)
    {
        string symbolPlayerid = "@";
        string symbolWall = "#";
        string symbolMove = " ";

        if (map[pacmanPositionX + pacmanDirectionX, pacmanPositionY + pacmanDirectionY] != symbolWall)
        {
            DrawSetCursorPosition(pacmanPositionY, pacmanPositionX);
            Console.Write(symbolMove);

            pacmanPositionX += pacmanDirectionX;
            pacmanPositionY += pacmanDirectionY;

            DrawSetCursorPosition(pacmanPositionY, pacmanPositionX);
            Console.Write(symbolPlayerid);
        }
    }

    static void DrawSetCursorPosition(int pacmanPositionY, int pacmanPositionX)
    {
        Console.SetCursorPosition(pacmanPositionY, pacmanPositionX);
    }
}