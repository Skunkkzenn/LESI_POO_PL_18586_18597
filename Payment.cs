using System;
using System.Collections.Generic;
using System.IO;
using Safari_Management;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Safari_Management
{
    class Payment //Classe para definir o Pagamento
    {
        //Propriedades do pagamento
        public int IDPayment { get; set; }
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
            IDPayment = idpayment;
            Value = value;
            Date = date;
            Paymentmethod = paymentmethod;
            Paymentstatus = paymentstatus;
            Paymentdetails = paymentdetails;

        }

        //Método para escolher o método de pagamento
        public string ChoosePaymentMethod(string paymentmethod)
        {
            return paymentmethod;
        }

        //Método para efetuar o pagamentos
        public void MakePayment(decimal valor, string paymentmethod)
        {

        }

        //Método que gera o recibo após o pagamento
        public void GenerateReceipt(Payment payment)
        {

        }

        //Método que regista os pagamentos
        public int RegisterPayment(int numOfreg, List<Payment> paymentList) 
        {
            return paymentList.Count;
        }

        //Método que salva os dados dos pagamentos em um ficheiro binário
        public void SavePaymentToFile(List<Payment> paymentList, string fileName)
        {

        }

        //Método que lê os dados dos pagamentos do ficheiro binário
        public List<Payment> ReadPaymentFromFile(string fileName)
        {
            return null;
        }

    }
}
