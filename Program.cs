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
            List<Animals> animalsList = new List<Animals>(); // Cria uma lista para armazenar os animais registrados

            Animals animalManager = new Animals(); // Cria uma instância da classe Animals

            Console.WriteLine("Welcome to the animal registration system!");

            //Inicia o programa
            while (true)
            {
                Console.Write("Select one option: ");
                Console.WriteLine();
                Console.WriteLine("0. Load database animal");
                Console.WriteLine("1. Regiter a new animal");
                Console.WriteLine("2. Exit");
                Console.WriteLine();
                int choice = int.Parse(Console.ReadLine());

                if (choice == 0)
                {
                    animalsList = animalManager.ReadAnimalsFromFile("AnimalList.bin"); // Atualize a lista com os dados lidos do arquivo

                    if (animalsList != null)
                    {
                        foreach (Animals animal in animalsList)
                        {
                            Console.WriteLine(animal);
                        }
                    }
                    else
                    {
                        Console.WriteLine("The animal list is empty or the data could not be read.");
                    }
                }

                else if (choice == 1)
                {
                    int numOfReg = 0;
                    Console.Write("How many animals do you want to register? ");
                   
                    //Chama o método registerAnimal, junto com animalManager, onde aloca os atributos da classe inseridos pelo utilizador
                    int registeredCount = animalManager.registerAnimal(numOfReg, animalsList);

                    Console.WriteLine($"Total registered animals: {registeredCount}");

                    animalManager.SaveAnimalsToFile(animalsList, "AnimalList.bin");

                    animalManager.ReadAnimalsFromFile("AnimalList.bin");

                    /* foreach (Animals animal in animalsList)
                    {
                        Console.WriteLine($"Id: {animal.Id}, Weight: {animal.Weight}, Height: {animal.Height}");
                    }  */
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

