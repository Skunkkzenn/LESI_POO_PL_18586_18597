using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Safari_Management.Entities.SecondaryEntities;
using Safari_Management.Interfaces;

namespace Safari_Management.Entities
{
    [Serializable] // Marcar a classe como serializável
    class Security : Database //Classe para definir o Segurança
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
