using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Safari_Management.Entities
{
    class Security //Classe para definir o Segurança
    {

        //Propriedades dos Seguranças
        public int SId { get; set; }
        public string Name { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Equipment { get; set; }
        public string Section { get; set; }
        public string Processes { get; set; }
        public string EmergencyNumbers { get; set; }

        public Security() { }

        //Construtor para criar o objeto 'Security' com valores iniciais
        public Security(int sid, string name, DateTime dateofbirth, string equipment, string section, string processes, string emergencynumbers)
        {
            //Inicializa as propriedades com os valores fornecidos
            SId = sid;
            Name = name;
            DateofBirth = dateofbirth;
            Equipment = equipment;
            Section = section;
            Processes = processes;
            EmergencyNumbers = emergencynumbers;

        }

        //Método que regista os seguranças
        public int RegisterSecurity(int numOfreg, List<Security> securityList)
        {
            return securityList.Count;
        }

        //Método que salva os dados dos seguranças em um ficheiro binário
        public void SaveSecurityToFile(List<Security> securityList, string fileName)
        {

        }

        //Método que lê os dados dos seguranças do ficheiro binário
        public List<Security> ReadSecurityFromFile(string fileName)
        {
            return null;
        }

        //Método que aloca segurança a um determinado setor
        public void AssignSectorSecurity(int sid, string section)
        {

        }

        //Método que define procedimentos de emergência
        public void DefineEmergencyProcedures(string processes)
        {

        }

        //Método que reporta emergência
        public void ReportEmergency(string emergencynumbers)
        {

        }

    }
}
