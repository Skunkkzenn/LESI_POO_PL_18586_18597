using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Safari_Management.Entities
{
    [Serializable] // Marcar a classe como serializável
    class Security //Classe para definir o Segurança
    {

        //Propriedades dos Seguranças
        public int SId { get; set; }
        public string Name { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Equipment { get; set; }
        public Section Section { get; set; }
        public int EmergencyNumber { get; set; }

        public Security() { }

        //Construtor para criar o objeto 'Security' com valores iniciais
        public Security(int sid, string name, DateTime dateOfBirth, string equipment, Section section, int emergencyNumbers)
        {
            //Inicializa as propriedades com os valores fornecidos
            SId = sid;
            Name = name;
            DateofBirth = dateOfBirth;
            Equipment = equipment;
            Section = section;
            EmergencyNumber = emergencyNumbers;

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
