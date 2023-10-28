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

            Console.WriteLine("Bem-vindo ao sistema de registro de animais!");

            while (true)
            {
                Console.WriteLine("1. Registrar um novo animal");
                Console.WriteLine("2. Sair");
                Console.Write("Escolha uma opção: ");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    int numOfReg = 0;
                    Console.Write("Quantos animais você deseja registrar? ");
                   
                    int registeredCount = animalManager.registerAnimal(numOfReg, animalsList);

                    Console.WriteLine($"Total de animais registrados: {registeredCount}");
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Saindo do programa.");
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                }
            }
        }
    }
}

