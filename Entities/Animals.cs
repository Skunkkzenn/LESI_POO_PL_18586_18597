using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Safari_Management.Interfaces;
using Safari_Management.Entities.SecondaryEntities;

namespace Safari_Management.Entities
{
    [Serializable] // Marcar a classe como serializável
    class Animals : Database //Classe para definir os animais
    {
        public static List<Animals> listAnimals = new List<Animals>();

        //Propriedades dos Clientes
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string Specie { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public string Genre { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Animals() { }

        //Construtor para criar o objeto 'Animals' com valores iniciais
        public Animals(int id, double weight, double height, string specie, string name, Location location, string genre, DateTime dateofbirth)
        {
            //Inicializa as propriedades com os valores fornecidos
            Id = id;
            Weight = weight;
            Height = height;
            Specie = specie;
            Name = name;
            Location = location;
            Genre = genre;
            DateOfBirth = dateofbirth;
        }

        //Método que regista os animais
        //alterei int para void
        public void registerAnimal(int numOfreg, List<Animals> animalsList)
        {

            numOfreg = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfreg; i++)
            {

                Console.Write("Id: ");
                int animalId = int.Parse(Console.ReadLine());

                if (animalsList.Any(animal => animal.Id == animalId))
                {
                    Console.WriteLine("Animal ID already exists.");
                }
                else
                {
                    Console.Write("Weight: "); double weight = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Height: "); double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Specie: "); string specie = Console.ReadLine();
                    Console.Write("Name: ");   string name = Console.ReadLine();

                    Console.Write("Location: ");
                    string locationName = Console.ReadLine();
                    //Instancia classe do local
                    Location location = new Location(locationName);

                    Console.Write("Genre: "); string genre = Console.ReadLine();
                    Console.Write("Date of birth: "); DateTime dateofbirth = new DateTime();

                    //Para verificar a inserção correta da data de nascimento
                    bool validDate = false;

                    while (!validDate)
                    {
                        Console.Write("Date of Birth (dd/MM/yyyy): ");
                        if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateofbirth))
                        {
                            validDate = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid date of birth. Please try again.");
                        }
                    }

                    // Cria uma nova instância da classe `Animals` com todos os dados do novo animal
                    Animals animal = new Animals(animalId, weight, height, specie, name, location, genre, dateofbirth);

                    // Adiciona o novo animal à lista
                    animalsList.Add(animal);

                }
            }

        }

        //Método que salva os dados dos animais em um ficheiro binário
        public void SaveAnimalsToFile(List<Animals> animalsList, string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, animalsList);
                }

                Console.WriteLine($"Animal data saved in {fileName} successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving animal data: {ex.Message}");
            }
        }

        //Método que lê os dados dos animais do ficheiro binário
        public List<Animals> ReadAnimalsFromFile(string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
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
            //Usado para capturar qualquer erro inesperado que possa ocorrer ao tentar ler o arquivo e desserializar os dados.
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading animal data:  {ex.Message}");
                return null;
            }
        }

        //Método para exibir as informações dos animais
        public override string ToString()
        {
            return $"Id: {Id}, Weight: {Weight.ToString("F2", CultureInfo.InvariantCulture)}, Height: {Height.ToString("F2", CultureInfo.InvariantCulture)}, Specie: {Specie}, Name: {Name}, Location: {Location}, DateOfBirth: {DateOfBirth}";

        }
    }
}


