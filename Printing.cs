using System;
using System.Collections.Generic;
using static System.Console;
namespace webAPI_inlämning_2
{
    class Printing
    {

        public void PrintListHorisontal<T>(int x, int y, List<T> list, string printStringFormat)
        {
            int indexer = 1;

            SetCursorPosition(x, y += 3);
            foreach (var listItem in list)
            {
                if (x > 90)
                {
                    y++;
                    x = 60;
                }
                SetCursorPosition(x, y);
                string categoryString = printStringFormat;
                WriteLine(categoryString);
                x += categoryString.Length + 2;

            }

        }

    }
}
