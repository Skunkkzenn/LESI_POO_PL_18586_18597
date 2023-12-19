using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Safari_Management.Entities
{
    class Payment //Classe para definir o Pagamento
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
    }
}
