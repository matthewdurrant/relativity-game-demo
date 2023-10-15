using System.Diagnostics.Metrics;

namespace RelativityDemo
{
    /// <summary>
    /// Implement the Ship Terminal with the default system console.
    /// </summary>
    internal class ConsoleTerminal : IShipTerminal
    {
        const int minSleepTime = 5;
        const int maxSleepTime = 50;
        const int beepProbability = 25; //Higher the less likely e.g 10 = 1 in 10

        Random rand;

        public ConsoleTerminal()
        {
            ResetColor();
            rand = new Random();
        }

        public void Clear()
        {
            Console.Clear();
        }

        private void RandomSleep()
        {
            int sleepTime = rand.Next(5, 50);
            Spinner(sleepTime);
        }

        private void RandomBeep()
        {
            int random = rand.Next(1, beepProbability);
            if (random == 1)
                Console.Beep();
        }

        public void WriteLine(string text)
        {
            RandomSleep();
            if (text.ToLower().StartsWith("warning") || text.ToLower().StartsWith("error"))
            {
                WriteError(text);
            }
            else
            {
                Console.WriteLine(text);
            }
            RandomBeep();
        }
        public void WriteLine()
            => Console.WriteLine();

        public int GetInt()
        {
            Console.Write(">");
            string input = Console.ReadLine();

            int v;
            if (!int.TryParse(input, out v))
            {
                WriteError("Please input a valid numeric value.");
                return GetInt();
            }

            return v;
        }

        public float GetFloat()
        {
            Console.Write(">");
            string input = Console.ReadLine();

            float v;
            if (!float.TryParse(input, out v))
            {
                WriteError("Please input a valid numeric value.");
                return GetFloat();
            }

            return v;
        }


        public void WriteBlue(string v)
        {
            WriteColor(v, ConsoleColor.White, ConsoleColor.Blue);
        }

        public void WriteError(string v)
        {
            WriteColor(v, ConsoleColor.White, ConsoleColor.Red);
        }

        public void WriteSuccess(string v)
        {
            WriteColor(v, ConsoleColor.White, ConsoleColor.Green);
        }

        private void WriteColor(string text, ConsoleColor fg, ConsoleColor bg)
        {
            Console.Beep();
            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;
            Console.Write(text);
            ResetColor();
            Console.WriteLine();
        }

        private void ResetColor()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Spinner(int time)
        {
            //Time should be in ms. However the spinner seems to take longer than requested. Strange.
            int counter = 0;
            while (counter < time)
            {
                string v = (counter % 4) switch
                {
                    0 => "|",
                    1 => "/",
                    2 => "-",
                    3 => "\\",
                    _ => "o"
                };

                Console.Write(v);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                counter++;
                Thread.Sleep(1);
            }

            Console.Write("");

        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
