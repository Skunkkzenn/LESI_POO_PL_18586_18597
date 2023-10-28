using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Safari_Management;

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
                Console.WriteLine("1. Regiter a new animal");
                Console.WriteLine("2. Exit");

                Console.Write("Select one option: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    int numOfReg = 0;
                    Console.Write("How many animals do you want to register? ");
                   
                    //Chama o método registerAnimal, junto com animalManager, onde aloca os atributos da classe inseridos pelo utilizador
                    int registeredCount = animalManager.registerAnimal(numOfReg, animalsList);

                    Console.WriteLine($"Total registered animals: {registeredCount}");

                    animalManager.SaveAnimalsToFile(animalsList, "AnimalList.bin");
                    
                    string filePath = "bin/Debug/net6.0/AnimalList.bin"; // Substitua com o caminho do seu arquivo binário
                    animalManager.ReadBinaryFile(filePath);
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

