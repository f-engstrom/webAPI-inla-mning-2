using System;
using static System.Console;

namespace webAPI_inlämning_2
{
    class ProductMenu
    {
        public static void Menu()
        {
            bool shouldNotExit = true;

            while (shouldNotExit)
            {

                Clear();
                SetCursorPosition(Program.menuCursorPosLeft, Program.menuCursorPosTop);
                WriteLine("1. List Products");
                SetCursorPosition(Program.menuCursorPosLeft, Program.menuCursorPosTop+1);

                WriteLine("2. Add Product");
                SetCursorPosition(Program.menuCursorPosLeft, Program.menuCursorPosTop+2);

                WriteLine("3. Delete Product");

                SetCursorPosition(Program.menuCursorPosLeft, Program.menuCursorPosTop+3);

                WriteLine("4. Exit");

                ConsoleKeyInfo keyPressed = ReadKey(true);


                switch (keyPressed.Key)
                {

                    case ConsoleKey.D1:

                        Clear();

                        ProductAdminMethods.ListProducts();

                        break;

                    case ConsoleKey.D2:

                        Clear();

                        ProductAdminMethods.AddProduct();

                        break;


                    case ConsoleKey.D3:

                        Clear();
                        ProductAdminMethods.DeleteProduct();


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