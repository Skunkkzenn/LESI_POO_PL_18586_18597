using System;
using System.Collections.Generic;

namespace Safari_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animals> animalsList = new List<Animals>(); // Cria uma lista para armazenar os animais registrados

            Animals animalManager = new Animals(); // Cria uma instância da classe Animals

            Console.WriteLine("Welcome to the animal registration system!");

            while (true)
            {
                Console.WriteLine("1. Regiter a new animal");
                Console.WriteLine("2. Exit");

                Console.Write("Escolha uma opção: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    int numOfReg = 0;
                    Console.Write("How many animals do you want to register? ");
                   
                    int registeredCount = animalManager.registerAnimal(numOfReg, animalsList);

                    Console.WriteLine($"Total registered animals: {registeredCount}");
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Leaving the program.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                }
            }
        }
    }
}

