using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HotelCrudModel
{


    internal class Program
    {
        internal static List<Hotel> Hotels { get; set; }
        private static string Country { get; set; }
        private static string Title { get; set; }
        private static int Key { get; set; }
        private static int Action { get; set; }

        static void Main()
        {
            Action = int.Parse(Console.ReadLine());

            Hotels = new List<Hotel>();
            // Список команд
            static void ListCommand()
            {
                Console.WriteLine("\n1. Add");
                Console.WriteLine("2. Edit");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. View");
                Console.WriteLine("5. Serch");
                Console.WriteLine("6. Log out of Profile");
                Console.WriteLine("7. Exit program");

            }
            // Регистрация
            while (Key != 2)
            {
                Console.WriteLine("Registration (1) | Cancel (2)");
                Message("Enter the command: ", ConsoleColor.Yellow);
                Key = int.Parse(Console.ReadLine());
                if (Key == 1)
                {
                    Console.WriteLine("Registration");
                    Message("Title: ", ConsoleColor.Blue);
                    Title = Console.ReadLine();
                    Message("Country: ", ConsoleColor.Blue);
                    Country = Console.ReadLine();

                    var registrationHotel = Hotels.FirstOrDefault(item => item.Title == Title && item.Country == Country);
                    if (registrationHotel != null)
                    {
                        Message("Registration completed!\n", ConsoleColor.Green);
                        while (Action != 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            ListCommand();
                            Console.ForegroundColor = ConsoleColor.White;
                            try
                            {
                                Message("Enter the command: ", ConsoleColor.DarkRed);

                                Action = int.Parse(Console.ReadLine());
                                switch (Action)
                                {
                                    // Добавление
                                    case 1:
                                        Hotels.Add(ActionHotel(new Hotel()));
                                        break;
                                    // Редактирование
                                    case 2:

                                        Console.Write("Enter ID: ");
                                        int idEdit = int.Parse(Console.ReadLine());
                                        var editHotel = Hotels.FirstOrDefault(item => item.ID == idEdit);
                                        if (editHotel != null)
                                        {
                                            ActionHotel(editHotel);
                                        }
                                        else
                                        {

                                            Message("Error! Not found...", ConsoleColor.Red);
                                        }
                                        break;
                                    // Удаление
                                    case 3:

                                        Console.Write("Enter ID: ");
                                        int idRemove = int.Parse(Console.ReadLine());
                                        var removeHotel = Hotels.FirstOrDefault(item => item.ID == idRemove);
                                        if (removeHotel != null)
                                        {
                                            Hotels.Remove(removeHotel);

                                            Message("Success!", ConsoleColor.Green);
                                        }
                                        else
                                        {

                                            Message("Error! Not found...", ConsoleColor.Red);
                                        }
                                        break;

                                    // Просмторт
                                    case 4:

                                        if (Hotels.Any())
                                        {
                                            foreach (var hotel in Hotels)
                                            {
                                                Console.WriteLine(hotel.GetInfo());
                                            }
                                        }
                                        else
                                        {

                                            Message("Error! Not found...", ConsoleColor.Red);
                                        }
                                        break;
                                    case 5:
                                        // Поиск
                                        Console.Write("Enter data: ");
                                        string search = Console.ReadLine();
                                        var searchHotel = Hotels.Where(item => item.ID.ToString().Contains(search) || item.Stardom.Contains(search) ||
                                        item.Country.Contains(search) || item.Title.Contains(search)).ToList();
                                        if (searchHotel.Any())
                                        {
                                            foreach (var item in searchHotel)
                                            {
                                                Console.WriteLine(item.GetInfo());
                                            }
                                        }
                                        else
                                        {

                                            Message("Error! Not found...", ConsoleColor.Red);
                                        }
                                        break;
                                    // Закрытие программы
                                    case 7:
                                        Process.GetCurrentProcess().Kill();
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        Message("Error! Not found...\n", ConsoleColor.Red);
                    }
                }

            }
        }
        // Сообщение
        internal static void Message(string message, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Ввод команд
        internal static Hotel ActionHotel(Hotel hotel)
        {
            try
            {
                if (hotel.ID == 0)
                {
                    hotel = new Hotel();
                    Console.Write("Введите ваше ID: ");
                    hotel.ID = int.Parse(Console.ReadLine());
                }
                Console.Write("Enter title hotel: ");
                hotel.Title = Console.ReadLine();
                Message("Success!\n", ConsoleColor.Green);
                Console.Write("Enter country:");
                hotel.Country = Console.ReadLine();
                Console.Write("Enter stardom:");
                hotel.Stardom = Console.ReadLine();
                return hotel;

            }
            catch (Exception ex)
            {
                Message($"{ex.Message}\n", ConsoleColor.Red);
                return null;
            }
        }
    }
}
