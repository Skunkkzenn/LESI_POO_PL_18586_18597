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
            Animals animalManager = new Animals(); // Cria um objeto da classe Animals

            Console.WriteLine("\t\t\t\tWelcome to the animal registration system!");
            Console.WriteLine(" #####                                   #     #                                                               \r\n#     #   ##   ######   ##   #####  #    ##   ##   ##   #    #   ##    ####  ###### #    # ###### #    # ##### \r\n#        #  #  #       #  #  #    # #    # # # #  #  #  ##   #  #  #  #    # #      ##  ## #      ##   #   #   \r\n #####  #    # #####  #    # #    # #    #  #  # #    # # #  # #    # #      #####  # ## # #####  # #  #   #   \r\n      # ###### #      ###### #####  #    #     # ###### #  # # ###### #  ### #      #    # #      #  # #   #   \r\n#     # #    # #      #    # #   #  #    #     # #    # #   ## #    # #    # #      #    # #      #   ##   #   \r\n #####  #    # #      #    # #    # #    #     # #    # #    # #    #  ####  ###### #    # ###### #    #   #  ");
            Console.WriteLine();
            //Inicia o programa
            while (true)
            {
                Console.Write("Select one option: ");
                Console.WriteLine("0. Load database animal.");
                Console.WriteLine("1. Regiter a new animal.");
                Console.WriteLine("2. Count animals in list.");
                Console.WriteLine("3. Exit.");
                Console.WriteLine("------------------------------------------------------------");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {

                    case 0:
                        Animals.listAnimals = animalManager.ReadAnimalsFromFile("AnimalList.bin");
                        if (Animals.listAnimals != null)
                        {

                            foreach (Animals animals in Animals.listAnimals)
                            {
                                Console.WriteLine(animals);
                            }

                        }
                        else
                        {
                            Console.WriteLine("The animal list is empty.");
                        }
                        break;


                    case 1:
                        Console.WriteLine("How many animals do you want to register?");
                        
                        //Chama o método registerAnimal, junto com animalManager, onde aloca os atributos da classe inseridos pelo utilizador
                        animalManager.Register();
                        
                        Console.WriteLine($"Total registered animals: {animalManager.TotalRegisteredAnimals}");
                        
                        animalManager.SaveAnimalsToFile(Animals.listAnimals, "AnimalList.bin");

                        /* 
                        Verificar!!!

                        foreach (Animals animal in animalsList)
                        {
                            Console.WriteLine($"Id: {animal.Id}, Weight: {animal.Weight}, Height: {animal.Height}");
                        } 
                        */

                        break;


                    case 2:

                        Console.WriteLine($"{animalManager.Count()}");

                        break;


                    case 3:

                        Console.WriteLine("Leaving the program.");

                        break;


                    default:

                        Console.WriteLine("Invalid option. Please choose a valid option.");

                        break;

                }

                if (choice == 3)
                {
                    break;
                }

            }
        }
    }
}

