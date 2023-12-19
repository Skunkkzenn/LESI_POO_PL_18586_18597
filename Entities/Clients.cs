/* using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Safari_Management.Interfaces;

namespace Safari_Management.Entities
{

    [Serializable]
    class Clients : Database
    { //Classe para definir os Clientes

        //Propriedades dos Clientes
        public int IdCli { get; set; }
        public string Name { get; set; }
        public DateTime DateofBirth { get; set; }
        public int Contact { get; set; }
        public string Email { get; set; }
        public int NIF { get; set; }
        public string Location { get; set; }

        public Clients() { }

        //Construtor para criar o objeto 'Clients' com valores iniciais
        public Clients(int id, string name, DateTime dateofbirth, int contact, string email, int nif, string location)
        {
            //Inicializa as propriedades com os valores fornecidos
            IdCli = id;
            Name = name;
            DateofBirth = dateofbirth;
            Contact = contact;
            Email = email;
            NIF = nif;
            Location = location;
        }

        //Método que regista os clientes
        public int RegisterClient(int numOfreg, List<Clients> clientsList)
        {
            numOfreg = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfreg; i++)
            {
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());

                if (clientesList.Any(client => client.ID == id))
                {
                    Console.WriteLine("Client ID already exists.");
                }
                else
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Contact: ");
                    string contactStr = Console.ReadLine();
                    int contact = 0;
                    if (int.TryParse(contactStr, out contact))
                    {

                    }
                    else
                    {
                        Console.WriteLine("Contacto inválido. Certifique-se de que inseriu um número inteiro.");
                    }

                    Console.Write("Email: ");
                    string email = Console.ReadLine();

                    Console.Write("NIF: ");
                    string nifStr = Console.ReadLine();
                    int nif = 0;
                    if (int.TryParse(nifStr, out nif))
                    {

                    }
                    else
                    {
                        Console.WriteLine("NIF inválido. Certifique-se de que inseriu um número inteiro.");
                    }

                    Console.Write("Date of birth: ");
                    DateTime dateofbirth = new DateTime();
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

                    Clients client = new Clients(id, name, contact, email, nif, dateofbirth);


                    clientesList.Add(client);

                }
            }

            return clientesList.Count;

        }

        //Método que salva os dados dos clientes em um ficheiro binário
        public void SaveClientsToFile(List<Clients> clientsList, string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, clientsList);
                }

                Console.WriteLine($"Client data saved in {fileName} successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving Client data: {ex.Message}");
            }
        }

        //Método que lê os dados dos clientes do ficheiro binário
        public List<Clients> ReadClientsFromFile(string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    List<Clients> clientsList = formatter.Deserialize(fs) as List<Clients>;

                    if (clientsList != null && clientsList.Count > 0)
                    {
                        return clientsList;
                    }
                    else
                    {
                        Console.WriteLine("The Client list is empty or the data could not be read.");
                        return null;
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading Client data:  {ex.Message}");
                return null;
            }
        }

        //Método para exibir as informações dos clientes
        public override string ToString()
        {
            return $"ID: {IdCli}, Name: {Name}, DateOfBirth: {DateofBirth}, Contact: {Contact}, Email: {Email}, NIF:{NIF} ,Location: {Location}";

        }

        public void Register()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Search()
        {
            throw new NotImplementedException();
        }
    }

}
*/