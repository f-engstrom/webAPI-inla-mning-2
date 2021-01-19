using System;
using static System.Console;

namespace webAPI_inlämning_2
{
    class CategoryMenu
    {
        public static void Menu()
        {
            bool shouldNotExit = true;

            while (shouldNotExit)
            {

                Clear();

                SetCursorPosition(Program.menuCursorPosLeft, Program.menuCursorPosTop);
                WriteLine("1. List Categories");
                SetCursorPosition(Program.menuCursorPosLeft, Program.menuCursorPosTop+1);

                WriteLine("2. Add Category");
                SetCursorPosition(Program.menuCursorPosLeft, Program.menuCursorPosTop+2);

                WriteLine("3. Delete Category");
                SetCursorPosition(Program.menuCursorPosLeft, Program.menuCursorPosTop+3);

                WriteLine("4. Exit");

                ConsoleKeyInfo keyPressed = ReadKey(true);


                switch (keyPressed.Key)
                {

                    case ConsoleKey.D1:

                        Clear();

                        CategoryAdminMethods.ListCategories();

                        break;

                    case ConsoleKey.D2:

                        Clear();


                        CategoryAdminMethods.AddCategory();
                        break;

                    case ConsoleKey.D3:

                        Clear();


                        CategoryAdminMethods.DeleteCategory();
                        break;

                    case ConsoleKey.D4:

                        Clear();


                        shouldNotExit = false;
                        break;




                }



            }




        }
    }
}