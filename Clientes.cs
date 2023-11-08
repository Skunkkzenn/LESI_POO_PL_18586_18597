using System;
using System.Collections.Generic;
using System.IO;
using Safari_Management;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Safari_Management
{

    [Serializable]
    class Clientes {
        

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateofBirth { get; set; }
        public int Contact { get; set; }
        public string Email { get; set; }
        public int NIF { get; set; }
        public string Location { get; set; }

        public Clientes() { }


        public Clientes(int id, string name, DateTime dateofbirth, int contact, string email, int nif, string location)
        {
            ID = id;
            Name = name;
            DateofBirth = dateofbirth;
            Contact = contact;
            Email = email;
            NIF = nif;
            Location = location;
        }

        public int RegisterClient(int numOfreg, List <Clientes> clientesList)
        {
            numOfreg = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfreg; i++)
            {
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());

                if (clientesList.Any(cliente => cliente.ID == id))
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

                    Clientes cliente = new Clientes(id, name, contact, email, nif, dateofbirth);

          
                    clientesList.Add(cliente);

                }
            }

            return clientesList.Count;

        }

        public void SaveClientesToFile(List<Clientes> clientesList, string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, clientesList);
                }

                Console.WriteLine($"Client data saved in {fileName} successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving Client data: {ex.Message}");
            }
        }

        public List<Clientes> ReadClientesFromFile(string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    List<Clientes> clientesList = formatter.Deserialize(fs) as List<Clientes>;

                    if (clientesList != null && clientesList.Count > 0)
                    {
                        return clientesList;
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

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, DateOfBirth: {DateofBirth}, Contact: {Contact}, Email: {Email}, NIF:{NIF} ,Location: {Location}";

        }

    }
        
}
