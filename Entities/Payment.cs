using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Safari_Management.Interfaces;
using InterfaceDLL;

namespace Safari_Management.Entities
{
    class Payment : Database, Business  //Classe para definir o Pagamento
    {
        private static List<Payment> listPayment = new List<Payment>();

        //Propriedades do pagamento
        public int IdPay { get; set; }
        public decimal Value { get; set; }
        public int Date { get; set; }
        public string Paymentmethod { get; set; }
        public string Paymentstatus { get; set; }
        public string Paymentdetails { get; set; }

        public Payment() { }

        //Construtor para criar o objeto 'Payment' com valores iniciais
        public Payment(int idpayment, decimal value, int date, string paymentmethod, string paymentstatus, string paymentdetails)
        {

            //Inicializa as propriedades com os valores fornecidos
            IdPay = idpayment;
            Value = value;
            Date = date;
            Paymentmethod = paymentmethod;
            Paymentstatus = paymentstatus;
            Paymentdetails = paymentdetails;

        }

        public void CreateInvoice()
        {
            Console.Write("How many tickets to buy? ");
            ValorTotal.Quantidade = int.Parse(Console.ReadLine());

            Console.Write("How much is a ticket worth? ");
            ValorTotal.Preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double resultado = InterfaceDLL.ValorTotal.SomaDiaria();
            Console.Write($"Price total tickets: {resultado.ToString("F2", CultureInfo.InvariantCulture)}");
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

        public void Search()
        {
            throw new NotImplementedException();
        }
    }
}
