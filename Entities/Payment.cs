using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Safari_Management.Interfaces;
using InterfaceDLL;
using Safari_Management.Entities.SecondaryEntities;
using System.Xml.Linq;

namespace Safari_Management.Entities
{
    class Payment : Database, Business  //Classe para definir o Pagamento
    {
        public List<Payment> listPayment { get; set; } = new List<Payment>();

        //Propriedades do pagamento
        public int IdPay { get; set; }
        public decimal Value { get; set; }
        public int Date { get; set; }
        public string Paymentdetails { get; set; }
        public List<Clients> listClients { get; private set; } = new List<Clients>();
        public Clients Client { get; set; }
        public int TotalRegisteredPayments { get; private set; } = 0;

        public Payment() { }

        //Construtor para criar o objeto 'Payment' com valores iniciais
        public Payment(int idpayment, decimal value, int date, string paymentdetails)
        {

            //Inicializa as propriedades com os valores fornecidos
            IdPay = idpayment;
            Value = value;
            Date = date;
            Paymentdetails = paymentdetails;
            listClients = new List<Clients>();

        }

        public void CreateInvoice()
        {

            Console.WriteLine("Insert the Id of the client buying tickets: ");
            int clientId = int.Parse(Console.ReadLine());
            Clients client = Clients.listClients.FirstOrDefault(client => client.IdCli == clientId);

            if (client == null)
            {
                Console.WriteLine("Client not found.");
                return;
            }

            Console.Write("How many tickets to buy? ");
            ValorTotal.Quantidade = int.Parse(Console.ReadLine());
            Console.Write("How much is a ticket worth? ");
            ValorTotal.Preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double resultado = InterfaceDLL.ValorTotal.SomaDiaria();
            Console.WriteLine();

            Payment payment = new Payment()
            {
                IdPay = GetNextPaymentId(),
                Value = (decimal)resultado,
                Date = DateTime.Now.Day + DateTime.Now.Month * 100 + DateTime.Now.Year * 10000,
                Client = client
            };

            Console.WriteLine($"Invoice: ");
            Console.WriteLine($"ID invoice: {GetNextPaymentId()}");
            Console.WriteLine($"Client -> {clientId} | {client.Name}");
            Console.WriteLine($"NIF: {client.NIF}");
            Console.WriteLine($"Date: {DateTime.Now.Day:D2}/{DateTime.Now.Month:D2}/{DateTime.Now.Year}");
            Console.WriteLine($"Total Price: {resultado.ToString("F2", CultureInfo.InvariantCulture)}\n");

            if (client.listPayment == null)
            {
                client.listPayment = new List<Payment>();
            }

            client.AddPayment(payment);
            listPayment.Add(payment);
            TotalRegisteredPayments++;

        }

        private int GetNextPaymentId()
        {
            return listPayment.Count + 1;
        }

        public void CancelInvoice()
        {
            throw new NotImplementedException();
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

        public void RunList(List<Clients> clientsList)
        {
            listClients = clientsList;
            bool validate = false;

            if (listClients != null && listClients.Count > 0)
            {
                validate = true;
            }
            else
            {
                Console.WriteLine("The client list is empty.");
            }
        }

        public void Search()
        {
            throw new NotImplementedException();
        }
    }
}
