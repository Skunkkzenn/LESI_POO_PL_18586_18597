﻿using System;
using System.Collections.Generic;
using System.IO;
using Safari_Management;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Safari_Management
{
    [Serializable] // Marcar a classe como serializável
    class Animals
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string Specie { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime DateOfBirth { get; set; }
       
        public Animals() { }

        public Animals(int id, double weight, double height, string specie, string name, string location, DateTime dateofbirth)
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
                    double weight = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
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
                        Console.Write("Date of Birth (dd/MM/yyyy): ");
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

        public void SaveAnimalsToFile(List<Animals> animalsList, string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, animalsList);
                }

                Console.WriteLine($"Animal data saved in {fileName} successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving animal data: {ex.Message}");
            }
        }

        public List<Animals> ReadAnimalsFromFile(string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    List<Animals> animalsList = formatter.Deserialize(fs) as List<Animals>;

                    if (animalsList != null && animalsList.Count > 0)
                    {
                        return animalsList;
                    }
                    else
                    {
                        Console.WriteLine("The animal list is empty or the data could not be read.");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading animal data:  {ex.Message}");
                return null;
            }
        }

        public override string ToString()
        {
            return $"Id: {Id}, Weight: {Weight.ToString("F2", CultureInfo.InvariantCulture)}, Height: {Height.ToString("F2", CultureInfo.InvariantCulture)}, Specie: {Specie}, Name: {Name}, Location: {Location}, DateOfBirth: {DateOfBirth}";

        }
    }
}


