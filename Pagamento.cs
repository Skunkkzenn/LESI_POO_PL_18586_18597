using System;
using System.Collections.Generic;
using System.IO;
using Safari_Management;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Safari_Management
{
    class Pagamento
    {

        public int IDPayment { get; set; }
        public decimal Value { get; set; }
        public int Date { get; set; }
        public string Paymentmethod { get; set; }
        public string Paymentstatus { get; set; }
        public string Paymentdetails { get; set; }

        public Pagamento() { }

        public Pagamento(int idpayment, decimal value, int date, string paymentmethod, string paymentstatus, string paymentdetails)
        {

            IDPayment = idpayment;
            Value = value;
            Date = date;
            Paymentmethod = paymentmethod;
            Paymentstatus = paymentstatus;
            Paymentdetails = paymentdetails;

        }

        public string ChoosePaymentMethod(string paymentmethod)
        {
            return paymentmethod;
        }

        public void MakePayment(decimal valor, string metodoPagamento)
        {

        }

        public void GenerateReceipt(Pagamento pagamento)
        {

        }

        public int RegisterPayment(int numOfreg, List<Pagamento> pagamentoList) 
        {
            return pagamentoList.Count;
        }

        public void SavePaymentToFile(List<Pagamento> pagamentoList, string fileName)
        {

        }

        public List<Animals> ReadPaymentFromFile(string fileName)
        {
            return null;
        }



    }
}
