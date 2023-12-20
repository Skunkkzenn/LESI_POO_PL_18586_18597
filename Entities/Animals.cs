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
        //TotalRegisteredAnimals serve apenas para retornar a quantidade de animais que foram registrados pelo utilizador.
        public int TotalRegisteredAnimals { get; private set; } = 0;

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
        public void Register()
        {
            int numOfreg = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfreg; i++)
            {
                Console.Write("Id: ");
                int animalId = int.Parse(Console.ReadLine());

                if (listAnimals.Any(animal => animal.Id == animalId))
                {
                    Console.WriteLine("Animal ID already exists.");
                }
                else
                {
                    Console.Write("Weight: "); double weight = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Height: "); double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Specie: "); string specie = Console.ReadLine();
                    Console.Write("Name: "); string name = Console.ReadLine();

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
                    listAnimals.Add(animal);
                    TotalRegisteredAnimals++;
                }
            }

        }

        public void Update()
        {
            Console.WriteLine("Enter the ID of the animal you want to update:");
            int idToUpdate = int.Parse(Console.ReadLine());

            Animals animalUpdate = listAnimals.Find(x => x.Id == idToUpdate);
            if (animalUpdate != null)
            {
                Console.Write("Enter the new weight: "); animalUpdate.Weight = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Enter the new height: "); animalUpdate.Height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Enter the new species: "); animalUpdate.Specie = Console.ReadLine();
                Console.Write("Enter the new name: "); animalUpdate.Name = Console.ReadLine();

                //Cria uma nova var para armazenar o valor da nova localidade e transferir o mesmo para o animalUpdate.Location
                Console.Write("Enter the new location: "); string newLocation = Console.ReadLine();
                Location location = new Location(newLocation);
                animalUpdate.Location = location;

                Console.Write("Enter the new genre: "); animalUpdate.Genre = Console.ReadLine();

                Console.Write("Enter the new date of birth (dd/MM/yyyy): ");
                DateTime dateofbirth = new DateTime();

                //Para verificar a inserção correta da data de nascimento
                bool validDate = false;

                while (!validDate)
                {
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateofbirth))
                    {
                        validDate = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date of birth. Please try again.");
                    }
                }
                animalUpdate.DateOfBirth = dateofbirth;

            }
            else Console.WriteLine("The animal does not exist.");
        }

        public void Delete()
        {
            Console.Write("Enter a id animal to remove: ");
            int idRemove = int.Parse(Console.ReadLine());

            Animals animalRemove = listAnimals.Find(x => x.Id == idRemove);
            if (animalRemove != null)
            {
                listAnimals.Remove(animalRemove);
                Console.WriteLine("Animal removed.");
                SaveAnimalsToFile(listAnimals, "AnimalList.bin");
            }
            
            else Console.WriteLine("The animal does not exist.");

        }

        public void Search()
        {
            Console.WriteLine("Enter a id animal to search: ");
            int idSearch = int.Parse(Console.ReadLine());

            Animals searchAnimal = listAnimals.Find(x => x.Id == idSearch);
            if (searchAnimal != null)
            {
                Console.WriteLine($"Animal >{Id}< found: Name: {searchAnimal.Name}, Specie: {searchAnimal.Specie}, Genre: {searchAnimal.Genre}");
            }
            else Console.WriteLine("The animal does not exist.");
        }

        public int Count()
        {
            return listAnimals.Count;
        }

        public void RunList()
        {
            Animals animalManager = new Animals();
            bool validate = false;
            listAnimals = animalManager.ReadAnimalsFromFile("AnimalList.bin");
            if (listAnimals != null)
            {
                validate = true;                 
            }
            else
            {
                Console.WriteLine("The animal list is empty.");
            }
        }

        public void ExibitionList()
        {
            Animals animalManager = new Animals();
            listAnimals = animalManager.ReadAnimalsFromFile("AnimalList.bin");
            if (listAnimals != null)
            {

                foreach (Animals animals in listAnimals)
                {
                    Console.WriteLine(animals);
                }

            }
            else
            {
                Console.WriteLine("The animal list is empty.");
            }
        }

        //Método que salva os dados dos animais em um ficheiro binário
        public void SaveAnimalsToFile(List<Animals> listAnimals, string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, listAnimals);
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
                    List<Animals> listAnimals = formatter.Deserialize(fs) as List<Animals>;

                    if (listAnimals != null && listAnimals.Count > 0)
                    {
                        return listAnimals;
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
            //return $"Id: {Id}, Weight: {Weight.ToString("F2", CultureInfo.InvariantCulture)}, Height: {Height.ToString("F2", CultureInfo.InvariantCulture)}, Specie: {Specie}, Name: {Name}, Location: {Location}, DateOfBirth: {DateOfBirth.ToString("dd/MM/yyyy")}";
            return $"Id: {Id} | Weight: {Weight.ToString("F2", CultureInfo.InvariantCulture).PadRight(5)} | Height: {Height.ToString("F2", CultureInfo.InvariantCulture).PadRight(5)} | Specie: {Specie.PadRight(5)} | Genre: {Genre.PadRight(5)} | Name: {Name.PadRight(5)} | Location: {Location.ToString().PadRight(5)} | DateOfBirth: {DateOfBirth.ToString("dd/MM/yyyy")}";

        }

    }
}


