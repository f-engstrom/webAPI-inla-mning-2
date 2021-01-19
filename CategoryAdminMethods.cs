using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebAPI_Inlämning_1;
using static System.Console;

namespace webAPI_inlämning_2
{
    class CategoryAdminMethods
    {
        static API a = new API();
        static public void ListCategories()
        {

            Clear();

            Printing p = new Printing();

            Uri categoryAPI = new Uri("https://localhost:44373/api/category");

            List<Category> categories = a.GetResourceAsync<Category>(categoryAPI).Result;



            int x = 10;
            int y = 10;

            SetCursorPosition(x, y += 3);
            foreach (var category in categories)
            {
                if (x > 30)
                {
                    y++;
                    x = 10;
                }
                SetCursorPosition(x, y);
                string categoryString = $"{category.Id}. {category.Name}";
                WriteLine(categoryString);
                x += categoryString.Length + 2;

            }

            WriteLine("View (ID): ");


            int id = Convert.ToInt32(ReadLine());

            Category chosenCategory = categories.FirstOrDefault(x => x.Id == id);
            ListCategory(chosenCategory);


        }

        internal static void AddCategory()
        {


            Clear();

            Uri categoryAPI = new Uri("https://localhost:44373/api/category");
            Category category = new Category();


            category = CreateCategoryFromInput();

            HttpResponseMessage response;

            try
            {
                response = a.PostResourceAsync(categoryAPI, category).Result;
                Clear();
                SetCursorPosition(Program.menuCursorPosLeft, Program.menuCursorPosTop);
                WriteLine($"Category added sucessfully. {response}");
                Thread.Sleep(2000);

            }
            catch (Exception e)
            {
                Clear();
                SetCursorPosition(Program.menuCursorPosLeft, Program.menuCursorPosTop);

                WriteLine($"Something went wrong with adding the category.");
                Thread.Sleep(2000);

            }



        }

        internal static void DeleteCategory()
        {

            Uri categoryAPI = new Uri("https://localhost:44373/api/category");

            Clear();
            bool b;

            Uri productAPI = new Uri("https://localhost:44373/api/category");

            List<Category> categories = a.GetResourceAsync<Category>(productAPI).Result;

            int x = 10;
            int y = 10;

            SetCursorPosition(x, y += 3);
            foreach (var category in categories)
            {
                if (x > 30)
                {
                    y++;
                    x = 10;
                }
                SetCursorPosition(x, y);
                string categoryString = $"{category.Id}. {category.Name}";
                WriteLine(categoryString);
                x += categoryString.Length + 2;

            }

            WriteLine("Choose category to delete (ID): ");


            int id = Convert.ToInt32(ReadLine());

            WriteLine("Are you sure you want to delete this Category? (Y)es or (N)o");

            ConsoleKeyInfo consoleKeyInfo;

            do
            {
                consoleKeyInfo = ReadKey(true);

                b = !(consoleKeyInfo.Key == ConsoleKey.Y || consoleKeyInfo.Key == ConsoleKey.N);
            } while (b);

            if (consoleKeyInfo.Key == ConsoleKey.Y)
            {

                try
                {
                    var response = a.DeleteResourceAsync(categoryAPI, id).Result;
                    Clear();
                    WriteLine($"Category sucessfully deleted. {response}");
                    Thread.Sleep(2000);

                }
                catch (Exception e)
                {
                    Clear();
                    WriteLine($"Something went wrong with deleting the category.");
                    Thread.Sleep(2000);

                }

            }



        }

        private static Category CreateCategoryFromInput()
        {
            bool customerExists = false;
            bool b = true;
            bool doNotExitLoop = true;


            Category category = new Category();

            int x = 10;
            int y = 10;

            string nameInput = "Name: ";
            string imageUrlInput = "ImageUrl: ";

            do
            {
                SetCursorPosition(x, y);
                WriteLine(nameInput);
                SetCursorPosition(x, y + 2);
                WriteLine(imageUrlInput);



                SetCursorPosition(x + nameInput.Length, y);
                string categoryName = ReadLine();
                SetCursorPosition(x + imageUrlInput.Length, y + 2);
                string categoryImageUrl = ReadLine();

                SetCursorPosition(x, y + 9);
                WriteLine("Is this correct? (Y)es or (N)o");

                ConsoleKeyInfo consoleKeyInfo;

                do
                {
                    consoleKeyInfo = ReadKey(true);

                    b = !(consoleKeyInfo.Key == ConsoleKey.Y || consoleKeyInfo.Key == ConsoleKey.N);
                } while (b);


                if (consoleKeyInfo.Key == ConsoleKey.Y)
                {

                    category.Name = categoryName;
                    category.ImageUrl = categoryImageUrl;
                    doNotExitLoop = false;


                }

                if (consoleKeyInfo.Key == ConsoleKey.N)
                {
                    Clear();

                }

            } while (doNotExitLoop);

            return category;
        }


        private static void ListCategory(Category category)
        {

            Clear();
            SetCursorPosition(Program.menuCursorPosLeft, Program.menuCursorPosTop);
            WriteLine($"Id: {category.Id}");
            SetCursorPosition(Program.menuCursorPosLeft, Program.menuCursorPosTop + 1);

            WriteLine($"Name: {category.Name}");
            SetCursorPosition(Program.menuCursorPosLeft, Program.menuCursorPosTop + 2);

            WriteLine($"Image Url: {category.ImageUrl}");

            ConsoleKeyInfo inputKey;
            bool incorrectKey;
            do
            {

                inputKey = ReadKey(true);

                incorrectKey = inputKey.Key != ConsoleKey.Escape;



            } while (incorrectKey);

            ListCategories();




        }
    }
}