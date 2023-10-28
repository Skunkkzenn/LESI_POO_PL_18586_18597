﻿using Safari_Management;
using System;
using System.Collections.Generic;
using System.Globalization;



namespace Safari_Management
{

    class Animals
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public double Height { get; set; }
        public string Specie { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime DateOfBirth { get; set; }
       
        public Animals() { }

        public Animals(int id, int weight, double height, string specie, string name, string location, DateTime dateofbirth)
        {
            Id = id;
            Weight = weight;
            Height = height;
            Specie = specie;
            Name = name;
            Location = location;
            DateOfBirth = dateofbirth;
        }
        
        public int registerAnimal(int numOfreg, List<Animals> animalsList)
        {
            numOfreg = int.Parse(Console.ReadLine());
        
            for(int i = 0; i < numOfreg; i++) {
                Console.Write("Id: ");
                int animalId = int.Parse(Console.ReadLine());

                if (animalsList.Any(animal => animal.Id == animalId))
                {
                    Console.WriteLine("Animal ID already exists.");
                }
                else
                {
                    Console.Write("Weight: ");
                    int weight = int.Parse(Console.ReadLine());
                    Console.Write("Height: ");
                    double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Specie: ");
                    string specie = Console.ReadLine();
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Location: ");
                    string location = Console.ReadLine();
                    Console.Write("Date of birth: ");
                    DateTime dateofbirth = new DateTime();
                    bool validDate = false;

                    while(!validDate)
                    {
                        Console.WriteLine("Date of Birth (dd/MM/yyyy): ");
                        if(DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateofbirth))
                        {
                            validDate = true;
                        }
                        else {
                            Console.WriteLine("Invalid date of birth. Please try again.");
                        }
                    }

                    // Cria uma nova instância da classe `Animals` com todos os dados do novo animal
                    Animals animal = new Animals(animalId, weight, height, specie, name, location, dateofbirth);

                    // Adiciona o novo animal à lista
                    animalsList.Add(animal);

                }
            }

            return animalsList.Count;

        }

    }

    
}