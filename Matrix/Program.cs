using System;
using System.Threading;

namespace Program
{
    internal class MatrixEffect
    {
        /*
           * Parameter meaning:
           *   height: the height of the effect matrix (Recommended value: Console.WindowHeight).
           *   width: the width of the matrix effect (Recommended value: Console.WindowWidth).
           *   charset: controls which characters will be displayed.
           *   numRand: controls whether the characters are close together (the larger the value, the closer the characters are).
           *   refreshTime: effect delay time (the smaller the value, the faster the effect).
           */
        public static void matrixEffect(int height, int width, string charset, int refreshTime, int closetRate)
        {
            char[,] matrixTable = new char[height, width];
            bool isTheFisrtTime = true; // At the first time, we have to fill in the characters in the
                                        // effect range as quickly as possible, so we don't need to delay
                                        // (refreshTime = 0)

            Random random = new Random();

            while (true)
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        matrixTable[i, j] = ' ';
                    }
                }

                for (int i = 0; i < closetRate; i++)
                {
                    int posX = random.Next(height);
                    int posY = random.Next(width);
                    int len = random.Next(height - random.Next(14));

                    if (len + posX > height)
                    {
                        len = height - posX;
                    }

                    for (int j = 0; j < len; j++)
                    {
                        matrixTable[posX + j, posY] = charset[random.Next(charset.Length)];
                    }
                }

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        Console.Write(matrixTable[i, j]);
                    }
                    Console.Write("\n");

                    if (!isTheFisrtTime)
                    {
                        Thread.Sleep(refreshTime);
                    }
                }

                isTheFisrtTime = false;
            }
        }
        public static void showHelp()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The simple matrix effect like cmatrix on Linux!");
            Console.WriteLine("\nCommand:");
            Console.WriteLine("matrix.exe [--width value] [--charset value] [--refreshTime value] [--closeRate value]");
            Console.WriteLine("Parameter meaning:\r\n" +
                              "\t width: the width of the matrix effect (Default: Console width).\r\n" +
                              "\t charset: controls which characters will be displayed (Default: 01).\r\n" +
                              "\t refresh time: effect delay time in miliseconds (the smaller the value, the faster the effect) (default: 45).\r\n" +
                              "\t close rate: controls whether the characters are close together (the larger the value, the closer the characters are) (default: 25).\r\n");
            Console.WriteLine("\n\nEx: \nmatrix.exe");
            Console.WriteLine("matrix.exe --width 100 --charset 0123456789 --refreshTime 20 --closeRate 50");
            Console.WriteLine("matrix.exe --refreshTime 1000");
        }

        public static int Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorVisible = false;

            int i = 0;
            int height = Console.WindowHeight;
            int width = Console.WindowWidth;
            string charset = "10";
            int refreshTime = 45;
            int closeRate = 25;

            if (args.Length % 2 != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Missing parameter!");
                Console.ResetColor();
                showHelp();
                return -1;
            }
            while (i < args.Length)
            {
                if (args[i] == "--width")
                {
                    width = int.Parse(args[i + 1]) == 0 ? width : int.Parse(args[i + 1]);
                    i += 2;
                    continue;
                }

                if (args[i] == "--charset")
                {
                    charset = args[i + 1];
                    i += 2;
                    continue;
                }

                if (args[i] == "--refreshTime")
                {
                    refreshTime = int.Parse(args[i + 1]) == 0 ? refreshTime : int.Parse(args[i + 1]);
                    i += 2;
                    continue;
                }

                if (args[i] == "--closeRate")
                {
                    closeRate = int.Parse(args[i + 1]) == 0 ? closeRate : int.Parse(args[i + 1]);
                    i += 2;
                    continue;
                }

                ++i;
            }

            matrixEffect(height, width, charset, refreshTime, closeRate);

            return 0;
        }
    }
}