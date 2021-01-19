﻿using System;
using static System.Console;

namespace webAPI_inlämning_2
{
    class MainMenu
    {

        public static void Menu()
        {
            bool shouldNotExit = true;

            while (shouldNotExit)
            {

                Clear();

                SetCursorPosition(Program.menuCursorPosLeft, Program.menuCursorPosTop);

                WriteLine("1. Products");
                SetCursorPosition(Program.menuCursorPosLeft, Program.menuCursorPosTop + 1);

                WriteLine("2. Category");
                SetCursorPosition(Program.menuCursorPosLeft, Program.menuCursorPosTop + 2);

                WriteLine("3. Exit");



                ConsoleKeyInfo keyPressed = ReadKey(true);


                switch (keyPressed.Key)
                {

                    case ConsoleKey.D1:

                        Clear();

                        ProductMenu.Menu();

                        break;

                    case ConsoleKey.D2:

                        Clear();
                        CategoryMenu.Menu();

                        break;

                    case ConsoleKey.D3:

                        Clear();

                        shouldNotExit = false;

                        break;

                    case ConsoleKey.D4:

                        Clear();
                        test();

                        break;

                    case ConsoleKey.D5:


                        break;




                }

            }
        }

        public static void test()
        {
            void EraseOldText(int length)
            {
                int cursorLeft = CursorLeft;
                int cursorTop = CursorTop;
                Write(" ".PadRight(length));
                SetCursorPosition(cursorLeft, cursorTop);
            }

            int[,] cursorPositions = new int[2, 2]
            {
                {Program.menuCursorPosLeft, Program.menuCursorPosTop },
                {Program.menuCursorPosLeft, Program.menuCursorPosTop + 1}

            };
            string forstaRutanText = "Första rutan: ";
            string andraRutanText = "Andra rutan: ";
            string inputEtt = "";
            string inputTvå = "";

            SetCursorPosition(cursorPositions[0, 0], cursorPositions[0, 1]);
            WriteLine(forstaRutanText);
            SetCursorPosition(cursorPositions[1, 0], cursorPositions[1, 1]);
            WriteLine(andraRutanText);
            SetCursorPosition(Program.menuCursorPosLeft + 30, Program.menuCursorPosTop);
            WriteLine(" ".PadRight(inputEtt.Length));
            SetCursorPosition(Program.menuCursorPosLeft + 30, Program.menuCursorPosTop);
            WriteLine($"Input ett: {inputEtt}");
            SetCursorPosition(Program.menuCursorPosLeft + 30, Program.menuCursorPosTop + 1);
            WriteLine(" ".PadRight(inputTvå.Length));
            SetCursorPosition(Program.menuCursorPosLeft + 30, Program.menuCursorPosTop + 1);
            WriteLine($"Input två: {inputTvå}");

            SetCursorPosition(forstaRutanText.Length + cursorPositions[0, 0], cursorPositions[0, 1]);

            int moveCursor = 0;

            bool shouldNotExit = true;


            int oldLengthInputEtt = 0;
            int oldLengthInputTvå = 0;

            while (shouldNotExit)
            {


                ConsoleKeyInfo upORDown = ReadKey(true);

                if (oldLengthInputEtt > 0 | oldLengthInputTvå > 0)
                {
                    SetCursorPosition(Program.menuCursorPosLeft + 30, Program.menuCursorPosTop);
                    WriteLine(" ".PadRight(oldLengthInputEtt));

                    SetCursorPosition(Program.menuCursorPosLeft + 30, Program.menuCursorPosTop + 1);
                    WriteLine(" ".PadRight(oldLengthInputTvå));

                }

                SetCursorPosition(Program.menuCursorPosLeft + 30, Program.menuCursorPosTop);
                WriteLine($"Input ett: {inputEtt}");
                SetCursorPosition(Program.menuCursorPosLeft + 30, Program.menuCursorPosTop + 1);
                WriteLine($"Input två: {inputTvå}");



                SetCursorPosition(forstaRutanText.Length + cursorPositions[0, 0], cursorPositions[moveCursor, 1]);
                switch (upORDown.Key)
                {

                    case ConsoleKey.UpArrow:

                        if (moveCursor > 0)
                        {
                            moveCursor--;
                        }

                        break;

                    case ConsoleKey.DownArrow:

                        if (moveCursor < cursorPositions.GetLength(0) - 1)
                        {
                            moveCursor++;
                        }

                        break;

                    case ConsoleKey.Enter:

                        if (moveCursor == 0)
                        {
                            if (inputEtt.Length > 0)
                            {
                                oldLengthInputEtt = inputEtt.Length;
                                EraseOldText(oldLengthInputEtt);

                            }

                            inputEtt = ReadLine() ?? inputEtt;

                        }
                        if (moveCursor == 1)
                        {
                            if (inputTvå.Length > 0)
                            {
                                oldLengthInputTvå = inputTvå.Length;
                                EraseOldText(oldLengthInputTvå);

                            }
                            inputTvå = ReadLine() ?? inputTvå;

                        }

                        break;

                    case ConsoleKey.Escape:
                        shouldNotExit = false;

                        break;

                }


                SetCursorPosition(forstaRutanText.Length + cursorPositions[0, 0], cursorPositions[moveCursor, 1]);





            }

        }
    }
}