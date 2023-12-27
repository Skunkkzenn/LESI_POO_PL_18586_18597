using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Safari_Management.Entities;


namespace Safari_Management
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("\t\t\t\tWelcome to the Safari Management!");
            Console.WriteLine(" #####                                   #     #                                                               \r\n#     #   ##   ######   ##   #####  #    ##   ##   ##   #    #   ##    ####  ###### #    # ###### #    # ##### \r\n#        #  #  #       #  #  #    # #    # # # #  #  #  ##   #  #  #  #    # #      ##  ## #      ##   #   #   \r\n #####  #    # #####  #    # #    # #    #  #  # #    # # #  # #    # #      #####  # ## # #####  # #  #   #   \r\n      # ###### #      ###### #####  #    #     # ###### #  # # ###### #  ### #      #    # #      #  # #   #   \r\n#     # #    # #      #    # #   #  #    #     # #    # #   ## #    # #    # #      #    # #      #   ##   #   \r\n #####  #    # #      #    # #    # #    #     # #    # #    # #    #  ####  ###### #    # ###### #    #   #  ");
            Console.WriteLine();

            while (true)
            {

                Console.WriteLine("Select one option: ");
                Console.WriteLine("0. Animals.");
                Console.WriteLine("1. Clients.");
                Console.WriteLine("2. Payment.");
                Console.WriteLine("3. Exit.");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

                int mainChoice = int.Parse(Console.ReadLine());

                switch (mainChoice)
                {
                    case 0:
                        RunAnimalMenu();
                        break;

                    case 1:
                        RunClientMenu();
                        break;

                    case 2:
                        RunPaymentMenu();
                        break;

                    case 3:
                        Console.WriteLine("Leaving the program.");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }

                if (mainChoice == 3)
                {
                    break;
                }

            }

        }

        static void RunAnimalMenu()
        {
            Animals animalManager = new Animals(); // Cria um objeto da classe Animals

            Console.WriteLine("\t\t\t\tWelcome to the animal registration system!");
            Console.WriteLine("   #                                            #     #                                                               \r\n  # #   #    # # #    #   ##   #       ####     ##   ##   ##   #    #   ##    ####  ###### #    # ###### #    # ##### \r\n #   #  ##   # # ##  ##  #  #  #      #         # # # #  #  #  ##   #  #  #  #    # #      ##  ## #      ##   #   #   \r\n#     # # #  # # # ## # #    # #       ####     #  #  # #    # # #  # #    # #      #####  # ## # #####  # #  #   #   \r\n####### #  # # # #    # ###### #           #    #     # ###### #  # # ###### #  ### #      #    # #      #  # #   #   \r\n#     # #   ## # #    # #    # #      #    #    #     # #    # #   ## #    # #    # #      #    # #      #   ##   #   \r\n#     # #    # # #    # #    # ######  ####     #     # #    # #    # #    #  ####  ###### #    # ###### #    #   #   ");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Select one option: ");
                Console.WriteLine("0. Load database animal.");
                Console.WriteLine("1. Regiter a new animal.");
                Console.WriteLine("2. Count animals in list.");
                Console.WriteLine("3. Update animal.");
                Console.WriteLine("4. Remove animal.");
                Console.WriteLine("5. Search animal.");
                Console.WriteLine("6. Return to the main menu.");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                int choice = int.Parse(Console.ReadLine());


                switch (choice)
                {

                    case 0:
                        animalManager.ExibitionList();
                        break;


                    case 1:
                        Console.WriteLine("How many animals do you want to register?");
                        //Chama o método registerAnimal, junto com animalManager, onde aloca os atributos da classe inseridos pelo utilizador
                        animalManager.Register();
                        Console.WriteLine($"Total registered animals: {animalManager.TotalRegisteredAnimals}");
                        animalManager.SaveAnimalsToFile(Animals.listAnimals, "AnimalList.bin");
                        break;


                    case 2:
                        animalManager.RunList();
                        Console.WriteLine($"{animalManager.Count()}");
                        break;

                    case 3:

                        animalManager.Update();
                        animalManager.SaveAnimalsToFile(Animals.listAnimals, "AnimalList.bin");
                        break;

                    case 4:
                        animalManager.Delete();
                        break;

                    case 5:
                        animalManager.RunList();
                        animalManager.Search();
                        break;

                    case 6:
                        Console.WriteLine("Returning to the main menu.");
                        break;

                    default:
                        Console.WriteLine("Returning to the main menu.");
                        break;
                }

                if (choice == 6)
                {
                    break;
                }

            }
        }

        static void RunClientMenu()
        {

            Clients clientManager = new Clients();

            Console.WriteLine("\t\t\t\tWelcome to the Client registration system!");
            Console.WriteLine(" #####                                         #     #                                                               \r\n#     # #      # ###### #    # #####  ####     ##   ##   ##   #    #   ##    ####  ###### #    # ###### #    # ##### \r\n#       #      # #      ##   #   #   #         # # # #  #  #  ##   #  #  #  #    # #      ##  ## #      ##   #   #   \r\n#       #      # #####  # #  #   #    ####     #  #  # #    # # #  # #    # #      #####  # ## # #####  # #  #   #   \r\n#       #      # #      #  # #   #        #    #     # ###### #  # # ###### #  ### #      #    # #      #  # #   #   \r\n#     # #      # #      #   ##   #   #    #    #     # #    # #   ## #    # #    # #      #    # #      #   ##   #   \r\n #####  ###### # ###### #    #   #    ####     #     # #    # #    # #    #  ####  ###### #    # ###### #    #   #   ");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Select one option: ");
                Console.WriteLine("0. Load database client.");
                Console.WriteLine("1. Regiter a new client.");
                Console.WriteLine("2. Count clients in list.");
                Console.WriteLine("3. Update client.");
                Console.WriteLine("4. Remove client.");
                Console.WriteLine("5. Search client.");
                Console.WriteLine("6. Return to the main menu.");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                int choice = int.Parse(Console.ReadLine());


                switch (choice)
                {

                    case 0:
                        clientManager.ExibitionList();
                        break;


                    case 1:
                        Console.WriteLine("How many clients do you want to register?");
                        //Chama o método registerClient, junto com o clientManager, onde aloca os atributos da classe inseridos pelo utilizador
                        clientManager.Register();
                        Console.WriteLine($"Total registered clients: {clientManager.TotalRegisteredClients}");
                        clientManager.SaveClientsToFile(Clients.listClients, "ClientList.bin");
                        break;

                    case 2:
                        clientManager.RunList();
                        Console.WriteLine($"{clientManager.Count()}");
                        break;

                    case 3:

                        clientManager.Update();
                        clientManager.SaveClientsToFile(Clients.listClients, "ClientList.bin");
                        break;

                    case 4:
                        clientManager.Delete();
                        break;

                    case 5:
                        clientManager.RunList();
                        clientManager.Search();
                        break;

                    case 6:
                        Console.WriteLine("Returning to the main menu.");
                        break;

                    default:
                        Console.WriteLine("Returning to the main menu.");
                        break;
                }

                if (choice == 6)
                {
                    break;
                }

            }

        }

        static void RunPaymentMenu()
        {

            Clients clientManager = new Clients();
            Payment payManager = new Payment();

            Console.WriteLine("\t\t\t\tWelcome to the Payment registration system!");
            Console.WriteLine("######                                             #     #                                                               \r\n#     #   ##   #   # #    # ###### #    # #####    ##   ##   ##   #    #   ##    ####  ###### #    # ###### #    # ##### \r\n#     #  #  #   # #  ##  ## #      ##   #   #      # # # #  #  #  ##   #  #  #  #    # #      ##  ## #      ##   #   #   \r\n######  #    #   #   # ## # #####  # #  #   #      #  #  # #    # # #  # #    # #      #####  # ## # #####  # #  #   #   \r\n#       ######   #   #    # #      #  # #   #      #     # ###### #  # # ###### #  ### #      #    # #      #  # #   #   \r\n#       #    #   #   #    # #      #   ##   #      #     # #    # #   ## #    # #    # #      #    # #      #   ##   #   \r\n#       #    #   #   #    # ###### #    #   #      #     # #    # #    # #    #  ####  ###### #    # ###### #    #   #   ");
            Console.WriteLine();

            while (true)
            {

                Console.WriteLine("Select one option: ");
                Console.WriteLine("0. Buy a ticket.");
                Console.WriteLine("1. Search invoice.");
                Console.WriteLine("2. Return to the main menu.");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {

                    case 0:
                        clientManager.RunList();
                        payManager.CreateInvoice();
                        clientManager.AddPayment(payManager);
                        break;

                    case 1:
                        clientManager.RunList();
                        clientManager.DisplayClientInvoices();
                        break;

                    case 2:
                        Console.WriteLine("Returning to the main menu.");
                        break;

                    default:
                        Console.WriteLine("Returning to the main menu.");
                        break;
                }

                if (choice == 2)
                {
                    break;
                }

            }
        }
    }
}

