using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAPI_Inlämning_1;
using static System.Console;

namespace webAPI_inlämning_2
{
    class ProductAdminMethods
    {
        static API p = new API();

        static public void ListProducts()
        {

            Clear();


            Uri productAPI = new Uri("https://localhost:44373/api/product");

            List<Product> products = p.GetResourceAsync<Product>(productAPI).Result;

            foreach (var product in products)
            {

                WriteLine($"Id {product.Id} | Name {product.Name}");

            }

            WriteLine("View (ID): ");

            int id = Convert.ToInt32(ReadLine());

            Product chosenProduct = products.FirstOrDefault(x => x.Id == id);
            ListProduct(chosenProduct);


        }

        public static void AddProduct()
        {
            Uri categoryAPI = new Uri("https://localhost:44373/api/category");
            List<Category> categories = p.GetResourceAsync<Category>(categoryAPI).Result;
            Clear();

            Uri productAPI = new Uri("https://localhost:44373/api/product");
            ProductDTO product = new ProductDTO();


            product = CreateProductFromInput();

            product.CategoriesId = AddCategoriesToProduct(categories);


            try
            {
                var response = p.PostResourceAsync(productAPI, product).Result;
                Clear();
                WriteLine($"Poduct added sucessfully. {response}");
                Thread.Sleep(2000);

            }
            catch (Exception e)
            {
                Clear();
                WriteLine("Something went wrong with adding the product.");
                Thread.Sleep(2000);

            }


        }


        internal static void DeleteProduct()
        {

            Clear();
            bool b;

            Uri productAPI = new Uri("https://localhost:44373/api/product");

            List<Product> products = p.GetResourceAsync<Product>(productAPI).Result;


            foreach (var product in products)
            {

                WriteLine($"Id {product.Id} | Name {product.Name}");

            }

            WriteLine("Choose product to delete (ID): ");


            int id = Convert.ToInt32(ReadLine());

            WriteLine("Are you sure you want to delete this product? (Y)es or (N)o");

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
                    var response = p.DeleteResourceAsync(productAPI, id).Result;
                    Clear();
                    WriteLine($"Poduct sucessfully deleted. {response}");
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

        private static ProductDTO CreateProductFromInput()
        {
            bool customerExists = false;
            bool b = true;
            bool doNotExitLoop = true;


            ProductDTO product = new ProductDTO();

            int x = 10;
            int y = 10;

            string nameInput = "Name: ";
            string descriptionInput = "Description: ";
            string priceInput = "Price: ";
            string imageUrlInput = "ImageUrl: ";

            do
            {
                SetCursorPosition(x, y);
                WriteLine(nameInput);
                SetCursorPosition(x, y + 2);
                WriteLine(descriptionInput);
                SetCursorPosition(x, y + 4);
                WriteLine(priceInput);
                SetCursorPosition(x, y + 6);
                WriteLine(imageUrlInput);



                SetCursorPosition(x + nameInput.Length, y);
                string productName = ReadLine();
                SetCursorPosition(x + descriptionInput.Length, y + 2);
                string productDescription = ReadLine();
                SetCursorPosition(x + priceInput.Length, y + 4);
                decimal productPrice = Convert.ToDecimal(ReadLine());
                SetCursorPosition(x + imageUrlInput.Length, y + 6);
                string productImageUrl = ReadLine();

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

                    product.Name = productName;
                    product.Description = productDescription;
                    product.Price = productPrice;
                    product.ImageUrl = productImageUrl;
                    doNotExitLoop = false;


                }

                if (consoleKeyInfo.Key == ConsoleKey.N)
                {
                    Clear();

                }

            } while (doNotExitLoop);

            return product;
        }

        private static int[] AddCategoriesToProduct(List<Category> categories)
        {

            int x = 60;
            int y = 10;

            bool b = true;
            ConsoleKeyInfo consoleKeyInfo;

           



            SetCursorPosition(x, y);
            WriteLine("Available Categories");
            SetCursorPosition(x, y + 1);
            WriteLine("___________________________________");

            int indexer = 1;
            SetCursorPosition(x, y += 3);
            foreach (var category in categories)
            {
                if (x > 90)
                {
                    y++;
                    x = 60;
                }
                SetCursorPosition(x, y);
                string categoryString = $"{indexer++}. {category.Name}";
                WriteLine(categoryString);
                x += categoryString.Length + 2;

            }

            bool doNotExitLoop = true;

            List<Category> addedCategories = new List<Category>();
            int cursorLeft = CursorLeft;
            int cursorTop = CursorTop;
            int inputCursorPosleft = 10;
            int inputCursorPosTop = 19;
            int categoriesCursorPosLeft = inputCursorPosleft;
            SetCursorPosition(inputCursorPosleft, inputCursorPosTop);
            WriteLine("                                                                              ");

            string categoriesAdded = "Categories added: ";

            SetCursorPosition(inputCursorPosleft, inputCursorPosTop - 1);
            WriteLine(categoriesAdded);
            do
            {
                SetCursorPosition(inputCursorPosleft, inputCursorPosTop);
                WriteLine("Add a category by number: ");
                SetCursorPosition("Add a category by number: ".Length + inputCursorPosleft + 1, inputCursorPosTop);
                int categoryNr = Convert.ToInt32(ReadLine());
                SetCursorPosition("Add a category by number: ".Length + inputCursorPosleft + 1, inputCursorPosTop);
                WriteLine("   ");
                addedCategories.Add(categories[categoryNr - 1]);
                categoriesAdded += categories[categoryNr - 1].Name + ", ";
                SetCursorPosition(inputCursorPosleft, inputCursorPosTop - 1);
                WriteLine(categoriesAdded);

                //SetCursorPosition( categoriesCursorPosLeft+categoriesAdded, inputCUrsorPosTop - 1);
                //foreach (var category in addedCategories)
                //{
                //    string categoryName = $" {category.Name},";

                //    Console.Write(categoryName);
                //    categoriesCursorPosLeft += categoryName.Length + 1;
                //}




                SetCursorPosition(inputCursorPosleft, inputCursorPosTop + 2);
                WriteLine("Add additional category? (Y)es (N)o");
                SetCursorPosition(inputCursorPosleft, inputCursorPosTop + 2);
                do
                {
                    consoleKeyInfo = ReadKey(true);

                    b = !(consoleKeyInfo.Key == ConsoleKey.Y || consoleKeyInfo.Key == ConsoleKey.N);

                } while (b);
                SetCursorPosition(inputCursorPosleft, inputCursorPosTop + 2);
                WriteLine("                                                 ");


                if (consoleKeyInfo.Key == ConsoleKey.N)
                {
                    doNotExitLoop = false;

                }

            } while (doNotExitLoop);



            return addedCategories.Select(x => x.Id).ToArray();
        }



        public static void ListProduct(Product product)
        {

            Clear();

            WriteLine($"Id {product.Id}");
            WriteLine($"Name {product.Name}");
            WriteLine($"Description {product.Description}");
            WriteLine($"Price {product.Price} kr");
            foreach (var category in product.Categories)
            {
                WriteLine($"{category.Name}");
            }

            ConsoleKeyInfo inputKey;
            bool incorrectKey;
            do
            {

                inputKey = ReadKey(true);

                incorrectKey = !(inputKey.Key == ConsoleKey.Escape);



            } while (incorrectKey);

            ListProducts();

        }



    }
}