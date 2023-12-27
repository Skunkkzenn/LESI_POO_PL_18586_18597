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

    [Serializable]
    class Clients : Database
    { //Classe para definir os Clientes

        public static List<Clients> listClients = new List<Clients>();

        //Propriedades dos Clientes
        public int IdCli { get; set; }
        public string Name { get; set; }
        public DateTime DateofBirth { get; set; }
        public int Contact { get; set; }
        public string Email { get; set; }
        public int NIF { get; set; }
        public Location Location { get; set; }
        //TotalRegisteredClients serve apenas para retornar a quantidade de clientes que foram registrados pelo utilizador.
        public int TotalRegisteredClients { get; private set; } = 0;
        public List<Payment> listPayment { get; private set; } = new List<Payment>();

        public Clients() { }

        //Construtor para criar o objeto 'Clients' com valores iniciais
        public Clients(int id, string name, DateTime dateofbirth, int contact, string email, int nif, Location location)
        {
            //Inicializa as propriedades com os valores fornecidos
            IdCli = id;
            Name = name;
            DateofBirth = dateofbirth;
            Contact = contact;
            Email = email;
            NIF = nif;
            Location = location;
            listPayment = new List<Payment>();
        }

        //Método que regista os clientes
        public void Register()
        {

            int numOfreg = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfreg; i++)
            {
                Console.Write("Id: ");
                int clientId = int.Parse(Console.ReadLine());

                if (listClients.Any(client => client.IdCli == clientId))
                {
                    Console.WriteLine("Client ID already exists.");
                }
                else
                {
                    
                    Console.Write("Name: "); string name = Console.ReadLine();
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

                    Console.WriteLine("Contact: "); int contact = int.Parse(Console.ReadLine());
                    Console.Write("Email: "); string email = Console.ReadLine();
                    Console.WriteLine("NIF: "); int nif = int.Parse(Console.ReadLine());
                    Console.Write("Location: ");
                    string locationName = Console.ReadLine();
                    //Instancia classe do local
                    Location location = new Location(locationName);

                    // Cria uma nova instância da classe `Clients` com todos os dados do novo animal
                    Clients client = new Clients(clientId, name, dateofbirth, contact, email, nif, location);

                    // Adiciona o novo cliente à lista
                    listClients.Add(client);
                    TotalRegisteredClients++;
                }
            }

        }

        public void Update()
        {
            Console.WriteLine("Enter the ID of the animal you want to update:");
            int clientIdToUpdate = int.Parse(Console.ReadLine());

            Clients clientUpdate = listClients.Find(client => client.IdCli == clientIdToUpdate);
            if (clientUpdate != null)
            {

                Console.Write("Enter the new name: "); clientUpdate.Name = Console.ReadLine();

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
                clientUpdate.DateofBirth = dateofbirth;

                Console.WriteLine("Contact: "); int contact = int.Parse(Console.ReadLine());
                Console.Write("Email: "); string email = Console.ReadLine();
                Console.WriteLine("NIF: "); int nif = int.Parse(Console.ReadLine());
                //Cria uma nova var para armazenar o valor da nova localidade e transferir o mesmo para o clientUpdate.Location
                Console.Write("Enter the new location: "); string newLocation = Console.ReadLine();
                Location location = new Location(newLocation);
                clientUpdate.Location = location;

            }
            else Console.WriteLine("The client does not exist.");
        }

        public void Delete()
        {
            Console.Write("Enter a id client to remove: ");
            int clientIdRemove = int.Parse(Console.ReadLine());

            Clients clientRemove = listClients.Find(client => client.IdCli == clientIdRemove);
            if (clientRemove != null)
            {
                listClients.Remove(clientRemove);
                Console.WriteLine("Animal removed.");
                SaveClientsToFile(listClients, "ClientsList.bin");
            }

            else Console.WriteLine("The client does not exist.");
        }

        public void Search()
        {
            Console.WriteLine("Enter a id client to search: ");
            int clientIdSearch = int.Parse(Console.ReadLine());

            Clients searchClient = listClients.Find(client => client.IdCli == clientIdSearch);
            if (searchClient != null)
            {
                Console.WriteLine($"Client >{searchClient.IdCli}< found: Name: {searchClient.Name}, Contact: {searchClient.Contact}, NIF: {searchClient.NIF}");
                searchClient.DisplayClientInvoices();
            }
            else Console.WriteLine("The client does not exist.");
        }

        public int Count()
        {
            return listClients.Count;
        }

        public void RunList()
        {
            Clients clientManager = new Clients();
            bool validate = false;
            listClients = clientManager.ReadClientsFromFile("ClientList.bin");
            if (listClients != null)
            {
                validate = true;
            }
            else
            {
                Console.WriteLine("The client list is empty.");
            }
        }

        public void ExibitionList()
        {
            Clients clientManager = new Clients();
            listClients = clientManager.ReadClientsFromFile("ClientList.bin");
            if (listClients != null)
            {

                foreach (Clients clients in listClients)
                {
                    Console.WriteLine(clients);
                }

            }
            else
            {
                Console.WriteLine("The client list is empty.");
            }
        }

        public void SaveClientsToFile(List<Clients> listClients, string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, listClients);
                }

                Console.WriteLine($"Client data saved in {fileName} successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving client data: {ex.Message}");
            }
        }

        //Método que lê os dados dos clientes do ficheiro binário
        public List<Clients> ReadClientsFromFile(string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    List<Clients> listClients = formatter.Deserialize(fs) as List<Clients>;

                    if (listClients != null && listClients.Count > 0)
                    {
                        return listClients;
                    }
                    else
                    {
                        Console.WriteLine("The client list is empty or the data could not be read.");
                        return null;
                    }
                }
            }
            //Usado para capturar qualquer erro inesperado que possa ocorrer ao tentar ler o arquivo e desserializar os dados.
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading client data:  {ex.Message}");
                return null;
            }
        }

        public void AddPayment(Payment payment)
        {

            if (listPayment == null)
            {
                listPayment = new List<Payment>();
            }

            listPayment.Add(payment);
            payment.Client = this;

            if (payment.Client != null)
            {
                Console.WriteLine($"Payment associated with client: {payment.Client.IdCli} | {payment.Client.Name} \n");
            }
        }

        public void DisplayClientInvoices()
        {
            Console.WriteLine($"Invoices for Client:  {IdCli} | {Name}:");

            if (listPayment != null && listPayment.Count > 0)
            {

                foreach (Payment payment in listPayment)
                {
                    Console.WriteLine($"Invoice ID: {payment.IdPay} | Client ID: {IdCli.ToString().PadRight(5)} | Client Name: {Name.PadRight(5)} | NIF: {NIF.ToString().PadRight(5)} | Total Price: {payment.Value}");
                }

            }
            else
            {
                Console.WriteLine("No invoices found for this client.");
            }
        }

        //Método para exibir as informações dos clientes
        public override string ToString()
        {
            return $"Id: {IdCli} | Name: {Name.PadRight(5)} |  DateOfBirth: {DateofBirth.ToString("dd/MM/yyyy")} | Contact: {Contact.ToString().PadRight(5)} | Email: {Email.PadRight(5)} | NIF: {NIF.ToString().PadRight(5)} | Location: {Location.ToString()}";
        }

    }
}
